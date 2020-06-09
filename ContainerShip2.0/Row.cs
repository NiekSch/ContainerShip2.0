using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Row
    {
        public int Id { get; set; }
        public bool Full => full;
        public Container[] Containers { get; set; }
        private bool full = false;

        public Row(int id, int length)
        {
            Id = id;
            Containers = new Container[length];
        }

        public Row(int id,Container[] containers)
        {
            Id = id;
            Containers = containers;
        }
        public bool SpotAvailable(int layer, Container.ContainerType type)
        {
            if (!ValuableClosedIn(layer,type))
            {
                return true;
            }

            return false;
        }

        private bool ValuableClosedIn(int layer, Container.ContainerType type)
        {
            if ((type == Container.ContainerType.Valuable || type == Container.ContainerType.ValuableCooled)&&ClosedInSelf(layer))
            {
                return true;
            }
            if (!ValuableToFrontClosedIn(layer) && !ValuableToRearClosedIn(layer))
            {
                return false;
            }

            return true;
        }

        private bool ValuableToFrontClosedIn(int layer)
        {
            if (layer < 2 || Containers[layer - 1] == null)
            {
                return false;
            }
            if (Containers[layer - 1].Type != Container.ContainerType.Valuable && Containers[layer - 1].Type != Container.ContainerType.ValuableCooled)
            {
                return false;
            }

            if (Containers[layer - 2] == null)
            {
                return false;
            }

            return true;
        }
        private bool ValuableToRearClosedIn(int layer)
        {
            if (layer > Containers.Length - 3 || Containers[layer + 1] == null)
            {
                return false;
            }
            if (Containers[layer + 1].Type != Container.ContainerType.Valuable && Containers[layer + 1].Type != Container.ContainerType.ValuableCooled)
            {
                return false;
            }
            if (Containers[layer + 2] == null)
            {
                return false;
            }

            return true;
        }

        private bool ClosedInSelf(int layer)
        {
            if (layer != 0 && layer != Containers.Length - 1 && Containers[layer - 1] != null &&
                Containers[layer + 1] != null)
            {
                return true;
            }

            return false;
        }

        //wordt niet meer gebruikt
        //public void CheckIfRowIsFull()
        //{
        //    bool filled = true;
        //    foreach (var container in Containers)
        //    {
        //        if (container == null)
        //        {
        //            filled = false;
        //        }
        //    }
        //    if (filled)
        //    {
        //        full = true;
        //    }
        //}
    }
}
