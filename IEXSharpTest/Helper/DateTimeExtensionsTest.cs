using IEXSharp.Helper;
using IEXSharp.Model.Crypto.Response;
using IEXSharp.Model.SocialSentiment.Response;
using IEXSharp.Model.StockPrices.Response;
using NUnit.Framework;
using System;

namespace IEXSharpTest.Helper
{
	public class DateTimeExtensionsTest
	{
		[Test]
		[TestCase("2020-05-06", "13:40")]
		public void TimestampedDateMinuteInUTCTest(string inputDate, string inputMinute)
		{
			var timstampedObj = new HistoricalPriceResponse() { date = inputDate, minute = inputMinute };
			Assert.AreEqual(new DateTime(2020, 05, 06, 17, 40, 0), timstampedObj.GetTimestampInUTC());
		}

		[Test]
		[TestCase("2020-05-06", "13:40")]
		public void TimestampedDateMinuteInESTTest(string inputDate, string inputMinute)
		{
			var timstampedObj = new HistoricalPriceResponse() { date = inputDate, minute = inputMinute };
			Assert.AreEqual(new DateTime(2020, 05, 06, 13, 40, 0), timstampedObj.GetTimestampInEST());
		}

		[Test]
		[TestCase("2020-05-06", null)]
		public void TimestampedDateNullMinuteInUTCTest(string inputDate, string inputMinute)
		{
			var timstampedObj = new HistoricalPriceResponse() { date = inputDate, minute = inputMinute };
			Assert.AreEqual(new DateTime(2020, 05, 06, 4, 0, 0), timstampedObj.GetTimestampInUTC());
		}

		[Test]
		[TestCase("2020-05-06", null)]
		public void TimestampedDateNullMinuteInESTTest(string inputDate, string inputMinute)
		{
			var timstampedObj = new HistoricalPriceResponse() { date = inputDate, minute = inputMinute };
			Assert.AreEqual(new DateTime(2020, 05, 06, 0, 0, 0), timstampedObj.GetTimestampInEST());
		}

		[Test]
		[TestCase("2357")]
		public void TimestampedMinuteInESTTest(string inputMinute)
		{
			var timstampedObj = new SentimentMinuteResponse() { minute = inputMinute };
			Assert.AreEqual(new TimeSpan(23, 57, 0), timstampedObj.GetTimeOfDayInEST());
		}

		// not sure if this test is correct bc IEX sandbox returns obfuscated values for these dates!
		[Test]
		[TestCase(1607862678216)]
		public void UnixLongToDTTest(long inputUnixTime)
		{
			var timstampedObj = new CryptoBookQuote() { timestamp = inputUnixTime };
			Assert.AreEqual(DateTime.Parse("2020-12-13 12:31:18.216"), timstampedObj.timestamp.ConvertFromUnixMilliSecToDateTime());
		}
	}
}
