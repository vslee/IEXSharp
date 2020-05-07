using System.Threading.Tasks;
using IEXSharp.Model;
using IEXSharp.Model.CeoCompensation.Response;

namespace IEXSharp.Service.Cloud.CeoCompensation
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
