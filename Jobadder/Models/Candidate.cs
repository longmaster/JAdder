using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jobadder.Models
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string name { get; set; }
        public string SkillTags { get; set; }
        public int NumberMatchedSkills { get; set; }
    }
}
