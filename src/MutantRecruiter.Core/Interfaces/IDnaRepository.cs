using MutantRecruiter.Core.Entities;
using System.Threading.Tasks;

namespace MutantRecruiter.Core.Interfaces
{
    public interface IDnaRepository
    {
        Task SaveDna(Dna dna);
    }
}
