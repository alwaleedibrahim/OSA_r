namespace OSA_r.Controllers
{
    public class UserController : Controller
    {
        private readonly IUsersService _usersService;

        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet]
        public IActionResult Login(string Msg)
        {
            ViewData["Msg"] = Msg;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var (user, token) = await _usersService.Login(model);

            if (user != null && token != null)
            {
                HttpContext.Response.Cookies.Append("JWTToken", token, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTimeOffset.Now.AddMinutes(10)
                });

                return RedirectToAction("Index", "Home");

            }

            return RedirectToAction("Login", "User", new { Msg = "Invalid username or password" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Logout()
        {
            // Remove the JWTToken cookie
            HttpContext.Response.Cookies.Delete("JWTToken");

            // Redirect to the login page
            return RedirectToAction("Login", "User");
        }

        [Authorize(Policy = "Administrator")]

        public IActionResult Index(string searchval)
        {
            if (searchval == null)
            {
                var users = _usersService.GetAll();
                return View(users);
            }
            else
            {
                var users = _usersService.searchbyname(searchval);
                return View(users);
            }
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet]
        public IActionResult Create()
        {
            CreateUserFormViewModel viewModel = new();
            return View(viewModel);
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet]
        public IActionResult Update(int id)
        {
            var user = _usersService.GetById(id);

            if (user is null)
                return NotFound();

            EditUserFormViewModel viewModel = new()
            {
                UserId = user.UserId,
                Username = user.Username,
                Password = user.Password,
                Role = user.Role,
                FullName = user.FullName,
                Email = user.Email,
                Gender = user.Gender,
                PhoneNumber = user.PhoneNumber,
                Nationality = user.Nationality
            };

            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Details(int id)
        {
            var user = _usersService.GetById(id);

            if (user is null)
                return NotFound();

            return View(user);
        }

        [Authorize(Policy = "Administrator")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var user = _usersService.GetById(id);

            if (user is null)
                return NotFound();

            DeleteUserFormViewModel viewModel = new()
            {
                UserId = user.UserId,
                Username = user.Username,
                Role = user.Role,
                Email = user.Email,
            };

            return View(viewModel);
        }

        [Authorize(Policy = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> create(CreateUserFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _usersService.Create(model);

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Update(EditUserFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                return View(model);
            }

            var user = await _usersService.Update(model);

            if (user is null)
                return BadRequest();

            return RedirectToAction(nameof(Index));
        }

        [Authorize(Policy = "Administrator")]
        [HttpPost]
        public IActionResult Delete(DeleteUserFormViewModel model)
        {
            var isDeleted = _usersService.Delete(model);

            if (isDeleted)
            {
                return RedirectToAction(nameof(Index)); 
            }
            else
            {
                return BadRequest("Failed to delete the user.");  
            }
        }

    }
}
