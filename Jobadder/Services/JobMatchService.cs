using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jobadder.Interfaces;
using Jobadder.Models;

namespace Jobadder.Services
{
   
    public class JobMatchService:IJobMatchService
    {
        /// <summary>
        /// Finding a most qualified candidate for a job
        /// </summary>
        /// <returns>Return a list of jobs with most qualified candidates </returns>
         
        public async Task<List<Job>> JobMatchAsync(List<Job> Jobs, List<Candidate> Candidates)
        {
            List<JobMatch> JobMatches = new List<JobMatch>();
            List<Candidate> matchedCandidates = new List<Candidate>();

            //STEP 1: GO THROUGH ALL JOBS AND CANDIDATES LIST 
            foreach (var job in Jobs)
            {
                JobMatch jobMatch = new JobMatch();

                foreach (var candidate in Candidates)
                {

                    var CommonList = job.skills.Split(',').Select(s => s.Trim()).Intersect(candidate.SkillTags.Split(',').Select(s => s.Trim()));

                    if (CommonList.Count() > 0)
                    {
                        candidate.NumberMatchedSkills = CommonList.Count();
                        matchedCandidates.Add(candidate);
                    }


                }

                //STEP 2: TAKING ALL CANDIDATES WITH SKILLS WHICH MATCHED JOB SKILLS
                matchedCandidates = matchedCandidates.Where(c => c.NumberMatchedSkills == matchedCandidates.Max(m => m.NumberMatchedSkills)).ToList();


                //STEP 3: FIDING THE STAFF WITH THE MOST RELEVANT SKILLS FOR THE JOB BY USING INDEX TO DETERMINE MOST RELEVANT SKILLS
                int SmallestTotalIndex = 0;
                int TotalIndex = 0;
                foreach (var candidate in matchedCandidates)
                {
                    var jobSkillList = job.skills.Split(',').Select(s => s.Trim()).ToList<string>();

                    foreach (var skill in candidate.SkillTags.Split(',').Select(s => s.Trim()).ToList<string>())
                    {
                        int indexSkill = jobSkillList.IndexOf(skill);
                        if (indexSkill > 0)
                            TotalIndex = TotalIndex + indexSkill;
                    }

                    if (TotalIndex < SmallestTotalIndex || SmallestTotalIndex == 0)
                    {
                        SmallestTotalIndex = TotalIndex;
      
                        job.qualifiedCandidate = candidate;
                    }
                    TotalIndex = 0;

                }
                //RESET
                SmallestTotalIndex = 0;
                matchedCandidates.Clear();
            }
 
             return await Task.FromResult<List<Job>>(Jobs); 
        }
    
    }
    
}
