using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;
using System.Text.Json;
using System.Text;
using dotnetCommonUtils.CommonModels;

namespace dotnetmvcapp.Services
{
    public interface IHttpClientService{
        public Task<ResponseObject<T>> Delete<T>(string uri, object content);
        public Task<ResponseObject<T>> Get<T>(string uri);
        public Task<ResponseObject<T>> Post<T>(string uri,object content);
        public Task<ResponseObject<T>> Put<T>(string uri, object content);
    }
    public class HttpClientService: IHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly JsonSerializerOptions options;
        private string baseurl = "https://8080-cfddbbbdedacfcbefaafbaaebaaffaffcdcfacc.premiumproject.examly.io";
        public HttpClientService(IHttpClientFactory httpClientFactory,IHttpContextAccessor httpContextAccessor){
            _httpClientFactory = httpClientFactory;
            _httpContextAccessor = httpContextAccessor;
            options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<ResponseObject<T>> Get<T>(string uri){
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"{baseurl}{uri}"
            ){
                Headers = {
                    {HeaderNames.Accept,"application/json"}
                }
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            if(httpResponseMessage.IsSuccessStatusCode){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            throw new Exception("API Unavailable");
        }

        public async Task<ResponseObject<T>> Post<T>(string uri,object content){
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Post,
                $"{baseurl}{uri}"
            ){
                Headers = {
                    {HeaderNames.Accept,"application/json"},
                    {HeaderNames.Authorization,$"Bearer {token}"}
                },
                Content = new StringContent(JsonSerializer.Serialize(content),Encoding.UTF8,"application/json")
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            Console.WriteLine(token);
            Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString("UserName"));
            Console.WriteLine(_httpContextAccessor.HttpContext.User);

            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            if(httpResponseMessage.IsSuccessStatusCode){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            throw new Exception("API Unavailable");
        }

        public async Task<ResponseObject<T>> Put<T>(string uri,object content){
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Put,
                $"{baseurl}{uri}"
            ){
                Headers = {
                    {HeaderNames.Accept,"application/json"},
                    {HeaderNames.Authorization,$"Bearer {token}"}
                },
                Content = new StringContent(JsonSerializer.Serialize(content),Encoding.UTF8,"application/json")
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            Console.WriteLine(token);
            Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString("UserName"));
            Console.WriteLine(_httpContextAccessor.HttpContext.User);

            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            if(httpResponseMessage.IsSuccessStatusCode){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            throw new Exception("API Unavailable");
        }

        public async Task<ResponseObject<T>> Delete<T>(string uri,object content){
            var token = _httpContextAccessor.HttpContext.Session.GetString("AuthToken");
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Delete,
                $"{baseurl}{uri}"
            ){
                Headers = {
                    {HeaderNames.Accept,"application/json"},
                    {HeaderNames.Authorization,$"Bearer {token}"}
                },
                Content = new StringContent(JsonSerializer.Serialize(content),Encoding.UTF8,"application/json")
            };

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
            Console.WriteLine(token);
            Console.WriteLine(_httpContextAccessor.HttpContext.Session.GetString("UserName"));
            Console.WriteLine(_httpContextAccessor.HttpContext.User);

            using var contentStream = await httpResponseMessage.Content.ReadAsStreamAsync();

            if(httpResponseMessage.IsSuccessStatusCode){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            if(httpResponseMessage.StatusCode == System.Net.HttpStatusCode.BadRequest){
                return await JsonStreamToObject<ResponseObject<T>>(contentStream);
            }
            throw new Exception("API Unavailable");
        }     

        private async Task<T> JsonStreamToObject<T>(Stream s){
            return await JsonSerializer.DeserializeAsync<T>(s,options);
        }
    }
}