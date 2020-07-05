using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MutantRecruiter.Api.Models
{
    public class RecruitModel
    {
        [JsonPropertyName("dna")]
        public List<string> Dna { get; set; }

        public RecruitModel()
        {
            this.Dna = new List<string>();
        }
    }
}
