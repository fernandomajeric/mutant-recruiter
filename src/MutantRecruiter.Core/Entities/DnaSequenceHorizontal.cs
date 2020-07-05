namespace MutantRecruiter.Core.Entities
{
    public class DnaSequenceHorizontal : DnaSequence
    {
        public DnaSequenceHorizontal(char[,] matrix, int lettersDnaCounter)
            : base(matrix, lettersDnaCounter)
        {
        }

        public override void AddPoint(Point point)
        {
            for (int i = 1; i < this.LettersDnaCounter; i++)
                this.ReferencePoints.Add(new Point(point.X, point.Y + i));
        }

        /// <summary>
        /// Sequence Manager for Horizontal
        /// </summary>
        /// <param name="currentPoint"></param>
        /// <returns></returns>
        public override bool IsNextSequenceMutant(Point currentPoint)
        {
            int i = currentPoint.X;
            int upperLimit = currentPoint.Y + this.LettersDnaCounter - 1;

            for (int j = currentPoint.Y; j < upperLimit; j++)
            {
                if (j + 1 >= MatrixLength)
                    return false;

                char dna = this.Matrix[i, j];
                char dnaNext = this.Matrix[i, j + 1];

                if (dna != dnaNext)
                    return false;
            }

            return true;
        }
    }
}
