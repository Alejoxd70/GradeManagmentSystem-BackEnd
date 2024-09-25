namespace GradeManagmentSystem_BackEnd.Model
{
    public class UserHistory
    {
        public int Id { get; set; }
        public required string IdUser { get; set; }
        public required string Name { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Identification { get; set; }

        public required string UserType { get; set; }
        public required DateTime Modified {  get; set; }
        public required string ModifiedBy {  get; set; }
    }
}
