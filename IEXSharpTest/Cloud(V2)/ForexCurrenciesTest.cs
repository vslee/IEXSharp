using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VSLee.IEXSharp;

namespace VSLee.IEXSharpTest.Cloud
{
	public class ForexCurrenciesTest
	{
		private IEXCloudClient sandBoxClient;

		[SetUp]
		public void Setup()
		{
			sandBoxClient = new IEXCloudClient(TestGlobal.pk, TestGlobal.sk, false, true);
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
