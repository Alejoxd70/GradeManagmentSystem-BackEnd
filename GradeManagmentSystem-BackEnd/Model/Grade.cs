namespace GradeManagmentSystem_BackEnd.Model
{
    public class Grade
    {
        public int Id { get; set; }
        public required string Value { get; set; }
        public virtual required Assigment? Assigment { get; set; }
        public virtual required Student? Student { get; set; }
    }
}