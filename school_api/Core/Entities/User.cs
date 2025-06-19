

namespace school_api.Core.Entities
{


    public class Student
    {
        public int CareerId { get; }

        public Student(int careerId)
        {
            CareerId = careerId;
        }
    }


    public class Teacher
    {
        public string Title { get; }
        public string Speciality { get; }

        public Teacher(string title, string speciality)
        {
            Title = title;
            Speciality = speciality;
        }
    }


    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surnames { get; set; }
        public string? Email { get; set; }
        public string? Enrollment { get; set; }
        public string? Password { get; set; }
        public bool? IsActive { get; set; } = true;

        public byte[]? Hash { get; private set; }
        public byte[]? Salt { get; private set; }
        public string? Role { get; private set; }
        public Student? Student { get; private set; }
        public Teacher? Teacher { get; private set; }



        public void PromoteToStudent(int careerId)
        {
            if (Student != null) throw new InvalidOperationException("Already a student");

            Student = new Student(careerId);
            UpdateRole("Student");
        }

        public void PromoteToTeacher(string title, string speciality)
        {
            if (Teacher != null) throw new InvalidOperationException("Already a teacher");

            Teacher = new Teacher(title, speciality);
            UpdateRole("Teacher");
        }

        public void PromoteToAdmin()
        {
            UpdateRole("Admin");
        }

        public void UpdateRole(string role)
        {
            Role = role;
        }

        public void SetHash(byte[] hash, byte[] salt)
        {
            Hash = hash;
            Salt = salt;
        }

    }

    
}