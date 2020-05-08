using System;
using System.Globalization;

namespace IEXSharp.Helper
{
	public static class DateTimeExtensions
	{
		public static readonly TimeZoneInfo EST = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
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
