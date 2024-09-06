namespace GradeManagmentSystem_BackEnd.Model
{
    public class Student
    {
        public int Id { get; set; }
        public virtual required User User { get; set; }
    }
}
