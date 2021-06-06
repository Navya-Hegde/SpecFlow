using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using UserDetails.Model;

namespace SpecFlowTest.Helper
{
    public static class RestServiceCall
    {
        private static HttpClient _httpClient;

        private static readonly string _baseUri = "https://localhost:44374/";
        public static HttpResponseMessage GetUserDetailById(int id)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUri);
            HttpResponseMessage response = _httpClient.GetAsync($"api/User/GetUser?id={id}").Result;

            return response;
        }

        public static HttpResponseMessage AddUser(User user)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUri);
            var content = JsonConvert.SerializeObject(user);
            var buffer = System.Text.Encoding.UTF8.GetBytes(content);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = _httpClient.PostAsync($"api/User", byteContent).Result;

            return response;
        }

        public static HttpResponseMessage UpdateUser(int id)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUri);
            HttpResponseMessage response = _httpClient.GetAsync($"api/User?id={id}").Result;

            return response;
        }
    }
}
