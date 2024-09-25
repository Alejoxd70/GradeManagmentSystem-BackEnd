using GradeManagmentSystem_BackEnd.Model;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<UserType>().HasKey(u => u.Id);
            modelBuilder.Entity<PermissionUserType>().HasKey(u => u.Id);
            modelBuilder.Entity<Permission>().HasKey(u => u.Id);
            modelBuilder.Entity<Student>().HasKey(u => u.Id);
            //Añadi Builder
            modelBuilder.Entity<Attendant>().HasKey(u => u.Id);
            modelBuilder.Entity<Teacher>().HasKey(u => u.Id);
            modelBuilder.Entity<GroupYear>().HasKey(u => u.Id);

            //añadi estos builders
            modelBuilder.Entity<Subject>().HasKey(u => u.Id);
            modelBuilder.Entity<Group>().HasKey(u => u.Id);


            modelBuilder.Entity<Assigment>().HasKey(u => u.Id);
            modelBuilder.Entity<Grade>().HasKey(u => u.Id);
            modelBuilder.Entity<SubjectTeacher>().HasKey(u => u.Id);




        }
    }
}
