using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class ActivitiesList
{
    public int Id { get; set; }

    public string NameActivity { get; set; } = null!;

    public virtual ICollection<Activity> Activities { get; set; } = new List<Activity>();
}
