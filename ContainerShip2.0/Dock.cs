using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Dock
    {
        public List<Ship> Ships { get; } = new List<Ship>();

        public void PlaceContainers(Container[] containers, int shipNr)
        {
            containers = OrderContainer(containers);
            if (Ships.Count >= shipNr)
            {
                Ships[shipNr - 1].PlaceContainers(containers);
            }
        }

        public void AddShip(Ship ship)
        {
            Ships.Add(ship);
        }

        public void OpenVisualizer(string url)
        {
            System.Diagnostics.Process.Start(url);
        }
        // niet meer nodig, containers worden in het schip op type geselecteerd.
        private Container[] OrderContainer(Container[] containers)
        {
            return containers.OrderByDescending(x => x.Weight).ToArray();
        }
    }
}
