using Newtonsoft.Json;
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
        /// <summary>
        /// Deserializes the cookie string into a list of strings
        /// </summary>
        /// <param name="cookieString">The cookie string retrieved from th eclient</param>
        /// <returns></returns>
        public List<string> GetCookieStocks(string cookieString) => JsonConvert.DeserializeObject<List<string>>(cookieString);
    }
}
