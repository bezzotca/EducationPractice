using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class Gender
{
    public int Id { get; set; }

    public string Gender1 { get; set; } = null!;

    public virtual ICollection<Arranger> Arrangers { get; set; } = new List<Arranger>();

    public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
