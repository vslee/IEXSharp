using IEX.V2.Model.Account;
using System.Threading.Tasks;

namespace IEX.V2.Service.Account
{
    public interface IAccountService
    {
        MetadataResponse Metadata();

        Task<MetadataResponse> MetadataAsync();
    }
}