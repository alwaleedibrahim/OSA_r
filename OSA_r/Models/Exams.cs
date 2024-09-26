namespace OSA_r.Models
{
    [Table("Exams")]
    public class Exams
    {
        [Key]
        [Column("exam_id")]
        public int ExamId { get; set; }

        [Column("exam_name")]
        [StringLength(255)]
        public string ExamName { get; set; } = string.Empty;

        [Column("exam_date")]
        public DateTime ExamDate { get; set; }

        [Column("instructor_id")]
        [ForeignKey("InstructorId")]
        public int InstructorId { get; set; }
        public Instructors Instructor { get; set; } = default!;

        public ICollection<ExamQuestions> ExamQuestions { get; set; } = new List<ExamQuestions>();
        public ICollection<ExamResults> ExamResults { get; set; } = new List<ExamResults>();

    }
}
