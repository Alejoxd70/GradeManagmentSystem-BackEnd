namespace GradeManagmentSystem_BackEnd.Model
{
    public class AttendantHistory
    {
        public int Id { get; set; }
        public required int IdAttendant { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Relationship { get; set; }
        public required DateTime Modified { get; set; }
        public required string ModifiedBy { get; set; }
    }
}
