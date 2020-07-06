using MutantRecruiter.Core.Entities;
using MutantRecruiter.Core.Interfaces;

namespace MutantRecruiter.Core.Services
{
    public class StatsService : IStatsService
    {
        private readonly IStatsRepository repository;

        public StatsService(IStatsRepository repository)
        {
            this.repository = repository;
        }

        public Stats GetStats()
        {
            return repository.GetStats();
        }
    }
}
