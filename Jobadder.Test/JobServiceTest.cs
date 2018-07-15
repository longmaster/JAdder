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
    public class JobServiceTest : BaseWebTest
    {
        [Fact]
        public void Can_Get_Job_List()
        {
            //Arrange

            IApiService<Job> apiService = new ApiService<Job>(clientFactory);
            Mock<IConfiguration> mockConfigurationService = new Mock<IConfiguration>();
            mockConfigurationService.SetupGet(x => x[It.IsAny<string>()]).Returns(JobApiURL);

            // Act
            JobService jobService = new JobService(apiService, mockConfigurationService.Object);
            Task<List<Job>> JobList = jobService.GetAllJobs();

            //Assert
            Assert.NotNull(JobList);
            Assert.True(JobList.Result.Count > 0);

        }
        [Fact]
        public async void Can_Return_Jobs()
        {
            //Arrange
            var response = await clientFactory.CreateClient().GetAsync(JobApiURL);
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();

            //Act
            var model = JsonConvert.DeserializeObject<List<Job>>(stringResponse);

            //Assert
            Assert.NotNull(model);
            Assert.True(model.Count > 0);
        }
    }
}
