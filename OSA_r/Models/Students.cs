namespace OSA_r.Models
{
    [Table("Students")]
    public class Students
    {
        [Key]
        [Column("student_id")]
        public int StudentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users User { get; set; } = default!;
        public ICollection<ExamResults> ExamResults { get; set; } = new List<ExamResults>();

        public ICollection<Answers> Answers { get; set; } = new List<Answers>();
    }
}
