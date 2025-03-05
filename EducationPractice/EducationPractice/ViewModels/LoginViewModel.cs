using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Media.Imaging;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using SkiaSharp;
using Avalonia.Platform;
using System.Globalization;
using EducationPractice.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationPractice.ViewModels
{
    public partial class LoginViewModel : ViewModelBase
    {

        [ObservableProperty] string message = "Дисплей ошибок";
        [ObservableProperty] string login;
        [ObservableProperty] string password;
        [ObservableProperty] private string captchaText;
        [ObservableProperty] private Bitmap captchaImage;
        [ObservableProperty] private string userInput;
        [ObservableProperty] private string resultMessage;

        public void GetLogined()
        {
            
            if (Db.Experts.FirstOrDefault(x => x.Email == Login && x.Passwd == Password) != null && ResultMessage == "Капча пройдена!")
            {
                Message = "*Вы выполнили авторизацию как член жюри*";
            }
            else if (Db.Moderators.FirstOrDefault(x => x.Email == Login && x.Passwd == Password) != null && ResultMessage == "Капча пройдена!")
            {
                Message = "*Вы выполнили авторизацию как модератор*";
            }
            else if (Db.Members.FirstOrDefault(x => x.Email == Login && x.Passwd == Password) != null && ResultMessage == "Капча пройдена!")
            {
                Message = "*Вы выполнили авторизацию как участник*";
            }
            else if (Db.Arrangers.FirstOrDefault(x => x.Email == Login && x.Passwd == Password) != null && ResultMessage == "Капча пройдена!")
            {
                MainWindowViewModel.Instance.loginedArranger = Db.Arrangers.FirstOrDefault(x => x.Email == Login && x.Passwd == Password);
                MainWindowViewModel.Instance.PageSwitcher = new ArrangersViewModel();
                
            }
            else if(ResultMessage == "Капча пройдена!")
            {
                Message = "Были введены неправильные данные.";
            }else
            {
                Message = "Вы не прошли капчу";
            }
        }

        private static readonly Random _random = new();

        public LoginViewModel()
        {
            GenerateCaptcha();
        }

        [RelayCommand]
        private void GenerateCaptcha()
        {
            CaptchaText = GenerateRandomText(6);
            CaptchaImage = GenerateCaptchaImage(CaptchaText);
            UserInput = string.Empty;
            ResultMessage = string.Empty;
        }

        [RelayCommand]
        private void ValidateCaptcha()
        {
            ResultMessage = (UserInput?.ToUpper() == CaptchaText) ? "Капча пройдена!" : "Капча не пройдена!";
        }

        private static string GenerateRandomText(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length) //Выборка случайных символов в размере 6-ти символов
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        private Bitmap GenerateCaptchaImage(string text)
        {
            var renderTarget = new RenderTargetBitmap(new PixelSize(400, 150), new Vector(96, 96));

            using (var context = renderTarget.CreateDrawingContext(true))
            {
                var backgroundBrush = Brushes.White;
                var textBrush = Brushes.Black;
                var lineBrush = Brushes.LightGray;

                // Заливка фона белым цветом
                context.FillRectangle(backgroundBrush, new Rect(0, 0, 400, 150));

                // Исправление параметров отображаемого текста капчи
                var formattedText = new FormattedText(
                    text,                             // Текст
                    CultureInfo.CurrentCulture,       //Так и не разобрался для чего это нужно
                    FlowDirection.LeftToRight,        // Направление текста
                    Typeface.Default,                 // Шрифт
                    56,                               // Размер шрифта
                    Brushes.Black                     // Цвет текста
                );

                // Определение позиции на изображении, где будет отрисован текст
                var textPosition = new Point(
                    (400 - formattedText.Width)/2,  // Ширина
                    (150 - formattedText.Height)/2   // Длина
                );

 
                context.DrawText(formattedText, textPosition);


                var random = new Random();
                int numberOfLines = random.Next(98, 100);

                for (int i = 0; i < numberOfLines; i++)
                {
                    // Случайный выбор цвета полосы, которая будет в капче
                    var lineColor = new SolidColorBrush(Color.FromArgb(
                        (byte)random.Next(256),  // Случайный альфа код
                        (byte)random.Next(256),  // Случайный красный код
                        (byte)random.Next(256),  // Случайный зеленый код
                        (byte)random.Next(256)   // Случайный синий код
                    ));

                    // Задаётся случайное направление т.е. горизонтальное или вертикальное
                    bool isHorizontal = random.Next(2) == 0;

                    double lineWidth = isHorizontal ? 400 : random.Next(3, 5);  // Ширина полосы для горизонтальных полос
                    double lineHeight = isHorizontal ? random.Next(3, 5) : 150;  // Высота полосы для вертикальных полос


                    double xPosition = isHorizontal ? 0 : random.Next(0, 400 - (int)lineWidth);  // Случайное положение для вертикальных полос
                    double yPosition = isHorizontal ? random.Next(0, 150 - (int)lineHeight) : 0; // Случайное положение для горизонтальных полос


                    context.FillRectangle(lineColor, new Rect(xPosition, yPosition, lineWidth, lineHeight));
                }
            }
            return renderTarget;
        }
    }
}
