using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApiConsumers
{
    public class TokenChecker
    {
        public string Token { get; set; }
        private string TokenApiUrl { get; set; }

        public TokenChecker(string token)
        {
            TokenApiUrl = "http://localhost:13203/token/get-token";
        }

      protected async void CheckAndRetrieveToken()
        {
            bool tokenOk = await ValidateToken();
            if (!tokenOk) SetToken();

        }

        private async Task<bool> ValidateToken()
        {
            string response = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                response = await client.GetStringAsync(TokenApiUrl);
            }
            return string.IsNullOrEmpty(response);
        }

        private async void SetToken()
        {
            using (var client = new HttpClient())
            {
                Token = await client.GetStringAsync(TokenApiUrl);
            }
        }
    }
}
