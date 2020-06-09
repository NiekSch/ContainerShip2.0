using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ContainerShip2._0;

namespace ContainerShip2._0.Tests
{
    public class RowTestsValuableToFrontClosedIn
    {
        [Theory]
        [ClassData(typeof(ValuableClosedInData))]
        public void ValuableClosedInTest(Row row, bool expectedResult)
        {
            //Arrange
            
            //Act
            bool actualResult = row.SpotAvailable(2,Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult,actualResult);
        }

        [Fact]
        public void ShouldFail_SecondValuableContainerClosedIn()
        {
            //Arrange
            Row row = new Row(1, new []{new Container(Container.ContainerType.Valuable,30), new Container(Container.ContainerType.Valuable, 30), null });
            bool expectedResult = false;
            //Act
            bool actualResult = row.SpotAvailable(2,Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldPass_SecondContainerIsStandard()
        {
            //Arrange
            Row row = new Row(1, new[] { new Container(Container.ContainerType.Normal, 30), new Container(Container.ContainerType.Normal, 30), null });
            bool expectedResult = true;
            //Act
            bool actualResult = row.SpotAvailable(2,Container.ContainerType.Normal);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldPass_NoOtherContainersInRow()
        {
            //Arrange
            Row row = new Row(1, new Container[3] );
            bool expectedResult = true;
            //Act
            bool actualResult = row.SpotAvailable(0,Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

    }
}
