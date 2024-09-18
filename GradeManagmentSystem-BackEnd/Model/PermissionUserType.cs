namespace GradeManagmentSystem_BackEnd.Model
{
    public class PermissionUserType
    {
        public int Id { get; set; }
        public virtual required UserType UserType { get; set; }
        public virtual required Permission Permission { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}
