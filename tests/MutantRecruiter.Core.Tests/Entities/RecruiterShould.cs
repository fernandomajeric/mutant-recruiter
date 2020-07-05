using FluentAssertions;
using MutantRecruiter.Core.Exceptions;
using System;
using Xunit;

namespace MutantRecruiter.Core.Tests
{
    public class RecruiterShould
    {
        private readonly Recruiter _sut;

        public RecruiterShould()
        {
            this._sut = new Recruiter();
        }

        [Fact]
        public void Throw_Error_Dna_Is_Null()
        {
            // Arrange
            string[] dnaChain = null;

            //Act
            Action act = () => _sut.IsMutant(dnaChain);

            //Assert
            act.Should()
             .Throw<ArgumentException>()
             .WithMessage("Debe ingresar una cádena adn (Parameter 'dna')");

        }

        [Fact]
        public void Throw_Error_Dna_Is_Empty()
        {
            // Arrange
            string[] dnaChain = new string[] { };

            //Act
            Action act = () => _sut.IsMutant(dnaChain);

            //Assert
            act.Should()
             .Throw<ArgumentException>()
             .WithMessage("Debe ingresar una cádena adn (Parameter 'dna')");

        }

        [Fact]
        public void Throw_Error_Dna_With_Letters_Not_Included_In_Nitrogenous_Base()
        {
            // Arrange
            string[] dnaChain = new string[] { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGTCA", "WCACTG" };

            //Act
            Action act = () => _sut.IsMutant(dnaChain);

            //Assert
            act.Should()
             .Throw<ArgumentException>()
             .WithMessage("Debe ingresar una cádena adn válida");
        }

        [Fact]
        public void Throw_Error_Dna_With_Diff_Col_Than_Rows_Is_Not_Matrix()
        {
            // Arrange
            string[] dnaChain = new string[] { "ATGCGA", "ATGCGA", "ATGCGA", "ATGCGA", "ATGCGA" };

            //Act
            Action act = () => _sut.IsMutant(dnaChain);

            //Assert
            act.Should()
             .Throw<DnaInvalidFormatException>()
             .WithMessage("El formato del ADN es inválido");
        }

        [Fact]
        public void Throw_Error_Dna_With_Differents_Lengths_Is_Not_Matrix()
        {
            // Arrange
            string[] dnaChain = new string[] { "ATGCGA", "ATGCGA", "ATCGA", "ATGCGA", "ACGA", "ATGCGA" };

            //Act
            Action act = () => _sut.IsMutant(dnaChain);

            //Assert
            act.Should()
             .Throw<DnaInvalidFormatException>()
               .WithMessage("El formato del ADN es inválido");
        }

        [Fact]
        public void Valid_Is_Human()
        {
            // Arrange
            string[] dnaChain = { "ATGCGA", "CAGTGC", "TTATTT", "AGACGG", "GCGCTA", "TCACTG" };

            //Act
            var result = this._sut.IsMutant(dnaChain);

            //Assert
            result.Should()
                .BeFalse();
        }

        [Fact]
        public void Valid_Is_Mutant()
        {
            // Arrange
            string[] dnaChain = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            //Act
            var result = this._sut.IsMutant(dnaChain);

            //Assert
            result.Should()
                .BeTrue();
        }

        [Fact]
        public void Valid_Horizontal_Is_Mutant()
        {
            // Arrange
            string[] dnaChain = new string[]
            {   "CCCCGA",
                "TTTTGC",
                "CGAGCT",
                "CTAAGG",
                "CGCCTA",
                "TCACTG"
            };

            //Act
            var result = this._sut.IsMutant(dnaChain);

            //Assert
            result.Should()
                .BeTrue();
        }

        [Fact]
        public void Valid_Vertical_Is_Mutant()
        {
            // Arrange
            string[] dnaChain = new string[]
            {   "CTGCGA",
                "CTGTGC",
                "CTATCT",
                "CTAAGG",
                "CGCCTA",
                "TCACTG"};

            //Act
            var result = this._sut.IsMutant(dnaChain);

            //Assert
            result.Should()
                .BeTrue();
        }

        [Fact]
        public void Valid_Oblique_Left_To_Right_Is_Mutant()
        {
            // Arrange
            string[] dnaChain = new string[] { "TTAAAA", "CAGTAC", "TTGAGT", "AGAAGG", "CCGCTA", "TCACTG" };

            //Act
            var result = this._sut.IsMutant(dnaChain);

            //Assert
            result.Should()
                .BeTrue();
        }

        [Fact]
        public void Valid_Oblique_Right_To_Left_Is_Mutant()
        {
            // Arrange
            string[] dnaChain = new string[]
           {
                "AGCCGA",
                "ACTTAC",
                "CTCACT",
                "CTACGG",
                "CGCTTA",
                "TGACCG"};

            //Act
            var result = this._sut.IsMutant(dnaChain);

            //Assert
            result.Should()
                .BeTrue();
        }
    }
}
