using Newtonsoft.Json;
using StockCalls.APICalls;
using StockCalls.APICalls.RealTimeQuote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockCalls
{
    /// <summary>
    /// The client that will make API calls and get stock data
    /// </summary>
    public class Client : HttpClient
    {

        #region Properties
        /// <summary>
        /// The API key to use against the stock ticker API
        /// </summary>
        private const string APIKey = "55Y9YVNNM98SMTKR";
        
        /// <summary>
        /// The format in which to make API requestsBATCH_STOCK_QUOTES&symbols=MSFT
        /// </summary>
        private const string APIRequestFormat = "https://www.alphavantage.co/query?function=BATCH_STOCK_QUOTES&symbols={symbols}&apikey=55Y9YVNNM98SMTKR";
        #endregion

        #region Methods
        /// <summary>
        /// Makes a request to the API for the given stock ticker quote
        /// </summary>
        /// <param name="stockTicker">The quote to get</param>
        /// <param name="interval">The interval of the quote to get</param>
        public async Task<APIResult> GetStocksAsync(List<string> stockTicker)
        {
            try
            {
                // make the request
                string results = await GetStringAsync(APIRequestFormat.Replace("{symbols}", string.Join(",", stockTicker)));
                return JsonConvert.DeserializeObject<APIResult>(results);
            }
            catch (Exception E)
            {
                throw;
            }

        }
        #endregion

        #region Enums
        /// <summary>
        /// The stock interval in which to get data
        /// </summary>
        public enum StockTimeInterval
        {
            Min_1,
            Min_5,
            Min_15,
            Min_30,
            Min_60
        }
        #endregion

    }
}
