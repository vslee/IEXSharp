using IEXSharp.Model;
using IEXSharp.Model.CeoCompensation.Response;
using System.Threading.Tasks;

namespace IEXSharp.Service.Cloud.Options
{
	public interface ICeoCompensationService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#ceo-compensation"/>
		/// </summary>
		/// <param name="symbol">Stock symbol</param>
		/// <returns></returns>
		Task<IEXResponse<CeoCompensationResponse>> CeoCompensationAsync(string symbol);
	}
}
