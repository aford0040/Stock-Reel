using Newtonsoft.Json;
using Stock_Reel.Attributes;
using Stock_Reel.Services;
using StockCalls;
using StockCalls.APICalls.RealTimeQuote;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_Reel.Models
{
    /// <summary>
    /// The model that handles taking input from the user
    /// </summary>
    public class StockInputModel
    {
        #region Properties
        /// <summary>
        /// The ticker name
        /// </summary>
        [Required]
        [IsKnownStock]
        public string TickerName { get; set; }

        /// <summary>
        /// The list of known stock tickers
        /// </summary>
        public List<StockTickerSelection> KnownStocks { get; set; } = new List<StockTickerSelection>();
        #endregion

        #region Constructors
        /// <summary>
        /// Model that takes the JSON data from the cookie and populates the model
        /// </summary>
        /// <param name="cookieString"></param>
        public StockInputModel(string cookieString)
        {
            DeserializeCookie(cookieString);
        }

        /// <summary>
        /// Blank construxctor
        /// </summary>
        public StockInputModel()
        {

        }
        #endregion

        #region Methods
        /// <summary>
        /// deserializes the cookie and populates the list of known stocks
        /// </summary>
        /// <param name="cookieString">The value of the cookie that comes from the user's browser</param>
        private async void DeserializeCookie(string cookieString)
        {
            var deserializedCookie = JsonConvert.DeserializeObject<List<string>>(cookieString);
            if (deserializedCookie.Count == 0)
                return;

            using (var apiClient = new Client())
            {
                var apiResult = await apiClient.GetStocksAsync(deserializedCookie);
                KnownStocks.AddRange(apiResult.StockQuotes);
            }
        }
        #endregion


    }
}
