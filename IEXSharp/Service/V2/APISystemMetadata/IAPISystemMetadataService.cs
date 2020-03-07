using IEXSharp.Model;
using System.Threading.Tasks;
using VSLee.IEXSharp.Model.APISystemMetadata.Response;

namespace VSLee.IEXSharp.Service.V2.APISystemMetadata
{
	public interface IAPISystemMetadataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-records"/>
		/// </summary>
		/// <returns></returns>
		Task<IEXResponse<StatusResponse>> StatusAsync();
	}
}