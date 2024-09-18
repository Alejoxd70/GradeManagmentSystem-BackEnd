using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GradeManagmentSystem_BackEnd.Model
{
    public class User
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Identification { get; set; }

        public virtual required UserType UserType { get; set; }
    }
}

