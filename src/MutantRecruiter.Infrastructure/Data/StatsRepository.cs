using Microsoft.Extensions.Options;
using MutantRecruiter.Core.Common;
using MutantRecruiter.Core.Entities;
using MutantRecruiter.Core.Interfaces;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace MutantRecruiter.Infrastructure.Data
{
    public class StatsRepository : IStatsRepository
    {
        readonly IOptions<ConnectionStringsSettings> configuration;

        public StatsRepository(IOptions<ConnectionStringsSettings> options)
        {
            this.configuration = options;
        }

        public Stats GetStats()
        {
            using ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(configuration.Value.RedisDb);
            IDatabase conn = muxer.GetDatabase();

            var countHumanDna = conn.StringGet("count_human_dna");
            var countMutantDna = conn.StringGet("count_mutant_dna");

            var entity = new Stats
            {
                HumanCount = countHumanDna.HasValue ? (long)countHumanDna : 0,
                MutantCount = countMutantDna.HasValue ? (long)countMutantDna : 0,
            };

            return entity;
        }

        public Task<long> IncrementHumanCount()
        {
            using ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(configuration.Value.RedisDb);
            IDatabase conn = muxer.GetDatabase();
            return conn.StringIncrementAsync("count_human_dna");
        }

        public Task<long> IncrementMutantCount()
        {
            using ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(configuration.Value.RedisDb);
            IDatabase conn = muxer.GetDatabase();
            return conn.StringIncrementAsync("count_mutant_dna");
        }
    }
}
