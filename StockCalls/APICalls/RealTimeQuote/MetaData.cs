using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockCalls.APICalls.RealTimeQuote
{
    /// <summary>
    /// The meta data that comes with the API calls
    /// </summary>
    public class MetaData
    {
        [JsonProperty("1. Information")]
        public string Info { get; set; }
        [JsonProperty("2. Notes")]
        public string Notes { get; set; }
        [JsonProperty("3. Time Zone")]
        public string TimeZone { get; set; }

    }
}
