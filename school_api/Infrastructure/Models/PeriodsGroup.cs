using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class PeriodsGroup
{
    public int Id { get; set; }

    public int? GroupId { get; set; }

    public int? PeriodId { get; set; }

    public virtual Group? Group { get; set; }

    public virtual Period? Period { get; set; }

    public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();
}
