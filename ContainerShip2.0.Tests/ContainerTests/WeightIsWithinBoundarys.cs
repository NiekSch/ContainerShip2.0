using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests
{
    public class ContainerTestsWeightIsWithinBoundarys
    {
        [Fact]
        public void ShouldPass_WeightIsFourTons()
        {
            //arrange
            Container container = new Container(Container.ContainerType.Normal,4);
            bool expectedResult = true;

            //act
            bool actualResult = container.WeightIsWithinBoundarys();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldPass_WeightIsThirtyTons()
        {
            //arrange
            Container container = new Container(Container.ContainerType.Normal, 30);
            bool expectedResult = true;

            //act
            bool actualResult = container.WeightIsWithinBoundarys();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldFail_WeightIsTooLow()
        {
            //arrange
            Container container = new Container(Container.ContainerType.Normal, 3);
            bool expectedResult = false;

            //act
            bool actualResult = container.WeightIsWithinBoundarys();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldFail_WeightIsTooHigh()
        {
            //arrange
            Container container = new Container(Container.ContainerType.Normal, 31);
            bool expectedResult = false;

            //act
            bool actualResult = container.WeightIsWithinBoundarys();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
