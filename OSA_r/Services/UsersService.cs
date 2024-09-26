using System.IdentityModel.Tokens.Jwt;
namespace OSA_r.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext _context;

        public UsersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Users> GetAll() 
        { 
            return _context.Users
                .ToList(); 
        }

        public Users? GetById(int id) 
        {
            return _context.Users
                .SingleOrDefault(u => u.UserId == id);
        }

        public async Task Create(CreateUserFormViewModel model)
        {

            Users user = new()
            {
                Username = model.Username,
                Password = HashPassword(model.Password),
                Role = model.Role,
                FullName = model.FullName,
                Email = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                Nationality = model.Nationality
            };

            _context.Add(user);
            _context.SaveChanges();
            
            switch(user.Role) 
            {
                case "administrator":
                    Administrators administrator = new()
                    {
                        UserId = user.UserId,
                    };
                    _context.Add(administrator);
                    _context.SaveChanges();
                    break;

                case "instructor":
                    Instructors instructor = new()
                    {
                        UserId = user.UserId
                    };
                    _context.Add(instructor);
                    _context.SaveChanges();
                    break;
                case "student":
                    Students student = new()
                    {
                        UserId = user.UserId
                    };
                    _context.Add(student);
                    _context.SaveChanges();
                    break;
            };
        }

        public async Task<Users?> Update(EditUserFormViewModel model)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.UserId == model.UserId);

            if (user is null)
                return null;


            user.Username = model.Username;
            user.Password = HashPassword(model.Password);
            user.Role = model.Role;
            user.FullName = model.FullName;
            user.Email = model.Email;
            user.Gender = model.Gender;
            user.PhoneNumber = model.PhoneNumber;
            user.Nationality = model.Nationality;

            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public bool Delete(DeleteUserFormViewModel model)
        {
            var isDeleted = false;

            var user = _context.Users
                .SingleOrDefault(u => u.UserId == model.UserId);

            if (user is null)
                return isDeleted;

            _context.Remove(user);
            var effectedRows = _context.SaveChanges();

            if (effectedRows > 0)
            {
                isDeleted = true;
            }

            return isDeleted;
        }

        public IEnumerable<Users> searchbyname(string searchval)
        {
            var data = _context.Users.Where(x => x.FullName.Contains(searchval)).ToList();
            return data;

        }

        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var pwdBytes = Encoding.UTF8.GetBytes(password);
                var hashBytes = sha256.ComputeHash(pwdBytes);
                var hashBuilder = new StringBuilder(hashBytes.Length * 2);

                foreach (byte b in hashBytes)
                {
                    hashBuilder.Append(b.ToString("x2"));
                }

                return hashBuilder.ToString();
            }
        }

        public async Task<(Users? user, string? token)> Login(LoginFormViewModel model)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.Username == model.Username
                                   && u.Password == HashPassword(model.Password));

            if (user != null)
            {
                int? RoleBasedId = GetRoleBasedId(user.UserId);
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, "" + user.UserId),
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(ClaimTypes.PrimaryGroupSid, "" + RoleBasedId.Value)
                };
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@830superSecretKey@830superSecretKey@830"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "Issuer",
                    audience: "Audience",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return (user, tokenString);
            }
            return (null, null);
        }

        public int? GetRoleBasedId(int id)
        {
            var user = _context.Users
                .SingleOrDefault(u => u.UserId == id);
            if (user != null)
            {
                switch (user.Role)
                {
                    case "administrator":
                        var admin = _context.Administrators
                .SingleOrDefault(a => a.UserId == user.UserId);
                        return admin.AdminId;

                    case "instructor":
                        var instructor = _context.Instructors
                .SingleOrDefault(i => i.UserId == user.UserId);
                        return instructor.InstructorId;

                    case "student":
                        var student = _context.Students
                .SingleOrDefault(s => s.UserId == user.UserId);
                        return student.StudentId;
                }
                return id;

            }
            return null;
        }

    }
}
