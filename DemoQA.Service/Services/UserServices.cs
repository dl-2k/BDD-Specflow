using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.API;

using DemoQA.Service.Model.Request;
using DemoQA.Service.Model.Response;
using RestSharp;

namespace DemoQA.Service.Services
{
    public class UserServices
    {
        private readonly APIClient _client;

        public UserServices(APIClient client)
        {
            _client = client;
        }

        public async Task<RestResponse<GenerateTokenResponseDto>> GenerateTokenAsync(string username, string password)
        {
            var requestBody = new GenerateTokenRequestDto()
            {
                UserName = username,
                Password = password
            };
            return await _client.CreateRequest(String.Format(APIConstant.GenerateToken))
                .AddContentTypeHeader("application/json")
                .AddBody(requestBody)
                .ExecutePostAsync<GenerateTokenResponseDto>();
        }



    }
}