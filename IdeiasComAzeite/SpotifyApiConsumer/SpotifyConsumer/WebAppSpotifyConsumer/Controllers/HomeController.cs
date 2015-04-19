﻿using System.Web.Mvc;
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
            if (string.IsNullOrEmpty(access_token))
                return View();

            SpotifyService spotifyService = new SpotifyService();

            SpotifyUser spotifyUser = spotifyService.GetUserProfile(access_token);

            Playlists playlists = spotifyService.GetPlaylists(spotifyUser.UserId, access_token);

            ViewBag.Playlists = playlists;

            return View();
        }

        private string GetAuthUri()
        {
            string clientId = "939de55142e64b519923e66738e3a602";
            string redirectUri = "http://localhost:17789/Home/AuthResponse";
            Scope scope = Scope.PLAYLIST_MODIFY_PRIVATE;

            return "https://accounts.spotify.com/en/authorize?client_id=" + clientId +
                "&response_type=token&redirect_uri=" + redirectUri +
                "&state=&scope=" + scope.GetStringAttribute(" ") +
                "&show_dialog=true";
        }
    }
}