using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InMemDb.Data;
using InMemDb.Models;
using Microsoft.AspNetCore.Mvc;

namespace InMemDb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public string CreateClient(Client client)
        {
            if(_context.Clients.FirstOrDefault(c => c.Cnpj == client.Cnpj) != null)
                return "Cnpj já existe!";

            _context.Add(client);
            _context.SaveChanges();

            return "Funfou";            
        }
    }
}
