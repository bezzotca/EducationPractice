using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;

namespace EducationPractice.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {

        [ObservableProperty] ViewModelBase pageSwitcher;
        [ObservableProperty] private string previousPage;
        public Arranger? loginedArranger;
        public MainWindowViewModel()
        {
            Instance = this;
            pageSwitcher = new LoginViewModel();
            previousPage = pageSwitcher?.GetType().Name;
        }

        public static MainWindowViewModel Instance { get; set; }
    }
}
