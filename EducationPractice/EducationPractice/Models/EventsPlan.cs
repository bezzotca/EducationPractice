using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class EventsPlan
{
    public int Id { get; set; }

    public string EventName { get; set; } = null!;

    public DateOnly Contestday { get; set; }

    public int Countdays { get; set; }

    public int Idcity { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();

    public virtual City IdcityNavigation { get; set; } = null!;
}
