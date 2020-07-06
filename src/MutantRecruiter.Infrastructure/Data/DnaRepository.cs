using Microsoft.Extensions.Options;
using MutantRecruiter.Core.Common;
using MutantRecruiter.Core.Entities;
using MutantRecruiter.Core.Interfaces;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace MutantRecruiter.Infrastructure.Data
{
    public class DnaRepository : IDnaRepository
    {
        private readonly IOptions<ConnectionStringsSettings> configuration;

        public DnaRepository(IOptions<ConnectionStringsSettings> options)
        {
            this.configuration = options;
        }

        public Task SaveDna(Dna dna)
        {
            using ConnectionMultiplexer muxer = ConnectionMultiplexer.Connect(configuration.Value.RedisDb);
            IDatabase conn = muxer.GetDatabase();
            return conn.SetAddAsync(Guid.NewGuid().ToString(), JsonConvert.SerializeObject(dna));
        }
    }
}
