namespace OSA_r.Models
{

    [Table("Administrators")]
    public class Administrators
    {
        [Key]
        [Column("admin_id")]
        public int AdminId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual Users User { get; set; } = default!;
    }
}
