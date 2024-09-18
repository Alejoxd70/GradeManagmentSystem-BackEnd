namespace GradeManagmentSystem_BackEnd.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public required string Subjectname { get; set; }
        public required string Description { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
