using Application.Contracts;
using Application.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI.Constants;
using WebUI.Extensions;
using WebUI.Models;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return LocalRedirect(returnUrl ?? "/");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            UserDTO user = await _authService.LoginAsync(model.Username, model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, ValidationMessages.UsernameOrPasswordIsWrong);
                return View(model);
            }

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                      new ClaimsPrincipal(CookieAuthenticationExtensions.SignIn(user)));

            return Redirect("/");

        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return Redirect("/Auth/Login?ReturnUrl=%2F");
        }
    }
}
