namespace OSA_r.ViewModels.User
{
    public class ViewUsersViewModel
    {
        public int UserId { get; set; }
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [StringLength(255)]
        public string Email { get; set; } = string.Empty;

        [StringLength(255)]
        public string Role { get; set; } = string.Empty;
    }
}
