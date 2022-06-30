using IKBasvuru.COMMON.Models;
using IKBasvuru.COMMON.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace IKBasvuru.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly COMMON.Services.IAuthenticationService _authService;
        private readonly LdapConfig _config;


        public AccountController(COMMON.Services.IAuthenticationService authService, IOptions<LdapConfig> configAccessor
)
        {
            _authService = authService;
            _config = configAccessor.Value;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {

            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = _authService.Login(model.Username, model.Password);

                    // If the user is authenticated, store its claims to cookie
                    if (user != null)
                    {
                        var userClaims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Username),
                            new Claim(ClaimTypes.Email, user.Email)
                        };

                        // Roles
                        foreach (var role in user.Roles)
                        {
                            userClaims.Add(new Claim(ClaimTypes.Role, role));
                        }

                        //we can add custom claims based on the AD user's groups
                        string authorizationRole = _config.AuthorizationRole;
                        var claimsIdentity = new ClaimsIdentity(userClaims, _authService.GetType().Name);
                        if (Array.Exists(user.Roles, s => s.Contains(authorizationRole)))
                        {
                            //if in the AD the user belongs to the aspnetcore.ldap group, we add a claim
                            claimsIdentity.AddClaim(new Claim("aspnetcore.ldap.user", "true"));
                        }

                        await HttpContext.SignInAsync(
                          CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            new AuthenticationProperties
                            {
                                IsPersistent = model.RememberMe
                            }
                        );

                        return Redirect(Url.IsLocalUrl(model.ReturnUrl)
                            ? model.ReturnUrl
                            : "/");
                    }

                    ModelState.AddModelError("", @"Your username or password is incorrect. Please try again.");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

        [HttpGet]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
