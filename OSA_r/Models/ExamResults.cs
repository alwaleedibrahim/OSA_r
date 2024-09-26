namespace OSA_r.Models
{

    [Table("Exam_Results")]
    public class ExamResults
    {
        [Key]
        [Column("result_id")]
        public int ResultId { get; set; }

        [Column("exam_id")]
        public int ExamId { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("score")]
        public decimal Score { get; set; }

        [Column("completion_time")]
        public DateTime CompletionTime { get; set; }

        [ForeignKey("ExamId")]
        public Exams Exam { get; set; } = default!;

        [ForeignKey("StudentId")]
        public Students Student { get; set; } = default!;
    }
}
