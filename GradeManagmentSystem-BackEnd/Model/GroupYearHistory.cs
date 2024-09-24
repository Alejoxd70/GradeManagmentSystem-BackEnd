namespace GradeManagmentSystem_BackEnd.Model
{
    public class GroupYearHistory
    {
        public int Id { get; set; }
        public required string IdGroupYear { get; set; }
        public required string Year { get; set; }
        public required string Student { get; set; }
        public required string Group { get; set; }
        public required DateTime Modified { get; set; }
        public  required string User { get; set; }
    }
}
