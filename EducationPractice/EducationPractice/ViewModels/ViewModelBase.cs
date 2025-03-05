using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;

namespace EducationPractice.ViewModels
{
    public partial class ViewModelBase : ObservableObject
    {
        [ObservableProperty] static EducationpracticeContext db = new EducationpracticeContext();
    }
}
