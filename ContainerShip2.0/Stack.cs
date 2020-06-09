using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Stack
    {
        public int Id { get; }
        public Container[] Containers { get; set; }

        public Stack(int id, int height)
        {
            Containers = new Container[height];
            Id = id;
        }

        public Stack(int id, Container[] containers)
        {
            Containers = containers;
            Id = id;
        }

        public bool SpotAvalable(int height, int weight, int nrOfValuable)
        {
            if (!ContainerIsFloating(height) && !TooMuchWeightOnTop(weight) && !ContainerOnTopOfValuable(height) &&
                !SpaceReservedForValuableCooled(height,nrOfValuable,weight))
            {
                return true;
            }
            return false;
        }

        private bool TooMuchWeightOnTop(int weight)
        {
            int totalWeight = 0;
            for (int y = 1; y <Containers.Length; y++)
            {
                if (Containers[y] != null)
                {
                    totalWeight += Containers[y].Weight;
                }
            }

            if (totalWeight + weight > 120)
            {
                return true;
            }

            return false;
        }
        private bool ContainerOnTopOfValuable(int height)
        {
            if (height == 0 || (Containers[height - 1].Type != Container.ContainerType.Valuable && Containers[height - 1].Type != Container.ContainerType.ValuableCooled))
            {
                return false;
            }

            return true;
        }
        private bool SpaceReservedForValuableCooled(int height, int nrOfValuable, int weight)
        {
            //als er plek is voor nog een volle waardevolle container op de stapel of als deze plek niet nodig is
            if ((height < Containers.Length-1 && !TooMuchWeightOnTop(weight + 30)) || nrOfValuable <= Id)
            {
                return false;
            }

            return true;
        }

        private bool ContainerIsFloating(int height)
        {
            if (height == 0 || Containers[height - 1] != null)
            {
                return false;
            }

            return true;
        }

    }
}
