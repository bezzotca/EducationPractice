using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EducationPractice.ViewModels
{
    public partial class RegistrationViewModel : ViewModelBase
    {
        [ObservableProperty] Bitmap bitmap;
        [ObservableProperty] List<string> roles;
        [ObservableProperty] List<Gender> genders;
        [ObservableProperty] List<ActivitiesList> activities;
        [ObservableProperty] List<Direction> directions;

        [ObservableProperty] int id;
        [ObservableProperty] Gender selectedGender;
        [ObservableProperty] string role;
        [ObservableProperty] string fcs;
        [ObservableProperty] private string phone_number;
        [ObservableProperty] string email;
        [ObservableProperty] string password;
        [ObservableProperty] string password2;
        [ObservableProperty] ActivitiesList selectedActivity;
        [ObservableProperty] Direction selectedDirection;
        [ObservableProperty] string message;
        [ObservableProperty] string color;
        public RegistrationViewModel()
        {
            bitmap = GetDefaultImage();
            roles = ["Жюри", "Модератор"];
            genders = Db.Genders.ToList();
            activities = Db.ActivitiesLists.ToList();
            directions = Db.Directions.ToList();
            color = "Red";
            if (MainWindowViewModel.Instance.PreviousPage == "RegistrationViewModel")
            {
                color = "Green";
                Message = "Успешно";
            }
        }

        public Bitmap GetDefaultImage()
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uridefault = new Uri($"avares://{assemblyName}/Assets/default.png");
            return new Bitmap(AssetLoader.Open(uridefault));
        }

        public void GoBack()
        {
            MainWindowViewModel.Instance.PageSwitcher = new ArrangersViewModel();
        }

        partial void OnRoleChanged(string value)
        {
            switch (value)
            {
                case "Жюри":
                    Id = Db.Experts.Count() + 1;
                    break;
                case "Модератор":
                    Id = Db.Moderators.Count() + 1;
                    break;
            }
        }
        bool IsPasswordValid()
        {

            if (Password.Length < 6)
                return false;

            bool hasUpperCase = false;
            bool hasLowerCase = false;
            bool hasDigit = false;
            bool hasSpecialChar = false;

            foreach (char c in Password)
            {
                if (char.IsUpper(c)) hasUpperCase = true;
                if (char.IsLower(c)) hasLowerCase = true;
                if (char.IsDigit(c)) hasDigit = true;
                if (Regex.IsMatch(c.ToString(), @"[\W_]")) hasSpecialChar = true; 
            }

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }

        bool IsEmailValid()
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            return Regex.IsMatch(Email, emailPattern);
        }

        public void Register()
        {
            if (Id == null || Email == null || Phone_number== null || SelectedGender == null || SelectedDirection == null || SelectedDirection == null || Password == null || Password2 == null || Fcs == null)
            {
                Color = "Red";
                Message = "Не все поля заполнены данными";

            }
            else if (Password != Password2)
            {
                Color = "Red";
                Message = "Введённые пароли не равны";

            }
            else
            {
                if (Role == "Жюри")
                {
                    Random random = new Random();
                    Expert expert = new Expert()
                    {
                        Id = Id,
                        Fcs = Fcs,
                        Gender = SelectedGender.Id,
                        Email = Email,
                        Birthdate = DateOnly.MaxValue,
                        IdCountry = random.Next(1, 251),
                        PhoneNumber = Phone_number,
                        Direction = SelectedDirection.Id,
                        Passwd = Password,
                        Image = "None"
                    };
                    Console.WriteLine(expert);
                    Db.Experts.Add(expert);
                    Db.SaveChanges();
                    MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher.GetType().Name;
                    MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
                }
                else if(!IsPasswordValid())
                {
                    Color = "Red";
                    Message = "Введён слишком лёгкий пароль";
                }else if(!IsEmailValid())
                {
                    Color = "Red";
                    Message = "Некорректно введена почта";
                }
                else if (Role == "Модератор" && SelectedActivity != null && IsEmailValid() && IsPasswordValid())
                {
                    Random random = new Random();
                    Moderator moderator = new Moderator()
                    {
                        Id = Id,
                        Fcs = Fcs,
                        Gender = SelectedGender.Id,
                        Email = Email,
                        Birthdate = DateOnly.MaxValue,
                        IdCountry = random.Next(1, 251),
                        PhoneNumber = Phone_number,
                        Direction = SelectedDirection.Id,
                        Events = SelectedActivity.Id,
                        Passwd = Password,
                        Image = "None"
                    };
                    Db.Moderators.Add(moderator);
                    Db.SaveChanges();
                    MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher.GetType().Name;
                    MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
                }
                else if (Role == "Модератор" && SelectedActivity == null && IsEmailValid() && IsPasswordValid())
                {
                    Random random = new Random();
                    Moderator moderator = new Moderator()
                    {
                        Id = Id,
                        Fcs = Fcs,
                        Gender = SelectedGender.Id,
                        Email = Email,
                        Birthdate = DateOnly.MaxValue,
                        IdCountry = random.Next(1, 251),
                        PhoneNumber = Phone_number,
                        Events =  null,
                        Direction = SelectedDirection.Id,
                        Passwd = Password,
                        Image = "None"
                    };
                    Db.Moderators.Add(moderator);
                    Db.SaveChanges();
                    MainWindowViewModel.Instance.PreviousPage = MainWindowViewModel.Instance.PageSwitcher.GetType().Name;
                    MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
                }
            }


        }

    }
}
