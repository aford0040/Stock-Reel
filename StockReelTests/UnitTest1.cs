using Microsoft.VisualStudio.TestTools.UnitTesting;
using StockCalls;

namespace StockReelTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Client testClient = new Client();
            testClient.MakeRequest("ATVI", "5min");
        }
    }
}
