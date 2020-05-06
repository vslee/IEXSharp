using IEXSharp.Model;
using System.Net.Http;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model.APISystemMetadata.Response;

namespace IEXSharp.Service.Cloud.APISystemMetadata
{
	internal class APISystemMetadata : IAPISystemMetadataService
	{
		private readonly ExecutorREST _executor;

		public APISystemMetadata(HttpClient client, string sk, string pk, bool sign)
		{
			_executor = new ExecutorREST(client, sk, pk, sign);
		}

		public async Task<IEXResponse<StatusResponse>> StatusAsync() =>
			await _executor.NoParamExecute<StatusResponse>("status");
	}
}