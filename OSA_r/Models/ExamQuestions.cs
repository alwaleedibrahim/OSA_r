namespace OSA_r.Models
{
    [Table("Exam_Questions")]
    public class ExamQuestions
    {
        [Key]
        [Column("exam_id")]
        public int ExamId { get; set; }

        [Key]
        [Column("question_id")]
        public int QuestionId { get; set; }

        [ForeignKey("ExamId")]
        public Exams Exam { get; set; } = default!;

        [ForeignKey("QuestionId")]
        public Questions Question { get; set; } = default!;
    }
}
