using System;

namespace MutantRecruiter.Core.Entities
{
    public class Stats
    {
        public long MutantCount { get; set; }
        public long HumanCount { get; set; }
        public double Ratio
        {
            get
            {
                var ratio = (HumanCount == 0) ? 0 : (double)MutantCount / HumanCount;
                return Math.Round(ratio, 2);
            }
        }
    }
}