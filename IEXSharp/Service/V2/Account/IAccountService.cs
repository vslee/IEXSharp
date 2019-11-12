using System.Threading.Tasks;
using IEXSharp.Model.Account.Request;
using IEXSharp.Model.Account.Response;

namespace IEXSharp.Service.V2.Account
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