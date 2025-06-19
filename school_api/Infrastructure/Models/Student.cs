using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Student
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? CareerId { get; set; }

    public virtual Career? Career { get; set; }

    public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();

    public virtual User? User { get; set; }
}
