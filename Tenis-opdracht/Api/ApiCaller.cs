using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tenis_opdracht.Api
{
    public class ApiCaller : IApiCaller
    {
        public async Task<T> GetObject<T>(string url) where T : class
        {
            string fullUri = ApiHelper.BASEURL + url;
            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(fullUri))
            {
                if (response.IsSuccessStatusCode)
                {
                    T r = await response.Content.ReadAsAsync<T>();
                    return r;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        public async Task<T> GetById<T>(object id) where T : class
        {
            return await GetObject<T>($"{typeof(T).Name}/{id}");
        }

        public async Task<List<T>> GetAll<T>() where T : class
        {
            return await GetObject<List<T>>($"{typeof(T).Name}");
        }
    }
}
