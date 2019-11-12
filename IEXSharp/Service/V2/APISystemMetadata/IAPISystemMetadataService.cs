using System.Threading.Tasks;
using IEXSharp.Model.APISystemMetadata.Response;

namespace IEXSharp.Service.V2.APISystemMetadata
{
	public interface IAPISystemMetadataService
	{
		/// <summary>
		/// <see cref="https://iexcloud.io/docs/api/#stats-records"/>
		/// </summary>
		/// <returns></returns>
		Task<StatusResponse> StatusAsync();
	}
}