namespace GradeManagmentSystem_BackEnd.Model
{
    public class Student
    {
        public int Id { get; set; }
        public required string Student_code { get; set; }
        public virtual required User User { get; set; }
        public virtual required Attendant Attendant { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
