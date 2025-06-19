using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Semester
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public virtual ICollection<CurriculumSubject> CurriculumSubjects { get; set; } = new List<CurriculumSubject>();
}
