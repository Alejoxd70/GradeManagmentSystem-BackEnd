namespace GradeManagmentSystem_BackEnd.Model
{
    public class Attendant
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public  string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
