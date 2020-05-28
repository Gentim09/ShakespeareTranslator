using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class ShakespearTranslator : ITranslate
    {
        readonly HttpClient client = new HttpClient();
        readonly string baseUri = "https://api.funtranslations.com/translate/shakespeare.json";

        public async Task<string> TranslateTextAsync(string input)
        {
            HttpContent content = new FormUrlEncodedContent(new[]
              {
                new KeyValuePair<string, string>("text", input)
            });

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var HttpResponseMessage = await client.PostAsync(baseUri, content);

            if (!HttpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception((int)HttpResponseMessage.StatusCode + "-" + HttpResponseMessage.StatusCode.ToString());
            }
            else
            {
                var response = HttpResponseMessage.Content.ReadAsStringAsync().Result;
                dynamic json = JToken.Parse(response);


                if (json.success.total != 0)
                {
                    return json.contents.translated;
                }
                else
                {
                    throw new Exception("Translation unavailable");
                }
            }
        }


    }
}
