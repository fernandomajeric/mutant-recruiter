using MutantRecruiter.Core.Constants;
using MutantRecruiter.Core.Entities;
using MutantRecruiter.Core.Utilities;
using System.Collections.Generic;

namespace MutantRecruiter.Core
{
    public class Recruiter
    {
        public bool IsMutant(string[] dna)
        {
            char[,] matrix = MatrixUtil.ConvertToMatrixAndValidate(dna);

            Guard.ThrowIfNullOrEmpty(dna, "Debe ingresar una cádena adn", nameof(dna));

            int mutantDnaCount = SearchMutantDna(matrix);

            return mutantDnaCount >= NitrogenousBaseConstants.DnaMutantCountRules.COUNT_MATCHS_TO_MUTANT;
        }

        private int SearchMutantDna(char[,] matrix)
        {
            List<DnaSequence> sequences = new List<DnaSequence>()
            {
                new DnaSequenceHorizontal(matrix,NitrogenousBaseConstants.DnaMutantCountRules.COUNT_DNA_TO_MUTANT),
                new DnaSequenceVertical(matrix,NitrogenousBaseConstants.DnaMutantCountRules.COUNT_DNA_TO_MUTANT),
                new DnaSequenceObliqueRightToLeft(matrix,NitrogenousBaseConstants.DnaMutantCountRules.COUNT_DNA_TO_MUTANT),
                new DnaSequenceObliqueLeftToRight(matrix,NitrogenousBaseConstants.DnaMutantCountRules.COUNT_DNA_TO_MUTANT),
            };

            int matrixLength = matrix.GetLength(0);
            int countMutantFound = 0;

            for (int i = 0; i < matrixLength; i++)
            {
                for (int j = 0; j < matrixLength; j++)
                {
                    Guard.ThrowIfNotValidDna(matrix[i, j], "Debe ingresar una cádena adn válida");

                    Point point = new Point(i, j);

                    foreach (var sequence in sequences)
                    {
                        if (sequence.ValidatePoint(point) && sequence.IsNextSequenceMutant(point))
                        {
                            sequence.AddPoint(point);
                            countMutantFound++;
                        }
                    }
                }
            }

            return countMutantFound;
        }

        public static Recruiter Build() => new Recruiter();
    }
}