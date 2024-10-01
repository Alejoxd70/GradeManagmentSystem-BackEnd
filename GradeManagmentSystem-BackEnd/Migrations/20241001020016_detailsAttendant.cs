using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class detailsAttendant : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AttendantId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_AttendantId",
                table: "Students",
                column: "AttendantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Attendants_AttendantId",
                table: "Students",
                column: "AttendantId",
                principalTable: "Attendants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Attendants_AttendantId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_AttendantId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "AttendantId",
                table: "Students");
        }
    }
}
