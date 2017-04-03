using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Asp.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/SignIn
        public async Task SignIn()
        {
            if (HttpContext.User == null || !HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.Authentication.ChallengeAsync(
                    OpenIdConnectDefaults.AuthenticationScheme,
                    new AuthenticationProperties {RedirectUri = "/"});
            }
        }

        // GET: /Account/SignOut
        [HttpGet]
        public async Task SignOut()
        {
            if (HttpContext.User != null && HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.Authentication.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);
                await HttpContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, 
                    new AuthenticationProperties { RedirectUri = "/" });
            }
        }
    }
}
