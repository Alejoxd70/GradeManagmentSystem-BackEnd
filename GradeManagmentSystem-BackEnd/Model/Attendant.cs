namespace GradeManagmentSystem_BackEnd.Model
{
    public class Attendant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Relationship { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
