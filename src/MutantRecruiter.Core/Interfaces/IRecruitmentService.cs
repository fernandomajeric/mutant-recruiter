using System.Collections.Generic;

namespace MutantRecruiter.Core.Interfaces
{
    public interface IRecruitmentService
    {
        bool Recruit(List<string> dna);
    }
}
