using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobadder.Models;

namespace Jobadder.Interfaces
{
    public interface IJobService
    {
        Task<List<Job>> GetAllJobs();
    }
}
