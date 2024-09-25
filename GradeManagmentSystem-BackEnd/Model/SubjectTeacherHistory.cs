namespace GradeManagmentSystem_BackEnd.Model
{
    public class SubjectTeacherHistory
    {
        public int Id { get; set; }
        public required string IdSubjectTeacher { get; set; }
        public required string Teacher { get; set; }
        public required string Subject { get; set; }
        public required string GroupYear { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
