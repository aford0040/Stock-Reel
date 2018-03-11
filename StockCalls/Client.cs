using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StockCalls
{
    public class Client
    {

        #region Properties
        /// <summary>
        /// The API key to use against the stock ticker API
        /// </summary>
        private const string APIKey = "55Y9YVNNM98SMTKR";

        private const string APIRequestFormat = "https://www.alphavantage.co/query?function=TIME_SERIES_INTRADAY&symbol={symbol}&interval={interval}&apikey=55Y9YVNNM98SMTKR";
        #endregion

        #region Methods
        /// <summary>
        /// Makes a request to the API for the given stock ticker quote
        /// </summary>
        /// <param name="stockTicker">The quote to get</param>
        /// <param name="interval">The interval of the quote to get</param>
        public void MakeRequest(string stockTicker, string interval)
        {
            HttpClient client = new HttpClient();
            string results = client.GetStringAsync(APIRequestFormat.Replace("{symbol}", stockTicker).Replace("{interval}", interval)).Result;

            var result = JsonConvert.DeserializeObject(results);

        }
        #endregion

    }
}
