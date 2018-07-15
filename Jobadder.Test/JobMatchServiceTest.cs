using System;
using System.Collections.Generic;
using System.Text;
using Jobadder.Models;
using Jobadder.Services;
using Xunit;
using Moq;
using System.Linq;

namespace Jobadder.Test
{
    public class JobMatchServiceTest
    {
        [Fact]
        public async void Can_Return_Best_Candidate_Job()
        {
            //Arrange
            List<Job> listJobsMock = new List<Job>()
             {
                new Job  { jobId = 1, company = "Google", name = "Programmer", skills = "c#, angular, .net, oop, solid" }
            };


            List<Candidate> listCandidatesMock = new List<Candidate>()
            {
                new Candidate { CandidateId = 1, name = "Andy", SkillTags = "c#, vb, .net, react, solid" },
                new Candidate { CandidateId = 2, name = "Peter", SkillTags = "java, vb, angular, .net, solid" },
                new Candidate { CandidateId = 3, name = "Helen", SkillTags = "java, c#, angular, .net, test" }
            };

            //Act

            JobMatchService jobMatchService = new JobMatchService();
            var target = await jobMatchService.JobMatchAsync(listJobsMock, listCandidatesMock);

            //Assert
            Assert.NotNull(target.FirstOrDefault(c => c.qualifiedCandidate.CandidateId == 3));
            Assert.Equal(3, target.FirstOrDefault(c => c.qualifiedCandidate.CandidateId == 3).qualifiedCandidate.CandidateId);
            Assert.Equal("java, c#, angular, .net, test", target.FirstOrDefault(c => c.qualifiedCandidate.CandidateId == 3).qualifiedCandidate.SkillTags);
        }
    }
}
