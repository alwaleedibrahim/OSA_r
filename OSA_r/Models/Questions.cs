namespace OSA_r.Models
{
    [Table("Questions")]
    public class Questions
    {
        [Key]
        [Column("question_id")]
        public int QuestionId { get; set; }

        [Column("question_text")]
        public string QuestionText { get; set; } = string.Empty;

        [Column("category")]
        [StringLength(255)]
        public string Category { get; set; } = string.Empty;
        [Column("subject")]
        [StringLength(255)]
        public string Subject { get; set; } = string.Empty;

        [Column("instructor_id")]
        public int InstructorId { get; set; }

        [Column("correct_answer")]
        [StringLength(1)]
        public string CorrectAnswer { get; set; } = string.Empty;

        [Column("topic")]
        public string Topic { get; set; } = string.Empty;

        [Column("level")]
        [StringLength(50)]
        public string Level { get; set; } = string.Empty;

        [ForeignKey("InstructorId")]
        public Instructors Instructor { get; set; } = default!;

        public ICollection<ExamQuestions> ExamQuestions { get; set; } = new List<ExamQuestions>();

    }
}
