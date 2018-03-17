using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCalls.APICalls.RealTimeQuote
{
    /// <summary>
    /// The class that contains information that comes back from the API call
    /// </summary>
    public class StockTickerSelection
    {
        [JsonProperty("1. symbol")]
        public string Symbol { get; set; }
        [JsonProperty("2. price")]
        public string Price { get; set; }
        [JsonProperty("3. volume")]
        public string Volume { get; set; }
        [JsonProperty("4. timestamp")]
        public string Timestamp { get; set; }
    }
}
