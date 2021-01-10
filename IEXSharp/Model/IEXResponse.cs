namespace IEXSharp.Model
{
	/// <summary>
	/// Response to query, either containing data, or an error message
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class IEXResponse<T>
	{
		/// <summary>
		/// Error message returned by IEX (expect Data to be null if there is an error message)
		/// </summary>
		public string ErrorMessage;
		/// <summary>
		/// Core Messages used by request
		/// </summary>
		public int CoreMessagesUsage;
		/// <summary>
		/// Premium Messages used by request
		/// </summary>
		public int PremiumMessagesUsage;
		/// <summary>
		/// Data returned by IEx (expect ErrorMessage to be null if there is Data)
		/// </summary>
		public T Data;
	}
}
