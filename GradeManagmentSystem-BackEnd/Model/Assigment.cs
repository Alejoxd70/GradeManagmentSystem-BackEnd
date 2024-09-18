namespace GradeManagmentSystem_BackEnd.Model
{
    public class Assigment

    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required DateOnly Date { get; set; }
        public virtual required SubjectTeacher? SubjectTeacher { get; set; }
    }
}
