using MutantRecruiter.Core.Constants;
using System;

namespace MutantRecruiter.Core.Utilities
{
    public static class Guard
    {
        public static void ThrowIfNullOrEmpty(string[] argumentValue, string message, string parameterName)
        {
            if (argumentValue == null) throw new ArgumentException(message, parameterName);
            if (argumentValue.Length == 0) throw new ArgumentException(message, parameterName);
        }

        public static void ThrowIfNotValidDna(char letter, string message)
        {
            if (!NitrogenousBaseConstants.LettersIncluded.Contains(letter)) throw new ArgumentException(message);
        }
    }
}