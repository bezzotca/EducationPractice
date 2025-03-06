using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationPractice.ViewModels
{
    public partial class ArrangersViewModel : ViewModelBase
    {
        [ObservableProperty] Arranger arranger = MainWindowViewModel.Instance.loginedArranger;
        [ObservableProperty] string helloMessage;
        [ObservableProperty] string mrMrs;
        [ObservableProperty] string firstName;
        [ObservableProperty] Bitmap photo;
        public ArrangersViewModel()
        {
            if (Arranger != null && !string.IsNullOrWhiteSpace(Arranger.Fcs))
            {
                string[] parts = Arranger.Fcs.Split(' '); 
                FirstName = parts.Length > 1 ? parts[1] : "Неизвестно";
            }
            GenerateGreeting();
            MrsOrMs();
            photo = ConvertPathToBitmap();
        }

        public void GenerateGreeting()
        {
            int hour = DateTime.Now.Hour;
            string timeOfDay = hour switch
            {
                >= 9 and <= 11 => "Утро",
                >= 11 and < 18 => "День",
                _ => "Вечер"
            };

            HelloMessage = $"Добрый {timeOfDay}!";
        }

        public void MrsOrMs()
        {
            if (arranger.Gender== 1)
            {
                MrMrs = "Mr";
            }
            else
            {
                MrMrs = "Mrs";
            }
        }

        public void GoBack()
        {
            MainWindowViewModel.Instance.PageSwitcher = new LoginViewModel();
        }

        public void WatchProfile()
        {
            MainWindowViewModel.Instance.PageSwitcher = new ArrangerProfileViewModel();
        }

        public Bitmap ConvertPathToBitmap()
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"avares://{assemblyName}/Assets/Arrangers_media/{Arranger.Image}");
            Uri uridefault = new Uri($"avares://{assemblyName}/Assets/default.png");
            Stream stream = null;

            try
            {

                stream = AssetLoader.Open(uri);

                if (stream == null || stream.Length == 0)
                {
                    Console.WriteLine("Поток данных пуст или не может быть открыт.");
                    stream = AssetLoader.Open(uridefault);
                }

                return new Bitmap(stream);
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine($"Ошибка формата изображения: {argEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Произошла ошибка при загрузке изображения: {ex.Message}");
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }

            return new Bitmap(AssetLoader.Open(uridefault));
        }

        public void CheckEvents()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new EventListViewModel();
        }
        
        public void GoRegistration()
        {
            MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
        }

        public void GoMembersList()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new MembersViewModel();
        }

        public void GoExpertsList()
        {
            MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher.GetType().Name;
            MainWindowViewModel.Instance.PageSwitcher = new ExpertViewModel();
        }
    }
}

