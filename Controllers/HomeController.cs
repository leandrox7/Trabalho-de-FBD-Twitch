using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Twitch.Models;
using Pomelo.EntityFrameworkCore.MySql;
namespace Twitch.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private  Context _context;
        public HomeController(ILogger<HomeController> logger, [FromServices] Context context)
        {
           _logger = logger;
           _context = context;

        }

        public IActionResult Index()
        {
            var streamer =_context.CanalStreamer.First();
            ViewData["streamer"] = streamer;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
