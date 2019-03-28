using ZH.Code.IEX.V2.Model.Account.Request;
using ZH.Code.IEX.V2.Model.Account.Response;
using System.Threading.Tasks;

namespace ZH.Code.IEX.V2.Service.Account
{
    public interface IAccountService
    {
        MetadataResponse Metadata();

        Task<MetadataResponse> MetadataAsync();

        UsageResponse Usage(UsageType type);

        Task<UsageResponse> UsageAsync(UsageType type);

        void PayAsYouGo(bool allow);

        Task PayAsYouGoAsync(bool allow);
    }
}