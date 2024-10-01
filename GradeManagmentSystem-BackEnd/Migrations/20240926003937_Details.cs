using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class Details : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_userTypeHistories",
                table: "userTypeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userHistories",
                table: "userHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_teacherHistories",
                table: "teacherHistories");

            migrationBuilder.RenameTable(
                name: "userTypeHistories",
                newName: "UserTypeHistories");

            migrationBuilder.RenameTable(
                name: "userHistories",
                newName: "UserHistories");

            migrationBuilder.RenameTable(
                name: "teacherHistories",
                newName: "TeacherHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserTypeHistories",
                table: "UserTypeHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistories",
                table: "UserHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherHistories",
                table: "TeacherHistories",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserTypeHistories",
                table: "UserTypeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistories",
                table: "UserHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherHistories",
                table: "TeacherHistories");

            migrationBuilder.RenameTable(
                name: "UserTypeHistories",
                newName: "userTypeHistories");

            migrationBuilder.RenameTable(
                name: "UserHistories",
                newName: "userHistories");

            migrationBuilder.RenameTable(
                name: "TeacherHistories",
                newName: "teacherHistories");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userTypeHistories",
                table: "userTypeHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userHistories",
                table: "userHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_teacherHistories",
                table: "teacherHistories",
                column: "Id");
        }
    }
}
