using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using ShakespeareTranslation;
using ShakespeareTranslation.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;


namespace ShakespeareTranslationTest
{
    public class ApiTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _fixture;
        private readonly HttpClient _client;

        public ApiTest(WebApplicationFactory<Startup> fixture)
        {
            _fixture = fixture;
            _client = _fixture.CreateClient(new WebApplicationFactoryClientOptions
            {
                BaseAddress = new Uri("http://localhost:5000")
            });

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        [Fact]
        public async Task TestSwaggerAsync()
        {
            var url = "/swagger/v1/swagger.json";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPokemonAsync()
        {
            var url = "/Pokemon/charizard";
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();

            var shakespeareJson = JsonConvert.DeserializeObject<Shakespeare>(responseBody);


            NUnit.Framework.Assert.That(shakespeareJson.Name, Does.Contain("charizard"));
            NUnit.Framework.Assert.That(shakespeareJson.Description, Does.Contain("Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of such most wondrous heat yond 't melts aught. However,  't nev'r turns its fiery breath on any opponent weaker than itself."));


        }

    }
}
