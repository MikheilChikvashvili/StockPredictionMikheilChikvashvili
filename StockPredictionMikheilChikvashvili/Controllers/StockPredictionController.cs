using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StockPredictionMikheilChikvashviliML.Model;

namespace StockPredictionMikheilChikvashvili.Controllers
{
    public class StockPredictionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult StockPrediction()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StockPrediction(ModelInput input)
        {
            ViewBag.Result = "";
            var stockPredictions = ConsumeModel.Predict(input);
            ViewBag.Result = stockPredictions;

            ViewData["Open"] = input.Open;
            ViewData["Close"] = input.Close;
            return View();
        }
    }
}
