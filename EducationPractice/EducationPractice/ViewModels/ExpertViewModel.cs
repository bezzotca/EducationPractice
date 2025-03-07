using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPractice.ViewModels
{
    public partial class ExpertViewModel: ViewModelBase
    {
        [ObservableProperty] List<Expert> experts;
        [ObservableProperty] List<Expert> experts0;
        [ObservableProperty] string textFind;
        [ObservableProperty] string message;

        public ExpertViewModel()
        {
            Message = string.Empty;
            experts = Db.Experts.ToList();
        }

        
        partial void OnTextFindChanged(string value)
        {
            Message = string.Empty;
            Experts = experts0;
            Experts = Experts.Where(x => x.Fcs.Contains(value)).ToList();
            if (!Experts.Any())
            {
                Message = "По вашему запросу результатов нет";
            }
        }

        public void DataSort(int sortOrder)
        {
            Message = string.Empty;
            switch (sortOrder)
            {
                case 1:
                    Experts = Experts.OrderBy(x => x.Birthdate).ToList();
                    if (!Experts.Any())
                    {
                        Message = "По вашему запросу результатов нет";
                    }
                    break;
                case 2:
                    Experts = Experts.OrderByDescending(x => x.Birthdate).ToList();
                    if (!Experts.Any())
                    {
                        Message = "По вашему запросу результатов нет";
                    }
                    break;
            }
        }
        public void GoBack()
        {
            if (MainWindowViewModel.Instance.PreviousPage == "LoginViewModel")
            {
                MainWindowViewModel.Instance.PageSwitcher = new LoginViewModel();
            }
            else if (MainWindowViewModel.Instance.PreviousPage == "ArrangersViewModel")
            {
                MainWindowViewModel.Instance.PageSwitcher = new ArrangersViewModel();
            }
        }
        
        public void UpdateButton()
        {
            MainWindowViewModel.Instance.PageSwitcher = new ExpertViewModel();
        }
    }
}
