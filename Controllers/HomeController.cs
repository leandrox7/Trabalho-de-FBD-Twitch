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
using MySql.Data.MySqlClient;
using System.Data;

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

            MySqlConnection conexao = new MySqlConnection("Server=localhost;DataBase=Twitch;Uid=root;Pwd=1234");
            MySqlCommand comando = new MySqlCommand("SELECT * FROM PRODUTOS", conexao);
            DataTable tabela = new DataTable();
            try
            {
                conexao.Open();

                comando.CommandText = "SELECT  cod_item FROM items ORDER BY cod_item DESC";

                MySqlDataReader dr = comando.ExecuteReader();
                dr.Read();
                string cod_item = dr["cod_item"].ToString();
            }

            catch(Exception ex)
            {

            }



            var streamer =_context.Canalstreamer.First();
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
