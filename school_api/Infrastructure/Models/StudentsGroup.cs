using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class StudentsGroup
{
    public int Id { get; set; }

    public int? StudentId { get; set; }

    public int? PeriodGroupId { get; set; }

    public int? StudentSubjectsId { get; set; }

    public virtual PeriodsGroup? PeriodGroup { get; set; }

    public virtual Student? Student { get; set; }

    public virtual StudentsSubject? StudentSubjects { get; set; }
}
