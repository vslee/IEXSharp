using System.Net.Http;
using System.Threading.Tasks;
using VSLee.IEXSharp.Helper;
using VSLee.IEXSharp.Model.APISystemMetadata.Response;

namespace VSLee.IEXSharp.Service.V2.APISystemMetadata
{
	internal class APISystemMetadata : IAPISystemMetadataService
	{
		private readonly string _pk;
		private readonly ExecutorREST _executor;

		public APISystemMetadata(HttpClient client, string sk, string pk, bool sign)
		{
			_pk = pk;
			_executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<StatusResponse> StatusAsync() => await _executor.NoParamExecute<StatusResponse>("status", _pk);
	}
}