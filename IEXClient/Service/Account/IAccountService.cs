using System.Threading.Tasks;
using IEXClient.Model.Account.Request;
using IEXClient.Model.Account.Response;

namespace IEXClient.Service.Account
{
    public interface IAccountService
    {
        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#metadata"/>
        /// </summary>
        /// <returns></returns>
        Task<MetadataResponse> MetadataAsync();

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#usage"/>
        /// </summary>
        /// <returns></returns>
        Task<UsageResponse> UsageAsync(UsageType type);

        /// <summary>
        /// <see cref="https://iexcloud.io/docs/api/#pay-as-you-go"/>
        /// </summary>
        Task PayAsYouGoAsync(bool allow);
    }
}