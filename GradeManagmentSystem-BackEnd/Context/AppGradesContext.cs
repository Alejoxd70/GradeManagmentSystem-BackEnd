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
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<UserType>().HasKey(u => u.Id);
            modelBuilder.Entity<PermissionUserType>().HasKey(u => u.Id);
            modelBuilder.Entity<Permission>().HasKey(u => u.Id);
            modelBuilder.Entity<Student>().HasKey(u => u.Id); 


        }
    }
}
