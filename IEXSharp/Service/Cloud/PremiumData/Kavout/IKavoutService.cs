using System.Collections.Generic;
using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.PremiumData.Kavout.Response;

namespace IEXSharp.Service.Cloud.PremiumData.Kavout
{
	public interface IKavoutService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#k-score-for-us-equities"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<KavoutResponse>>> KScoreForUsEquitiesAsync(string symbol);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#k-score-for-china-a-shares"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<IEnumerable<KavoutResponse>>> KScoreForChinaASharesAsync(string symbol);
	}
}
