using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCalls.APICalls.RealTimeQuote
{
    /*
     "Meta Data": {
        "1. Information": "Batch Stock Market Quotes",
        "2. Notes": "IEX Real-Time Price provided for free by IEX (https://iextrading.com/developer/).",
        "3. Time Zone": "US/Eastern"
    },
    "Stock Quotes": [
        {
            "1. symbol": "MSFT",
            "2. price": "94.5500",
            "3. volume": "--",
            "4. timestamp": "2018-03-16 15:59:59"
        }
    ]
     */
    /// <summary>
    /// Represents a result from the realtime quote API
    /// </summary>
    public class APIResult
    {
        [JsonProperty("Meta Data")]
        public MetaData JSONMetaData { get; set; }
        [JsonProperty("Stock Quotes")]
        public List<StockTickerSelection> StockQuotes { get; set; }
    }



}
