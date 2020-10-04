using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Tenis_opdracht.Api
{
    public interface IApiCaller
    {
        public Task<T> GetObject<T>(string url) where T : class;
        public Task<T> GetById<T>(object id) where T : class;
        public Task<List<T>> GetAll<T>() where T : class;
    }
}
