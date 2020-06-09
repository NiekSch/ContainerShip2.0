using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests
{
    public class RowTestsClosedInSelf
    {
        [Fact]
        public void ShouldFail_ValuableContainerPlacedBetweenTwoContainers()
        {
            //Arrange
            Row row = new Row(1, new[] { new Container(Container.ContainerType.Valuable, 30), null, new Container(Container.ContainerType.Valuable, 30), });
            bool expectedResult = false;
            //Act
            bool actualResult = row.SpotAvailable(1, Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldPass_NormalContainerPlacedBetweenTwoContainers()
        {
            //Arrange
            Row row = new Row(1, new[] { new Container(Container.ContainerType.Valuable, 30), null, new Container(Container.ContainerType.Valuable, 30), });
            bool expectedResult = true;
            //Act
            bool actualResult = row.SpotAvailable(1, Container.ContainerType.Normal);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
