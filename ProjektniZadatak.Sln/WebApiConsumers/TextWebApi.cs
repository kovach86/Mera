using CustomErrorLogger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TransferObjects;

namespace WebApiConsumers
{
    public interface IWebApiService
    {
        Task<string> GetResponseFromApi(string resource);
    }

    public class TextWebApi : TokenChecker, IWebApiService
    {
        public string ApiUrl { get; set; }
         

        public TextWebApi(string keyName, string token) : base(token)
        {
            ApiUrl = ConfigurationManager.AppSettings[keyName];
            Token = token;
        }

        public bool ServiceRuning()
        {
             
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{ApiUrl}/status");
                if (!response.Result.IsSuccessStatusCode)
                    CustomNLogger.LogException($"TextWebApi at {ApiUrl} is down");

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                return response.Result.IsSuccessStatusCode;
            }
        }

        public async Task<string> GetResponseFromApi(string contentToSend)
        {
            CheckAndRetrieveToken();
            using (var client = new HttpClient())
            {
                var transeferObject = new SimpleDto { Text = contentToSend };
                var content = new StringContent(JsonConvert.SerializeObject(transeferObject), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var response = await client.PostAsync($"{ApiUrl}/count-words", content);
                if (!response.IsSuccessStatusCode)
                    CustomNLogger.LogException($"error occurred: \n{response.StatusCode} \n{response.RequestMessage.RequestUri}");

                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
