using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Dock dock = new Dock();
            Ship ship = new Ship(5,4,6,3600);
            ShipConverter converter = new ShipConverter();
            List<Container> containers = new List<Container>();
            for (int i = 0; i < 20; i++)
            {
                containers.Add(new Container(Container.ContainerType.Normal, 30));
                containers.Add(new Container(Container.ContainerType.Normal, 30));
                containers.Add(new Container(Container.ContainerType.Normal, 15));
            }
            for (int i = 0; i < 6; i++)
            {
                containers.Add(new Container(Container.ContainerType.Valuable, 30));
                containers.Add(new Container(Container.ContainerType.Valuable, 30));
                containers.Add(new Container(Container.ContainerType.Valuable, 15));
            }
            for (int i = 0; i < 6; i++)
            {
                containers.Add(new Container(Container.ContainerType.NormalCooled, 30));
            }
            for (int i = 0; i < 2; i++)
            {
                containers.Add(new Container(Container.ContainerType.ValuableCooled, 30));
            }
            containers.Add(new Container(Container.ContainerType.Normal, 15));
            dock.AddShip(ship);
            dock.PlaceContainers(containers.ToArray(), 1);
            string url = converter.ConvertToUrl(dock.Ships[0]);
            dock.OpenVisualizer(url);
            Console.Read();
        }
    }
}
