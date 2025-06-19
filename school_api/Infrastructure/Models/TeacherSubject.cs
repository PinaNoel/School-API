using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class TeacherSubject
{
    public int Id { get; set; }

    public int? TeacherId { get; set; }

    public int? SubjectId { get; set; }

    public int? PeriodGroupId { get; set; }

    public virtual PeriodsGroup? PeriodGroup { get; set; }

    public virtual ICollection<StudentsSubject> StudentsSubjects { get; set; } = new List<StudentsSubject>();

    public virtual Subject? Subject { get; set; }

    public virtual Teacher? Teacher { get; set; }
}
