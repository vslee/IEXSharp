using IEXSharp.Model;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.Account.Request;
using VSLee.IEXSharp.Model.Account.Response;

namespace VSLee.IEXSharp.Service.V2.Account
{
	public interface IAccountService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#metadata"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<MetadataResponse>> MetadataAsync();

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#usage"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<UsageResponse>> UsageAsync(UsageType type);

		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#pay-as-you-go"/>
		/// </summary>
		Task PayAsYouGoAsync(bool allow);
	}
}