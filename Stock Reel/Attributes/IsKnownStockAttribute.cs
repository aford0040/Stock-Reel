using Stock_Reel.Services;
using StockCalls;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Stock_Reel.Attributes
{
    internal class IsKnownStockAttribute : ValidationAttribute
    {
        #region Properties
        #endregion

        #region Constructors
        public IsKnownStockAttribute()
        {
        }


        #endregion

        #region Methods
        /// <summary>
        /// Checks to see if the stock quote is valid
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public override bool IsValid(object value)
        {
            var result = new StockServices(new Client()).GetStockQuoteAsync(new List<string>() { value.ToString() }).Result;

            return result.Count > 0;
        }

        #endregion

    }
}