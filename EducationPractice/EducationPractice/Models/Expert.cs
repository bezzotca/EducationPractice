using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class Expert
{
    public int Id { get; set; }

    public string Fcs { get; set; } = null!;

    public int Gender { get; set; }

    public string Email { get; set; } = null!;

    public DateOnly Birthdate { get; set; }

    public int IdCountry { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public int Direction { get; set; }

    public string Passwd { get; set; } = null!;

    public string Image { get; set; } = null!;

    public virtual ICollection<Activity> ActivityExpert1Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert2Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert3Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert4Navigations { get; set; } = new List<Activity>();

    public virtual ICollection<Activity> ActivityExpert5Navigations { get; set; } = new List<Activity>();

    public virtual Direction DirectionNavigation { get; set; } = null!;

    public virtual Gender GenderNavigation { get; set; } = null!;

    public virtual Country IdCountryNavigation { get; set; } = null!;
}
