using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests.ShipTests
{
    public class MaxWeightExceeded
    {
        [Fact]
        //max gewicht is 500. 10x30 <500
        public void ShouldPass_WeightBelowMaxShipWeight()
        {
            //arrange
            Ship ship = new Ship(3, 2, 3, 500);
            Container[] containers = new Container[10];
            for (int i = 0; i < 10; i++)
            {
                containers[i] = new Container(Container.ContainerType.Normal, 30);
            }
            bool expectedResult = true;

            //act
            bool actualResult = ship.PlaceContainers(containers);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //max gewicht is 500. 18x30 > 500
        public void ShouldPass_WeightAboveMaxShipWeight()
        {
            //arrange
            Ship ship = new Ship(3, 2, 3, 500);
            Container[] containers = new Container[18];
            for (int i = 0; i < 18; i++)
            {
                containers[i] = new Container(Container.ContainerType.Normal, 30);
            }
            bool expectedResult = false;

            //act
            bool actualResult = ship.PlaceContainers(containers);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
