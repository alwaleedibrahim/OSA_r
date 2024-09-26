namespace OSA_r.Models
{
  
    [Table("Users")]
    public class Users 
    {
        [Key]
        [Column("user_id")]
        public int UserId { get; set; }

        [Column("username")]
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [Column("password")]
        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [Column("role")]
        [StringLength(255)]
        public string Role { get; set; } = string.Empty;

        [Column("full_name")]
        [StringLength(255)]
        public string FullName { get; set; } = string.Empty;

        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [Column("gender")]
        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;

        [Column("phone_number")]
        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("nationality")]
        [StringLength(100)]
        public string Nationality { get; set; } = string.Empty;

        [Column("password_changed")]
        public char PasswordChanged { get; set; }

        // Navigation properties for generalization relationship
        public virtual Administrators Administrator { get; set; } = default!;
        public virtual Instructors Instructor { get; set; } = default!;
        public virtual Students Student { get; set; } = default!;
    }
}
