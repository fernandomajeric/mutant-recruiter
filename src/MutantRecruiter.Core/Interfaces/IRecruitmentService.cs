using System.Collections.Generic;
using System.Threading.Tasks;

namespace MutantRecruiter.Core.Interfaces
{
    public interface IRecruitmentService
    {
        Task<bool> Recruit(List<string> dna);
    }
}
