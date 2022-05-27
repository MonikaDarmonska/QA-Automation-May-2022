using NUnit.Framework;
using RestSharp;
using System.Net;
using System.Threading.Tasks;

namespace TestGitHubApi
{
    public class Github_Tests
    {
        private RestClient client;
        private RestRequest request;

        [SetUp]
        public void Setup()
        {
            this.client = new RestClient("https://api.github.com");
            string url = "/repos/MonikaDarmonska/Postman/issues";

            this.request = new RestRequest(url);
        }

        [Test]
        public async Task Test_Get_Issue()
        {
           var response = await client.ExecuteAsync(request);
            Assert.IsNotNull(response.Content);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}