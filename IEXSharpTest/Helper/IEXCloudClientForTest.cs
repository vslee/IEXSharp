using IEXSharp;
using Newtonsoft.Json;

namespace IEXSharpTest.Helper
{
	public class IEXCloudClientForTest : IEXCloudClient
	{
		public IEXCloudClientForTest(string publishableToken, string secretToken, bool signRequest, bool useSandBox, APIVersion version = APIVersion.stable) : base(publishableToken, secretToken, signRequest, useSandBox, version)
		{
		}

		public MissingMemberHandling JsonMissingMemberHandling
		{
			get => executor.JsonSerializerSettings.MissingMemberHandling;
			set => executor.JsonSerializerSettings.MissingMemberHandling = value;
		}
	}
}