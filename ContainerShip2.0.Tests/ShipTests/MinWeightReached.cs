using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests.ShipTests
{
    public class MinWeightReached
    {
        [Fact]
        //min gewicht is 500/2 = 250. 10x30 > 250
        public void ShouldPass_WeightAboveMinShipWeight()
        {
            //arrange
            Ship ship = new Ship(3,2,3,500);
            Container[] containers = new Container[10];
            for (int i = 0; i < 10; i++)
            {
                containers[i] = new Container(Container.ContainerType.Normal,30);
            }
            bool expectedResult = true;

            //act
            bool actualResult = ship.PlaceContainers(containers);

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //min gewicht is 500/2 = 250. 5x30 > 250
        public void ShouldFail_WeightBelowMinShipWeight()
        {
            //arrange
            Ship ship = new Ship(3, 2, 3, 500);
            Container[] containers = new Container[5];
            for (int i = 0; i < 5; i++)
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
