using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jobadder.Interfaces;
using Microsoft.Extensions.Configuration;

namespace Jobadder.Services
{
    public class ApiService<T>:IApiService<T> where T: class
    {
        private readonly IHttpClientFactory _httpClient;

        //HTTP CLIENT FACTORY - CREATING A SINGLE INSTANCE OF HTTP CLIENT
        public ApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory;
        }

        /// <summary>
        /// Generic function to get data from API
        /// </summary>
        /// <returns>Return a list of objects </returns>
        /// 
        public async Task<List<T>> GetData(string url)
        {
            List<T> data = null;
            var httpClient = _httpClient.CreateClient();

            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                data = await response.Content.ReadAsAsync<List<T>>();
            }
            return data;
        }
    }
}
