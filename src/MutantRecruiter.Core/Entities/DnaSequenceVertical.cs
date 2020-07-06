using MutantRecruiter.Core.Interfaces;

namespace MutantRecruiter.Core.Entities
{
    public class DnaSequenceVertical : DnaSequence
    {
        public DnaSequenceVertical(char[,] matrix, int lettersDnaCounter)
            : base(matrix, lettersDnaCounter)
        {
        }

        public override void AddPoint(Point point)
        {
            for (int i = 1; i < this.LettersDnaCounter; i++)
                this.ReferencePoints.Add(new Point(point.X + i, point.Y));
        }

        public override bool IsNextSequenceMutant(Point currentPoint)
        {
            int j = currentPoint.Y;
            int upperLimit = currentPoint.X + this.LettersDnaCounter - 1;

            for (int i = currentPoint.X; i < upperLimit; i++)
            {
                if (i + 1 >= this.MatrixLength)
                    return false;

                char dna = this.Matrix[i, j];
                char dnaNext = this.Matrix[i + 1, j];

                if (dna != dnaNext)
                    return false;
            }

            return true;
        }
    }
}
