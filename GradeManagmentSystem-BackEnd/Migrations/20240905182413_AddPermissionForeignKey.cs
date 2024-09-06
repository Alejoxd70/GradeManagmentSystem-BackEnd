using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class AddPermissionForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PermissionId",
                table: "PermissionUserType",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PermissionUserType_PermissionId",
                table: "PermissionUserType",
                column: "PermissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_PermissionUserType_Permission_PermissionId",
                table: "PermissionUserType",
                column: "PermissionId",
                principalTable: "Permission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PermissionUserType_Permission_PermissionId",
                table: "PermissionUserType");

            migrationBuilder.DropIndex(
                name: "IX_PermissionUserType_PermissionId",
                table: "PermissionUserType");

            migrationBuilder.DropColumn(
                name: "PermissionId",
                table: "PermissionUserType");
        }
    }
}
