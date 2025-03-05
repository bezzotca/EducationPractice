using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class Activity
{
    public int Id { get; set; }

    public int NameEvent { get; set; }

    public DateOnly StartDate { get; set; }

    public int Countdays { get; set; }

    public int Activity1 { get; set; }

    public int Activityday { get; set; }

    public TimeOnly Starttime { get; set; }

    public int Moderator { get; set; }

    public int? Expert1 { get; set; }

    public int? Expert2 { get; set; }

    public int? Expert3 { get; set; }

    public int? Expert4 { get; set; }

    public int? Expert5 { get; set; }

    public int? Winner { get; set; }

    public virtual ActivitiesList Activity1Navigation { get; set; } = null!;

    public virtual Expert? Expert1Navigation { get; set; }

    public virtual Expert? Expert2Navigation { get; set; }

    public virtual Expert? Expert3Navigation { get; set; }

    public virtual Expert? Expert4Navigation { get; set; }

    public virtual Expert? Expert5Navigation { get; set; }

    public virtual Moderator ModeratorNavigation { get; set; } = null!;

    public virtual EventsPlan NameEventNavigation { get; set; } = null!;

    public virtual Member? WinnerNavigation { get; set; }
}
