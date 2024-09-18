
namespace GradeManagmentSystem_BackEnd.Model
{
    public class SubjectTeacher
    {
        public int Id { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual Subject? Subject { get; set; }
        public virtual GroupYear? GroupYear { get; set; }
        public bool IsDeleted { get; set; } = false;

    }
}