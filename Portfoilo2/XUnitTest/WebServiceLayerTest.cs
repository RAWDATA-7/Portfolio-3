using System.Linq;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xunit;

namespace XUnitTest
{
    public class WebServiceLayerTest
    {
        private const string TitleApi = "https://localhost:5001/api/BestRatedTitles";

        [Fact]
        public void CheckDataInBestRatedTitleList()
        {
            var (data, statusCode) = GetObject(TitleApi);

           var list = data.Properties().Select(x => x.Value).ToList();


            Assert.Equal("Breaking Bad", list[4][0]["name"]);
            Assert.Equal("tt0903747", list[4][0]["id"]);
        }

        /*
         * 
         * Helper Stuff
         * 
         */
        (JObject, HttpStatusCode) GetObject(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }
    }
}
