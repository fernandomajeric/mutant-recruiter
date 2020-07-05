using MutantRecruiter.Core.Interfaces;
using System.Collections.Generic;

namespace MutantRecruiter.Core.Entities
{
    public abstract class DnaSequence : IDnaSequence
    {
        public char[,] Matrix;
        protected int LettersDnaCounter { get; set; }
        protected int MatrixLength { get; set; }
        protected List<Point> ReferencePoints { get; set; }

        public DnaSequence(char[,] matrix, int lettersDnaCounter)
        {
            this.LettersDnaCounter = lettersDnaCounter;
            this.Matrix = matrix;
            this.ReferencePoints = new List<Point>();
            this.MatrixLength = matrix.GetLength(0);
        }

        public virtual bool ValidatePoint(Point otherPoint)
        {
            foreach (var point in ReferencePoints)
            {
                if (point == otherPoint)
                    return false;
            }

            return true;
        }

        public abstract bool IsNextSequenceMutant(Point currentPoint);
        public abstract void AddPoint(Point point);
    }
}
