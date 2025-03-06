using Avalonia.Media.Imaging;
using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class Member
{
    public int Id { get; set; }

    public string Fcs { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public int IdCountry { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Passwd { get; set; } = null!;

    public string Image { get; set; } = null!;

    public Bitmap Photo => ConvertToBitmap.ConverterToBitmapMembers(Image);

    public int Gender { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual Country IdCountryNavigation { get; set; } = null!;
}
