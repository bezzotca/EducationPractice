using Avalonia.Media.Imaging;
using Avalonia.Platform;
using CommunityToolkit.Mvvm.ComponentModel;
using EducationPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationPractice.ViewModels
{
    public partial class ArrangerProfileViewModel : ViewModelBase
    {
        [ObservableProperty] Arranger arrangerProfile = MainWindowViewModel.Instance.loginedArranger;
        [ObservableProperty] Bitmap photo;
        [ObservableProperty] Arranger arrangerMoreInfo;
        public List<Gender> Genders => Db.Genders.ToList();
        public List<Country> Countries => Db.Countries.ToList();
        public ArrangerProfileViewModel()
        {
            photo = ConvertPathToBitmap();
            arrangerMoreInfo = (Arranger?)Db.Arrangers.Include(x => x.GenderNavigation).Include(x => x.IdCountryNavigation).FirstOrDefault(x => x.Id == ArrangerProfile.Id);
        }

        public void GoBack()
        {
            MainWindowViewModel.Instance.PageSwitcher = new ArrangersViewModel();
        }

        public void Save() => Db.SaveChanges();

        public DateTimeOffset DateTime
        {
            get => new DateTimeOffset(arrangerProfile.Birthdate, TimeOnly.MinValue, TimeSpan.Zero);
            set => arrangerProfile.Birthdate = new DateOnly(value.Year, value.Month, value.Day);
        }
        public Bitmap ConvertPathToBitmap()
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"avares://{assemblyName}/Assets/Arrangers_media/{ArrangerProfile.Image}");
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
    }
}
