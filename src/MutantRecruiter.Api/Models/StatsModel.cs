using MutantRecruiter.Core.Entities;
using System.Text.Json.Serialization;

namespace MutantRecruiter.Api.Models
{
    public class StatsModel
    {
        [JsonPropertyName("count_mutant_dna")]
        public long MutantCount { get; set; }
        [JsonPropertyName("count_human_dna")]
        public long HumanCount { get; set; }
        [JsonPropertyName("ratio")]
        public double Ratio { get; set; }

        public static StatsModel ToModel(Stats stat)
        {
            return new StatsModel()
            {
                HumanCount = stat.HumanCount,
                MutantCount = stat.MutantCount,
                Ratio = stat.Ratio
            };
        }
    }
}
