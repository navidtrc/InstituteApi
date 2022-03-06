using Microsoft.EntityFrameworkCore.Migrations;

namespace InstituteApi.Migrations
{
    public partial class studentCourseIndexColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId_CourseId",
                table: "StudentCourse",
                columns: new[] { "StudentId", "CourseId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StudentCourse_StudentId_CourseId",
                table: "StudentCourse");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourse_StudentId",
                table: "StudentCourse",
                column: "StudentId");
        }
    }
}
