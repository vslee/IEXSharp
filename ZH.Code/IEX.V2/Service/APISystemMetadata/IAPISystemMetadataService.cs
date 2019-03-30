using System.Threading.Tasks;
using ZH.Code.IEX.V2.Model.APISystemMetadata.Response;

namespace ZH.Code.IEX.V2.Service.APISystemMetadata
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