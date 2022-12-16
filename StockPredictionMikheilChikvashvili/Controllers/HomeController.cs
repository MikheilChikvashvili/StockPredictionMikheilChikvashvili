using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockPredictionMikheilChikvashvili.Models;
using StockPredictionMikheilChikvashviliML.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using WebMatrix.Data;

namespace StockPredictionMikheilChikvashvili.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlConnection con = new SqlConnection();
        SqlDataReader dr;
        List<ModelInput> stocks = new List<ModelInput>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            con.ConnectionString = StockPredictionMikheilChikvashvili.Properties.Resources.ConnectionString;
            _logger = logger;
        }

        public IActionResult Index()
        {
            //FetchData();
            return View();
        }

        public IActionResult Privacy()
        {
            return View(stocks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
