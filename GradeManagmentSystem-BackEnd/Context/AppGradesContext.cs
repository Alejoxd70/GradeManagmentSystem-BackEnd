using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace GradeManagmentSystem_BackEnd.Context
{
    public class AppGradesContext : DbContext
    {
        public AppGradesContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        //Añadi los siguientes DbSet
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<PermissionUserType> PermissionUserTypes { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Attendant> Attendants { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<GroupYear> GroupYears { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Assigment> Assigments { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<SubjectTeacher> SubjectTeachers { get; set; }
        //TABLES HISTORY
        public DbSet<UserHistory> UserHistories { get; set; }
        public DbSet<UserTypeHistory> UserTypeHistories { get; set; }
        public DbSet<PermissionUserTypeHistory> PermissionUserTypeHistories { get; set; }
        public DbSet<PermissionHistory> PermissionHistories { get; set; }
        public DbSet<StudentHistory> StudentHistories { get; set; }
        public DbSet<AttendantHistory> AttendantHistories { get; set; }
        public DbSet<TeacherHistory> TeacherHistories { get; set; }
        public DbSet<GroupYearHistory> GroupYearHistories { get; set; }
        public DbSet<SubjectHistory> SubjectHistories { get; set; }
        public DbSet<GroupHistory> GroupHistories { get; set; }
        public DbSet<AssigmentHistory> AssigmentHistories { get; set; }
        public DbSet<GradeHistory> GradeHistories { get; set; }
        public DbSet<SubjectTeacherHistory> SubjectTeacherHistories { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //builders models
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<UserType>().HasKey(u => u.Id);
            modelBuilder.Entity<PermissionUserType>().HasKey(u => u.Id);
            modelBuilder.Entity<Permission>().HasKey(u => u.Id);
            modelBuilder.Entity<Student>().HasKey(u => u.Id);
            modelBuilder.Entity<Attendant>().HasKey(u => u.Id);
            modelBuilder.Entity<Teacher>().HasKey(u => u.Id);
            modelBuilder.Entity<GroupYear>().HasKey(u => u.Id);
            modelBuilder.Entity<Subject>().HasKey(u => u.Id);
            modelBuilder.Entity<Group>().HasKey(u => u.Id);
            modelBuilder.Entity<Assigment>().HasKey(u => u.Id);
            modelBuilder.Entity<Grade>().HasKey(u => u.Id);
            modelBuilder.Entity<SubjectTeacher>().HasKey(u => u.Id);

            //BUILDERS HISTORY

            modelBuilder.Entity<UserHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<UserTypeHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<PermissionUserTypeHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<PermissionHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<StudentHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<AttendantHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<TeacherHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<GroupYearHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<SubjectHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<GroupHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<AssigmentHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<GradeHistory>().HasKey(u => u.Id);
            modelBuilder.Entity<SubjectTeacherHistory>().HasKey(u => u.Id);

            //Builder Triggers
            modelBuilder.Entity<User>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Assigment>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<GroupYear>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<SubjectTeacher>().ToTable(tb => tb.UseSqlOutputClause(false));
            
            modelBuilder.Entity<Group>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Grade>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Subject>().ToTable(tb => tb.UseSqlOutputClause(false));
            
            modelBuilder.Entity<Student>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Attendant>().ToTable(tb => tb.UseSqlOutputClause(false));
            modelBuilder.Entity<Teacher>().ToTable(tb => tb.UseSqlOutputClause(false));
        }
       
    }
}
