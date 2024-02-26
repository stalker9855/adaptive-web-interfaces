using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SentinmentAPI
    {
        public string Sentiment { get; set; } = "";
        public string Language { get; set; } = "";
        public string ContentType { get; set; } = "";
        public int StatusCode { get; set; }
    }

    public class ApiResponse<T>
    {
        public string Message { get; set; }
        public int HttpStatusCode { get; set; }
        public List<T> Data { get; set; }
    }

    public class ApiClient<T>
    {
        private readonly HttpClient _httpClient;

        public ApiClient(string baseUrl)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(baseUrl);
            _httpClient.DefaultRequestHeaders.Add("apikey","FGoPMWkY1zvWoIGAWNngE3KX4vayZSsg");
        }
        public async Task<ApiResponse<T>> Post(string stringContent)
        {
            try
            {
                var content = new StringContent(stringContent, Encoding.UTF8, "text/plain");
                HttpResponseMessage response = await _httpClient.PostAsync(_httpClient.BaseAddress, content);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseData);
                    var data = JsonSerializer.Deserialize<List<T>>(responseData);
                    return new ApiResponse<T> { Data = data, HttpStatusCode = (int)response.StatusCode };
                }
                else
                {
                    return new ApiResponse<T> { Message = response.ReasonPhrase, HttpStatusCode = (int)response.StatusCode };
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new ApiResponse<T> { Message = ex.Message, HttpStatusCode = 500 };
            }
        }
    }
}
