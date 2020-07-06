using MutantRecruiter.Core.Entities;

namespace MutantRecruiter.Core.Interfaces
{
    /// <summary>
    /// Interface for Sequence Manager
    /// </summary>
    public interface IDnaSequence
    {
        /// <summary>
        /// Validate if the current Sequences is Mutant
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool IsNextSequenceMutant(Point currentPoint);
        /// <summary>
        /// Add Points without move next
        /// </summary>
        /// <param name="point"></param>
        public void AddPoint(Point point);
        /// <summary>
        /// Validate if already run this point
        /// </summary>
        /// <param name="point"></param>
        /// <returns></returns>
        public bool ValidatePoint(Point point);
    }
}