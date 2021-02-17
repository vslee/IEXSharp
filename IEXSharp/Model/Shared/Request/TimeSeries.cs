using System;
using Common.Logging.Configuration;
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

		private int _Range { get; set; }
		private string Range => period == TimeSeriesPeriod.Quarterly ? _Range + "q" : _Range + "y";
		private bool Calendar { get; set; }
		private int Limit { get; set; }
		private string From { get; set; }
		private string To { get; set; }
		private int Last { get; set; }
		private int First { get; set; }

		public TimeSeries AddRange(int range)
		{
			_Range = range;
			return this;
		}

		public TimeSeries AddDateRange(DateTime? from, DateTime? to = default)
		{
			if (from == null) return this;
			From = from?.ToTimeSeriesDate();
			To = to?.ToTimeSeriesDate() ?? DateTime.Today.ToTimeSeriesDate();
			return this;
		}

		public NameValueCollection TimeSeriesQueryParams()
		{
			var nvc = new NameValueCollection();

			if (From != null)
			{
				nvc.Add("from", From);
				nvc.Add("to", To);
			}

			if (_Range > 0 && string.IsNullOrEmpty(From))
			{
				nvc.Add("range", Range);
			}

			return nvc;
		}
	}
}