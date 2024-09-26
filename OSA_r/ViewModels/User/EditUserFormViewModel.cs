namespace OSA_r.ViewModels.User
{
    public class EditUserFormViewModel
    {
        public int UserId { get; set; }
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [StringLength(255)]
        public string Password { get; set; } = string.Empty;

        [StringLength(255)]
        public string Role { get; set; } = string.Empty;

        [StringLength(255)]
        public string FullName { get; set; } = string.Empty;

        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [StringLength(10)]
        public string Gender { get; set; } = string.Empty;

        [StringLength(20)]
        public string PhoneNumber { get; set; } = string.Empty;

        [StringLength(100)]
        public string Nationality { get; set; } = string.Empty;
    }
}
