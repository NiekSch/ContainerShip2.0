using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests
{
    public class StackTestsSpaceReservedForValuableCooled
    {
        [Fact]
        //er zijn nog 4 plekken boven deze dus hij is niet nodig
        public void ShouldPass_FirstContainerInFiveHighStack()
        {
            //arrange
            Stack stack = new Stack(0, new Container[5]);
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(0, 30, 1);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //er zijn geen plekken over maar deze zijn niet nodig want nrOfValuable is 0
        public void ShouldPass_FirstContainerInOneHighStack()
        {
            //arrange
            Stack stack = new Stack(0, new Container[1]);
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(0, 30, 0);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //er zijn geen plekken meer vrij hierna en er is een waardevolle maar dit is de 2e rij dus de container mag geplaats worden
        public void ShouldPass_FirstContainerInOneHighStackValuableInPreviousStack()
        {
            //arrange
            Stack stack = new Stack(1, new Container[1]);
            bool expectedResult = true;

            //act
            bool actualResult = stack.SpotAvalable(0, 30, 1);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //er zijn geen plekken meer vrij hierna en er is een waardevolle dus de container mag niet geplaatst worden
        public void ShouldFail_FirstContainerInOneHighStackWithValuable()
        {
            //arrange
            Stack stack = new Stack(0, new Container[1]);
            bool expectedResult = false;

            //act
            bool actualResult = stack.SpotAvalable(0, 30, 1);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //er zijn nog wel plekken vrij maar niet meer genoeg om een extra waardevolle container te plaatsen
        public void ShouldFail_TooMuchWeightToPlaceValuableOnTopOfContainer()
        {
            //arrange
            Stack stack = new Stack(0, new []
            {
                new Container(Container.ContainerType.Normal,30), new Container(Container.ContainerType.Normal, 30),
                new Container(Container.ContainerType.Normal,30),new Container(Container.ContainerType.Normal,30),
                null,null
            });
            bool expectedResult = false;

            //act
            bool actualResult = stack.SpotAvalable(4, 30, 1);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
