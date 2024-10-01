using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Trigger User
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditUser
            ON [Users]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO UserHistories (IdUser, Name, Lastname, Email, Password, Identification, UserType, Modified, ModifiedBy)
                    SELECT i.Id, i.Name, i.Lastname, i.Email, i.Password, i.Identification, i.UserTypeId,
                        GETDATE(),
                           CASE 
                               WHEN EXISTS (SELECT * FROM deleted) THEN 'UPDATE' 
                               ELSE 'INSERT' 
                           END
                    FROM inserted i;
                END
 
                -- If there are deleted records
                IF EXISTS (SELECT * FROM deleted)
                BEGIN
                    INSERT INTO UserHistories (IdUser, Name, Lastname, Email, Password, Identification, UserType, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, d.Lastname, d.Email, d.Password, d.Identification, d.UserTypeId, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");
            



        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditUser;");
        }

       

    }
}

