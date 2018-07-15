using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Jobadder.Interfaces;
using Jobadder.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;


namespace Jobadder.Services
{
    public class JobService : IJobService
    {

        private readonly IApiService<Job> _apiService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// List all jobs from API
        /// </summary>
        /// <returns>Return a list of jobs </returns>

        public JobService(IApiService<Job> apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;


        }
        public async Task<List<Job>> GetAllJobs()
        {
           return await _apiService.GetData(_configuration["JobAdderApiUrl:jobs"]);
        }
        

    }
}
