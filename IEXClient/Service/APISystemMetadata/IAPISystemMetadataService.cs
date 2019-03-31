using System.Threading.Tasks;
using IEXClient.Model.APISystemMetadata.Response;

namespace IEXClient.Service.APISystemMetadata
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