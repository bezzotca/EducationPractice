using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;

namespace EducationPractice.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        [ObservableProperty] ViewModelBase pageSwitcher;

        public MainWindowViewModel()
        {
            Instance = this;
            pageSwitcher = new LoginViewModel();
        }

        public static MainWindowViewModel Instance { get; set; }
    }
}
