namespace GradeManagmentSystem_BackEnd.Model
{
    public class PermissionUserTypeHistory
    {
        public int Id { get; set; }
        public required string IdPermissionUserType { get; set; }
        public required string UserType { get; set; }
        public required string Permission { get; set; }
        public required DateTime Modified { get; set; }
        public required string User { get; set; }

    }
}
