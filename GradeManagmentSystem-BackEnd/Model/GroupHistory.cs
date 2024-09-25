namespace GradeManagmentSystem_BackEnd.Model
{
    public class GroupHistory
    {
        public int Id { get; set; }
        public required string IdGroup { get; set; }
        public required string GroupName { get; set; }
        public required DateTime Modified {  get; set; }
        public required string ModifiedBy { get; set; }


    }
}
