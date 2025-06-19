using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Career
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<Curriculum> Curricula { get; set; } = new List<Curriculum>();

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
