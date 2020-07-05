using MutantRecruiter.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace MutantRecruiter.UnitTests.MutanteRecruiter.Core.Entities
{
    [TestFixture]
    public class HumanShould
    {
        private readonly Human _human;

        public HumanShould()
        {
            this._human = new Human();
        }

        [Test]
        public void Valid_Is_Mutant()
        {
            // Arrange
            List<string> dna = new List<string>
            {
                "ALALLA",
                "ALALAL"
            };

            this._human.Dna = new string[,] { { "ATGCGA", "CAGTGC" }, { "three", "four" }, { "five", "six" } };
            this._human.Dna = dna.ToArray();
            //Act

            //Assert
        }
    }
}