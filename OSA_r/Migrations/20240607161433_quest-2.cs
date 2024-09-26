using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSA_r.Migrations
{
    /// <inheritdoc />
    public partial class quest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 11, "Which of the following is a characteristic of a monolithic kernel? a. It runs as a single process in kernel mode    b. It has a microkernel architecture    c. It runs all processes in user mode   d. It uses message passing for IPC", "CS", "Operating Systems", 1, "a", "Kernel", "Medium" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 12, "In operating systems, what is the purpose of a scheduler? a. Manage file storage    b. Manage network connections    c. Allocate CPU time to processes   d. Manage memory allocation", "CS", "Operating Systems", 1, "c", "Scheduling", "Easy" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 13, "What is the primary function of a system call in an operating system? a. Perform arithmetic operations    b. Provide an interface between the process and the kernel    c. Manage hardware devices   d. Compile programs", "CS", "Operating Systems", 1, "b", "System Calls", "Easy" });

            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id","question_id"},
                    values: new object[] { 2,  11});

            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 2, 12 });

            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 2, 13 });

            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 2 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 3 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 4 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 5 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 6 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 7 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 8 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 9 });
            migrationBuilder.InsertData(
                    table: "Exam_Questions",
                    columns: new[] { "exam_id", "question_id" },
                    values: new object[] { 1, 10 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
