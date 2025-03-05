using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class Direction
{
    public int Id { get; set; }

    public string NameDirection { get; set; } = null!;

    public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
