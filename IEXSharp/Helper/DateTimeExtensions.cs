using System;
using System.Runtime.InteropServices;

namespace IEXSharp.Helper
{
	public static class DateTimeExtensions
	{
		public static TimeZoneInfo EST =>
			TimeZoneInfo.FindSystemTimeZoneById(RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
				? "Eastern Standard Time" : "America/New_York");
		public readonly static DateTime UnixEpoch = new DateTime(1970, 1, 1);

		public static DateTime GetTimestampInUTC(this ITimestampedDateMinute timestampedObj) =>
			TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(timestampedObj.date + ' ' + timestampedObj.minute), EST);

		public static DateTime GetTimestampInEST(this ITimestampedDateMinute timestampedObj) =>
			DateTime.Parse(timestampedObj.date + ' ' + timestampedObj.minute);

		public static TimeSpan GetTimeOfDayInEST(this ITimestampedMinute timestampedObj) =>
			TimeSpan.ParseExact(timestampedObj.minute, "hhmm", null);

		/// <summary>
		/// Convert from Unix epoch to DateTime
		/// </summary>
		/// <param name="unixTime"></param>
		/// <returns></returns>
		public static DateTime ConvertFromUnixMilliSecToDateTime(this long unixTime) => UnixEpoch.AddMilliseconds(unixTime);

		/// <summary>
		/// Converts DateTime object to time series endpoint compatible query param value
		/// </summary>
		/// <param name="date"></param>
		/// <returns></returns>
		public static string ToTimeSeriesDate(this DateTime date) => date.ToString("yyyy-MM-dd");
	}

	public interface ITimestampedDateMinute
	{
		string date { get; }
		string minute { get; }
	}

	public interface ITimestampedMinute
	{
		string minute { get; }
	}
}
