using IEXSharp.Model;
using System.Threading.Tasks;
using IEXSharp.Helper;
using IEXSharp.Model.APISystemMetadata.Response;

namespace IEXSharp.Service.Cloud.APISystemMetadata
{
	internal class APISystemMetadata : IAPISystemMetadataService
	{
		private readonly ExecutorREST executor;

		internal APISystemMetadata(ExecutorREST executor)
		{
			this.executor = executor;
		}

		public async Task<IEXResponse<StatusResponse>> StatusAsync() =>
			await executor.NoParamExecute<StatusResponse>("status");
	}
}