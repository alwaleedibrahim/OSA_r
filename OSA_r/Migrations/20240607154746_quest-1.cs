using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OSA_r.Migrations
{
    /// <inheritdoc />
    public partial class quest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 1, "IPv6 uses ……… bits for specifying host address.a. 32     b. 48     c. 128   d.256", "CS", "Networks", 1, "c", "Internet", "Easy" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 2, "Which protocol is used to find the MAC address of a host from its known IP address? a. ARP     b. RARP     c. ICMP   d. IGMP", "CS", "Networks", 1, "a", "Protocols", "Medium" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 3, "What layer of the OSI model is responsible for end-to-end communication? a. Transport Layer     b. Network Layer     c. Data Link Layer   d. Physical Layer", "CS", "Networks", 1, "a", "OSI Model", "Hard" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 4, "Which of the following is a class A IP address? a. 192.168.0.1     b. 172.16.0.1     c. 10.0.0.1   d. 224.0.0.1", "CS", "Networks", 1, "c", "IP Addressing", "Easy" });
            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 10, "What does DNS stand for? a. Domain Name System     b. Dynamic Name System     c. Domain Name Service     d. Dynamic Name Service", "CS", "Networks", 1, "a", "Internet", "Easy" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 6, "Which protocol is used to send email? a. FTP     b. SMTP     c. HTTP     d. SSH", "CS", "Networks", 1, "b", "Internet", "Easy" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 7, "In networking, what is the primary function of DNS? a. Assign IP addresses   b. Map domain names to IP addresses   c. Route traffic   d. Encrypt data", "CS", "Networks", 1, "b", "DNS", "Medium" });


            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 8, "The application layer protocol of ………. is intentionally not available in the public domain because it is not specified in RFCs. a. skype    b. email    c. web   d.HTTP", "CS", "Networks", 1, "a", "Protocols", "Medium" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 9, "In networking, what is the primary function of DNS? a. Assign IP addresses   b. Map domain names to IP addresses   c. Route traffic   d. Encrypt data", "CS", "Networks", 1, "b", "DNS", "Medium" });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "question_id", "question_text", "category", "subject", "instructor_id", "correct_answer", "topic", "level" },
                values: new object[] { 5, "In networking, what is the primary function of DNS? a. Assign IP addresses   b. Map domain names to IP addresses   c. Route traffic   d. Encrypt data", "CS", "Networks", 1, "b", "DNS", "Medium" });
    }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
