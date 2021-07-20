using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Education_Core.WebApi.IntegrationTests.Extensions
{
    public static class Extension
    {
        public async static Task<T> GetAndDeserialize<T>(this HttpClient client, string requestUri)
        {
            var response = await client.GetAsync(requestUri);

            if(response.StatusCode == HttpStatusCode.OK)
            {
                var result = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<T>(result);
            }

            throw new HttpRequestException(response.StatusCode.ToString()); 
        }
    }
}
