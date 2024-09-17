using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class updatetables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBirth",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "UserTypeRequired",
                table: "UserTypes",
                newName: "UserTypeName");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Users",
                newName: "Identification");

            migrationBuilder.RenameColumn(
                name: "PermissionRequired",
                table: "Permissions",
                newName: "PermissionName");

            migrationBuilder.RenameColumn(
                name: "Groupname",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Attendants",
                newName: "Relationship");

            migrationBuilder.AddColumn<string>(
                name: "Student_code",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "GroupYears",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GroupYears_GroupId",
                table: "GroupYears",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_GroupYears_Groups_GroupId",
                table: "GroupYears",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GroupYears_Groups_GroupId",
                table: "GroupYears");

            migrationBuilder.DropIndex(
                name: "IX_GroupYears_GroupId",
                table: "GroupYears");

            migrationBuilder.DropColumn(
                name: "Student_code",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "GroupYears");

            migrationBuilder.RenameColumn(
                name: "UserTypeName",
                table: "UserTypes",
                newName: "UserTypeRequired");

            migrationBuilder.RenameColumn(
                name: "Identification",
                table: "Users",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "PermissionName",
                table: "Permissions",
                newName: "PermissionRequired");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "Groupname");

            migrationBuilder.RenameColumn(
                name: "Relationship",
                table: "Attendants",
                newName: "Email");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DateBirth",
                table: "Users",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }
    }
}
