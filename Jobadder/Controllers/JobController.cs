using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Jobadder.Interfaces;
using Jobadder.Services;
using Jobadder.Models;
namespace Jobadder.Controllers
{

    public class JobController : Controller
    {
        private readonly IJobService _jobService;
        private readonly ICandidateService _candidateService;
        private readonly IJobMatchService _jobMatchService;

        public JobController(IJobService jobService, ICandidateService candidateService, IJobMatchService jobMatchService)
        {
            _jobService = jobService;
            _candidateService = candidateService;
            _jobMatchService = jobMatchService;
        }

        public async Task<IActionResult> Index()
        {

            var Jobs = await _jobService.GetAllJobs();
            var Candidates = await _candidateService.GetAllCandidates();
            var result = await _jobMatchService.JobMatchAsync(Jobs, Candidates);

            return View(result);
        }
    }
}
