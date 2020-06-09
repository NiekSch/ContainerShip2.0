using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Container
    {
        public int Weight { get; set; }
        public ContainerType Type { get; set; }
        public enum ContainerType
        {
            Normal = 1,
            Valuable = 2,
            NormalCooled = 3,
            ValuableCooled = 4
        }

        public Container(ContainerType type, int weight)
        {
            Weight = weight;
            Type = type;
        }

        public bool WeightIsWithinBoundarys()
        {
            if (Enumerable.Range(4,27).Contains(Weight))
            {
                return true;
            }

            return false;
        }
    }
}
