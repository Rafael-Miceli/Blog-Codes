using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Thinktecture.IdentityModel.Clients;

namespace WebApp_AuthCode.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult RefreshAccessToken()
        {
            var claimsPrincipal = User as ClaimsPrincipal;

            //client para fazr request do Novo token com o refresh_toke atual
            var client = new OAuth2Client(new Uri("http://localhost:54734/connect/token"),
                "teste_code", "secret");

            var requestResponse = client.RequestAccessTokenRefreshToken(
                claimsPrincipal.FindFirst("refresh_token").Value);

            //Usar AuthenticationManager para substituir antigo access_token pelo novo access_token
            var manager = HttpContext.GetOwinContext().Authentication;

            var refreshedIdentity = new ClaimsIdentity(User.Identity);

            refreshedIdentity.RemoveClaim(refreshedIdentity.FindFirst("access_token"));
            refreshedIdentity.RemoveClaim(refreshedIdentity.FindFirst("refresh_token"));

            refreshedIdentity.AddClaim(new Claim("access_token",
                requestResponse.AccessToken));

            refreshedIdentity.AddClaim(new Claim("refresh_token",
                requestResponse.RefreshToken));

            //Atualizar o Cookie
            manager.AuthenticationResponseGrant =
                new AuthenticationResponseGrant(new ClaimsPrincipal(refreshedIdentity),
                new AuthenticationProperties { IsPersistent = true });

            return Redirect("Homex/Index");
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}