using GradeManagmentSystem_BackEnd.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections.Generic;
using System.Diagnostics.Metrics;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class addTriggersStudAttTeach : Migration
    {
        
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /// <inheritdoc />
            /// Trigger Student
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditStudent
            ON[Students]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
            --If there are inserted or updated records
                IF EXISTS(SELECT* FROM inserted)
                BEGIN
                    INSERT INTO StudentHistories(IdStudent, Student_code, [User], Attendant, Modified, ModifiedBy)
                    SELECT i.Id, i.Student_code, i.UserId, i.AttendantId,
                        GETDATE(),
                           CASE
                               WHEN EXISTS(SELECT * FROM deleted) THEN 'UPDATE'
                               ELSE 'INSERT'
                           END
                    FROM inserted i;
            END

            -- If there are deleted records
            IF EXISTS(SELECT * FROM deleted)
                BEGIN
                    INSERT INTO StudentHistories(IdStudent, Student_code, [User], Attendant, Modified, ModifiedBy)
                    SELECT d.Id, d.Student_code, d.UserId, d.AttendantId, GETDATE(), 'DELETE'
                          FROM deleted d;
            END
        END;
            ");

            //Trigger Attendant
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditAttendant
            ON [Attendants]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO AttendantHistories (IdAttendant, Name, LastName, Relationship, Modified, ModifiedBy)
                    SELECT i.Id, i.Name, i.LastName, i.Relationship,
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
                    INSERT INTO AttendantHistories (IdAttendant, Name, LastName, Relationship, Modified, ModifiedBy)
                    SELECT d.Id, d.Name, d.LastName, d.Relationship, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");


            //Trigger SubjectTeacher
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditTeacher
            ON [Teachers]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO TeacherHistories (IdTeacher, [User], Specialization, Modified, ModifiedBy)
                    SELECT i.Id, i.UserId, i.Specialization,
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
                    INSERT INTO TeacherHistories (IdTeacher, [User], Specialization, Modified, ModifiedBy)
                    SELECT d.Id, d.UserId, d.Specialization, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditStudent;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditAttendant;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditTeacher;");
        }
    }
}
