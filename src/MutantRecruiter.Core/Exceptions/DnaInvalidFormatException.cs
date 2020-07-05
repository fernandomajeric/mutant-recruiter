using System;

namespace MutantRecruiter.Core.Exceptions
{
    public class DnaInvalidFormatException : Exception
    {
        public DnaInvalidFormatException()
            : base("El formato del ADN es inválido")
        {
        }
    }
}
