using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZH.Code.IEX.V2;

namespace IEX.Test
{
    public class APISystemMetadataTest
    {
        private IEXRestV2Client sandBoxClient;

        [SetUp]
        public void Setup()
        {
            sandBoxClient = new IEXRestV2Client(TestGlobal.pk, TestGlobal.sk, false, true);
        }

        [Test]
        public async Task StatusAsyncTest()
        {
            var response = await sandBoxClient.ApiSystemMetadata.StatusAsync();

            Assert.IsNotNull(response);
        }
    }
}
