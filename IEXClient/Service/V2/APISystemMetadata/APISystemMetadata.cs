using System.Net.Http;
using System.Threading.Tasks;
using IEXClient.Helper;
using IEXClient.Model.APISystemMetadata.Response;

namespace IEXClient.Service.V2.APISystemMetadata
{
    internal class APISystemMetadata : IAPISystemMetadataService
    {
        private readonly string _pk;
        private readonly Executor _executor;

        public APISystemMetadata(HttpClient client, string sk, string pk, bool sign)
        {
            _pk = pk;
            _executor = new Executor(client, sk, pk, sign);
        }

        public async Task<StatusResponse> StatusAsync() => await _executor.NoParamExecute<StatusResponse>("status", _pk);
    }
}