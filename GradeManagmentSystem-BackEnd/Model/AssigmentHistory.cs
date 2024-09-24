namespace GradeManagmentSystem_BackEnd.Model
{
    public class AssigmentHistory
    {
        public int Id { get; set; }
        public required string IdAssigment { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Date { get; set; }
        public required string SubjectTeacher { get; set; }
        public required DateTime Modified { get; set; }
        public required string User { get; set; }
    }
}
