using Newtonsoft.Json;
using StockCalls;
using StockCalls.APICalls.RealTimeQuote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Stock_Reel.Services
{
    /// <summary>
    /// Various logic that will pertain to the stocks
    /// </summary>
    public class StockServices
    {
        #region Properties
        /// <summary>
        /// The client that goes off to get quotes
        /// </summary>
        private Client APIClient { get; }
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor that takes a client
        /// </summary>
        /// <param name="client"></param>
        public StockServices(Client client)
        {
            APIClient = client;
        }
        #endregion

        /// <summary>
        /// Deserializes the cookie string into a list of strings
        /// </summary>
        /// <param name="cookieString">The cookie string retrieved from th eclient</param>
        /// <returns></returns>
        public List<string> GetCookieStocks(string cookieString) => JsonConvert.DeserializeObject<List<string>>(cookieString ?? "");

        /// <summary>
        /// Gets a stock quote
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        internal async Task<List<StockTickerSelection>> GetStockQuoteAsync(List<string> stocks)
        {
            // go get the stock quote
            APIResult apiResult = await APIClient.GetStocksAsync(stocks);
            
            // if the results null, return null, otherwise return the quotes
            return apiResult?.StockQuotes;

        }
    }
}
