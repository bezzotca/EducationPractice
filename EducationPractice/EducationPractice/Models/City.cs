using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class City
{
    public int Id { get; set; }

    public string Image { get; set; } = null!;

    public string CityName { get; set; } = null!;

    public virtual ICollection<EventsPlan> EventsPlans { get; set; } = new List<EventsPlan>();
}
