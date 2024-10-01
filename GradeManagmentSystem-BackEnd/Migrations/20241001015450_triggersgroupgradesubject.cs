using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class triggersgroupgradesubject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditGroup
            ON [Groups]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO GroupHistories (IdGroup, GroupName, Modified, ModifiedBy)
                    SELECT i.Id, i.GroupName,
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
                    INSERT INTO GroupHistories (IdGroup, GroupName, Modified, ModifiedBy)
                    SELECT d.Id, d.GroupName, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditGrade
            ON [Grades]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO GradeHistories (IdGrade, Value, Assigment, Student, Modified, ModifiedBy)
                    SELECT i.Id, i.Value, i.AssigmentId, i.StudentId,
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
                    INSERT INTO GradeHistories (IdGrade, Value, Assigment, Student, Modified, ModifiedBy)
                    SELECT d.Id, d.Value, d.AssigmentId, d.StudentId, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditSubject
            ON [Subjects]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO SubjectHistories (IdSubject, SubjectName, Description, Modified, ModifiedBy)
                    SELECT i.Id, i.SubjectName, i.Description,
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
                    INSERT INTO SubjectHistories (IdSubject, SubjectName, Description, Modified, ModifiedBy)
                    SELECT d.Id, d.SubjectName, d.Description, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditGroup;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditGrade;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditSubject;");
        }
    }
}
