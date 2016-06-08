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
            //if (User.Identity.IsAuthenticated)
            //{
            //    return View();
            //}

            //var url = "http://localhost:54734/connect/authorize" +
            //    "?client_id=teste_code" +
            //    "&redirect_uri=http://localhost:60758/Home/AuthCallBack" +
            //    "&response_type=code" +
            //    "&scope=openid+profile" +
            //    "&response_mode=form_post";

            return View();

        }

        public ActionResult AuthCallBack(string code, string state, string error)
        {
            var tokenUrl = "http://localhost:54734/connect/token";

            var client = new OAuth2Client(new Uri(tokenUrl), "teste_code", "secret");

            var requestResult = client.RequestAccessTokenCode(code, new Uri("http://localhost:60758/Home/AuthCallBack"));

            var claims = new[]
            {
                new Claim("access_token", requestResult.AccessToken)
            };

            var identity = new ClaimsIdentity(claims, "cookies");
           
            Request.GetOwinContext().Authentication.SignIn(identity); 

            return Redirect("/");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}