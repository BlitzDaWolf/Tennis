using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Tenis_opdracht.Api;

namespace Tenis_opdracht
{
    public static class ApiHelper
    {
        public static HttpClient ApiClient { get; private set; }
        public static readonly string BASEURL = "https://localhost:5001/api/";
        public static IApiCaller apiCaller { get; private set; } = new ApiCaller();

        public static void InitializeClient()
        {
            ApiClient = new HttpClient();
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public static void InitializeClient(IApiCaller caller)
        {
            InitializeClient();
            apiCaller = caller;
        }
    }
}
