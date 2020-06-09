using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests
{
    public class StackTestsTooMuchWeightOnTop
    {
        [Fact]
        public void ShouldPass_SingleContainerInRow()
        {
            //arrange
            Stack stack = new Stack(1, new Container[4]);
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(0, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        // max gewicht op 1 container is 120 ton, 3x 30 = 90.  er mag nog een volle container op
        public void ShouldPass_FourMaxWeightContainersInStack()
        {
            //arrange
            Stack stack = new Stack(1, new []
            {
                new Container(Container.ContainerType.Normal, 30), new Container(Container.ContainerType.Normal, 30),
                new Container(Container.ContainerType.Normal, 30),new Container(Container.ContainerType.Normal, 30),
                null
            });
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(4, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        // max gewicht op 1 container is 120 ton, 4x 25 = 100.  er mag nog een container van max 20 ton op
        public void ShouldPass_FiveTwentyFiveTonContainersContainersInStack()
        {
            //arrange
            Stack stack = new Stack(1, new[]
            {
                new Container(Container.ContainerType.Normal, 25), new Container(Container.ContainerType.Normal, 25),
                new Container(Container.ContainerType.Normal, 25),new Container(Container.ContainerType.Normal, 25),
                new Container(Container.ContainerType.Normal, 25),null
            });
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(5, 20, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        // max gewicht op 1 container is 120 ton, 4x 25 = 100.  er mag geen container van 30 ton op
        public void ShouldFail_FiveTwentyFiveTonContainersContainersInStack()
        {
            //arrange
            Stack stack = new Stack(1, new[]
            {
                new Container(Container.ContainerType.Normal, 25), new Container(Container.ContainerType.Normal, 25),
                new Container(Container.ContainerType.Normal, 25),new Container(Container.ContainerType.Normal, 25),
                new Container(Container.ContainerType.Normal, 25),null
            });
            bool expectedResult = false;

            //act
            bool actualResult = stack.SpotAvalable(5, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        // max gewicht op 1 container is 120 ton, 4x 30 = 120.  er mag geen container meer op
        public void ShouldFail_FiveMaxWeightContainersInStack()
        {
            //arrange
            Stack stack = new Stack(1, new[]
            {
                new Container(Container.ContainerType.Normal, 30), new Container(Container.ContainerType.Normal, 30),
                new Container(Container.ContainerType.Normal, 30),new Container(Container.ContainerType.Normal, 30),
                new Container(Container.ContainerType.Normal, 30), null
            });
            bool expectedResult = false;

            //act
            bool actualResult = stack.SpotAvalable(5, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
