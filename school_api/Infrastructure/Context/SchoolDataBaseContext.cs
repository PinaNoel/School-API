
using Microsoft.EntityFrameworkCore;
using school_api.Infrastructure.Models;

namespace school_api.Infrastructure.Context;

public partial class SchoolDataBaseContext : DbContext
{
    public SchoolDataBaseContext()
    {
    }

    public SchoolDataBaseContext(DbContextOptions<SchoolDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Career> Careers { get; set; }

    public virtual DbSet<Curriculum> Curriculums { get; set; }

    public virtual DbSet<CurriculumSubject> CurriculumSubjects { get; set; }

    public virtual DbSet<Grade> Grades { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Period> Periods { get; set; }

    public virtual DbSet<PeriodsGroup> PeriodsGroups { get; set; }

    public virtual DbSet<Semester> Semesters { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<StudentsGroup> StudentsGroups { get; set; }

    public virtual DbSet<StudentsSubject> StudentsSubjects { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeacherSubject> TeacherSubjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Career>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Careers__3214EC072A5FD367");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Curriculum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC0790E0D6BF");

            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.Career).WithMany(p => p.Curricula)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Curriculu__Caree__49C3F6B7");
        });

        modelBuilder.Entity<CurriculumSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Curricul__3214EC077FCF999A");

            entity.HasOne(d => d.Curriculum).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.CurriculumId)
                .HasConstraintName("FK__Curriculu__Curri__4E88ABD4");

            entity.HasOne(d => d.Semester).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.SemesterId)
                .HasConstraintName("FK__Curriculu__Semes__5070F446");

            entity.HasOne(d => d.Subject).WithMany(p => p.CurriculumSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Curriculu__Subje__4F7CD00D");
        });

        modelBuilder.Entity<Grade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grades__3214EC07721DEB56");

            entity.Property(e => e.Unit1).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit2).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Unit3).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC072D9CBAF0");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Period>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Periods__3214EC07012C5C93");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<PeriodsGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PeriodsG__3214EC0709F4B126");

            entity.HasOne(d => d.Group).WithMany(p => p.PeriodsGroups)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__PeriodsGr__Group__534D60F1");

            entity.HasOne(d => d.Period).WithMany(p => p.PeriodsGroups)
                .HasForeignKey(d => d.PeriodId)
                .HasConstraintName("FK__PeriodsGr__Perio__5441852A");
        });

        modelBuilder.Entity<Semester>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Semester__3214EC07A956C529");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC076E7492E2");

            entity.HasOne(d => d.Career).WithMany(p => p.Students)
                .HasForeignKey(d => d.CareerId)
                .HasConstraintName("FK__Students__Career__3C69FB99");

            entity.HasOne(d => d.User).WithMany(p => p.Students)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Students__UserId__3B75D760");
        });

        modelBuilder.Entity<StudentsGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07B35ECE7E");

            entity.HasOne(d => d.PeriodGroup).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.PeriodGroupId)
                .HasConstraintName("FK__StudentsG__Perio__60A75C0F");

            entity.HasOne(d => d.Student).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__StudentsG__Stude__5FB337D6");

            entity.HasOne(d => d.StudentSubjects).WithMany(p => p.StudentsGroups)
                .HasForeignKey(d => d.StudentSubjectsId)
                .HasConstraintName("FK__StudentsG__Stude__619B8048");
        });

        modelBuilder.Entity<StudentsSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0793B660DA");

            entity.HasOne(d => d.Grades).WithMany(p => p.StudentsSubjects)
                .HasForeignKey(d => d.GradesId)
                .HasConstraintName("FK__StudentsS__Grade__5CD6CB2B");

            entity.HasOne(d => d.TeacherSubject).WithMany(p => p.StudentsSubjects)
                .HasForeignKey(d => d.TeacherSubjectId)
                .HasConstraintName("FK__StudentsS__Teach__5BE2A6F2");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subjects__3214EC07BBF03196");

            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC07539B111C");

            entity.Property(e => e.Speciality).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Teachers__UserId__3F466844");
        });

        modelBuilder.Entity<TeacherSubject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TeacherS__3214EC0759B3F194");

            entity.HasOne(d => d.PeriodGroup).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.PeriodGroupId)
                .HasConstraintName("FK__TeacherSu__Perio__59063A47");

            entity.HasOne(d => d.Subject).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__TeacherSu__Subje__5812160E");

            entity.HasOne(d => d.Teacher).WithMany(p => p.TeacherSubjects)
                .HasForeignKey(d => d.TeacherId)
                .HasConstraintName("FK__TeacherSu__Teach__571DF1D5");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B4960A92");

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Enrollment).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.Salt).HasMaxLength(50);
            entity.Property(e => e.Surnames).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
