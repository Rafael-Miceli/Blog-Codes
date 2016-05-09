using IdentityServer4.Core;
using IdentityServer4.Core.Models;
using IdentityServer4.Core.Services;
using Microsoft.AspNet.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AuthorizationServer.Configuration;

namespace IdSvrHost.UI.Logout
{
    public class LogoutController : Controller
    {
        private readonly SignOutInteraction _signOutInteraction;

        public LogoutController(SignOutInteraction signOutInteraction)
        {
            _signOutInteraction = signOutInteraction;
        }

        [HttpGet(Constants.RoutePaths.Logout, Name = "Logout")]
        public IActionResult Index(string id)
        {
            return View(new LogoutViewModel { SignOutId = id });
        }

        [HttpPost(Constants.RoutePaths.Logout)]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Submit(string signOutId)
        {
            await HttpContext.Authentication.SignOutAsync(Constants.PrimaryAuthenticationType);

            HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity());

            var vm = new LoggedOutViewModel();
            
            vm.ReturnInfo = GetClientReturnInfo(signOutId);
            
            return Redirect(vm.ReturnInfo.Uri);
        }
        
        private ClientReturnInfo GetClientReturnInfo(string signOutId)
        {
            var client = Clients.Get().FirstOrDefault(c => c.ClientId == signOutId);

            var clientReturnInfo = new ClientReturnInfo
            {
                ClientId = client.ClientId,
                Uri = client.PostLogoutRedirectUris.First() 
            };

            return clientReturnInfo;
        }
    }
}
