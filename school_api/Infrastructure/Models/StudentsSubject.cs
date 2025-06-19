using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class StudentsSubject
{
    public int Id { get; set; }

    public int? TeacherSubjectId { get; set; }

    public int? GradesId { get; set; }

    public virtual Grade? Grades { get; set; }

    public virtual ICollection<StudentsGroup> StudentsGroups { get; set; } = new List<StudentsGroup>();

    public virtual TeacherSubject? TeacherSubject { get; set; }
}
