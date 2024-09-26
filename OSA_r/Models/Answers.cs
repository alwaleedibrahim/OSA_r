namespace OSA_r.Models
{
    [Table("Answers")]
    public class Answers
    {
        [Key]
        [Column("answer_id")]
        public int AnswerId { get; set; }

        [Column("student_id")]
        public int StudentId { get; set; }

        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("answer_text")]
        [StringLength(1)]
        public string AnswerText { get; set; } = string.Empty;

        [ForeignKey("StudentId")]
        public Students Student { get; set; } = default!;

        [ForeignKey("QuestionId")]
        public Questions Question { get; set; } = default!;
    }
}
