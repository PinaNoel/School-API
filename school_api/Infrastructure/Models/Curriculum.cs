using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Curriculum
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? CareerId { get; set; }

    public virtual Career? Career { get; set; }

    public virtual ICollection<CurriculumSubject> CurriculumSubjects { get; set; } = new List<CurriculumSubject>();
}
