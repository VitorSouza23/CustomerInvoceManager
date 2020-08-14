using CustomerInvoiceManager.Entities;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomerInvoceManager.UnitTests.Domain.Entities.Tests.ContractTests
{
    public class GetFirstDateTests
    {
        [Theory]
        [MemberData(nameof(CriaDatasValidasDadoParametrosQueCompoemUmaDataValidaParameters))]
        public void CriaDatasValidasDadoParametrosQueCompoemUmaDataValida(int startYear, Month startMonth, int bilingStartDay, DateTime expectedDate)
        {
            //Arrange
            Contract contract = new Contract { StartYear = startYear, StartMonth = startMonth, BilingStyartDay = bilingStartDay };

            //Act
            DateTime returnedValue = contract.GetFirstDate();

            //Assert
            returnedValue.Should().Be(expectedDate);
        }

        public static IEnumerable<object[]> CriaDatasValidasDadoParametrosQueCompoemUmaDataValidaParameters()
        {
            yield return new object[] { 1, Month.January, 1, new DateTime(1, 1, 1) };
            yield return new object[] { 2000, Month.December, 25, new DateTime(2000, 12, 25) };
            yield return new object[] { 2020, Month.February, 29, new DateTime(2020, 2, 29) };
        }

        [Fact]
        public void LancaExcecaoDeArgumentoForaDoRangeDadoParametrosQueResultamNumaDatainvalida()
        {
            //Arrange
            Contract contract = new Contract { StartYear = 2000, StartMonth = Month.February, BilingStyartDay = 30 };

            //Act
            //Assert
            contract.Invoking(c => c.GetFirstDate())
                .Should().Throw<ArgumentOutOfRangeException>();

        }
    }
}
