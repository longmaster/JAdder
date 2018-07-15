using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Jobadder.Interfaces
{
    public interface IApiService<T> where T:class
    {
        Task<List<T>> GetData(string url);
    }
}
