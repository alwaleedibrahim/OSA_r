namespace OSA_r.Services
{
    public interface IUsersService
    {
        IEnumerable<Users> GetAll();
        Users? GetById(int id);
        Task Create(CreateUserFormViewModel model);
        Task<Users?> Update(EditUserFormViewModel model);
        bool Delete(DeleteUserFormViewModel model);
        IEnumerable<Users> searchbyname(string searchval);
        string HashPassword(string password);
        Task<(Users? user, string? token)> Login(LoginFormViewModel model);
    }
}
