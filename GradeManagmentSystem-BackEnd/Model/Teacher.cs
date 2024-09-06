using System.ComponentModel.DataAnnotations;

namespace GradeManagmentSystem_BackEnd.Model
{
    public class Teacher
    {
        public int Id { get; set; }

        public virtual required User User { get; set; }

        public required string Specialization { get; set; }
    }
}
