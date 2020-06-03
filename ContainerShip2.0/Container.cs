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
    }
}
