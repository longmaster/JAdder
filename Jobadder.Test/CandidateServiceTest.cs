using Jobadder.Interfaces;
using Jobadder.Models;
using Jobadder.Services;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Moq;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Jobadder.Test
{
    public class CandidateServiceTest:BaseWebTest
    {
        [Fact]
        public void Can_Get_Candidate_List()
        {
            //Arrange

            IApiService<Candidate> apiService = new ApiService<Candidate>(clientFactory);
            Mock<IConfiguration> mockConfigurationService = new Mock<IConfiguration>();
            mockConfigurationService.SetupGet(x => x[It.IsAny<string>()]).Returns(CandidatesApiURL);

            // Act
            CandidateService candidateService = new CandidateService(apiService, mockConfigurationService.Object);
            Task<List<Candidate>> JobList = candidateService.GetAllCandidates();

            //Assert
            Assert.NotNull(JobList);
            Assert.True(JobList.Result.Count > 0);
           
        }

        [Fact]
        public async void Can_Return_Candidates()
        {
            //Arrange
            var response = await clientFactory.CreateClient().GetAsync(CandidatesApiURL);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            //Act
            var model = JsonConvert.DeserializeObject<List<Candidate>>(stringResponse);

            //Assert
            Assert.NotNull(model);
            Assert.True(model.Count > 0);
        }
    }
}
