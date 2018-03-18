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
        #region Properties
        /// <summary>
        /// The service that makes stock calls
        /// </summary>
        private StockServices Service { get; }

        #endregion

        #region Constructors
        public HomeController(StockServices service)
        {
            Service = service;
        }

        #endregion

        #region Actions
        /// <summary>
        /// Entrance to the app
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Index()
        {
            // check to see if they've any stocks picked
            var cookieString = Request.Cookies["KnownStocks"];

            // if the cookie is null, give them a blank cookie
            if (cookieString == null)
                Response.Cookies.Append("KnownStocks", 
                                        JsonConvert.SerializeObject(new List<string>()), 
                                        new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddDays(10) });

            // if the cookie's null, dont populate the input model
            if (string.IsNullOrWhiteSpace(cookieString))
                return View(new StockInputModel());
            else
                return View(new StockInputModel(cookieString));
        }

        /// <summary>
        /// Posting a 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult Index(StockInputModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // get the known stocks
            var wantedStocks = Service.GetCookieStocks(Request.Cookies["KnownStocks"]);

            // add it to the list
            if (!wantedStocks.Contains(model.TickerName))
                wantedStocks.Add(model.TickerName);

            // append the cookie
            Response.Cookies.Append("KnownStocks",
                                    JsonConvert.SerializeObject(wantedStocks),
                                    new Microsoft.AspNetCore.Http.CookieOptions() { Expires = DateTime.Now.AddDays(10) });

            // go back to get method
            return RedirectToAction("Index");
        }

        #endregion


    }
}
