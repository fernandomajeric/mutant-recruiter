namespace MutantRecruiter.Core.Entities
{
    public class DnaSequenceObliqueLeftToRight : DnaSequence
    {
        public DnaSequenceObliqueLeftToRight(char[,] matrix, int lettersDnaCounter)
            : base(matrix, lettersDnaCounter)
        {
        }

        public override void AddPoint(Point point)
        {
            for (int i = 1; i < this.LettersDnaCounter; i++)
                this.ReferencePoints.Add(new Point(point.X + i, point.Y - i));
        }

        public override bool IsNextSequenceMutant(Point currentPoint)
        {
            int j = currentPoint.Y;
            int upperLimit = currentPoint.X + this.LettersDnaCounter - 1;

            for (int i = currentPoint.X; i < upperLimit; i++)
            {
                if (i + 1 >= this.MatrixLength || j >= MatrixLength || j - 1 < 0)
                    return false;

                char dna = Matrix[i, j];
                char dnaNext = Matrix[i + 1, j - 1];

                if (dna != dnaNext)
                    return false;

                j--;
            }

            return true;
        }
    }
}
