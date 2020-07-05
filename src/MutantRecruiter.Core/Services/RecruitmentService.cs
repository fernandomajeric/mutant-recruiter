using MutantRecruiter.Core.Interfaces;
using System.Collections.Generic;

namespace MutantRecruiter.Core.Services
{
    public class RecruitmentService : IRecruitmentService
    {
        public bool Recruit(List<string> dna)
        {
            return Recruiter
                .Build().IsMutant(dna.ToArray());
        }
    }
}
