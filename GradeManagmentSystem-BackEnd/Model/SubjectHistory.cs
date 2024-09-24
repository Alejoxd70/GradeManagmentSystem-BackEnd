namespace GradeManagmentSystem_BackEnd.Model
{
    public class SubjectHistory
    {
        public int Id { get; set; }
        public required string IdSubject { get; set; }
        public required string Subjectname { get; set; }
        public required string Description { get; set; }
        public required DateTime Modified {  get; set; }
        public required string User { get; set; }

    }
}
