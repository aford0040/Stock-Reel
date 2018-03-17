using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Stock_Reel.Models;
using Stock_Reel.Services;

namespace Stock_Reel.Controllers
{
    public class HomeController : Controller
    {
        private StockServices Service { get; }

        public HomeController(StockServices service)
        {
            Service = service;
        }

        /// <summary>
        /// Entrance to the app
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            // check to see if they've any stocks picked
            var cookieString = Request.Cookies["KnownStocks"];

            // if the cookie's null, dont populate the input model
            if (string.IsNullOrWhiteSpace(cookieString))
                return View(new StockInputModel());
            else
                return View(new StockInputModel(cookieString));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(StockInputModel model)
        {
            List<string> stocks = JsonConvert.DeserializeObject<List<string>>(Request.Cookies["KnownStocks"]);

            return RedirectToAction("Index");

        }
    }
}
