using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests
{
    public class RowTestsValuableToRearClosedIn
    {
        [Fact]
        public void ShouldPass_OnlyOneContainerBehind()
        {
            //Arrange
            Row row = new Row(1, new[] { null, new Container(Container.ContainerType.Valuable, 30) });
            bool expectedResult = true;
            //Act
            bool actualResult = row.SpotAvailable(0, Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldPass_TwoNormalContainersBehind()
        {
            //Arrange
            Row row = new Row(1, new[] { null, new Container(Container.ContainerType.Normal, 30), new Container(Container.ContainerType.Normal, 30) });
            bool expectedResult = true;
            //Act
            bool actualResult = row.SpotAvailable(0, Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldFail_TwoValuableContainersBehind()
        {
            //Arrange
            Row row = new Row(1, new[] { null, new Container(Container.ContainerType.Valuable, 30), new Container(Container.ContainerType.Valuable, 30) });
            bool expectedResult = false;
            //Act
            bool actualResult = row.SpotAvailable(0, Container.ContainerType.Valuable);
            //Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
