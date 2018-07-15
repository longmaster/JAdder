using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobadder.Models;

namespace Jobadder.Interfaces
{
    public interface IJobMatchService
    {
         Task<List<Job>> JobMatchAsync(List<Job> Jobs, List<Candidate> Candidates);
    }
}
