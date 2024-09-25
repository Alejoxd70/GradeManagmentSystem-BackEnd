namespace GradeManagmentSystem_BackEnd.Model
{
    public class StudentHistory
    {
        public int Id { get; set; }
        public required int IdStudent { get; set; }
        public required string Student_code { get; set; }
        public required string User { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
