using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppSpotifyConsumer.Models;

namespace WebAppSpotifyConsumer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.AuthUri = GetAuthUri();

            return View();
        }

        public ActionResult AuthResponse(string access_token, string token_type, string expires_in, string state)
        {
            return View();
        }

        private string GetAuthUri()
        {
            string clientId = "Your-Client-Id";
            string redirectUri = "http://localhost:17788/Home/AuthResponse";
            Scope scope = Scope.PLAYLIST_MODIFY_PRIVATE;

            return "https://accounts.spotify.com/en/authorize?client_id=" + clientId +
                "&response_type=token&redirect_uri=" + redirectUri +
                "&state=&scope=" + scope.GetStringAttribute(" ") +
                "&show_dialog=true";
        }
    }
}