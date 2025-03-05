using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class ModeratorEvent
{
    public int Id { get; set; }

    public string? NameEvent { get; set; }

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
