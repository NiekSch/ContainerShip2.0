using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Stack
    {
        public Container[] Containers { get; set; }

        public Stack(int height)
        {
            Containers = new Container[height];
        }

        public bool SpotAvalable(int height)
        {

        }

        private bool TooMuchWeightOnTop(int height)
        {

        }
        private bool ContainerOnTopOfValuable(int height)
        {

        }
        private bool SpaceReservedForValuableCooled(int height)
        {

        }
    }
}
