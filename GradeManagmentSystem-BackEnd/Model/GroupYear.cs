using System.ComponentModel.DataAnnotations;

namespace GradeManagmentSystem_BackEnd.Model
{
    public class GroupYear
    {
        public int Id { get; set; }

        public required string Year { get; set; }

        public virtual required Student Student { get; set; }

        //public virtual required Group Group { get; set; }
    }
}
