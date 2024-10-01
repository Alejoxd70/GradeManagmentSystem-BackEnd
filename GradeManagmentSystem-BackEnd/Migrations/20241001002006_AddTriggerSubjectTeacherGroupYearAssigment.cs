using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddTriggerSubjectTeacherGroupYearAssigment : Migration
    {
        //// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// <inheritdoc />
            //Trigger Assigment
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditAssigment
            ON [Assigments]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO AssigmentHistories (IdAssigment, Name, Description, Date, SubjectTeacher, Modified, ModifiedBy)
                    SELECT i.Id, i.Name, i.Description, i.Date, i.SubjectTeacherId,
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
                    INSERT INTO AssigmentHistories (IdAssigment, Name, Description, Date, SubjectTeacher, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, d.Description, d.Date, d.SubjectTeacherId, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            //Trigger GroupYear
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditGroupYear
            ON [GroupYears]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO GroupYearHistories (IdGroupYear, Year, Student, [Group], Modified, ModifiedBy)
                    SELECT i.Id, i.Year, i.StudentId, i.[GroupId],
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
                    INSERT INTO GroupYearHistories (IdGroupYear, Year, Student, [Group], Modified, ModifiedBy)
                    SELECT d.Id, d.Year, d.StudentId, d.[GroupId], GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");


            //Trigger SubjectTeacher
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditSubjectTeacher
            ON [SubjectTeachers]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO SubjectTeacherHistories (IdSubjectTeacher, Teacher, Subject, GroupYear, Modified, ModifiedBy)
                    SELECT i.Id, i.TeacherId, i.SubjectId, i.GroupYearId,
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
                    INSERT INTO SubjectTeacherHistories (IdSubjectTeacher, Teacher, Subject, GroupYear, Modified, ModifiedBy)
                    SELECT d.Id, d.TeacherId,d.SubjectId, d.GroupYearId, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");
        }
        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditAssigment;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditGroupYear;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditSubjectTeacher;");
        }
    }

}

