using Microsoft.EntityFrameworkCore.Migrations;
using System.Net;

#nullable disable

namespace OSA_r.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "username", "password", "role", "full_name", "email", "gender", "phone_number", "nationality", "password_changed" },
                values: new object[] { 1, "admin", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", "administrator", "System Admin", "Admin@example.com", "Male", "111111111", "Egypt", "N" });

            migrationBuilder.InsertData(
                table: "Administrators",
                columns: new[] { "UserId", "admin_id" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "username", "password", "role", "full_name", "email", "gender", "phone_number", "nationality", "password_changed" },
                values: new object[] { 2, "student", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "student", "Ahmed Mohammed", "student@example.com", "Male", "01234567890", "Egypt", "N" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserId", "student_id" },
                values: new object[] { 2, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "username", "password", "role", "full_name", "email", "gender", "phone_number", "nationality", "password_changed" },
                values: new object[] { 3, "student2", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "student", "Ali Abdullah", "student2@example.com", "Male", "01001110000", "Egypt", "N" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "UserId", "student_id" },
                values: new object[] { 3, 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "user_id", "username", "password", "role", "full_name", "email", "gender", "phone_number", "nationality", "password_changed" },
                values: new object[] { 4, "instructor", "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4", "instructor", "Dr Ahmed Ahmed", "drahmed@example.com", "Male", "01001111111", "Egypt", "N" });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "UserId", "instructor_id" },
                values: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "exam_id", "exam_name", "exam_date", "instructor_id" },
                values: new object[] { 1, "Networks", "03-Jun-24 6:47:09 PM", 1 });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "exam_id", "exam_name", "exam_date", "instructor_id" },
                values: new object[] { 2, "Operating Systems", "06-Jun-24 6:47:09 PM", 1 });

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
