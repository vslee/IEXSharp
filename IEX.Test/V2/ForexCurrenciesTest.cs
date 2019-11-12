using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IEXClient;

namespace IEX.Test.V2
{
    public class ForexCurrenciesTest
    {
        private IEXRestV2Client sandBoxClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
        }

        // Not supported for free account
        [Test]
        [TestCase("EUR", "USD")]
        public async Task ExchangeRateAsync(string from, string to)
        {
            var response = await sandBoxClient.ForexCurrencies.ExchangeRateAsync(from, to);

            Assert.IsNotNull(response);
        }
    }
}
