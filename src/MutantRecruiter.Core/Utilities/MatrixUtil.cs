using MutantRecruiter.Core.Exceptions;
using System;

namespace MutantRecruiter.Core.Utilities
{
    public static class MatrixUtil
    {
        public static char[,] ConvertToMatrixAndValidate(string[] value)
        {
            char[,] matrix = null;

            if (value != null)
            {
                var longMatrix = value.Length;

                matrix = new char[longMatrix, longMatrix];
                
                for (int i = 0; i < longMatrix; i++)
                {
                    if (value[i].Length != longMatrix) throw new DnaInvalidFormatException();
                    
                    for (int j = 0; j < value[i].Length; j++)
                    {
                        matrix[i, j] = value[i][j];
                    }
                }
            }

            return matrix;
        }
    }
}
