using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockCalls;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockReelTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Client testClient = new Client();
            var test = testClient.GetStocksAsync(new List<string>() { "ATVI" }).Result;

            
        }
    }
}
