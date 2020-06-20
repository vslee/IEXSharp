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
			// commenting out until  MissingMemberHandling gets implemented in System.Text.Json
			// https://github.com/dotnet/runtime/issues/37483
			get => default; //executor.jsonSerializerOptions.MissingMemberHandling;
			set { } //executor.jsonSerializerOptions.MissingMemberHandling = value;
		}
	}
}