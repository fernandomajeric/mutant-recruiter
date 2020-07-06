namespace MutantRecruiter.Core.Entities
{
    public class Dna
    {
        public string Data { get; set; }
        public bool IsMutant { get; set; }

        public Dna(string data, bool isMutant)
        {
            this.Data = data;
            this.IsMutant = isMutant;
        }
    }
}
