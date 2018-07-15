using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Jobadder.Interfaces;
using Jobadder.Models;
using Microsoft.Extensions.Configuration;

namespace Jobadder.Services
{
    public class CandidateService:ICandidateService
    {
        private readonly IApiService<Candidate> _apiService;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// List all candidates from API
        /// </summary>
        /// <returns>Return a list of candidates </returns>

        public CandidateService(IApiService<Candidate> apiService, IConfiguration configuration)
        {
            _apiService = apiService;
            _configuration = configuration;

        }
        public async Task<List<Candidate>> GetAllCandidates() => await _apiService.GetData(_configuration["JobAdderApiUrl:candidates"]);

    }
}
