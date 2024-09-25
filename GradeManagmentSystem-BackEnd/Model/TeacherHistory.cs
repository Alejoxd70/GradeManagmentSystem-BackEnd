namespace GradeManagmentSystem_BackEnd.Model
{
    public class TeacherHistory
    {
        public int Id { get; set; }
        public required string IdTeacher { get; set; }

        public required string User { get; set; }

        public required string Specialization { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }

    }
}
