using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tenis_opdracht.Api
{
    public interface IApiCaller
    {
        public Task<T> GetObject<T>(string url, params string[] args) where T : class;
        public Task Post<T>(string url, T send, params string[] args) where T : class;
        public Task Put<T>(string url, T send, params string[] args) where T : class;

        public Task<T> GetById<T>(object id, params string[] args) where T : class;
        public Task<List<T>> GetAll<T>(params string[] args) where T : class;
    }
}
