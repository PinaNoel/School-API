using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Grade
{
    public int Id { get; set; }

    public decimal? Unit1 { get; set; }

    public decimal? Unit2 { get; set; }

    public decimal? Unit3 { get; set; }

    public virtual ICollection<StudentsSubject> StudentsSubjects { get; set; } = new List<StudentsSubject>();
}
