using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContainerShip2._0.Tests.ShipTests
{
    public class ShipBalance
    {
        [Fact]
        //3 containers van 30 ton op eerste rij. links en recht is gelijk.
        public void ShouldBeCenter_LeftAndRightEqualWeight()
        {
            //arrange
            Ship ship = new Ship(3, 3, 3, 500);
            for (int x = 0; x < ship.Width; x++)
            {
                ship.Stacks[0,x].Containers[0] = new Container(Container.ContainerType.Normal,30);
            }
            Ship.balance expectedResult = Ship.balance.Center;

            //act
            Ship.balance actualResult = ship.ShipBalance();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //3 containers van 20 ton links, 2 containers van 20 ton rechts.  60/40 mag.
        public void ShouldBeCenter_LeftAndRightTwentyPercentDifference()
        {
            //arrange
            Ship ship = new Ship(3, 3, 3, 500);
            ship.Stacks[0, 0].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            ship.Stacks[1, 0].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            ship.Stacks[2, 0].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            ship.Stacks[0, 2].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            ship.Stacks[1, 2].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            Ship.balance expectedResult = Ship.balance.Center;

            //act
            Ship.balance actualResult = ship.ShipBalance();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //3 containers van 21 ton links, 2 containers van 20 ton rechts.  63/40 mag niet.
        public void ShouldBeLeft_LeftAndRightMoreThanTwentyPercentDifference()
        {
            //arrange
            Ship ship = new Ship(3, 3, 3, 500);
            ship.Stacks[0, 0].Containers[0] = new Container(Container.ContainerType.Normal, 21);
            ship.Stacks[1, 0].Containers[0] = new Container(Container.ContainerType.Normal, 21);
            ship.Stacks[2, 0].Containers[0] = new Container(Container.ContainerType.Normal, 21);
            ship.Stacks[0, 2].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            ship.Stacks[1, 2].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            Ship.balance expectedResult = Ship.balance.Left;

            //act
            Ship.balance actualResult = ship.ShipBalance();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        //3 containers van 21 ton rechts, 2 containers van 20 ton links.  40/63 mag niet.
        public void ShouldBeRight_LeftAndRightMoreThanTwentyPercentDifference()
        {
            //arrange
            Ship ship = new Ship(3, 3, 3, 500);
            ship.Stacks[0, 2].Containers[0] = new Container(Container.ContainerType.Normal, 21);
            ship.Stacks[1, 2].Containers[0] = new Container(Container.ContainerType.Normal, 21);
            ship.Stacks[2, 2].Containers[0] = new Container(Container.ContainerType.Normal, 21);
            ship.Stacks[0, 0].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            ship.Stacks[1, 0].Containers[0] = new Container(Container.ContainerType.Normal, 20);
            Ship.balance expectedResult = Ship.balance.Right;

            //act
            Ship.balance actualResult = ship.ShipBalance();

            //assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
