using eTickets.DataAccess.Data;
using eTickets.Models.Models.User;
using eTickets.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _applicationDbContext;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager,
                                 ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Login()
        {
            var response = new LoginVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginvm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginvm);
            }

            var user = await _userManager.FindByEmailAsync(loginvm.EmailAddress);
            if (user == null)
            {
                var passwordValid = await _userManager.CheckPasswordAsync(user, loginvm.Password);
                if (passwordValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginvm.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Movies", "Movie");
                    }
                }
                TempData["Error"] = "Wrong Credentials Please try again!";

                return View(loginvm);
            }

            TempData["Error"] = "Wrong Credentials Please try again!";

            return View(loginvm);
        }
    }
}
