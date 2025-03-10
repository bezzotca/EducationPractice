﻿using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EducationPractice.Models
{
    public partial class ConvertToBitmap
    {
        public static Bitmap ConverterToBitmap(string Image)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"avares://{assemblyName}/Assets/Events_media/{Image}");
            return new Bitmap(AssetLoader.Open(uri));
        }

        public static Bitmap ConverterToBitmapMembers(string Image)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"avares://{assemblyName}/Assets/Members_medfia/{Image}");
            return new Bitmap(AssetLoader.Open(uri));
        }
        public static Bitmap ConverterToBitmapExperts(string Image)
        {
            string assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            Uri uri = new Uri($"avares://{assemblyName}/Assets/Experts_media/{Image}");
            return new Bitmap(AssetLoader.Open(uri));
        }
    }
}
