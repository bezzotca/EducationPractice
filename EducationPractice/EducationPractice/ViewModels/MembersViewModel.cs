using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPractice.ViewModels
{
    public partial class MembersViewModel: ViewModelBase
    {
        [ObservableProperty] List<Member> members;
        [ObservableProperty] List<Member> members0;
        [ObservableProperty] string textFind;
        public MembersViewModel()
        {
            members = Db.Members.ToList();
            members0 = Db.Members.ToList();
        }

        partial void OnTextFindChanged(string value)
        {
            Members = members0;
            Members = Members.Where(x => x.Fcs.Contains(value)).ToList();
        }

        public void DataSort(int sortOrder)
        {
            switch (sortOrder)
            {
                case 1:
                    Members = Members.OrderBy(x => x.Birthdate).ToList();
                    break;
                case 2:
                    Members = Members.OrderByDescending(x => x.Birthdate).ToList();
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
            MainWindowViewModel.Instance.PageSwitcher = new MembersViewModel();
        }
    }
}
