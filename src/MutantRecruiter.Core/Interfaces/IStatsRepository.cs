using MutantRecruiter.Core.Entities;
using System.Threading.Tasks;

namespace MutantRecruiter.Core.Interfaces
{
    public interface IStatsRepository
    {
        Stats GetStats();
        Task<long> IncrementMutantCount();
        Task<long> IncrementHumanCount();
    }
}