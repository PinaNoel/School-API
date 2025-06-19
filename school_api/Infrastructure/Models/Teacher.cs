using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class Teacher
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Speciality { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; } = new List<TeacherSubject>();

    public virtual User? User { get; set; }
}
