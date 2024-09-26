namespace OSA_r.ViewModels.User
{
    public class LoginFormViewModel
    {
        public int UserId { get; set; }
        [StringLength(255)]
        public string Username { get; set; } = string.Empty;

        [StringLength(255)]
        public string Password { get; set; } = string.Empty;
    }
}
