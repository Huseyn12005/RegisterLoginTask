using Microsoft.AspNetCore.Mvc;
using RegisterLoginTask.FluentValidations;
using RegisterLoginTask.Models;
using RegisterLoginTask.Services;

namespace RegisterLoginTask.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model) 
        { 
            if (ModelState.IsValid)
            {
                Database.Users.Add(new User
                {
                    Email = model.Email,
                    Password = model.Password

                });
                return RedirectToAction("Login");
            }
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            var validator = new LoginViewModelValidator();
            var results = validator.Validate(model);

            if(results.IsValid)
            {
                var user = Database.Users.FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }

             
            }
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return View(model);
        }
    }
}
