namespace MutantRecruiter.Core.Constants
{
    public class NitrogenousBaseConstants
    {
        public static class Letters
        {
            public const char A = 'A';
            public const char T = 'T';
            public const char C = 'C';
            public const char G = 'G';
        }

        public static string LettersIncluded = string.Concat(
            Letters.A,
            Letters.T,
            Letters.C,
            Letters.G
        );

        public static class DnaMutantCountRules
        {
            public const int COUNT_DNA_TO_MUTANT = 4;
            public const int COUNT_MATCHS_TO_MUTANT = 2;
        }
    }
}
