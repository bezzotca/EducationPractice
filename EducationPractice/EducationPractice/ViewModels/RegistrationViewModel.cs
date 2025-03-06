using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
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
        [ObservableProperty] string phone_number;
        [ObservableProperty] string email;
        [ObservableProperty] string password;
        [ObservableProperty] string password2;
        [ObservableProperty] ActivitiesList selectedActivity;
        [ObservableProperty] Direction selectedDirection;
        [ObservableProperty] string message;
        public RegistrationViewModel() 
        {
            bitmap = GetDefaultImage();
            roles = ["Жюри", "Модератор"];
            genders = Db.Genders.ToList();
            activities = Db.ActivitiesLists.ToList();
            directions = Db.Directions.ToList();
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

        public void Register()
        {
            if (Id == null || Email == null || Phone_number== null || SelectedGender == null || SelectedDirection == null || SelectedDirection == null || Password == null || Password2 == null || Fcs == null)
            {
                Message = "Не все поля заполнены данными";
                
            }
            else if (Password != Password2)
            {
                Message = "Введённые пароли не равны";
                
            }
            else
            {
               if(Role == "Жюри")
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

                    MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
                }
               else if (Role == "Модератор" && SelectedActivity != null)
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
                    MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
                }
                else if (Role == "Модератор" && SelectedActivity == null )
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
                    MainWindowViewModel.Instance.PageSwitcher = new RegistrationViewModel();
                }
            }


        }
    }
}
