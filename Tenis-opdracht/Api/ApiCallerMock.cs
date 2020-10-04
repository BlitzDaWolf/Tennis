using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tenis_opdracht.Api
{
    public class ApiCallerMock : IApiCaller
    {
        #region Mocks
        private List<T> GetAllMock<T>() where T : new() =>  (from c in (new int[5]).ToList() select new T()).ToList();
        private T getByIdMock<T>() where T : new() => new T();
        #endregion

        public Task<List<T>> GetAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetById<T>(object id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<T> GetObject<T>(string url) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
