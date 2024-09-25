namespace GradeManagmentSystem_BackEnd.Model
{
    public class PermissionHistory
    {
        public int Id { get; set; }
        public required string IdPermission { get; set; }
        public required string PermissionName { get; set; }
        public required DateTime Modified {  get; set; }
        public required string User {  get; set; }
    }
}
