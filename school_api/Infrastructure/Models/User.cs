using System;
using System.Collections.Generic;

namespace school_api.Infrastructure.Models;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Surnames { get; set; }

    public string? Email { get; set; }

    public string? Enrollment { get; set; }

    public byte[]? Salt { get; set; }

    public byte[]? Password { get; set; }

    public string? Role { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
