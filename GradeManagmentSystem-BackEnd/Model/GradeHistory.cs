using Azure.Identity;

namespace GradeManagmentSystem_BackEnd.Model
{
    public class GradeHistory
    {
        public int Id { get; set; }
        public required string IdGrade { get; set; }
        public required string Value { get; set; }
        public required string Assigment { get; set; }
        public required string Student { get; set; }
        public required DateTime Modified { get; set; }
        public required string User { get; set; }
    }
}
