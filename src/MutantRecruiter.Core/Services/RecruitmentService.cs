using MutantRecruiter.Core.Entities;
using MutantRecruiter.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MutantRecruiter.Core.Services
{
    public class RecruitmentService : IRecruitmentService
    {
        private readonly IStatsRepository _statsRepository;
        private readonly IDnaRepository _dnaRepository;

        public RecruitmentService(IStatsRepository statsRepository, IDnaRepository dnaRepository)
        {
            _statsRepository = statsRepository;
            _dnaRepository = dnaRepository;
        }

        public async Task<bool> Recruit(List<string> dna)
        {
            var isMutant = Recruiter
                .Build().
                IsMutant(dna.ToArray());

            if (isMutant)
                await this._statsRepository.IncrementMutantCount();
            else
                await this._statsRepository.IncrementHumanCount();

            await this._dnaRepository.SaveDna(new Dna(string.Join(",", dna), isMutant));
            return isMutant;
        }
    }
}
