using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class triggersUseTyPermissPermisUsTy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditPermission
            ON [Permissions]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO PermissionHistories (IdPermission, PermissionName, Modified, ModifiedBy)
                    SELECT i.Id, i.PermissionName,
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
                    INSERT INTO PermissionHistories (IdPermission, PermissionName, Modified, ModifiedBy)
                    SELECT d.Id, d.PermissionName, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditPermissionUserType
            ON [PermissionUserTypes]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO PermissionUserTypeHistories (IdPermissionUserType , UserType, Permission, Modified, ModifiedBy)
                    SELECT i.Id, i. UserTypeId, i.PermissionId, 
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
                    INSERT INTO PermissionUserTypeHistories (IdPermissionUserType, UserType, Permission, Modified, ModifiedBy)
                    SELECT d.Id, d.UserTypeId, d.PermissionId, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

            migrationBuilder.Sql(@"
            CREATE OR ALTER TRIGGER trg_AuditUserType
            ON [UserTypes]
            AFTER INSERT, UPDATE, DELETE
            AS
            BEGIN
                SET NOCOUNT ON;
                -- If there are inserted or updated records
                IF EXISTS (SELECT * FROM inserted)
                BEGIN
                    INSERT INTO UserTypeHistories (IdUserType, UserTypeName, Modified, ModifiedBy)
                    SELECT i.Id, i. UserTypeName,
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
                    INSERT INTO UserTypeHistories (IdUserType, UserTypeName, Modified, ModifiedBy)
                    SELECT d.Id, d.UserTypeName, GETDATE(), 'DELETE'
                          FROM deleted d;
                END
            END;
        ");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditPermission;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditPermissionUserType;");
            migrationBuilder.Sql("DROP TRIGGER IF EXISTS trg_AuditUserType;");
        }
    


    }
  
}
