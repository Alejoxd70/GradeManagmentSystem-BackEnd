using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GradeManagmentSystem_BackEnd.Migrations
{
    /// <inheritdoc />
    public partial class add_group_grades_subject_repositories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
                //name: "FK_Assigment_SubjectTeacher_SubjectTeacherId",
                //table: "Assigment");

            /*migrationBuilder.DropForeignKey(
                name: "FK_Grade_Assigment_AssigmentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Students_StudentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_GroupYears_GroupYearId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grade",
                table: "Grade");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assigment",
                table: "Assigment");

            migrationBuilder.RenameTable(
                name: "SubjectTeacher",
                newName: "SubjectTeachers");

            migrationBuilder.RenameTable(
                name: "Grade",
                newName: "Grades");

            migrationBuilder.RenameTable(
                name: "Assigment",
                newName: "Assigments");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_TeacherId",
                table: "SubjectTeachers",
                newName: "IX_SubjectTeachers_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_SubjectId",
                table: "SubjectTeachers",
                newName: "IX_SubjectTeachers_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeacher_GroupYearId",
                table: "SubjectTeachers",
                newName: "IX_SubjectTeachers_GroupYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_StudentId",
                table: "Grades",
                newName: "IX_Grades_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grade_AssigmentId",
                table: "Grades",
                newName: "IX_Grades_AssigmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Assigment_SubjectTeacherId",
                table: "Assigments",
                newName: "IX_Assigments_SubjectTeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeachers",
                table: "SubjectTeachers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grades",
                table: "Grades",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assigments",
                table: "Assigments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assigments_SubjectTeachers_SubjectTeacherId",
                table: "Assigments",
                column: "SubjectTeacherId",
                principalTable: "SubjectTeachers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Assigments_AssigmentId",
                table: "Grades",
                column: "AssigmentId",
                principalTable: "Assigments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_GroupYears_GroupYearId",
                table: "SubjectTeachers",
                column: "GroupYearId",
                principalTable: "GroupYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_Subjects_SubjectId",
                table: "SubjectTeachers",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeachers_Teachers_TeacherId",
                table: "SubjectTeachers",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Assigments_SubjectTeachers_SubjectTeacherId",
                table: "Assigments");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Assigments_AssigmentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Students_StudentId",
                table: "Grades");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_GroupYears_GroupYearId",
                table: "SubjectTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_Subjects_SubjectId",
                table: "SubjectTeachers");

            migrationBuilder.DropForeignKey(
                name: "FK_SubjectTeachers_Teachers_TeacherId",
                table: "SubjectTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubjectTeachers",
                table: "SubjectTeachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Grades",
                table: "Grades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Assigments",
                table: "Assigments");

            migrationBuilder.RenameTable(
                name: "SubjectTeachers",
                newName: "SubjectTeacher");

            migrationBuilder.RenameTable(
                name: "Grades",
                newName: "Grade");

            migrationBuilder.RenameTable(
                name: "Assigments",
                newName: "Assigment");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeachers_TeacherId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_TeacherId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeachers_SubjectId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_SubjectTeachers_GroupYearId",
                table: "SubjectTeacher",
                newName: "IX_SubjectTeacher_GroupYearId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_StudentId",
                table: "Grade",
                newName: "IX_Grade_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_AssigmentId",
                table: "Grade",
                newName: "IX_Grade_AssigmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Assigments_SubjectTeacherId",
                table: "Assigment",
                newName: "IX_Assigment_SubjectTeacherId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubjectTeacher",
                table: "SubjectTeacher",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Grade",
                table: "Grade",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Assigment",
                table: "Assigment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Assigment_SubjectTeacher_SubjectTeacherId",
                table: "Assigment",
                column: "SubjectTeacherId",
                principalTable: "SubjectTeacher",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Assigment_AssigmentId",
                table: "Grade",
                column: "AssigmentId",
                principalTable: "Assigment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Students_StudentId",
                table: "Grade",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_GroupYears_GroupYearId",
                table: "SubjectTeacher",
                column: "GroupYearId",
                principalTable: "GroupYears",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Subjects_SubjectId",
                table: "SubjectTeacher",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubjectTeacher_Teachers_TeacherId",
                table: "SubjectTeacher",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id");
        }
    }
}
