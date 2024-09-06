using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GradeManagmentSystem_BackEnd.Model
{
    public class User
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public string Gender { get; set; } = string.Empty;
        public DateOnly DateBirth {  get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }

        public virtual required UserType UserType { get; set; }
    }
}
