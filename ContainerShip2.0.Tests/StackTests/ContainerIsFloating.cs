using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests
{
    public class StackTestsContainerIsFloating
    {
        [Fact]
        public void ShouldPass_ContainerPlacedOnGround()
        {
            //arrange
            Stack stack = new Stack(1,new Container[4]);
            bool expectedResult=true;

            //act
            bool actualResult = stack.SpotAvalable(0, 30, 0);

            //assert
            Assert.Equal(expectedResult,actualResult);
        }
        [Fact]
        public void ShouldPass_ContainerDirectlyUnderneath()
        {
            //arrange
            Stack stack = new Stack(1, new []{new Container(Container.ContainerType.Normal,30),null });
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(1, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void ShouldFail_NoContainerDirectlyUnderneath()
        {
            //arrange
            Stack stack = new Stack(1, new[] { new Container(Container.ContainerType.Normal, 30),null, null });
            bool expectedResult = false;

            //act
            bool actualResult = stack.SpotAvalable(2, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
