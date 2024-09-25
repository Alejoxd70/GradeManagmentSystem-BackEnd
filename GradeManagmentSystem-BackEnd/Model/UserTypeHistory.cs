namespace GradeManagmentSystem_BackEnd.Model
{
    public class UserTypeHistory
    {
        public int Id { get; set; }
        public required string IdUserType { get; set; }
        public required string UserTypeName { get; set; }
        public required DateTime Modified { get; set; }
        public required string User { get; set; }
    }
}
