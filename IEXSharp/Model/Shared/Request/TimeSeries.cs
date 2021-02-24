using System;
using IEXSharp.Helper;

namespace IEXSharp.Model.Shared.Request
{
	public class TimeSeries
	{
		private readonly TimeSeriesPeriod period;

		public TimeSeries(TimeSeriesPeriod period)
		{
			this.period = period;
		}

		private string Range { get; set; }
		private bool Calendar { get; set; }
		private int Limit { get; set; }
		private string From { get; set; }
		private string To { get; set; }
		private int Last { get; set; }
		private int First { get; set; }

		public TimeSeries SetRange(int range)
		{
			if (range <= 0) return this;
			Range = period == TimeSeriesPeriod.Quarterly ? range + "q" : range + "y";
			return this;
		}

		public TimeSeries SetDateRange(DateTime? from, DateTime? to = default)
		{
			if (from == null) return this;
			From = from?.ToTimeSeriesDate();
			To = to?.ToTimeSeriesDate() ?? DateTime.Today.ToTimeSeriesDate();
			return this;
		}

		public TimeSeries SetLast(int last)
		{
			Last = last;
			return this;
		}

		/// <summary>
		/// Updates give query string builder class with required Time series query params
		/// </summary>
		/// <param name="qsb"></param>
		public void AddTimeSeriesQueryParams(QueryStringBuilder qsb)
		{
			if (qsb == null) return;

			if (From != null)
			{
				qsb.Add("from", From);
				qsb.Add("to", To);
			}

			if (!string.IsNullOrEmpty(Range) && string.IsNullOrEmpty(From))
			{
				qsb.Add("range", Range);
			}

			if (Last > 0) qsb.Add("last", Last.ToString());
		}
	}
}