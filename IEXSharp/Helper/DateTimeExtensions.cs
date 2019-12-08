using System;

namespace IEXSharp.Helper
{
	public static class DateTimeExtensions
	{
		public static readonly TimeZoneInfo EST = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");

		public static DateTime GetDateTimeInUTC(this ITimestamped timestampedObj) =>
			TimeZoneInfo.ConvertTimeToUtc(DateTime.Parse(timestampedObj.date + ' ' + timestampedObj.minute), EST);
	}

	public interface ITimestamped
	{
		string date { get; }
		string minute { get; }
	}
}
