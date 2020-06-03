using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Ship
    {
        public Row[] Rows { get; set; }
        public Stack[] Stacks { get; set; }
        public Layer[] Layers { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int MaxWeight { get; set; }
        public int MinWeight { get; set; }
        private int nrOfValuableCooled;

        public Ship(int height, int width, int length, int maxWeight)
        {
            Rows = new Row[height*width];
            Stacks = new Stack[length*width];
            Layers = new Layer[length];
            Height = height;
            Width = width;
            Length = length;
            MaxWeight = maxWeight;
            MinWeight = maxWeight / 2;
        }

        public void PlaceContainers(Container[] containers)
        {
            nrOfValuableCooled = containers.Count(x => x.Type == Container.ContainerType.ValuableCooled);
            int[] order = new[] {3,1,4,2};
            for (int type = 0; type < 4; type++)
            {
                List<Container> selectedContainers = containers.Where(x => Convert.ToInt32(x.Type) == order[type]).ToList();
                PlaceSelection(selectedContainers, order[type]);
            }
        }

        private void PlaceSelection(List<Container> containers, int type)
        {
            foreach (var container in containers)
            {
                switch (type)
                {
                    case 1:
                        PlaceType1And2(container);
                        break;
                    case 2:
                        PlaceType1And2(container);
                        break;
                    case 3:
                        PlaceType3And4(container);
                        break;
                    case 4:
                        PlaceType3And4(container);
                        break;

                }
            }
        }

        private void PlaceType1And2(Container container)
        {
            for (int height = 0; height < Height; height++)
            {
                foreach (var stack in Stacks)
                {
                    if (stack.Containers[height] == null)
                    {

                    }
                }
            }
        }

    }
}
