﻿using Microsoft.AspNet.Mvc;

namespace AuthorizationServer.UI.Home
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
