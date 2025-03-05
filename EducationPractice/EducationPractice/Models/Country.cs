using System;
using System.Collections.Generic;

namespace EducationPractice.Models;

public partial class Country
{
    public int Id { get; set; }

    public string NameRussian { get; set; } = null!;

    public string NameEnglish { get; set; } = null!;

    public string Code { get; set; } = null!;

    public int CodeTwo { get; set; }

    public virtual ICollection<Arranger> Arrangers { get; set; } = new List<Arranger>();

    public virtual ICollection<Expert> Experts { get; set; } = new List<Expert>();

    public virtual ICollection<Member> Members { get; set; } = new List<Member>();

    public virtual ICollection<Moderator> Moderators { get; set; } = new List<Moderator>();
}
