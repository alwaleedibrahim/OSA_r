namespace OSA_r.Models
{

    [Table("Instructors")]
    public class Instructors
    {
        [Key]
        [Column("instructor_id")]
        public int InstructorId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users User { get; set; } = default!;

    }
}
