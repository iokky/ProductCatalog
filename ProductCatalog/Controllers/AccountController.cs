using Microsoft.AspNetCore.Mvc;
using ProductCatalog.Dal.Repository;
using ProductCatalog.Domain.Entity;
using ProductCatalog.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

namespace ProductCatalog.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserRepository _repository;
        public AccountController(UserRepository repository)
        {
            _repository = repository;
        }
        [Route("/login")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [Route("/login")]
        // POST: AccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IResult> Login(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                User? user = _repository.GetUser(login);
                if (user != null)
                {
                    var claims = new List<Claim> { new Claim(ClaimTypes.Name, login.Email) };
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity));

                    return Results.Redirect("/");
                    
                }
            }
            return Results.Unauthorized();
        }

        [Route("/logout")]
        [HttpGet]
        public async Task<IResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Results.Redirect("/login");
        }

    }
}
