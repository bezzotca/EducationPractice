using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationPractice.ViewModels
{
    public partial class EventListViewModel : ViewModelBase
    {
        [ObservableProperty] List<EventsPlan> eventsPlan;
        [ObservableProperty] List<EventsPlan> eventsPlan0;
        [ObservableProperty] string textFind;
        [ObservableProperty] List<int> daysInEvent;
        [ObservableProperty] int selectedDay;
        public EventListViewModel()
        {
            eventsPlan = Db.EventsPlans.ToList();
            eventsPlan0 = Db.EventsPlans.ToList();
            daysInEvent = Db.EventsPlans.Select(x=> x.Countdays).Distinct().ToList();
        }
        public void GoBack()
        {
            if(MainWindowViewModel.Instance.PreviousPage == "LoginViewModel")
            {
                MainWindowViewModel.Instance.PageSwitcher = new LoginViewModel();
            }
            else if(MainWindowViewModel.Instance.PreviousPage == "ArrangersViewModel")
            {
                MainWindowViewModel.Instance.PageSwitcher = new ArrangersViewModel();
            }
        }
        partial void OnTextFindChanged(string value)
        {
            EventsPlan = EventsPlan0;
            EventsPlan = EventsPlan.Where(x => x.EventName.Contains(value)).ToList();
        }

        partial void OnSelectedDayChanged(int value)
        {
            EventsPlan = EventsPlan0;
            EventsPlan = EventsPlan.Where(x => x.Countdays == value).ToList();
        }

        public void DataSort(int sortOrder)
        {
            switch (sortOrder)
            {
                case 1:
                    EventsPlan = EventsPlan.OrderBy(x => x.Contestday).ToList();
                    break;
                case 2:
                    EventsPlan = EventsPlan.OrderByDescending(x => x.Contestday).ToList();
                    break;
            }
        }

        public void UpdateButton()
        {
            MainWindowViewModel.Instance.PageSwitcher = new EventListViewModel();
        }
    }
}
