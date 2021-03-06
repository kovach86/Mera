﻿using CustomErrorLogger;
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

        bool ServiceRunning();
    }

    public class TextWebApi : TokenChecker, IWebApiService
    {
        public string ApiUrl { get; set; }
         

        public TextWebApi(string keyName, string token) : base(token)
        {
            ApiUrl = ConfigurationManager.AppSettings[keyName];
            Token = token;
        }

        public bool ServiceRunning()
        {
             
            using (var client = new HttpClient())
            {
                var response = client.GetAsync($"{ApiUrl}/status/check");
                if (!response.Result.IsSuccessStatusCode)
                    CustomNLogger.LogException($"TextWebApi at {ApiUrl} is down");
                 
                return response.Result.IsSuccessStatusCode;
            }
        }

        public async Task<string> GetResponseFromApi(string contentToSend)
        {
            CheckAndSetToken();
            using (var client = new HttpClient())
            {
                var transferObject = new SimpleDto { Text = contentToSend };
                var contentBody = new StringContent(JsonConvert.SerializeObject(transferObject), Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);

                var response = await client.PostAsync($"{ApiUrl}/text-infos/count-words", contentBody);
                if (!response.IsSuccessStatusCode)
                {
                    CustomNLogger.LogException($"error occurred: \n{response.StatusCode} \n{response.RequestMessage.RequestUri}");
                    return "There is currently error in communication with API";
                }

                return await response.Content.ReadAsStringAsync();
            }
        }

    }
}
