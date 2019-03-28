using ZH.Code.IEX.V2.Model.Account.Request;
using ZH.Code.IEX.V2.Model.Account.Response;
using System.Threading.Tasks;

namespace ZH.Code.IEX.V2.Service.Account
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