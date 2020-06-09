using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    public class Ship
    {
        public Row[] Rows { get; set; }
        public Stack[,] Stacks { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int Length { get; set; }
        public int MaxWeight { get; set; }
        public int MinWeight { get; set; }
        private int nrOfValuable;
        private int totalWeight = 0;

        public enum balance
        {
            Center = 0,
            Left = 1,
            Right = 2
        }

        public Ship(int height, int width, int length, int maxWeight)
        {
            Rows = new Row[height*width];
            Stacks = new Stack[length,width];
            Height = height;
            Width = width;
            Length = length;
            MaxWeight = maxWeight;
            MinWeight = maxWeight / 2;
            CreateStacksAndRows();
        }

        private void CreateStacksAndRows()
        {
            for (int y = 0; y < Length; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Stacks[y,x]= new Stack(y*Width+x,Height);
                }
            }
            for (int id = 0; id < Rows.Length; id++)
            {
                Rows[id] = new Row(id,Length);
            }
        }

        public bool PlaceContainers(Container[] containers)
        {
            nrOfValuable = containers.Count(x => x.Type == Container.ContainerType.ValuableCooled || x.Type==Container.ContainerType.Valuable);
            int[] order = new[] {3,1,4,2};
            bool everythingPlaced = true;
            for (int type = 0; type < 4; type++)
            {
                List<Container> selectedContainers = containers.Where(x => Convert.ToInt32(x.Type) == order[type]).ToList();
                bool selectionPlaced = PlaceSelection(selectedContainers, order[type]);
                if (!selectionPlaced)
                {
                    everythingPlaced = false;
                }
            }

            if (!MinWeightReached())
            {
                Console.WriteLine($"Ship weight is {totalWeight}, minimal weight has not been reached.");
                return false;
            }

            if (!everythingPlaced)
            {
                return false;
            }

            return true;
        }

        private bool PlaceSelection(List<Container> containers, int type)
        {
            int notPlaced = 0;
            foreach (var container in containers)
            {
                CountTotalWeight();
                if (!MaxWeightExceeded(container))
                {
                    switch (type)
                    {
                        case 1:
                            PlaceNormal(container);
                            break;
                        case 2:
                            PlaceNormal(container);
                            break;
                        case 3:
                            PlaceCooled(container);
                            break;
                        case 4:
                            PlaceCooled(container);
                            break;

                    }
                }
                else
                {
                    notPlaced++;
                }
            }

            if (notPlaced > 0)
            {
                Console.WriteLine($"MaxWeight reached, {notPlaced} nr of containers haven not been placed.");
                return false;
            }

            return true;
        }

        private void PlaceNormal(Container container)
        {
            bool placed = false;
            for (int height = 0; height < Height; height++)
            {
                if (placed) { break; }
                for (int y = 0; y < Length; y++)
                {
                    if (placed) { break; }
                    for (int x = 0; x < Width; x++)
                    {
                        if (ShipBalance() == balance.Left)
                        {
                            x = Width - 1 - x;
                        }
                        // layer en row zijn nodig voor het checken van en plaatsen in de row
                        int layer = Stacks[y,x].Id / Width;
                        int rowId = Stacks[y, x].Id - (layer * Width) + height * Width;
                    
                        if (Stacks[y, x].Containers[height] == null)
                        {
                            if (Stacks[y, x].SpotAvalable(height, container.Weight, nrOfValuable)&&Rows[rowId].SpotAvailable(layer,container.Type))
                            {
                                Stacks[y, x].Containers[height] = container;
                                Rows[rowId].Containers[layer] = container;
                                placed = true;
                                break;
                            }
                        }
                    }
                }
                
            }
            if (!placed) { Console.WriteLine($"Container not placed. Type: {container.Type}  Weight: {container.Weight}"); }
        }
        private void PlaceCooled(Container container)
        {
            bool placed = false;
            for (int height = 0; height < Height; height++)
            {
                if (placed) { break;}
                // alleen stacks aan de voorkant van het schip
                for (int x = 0; x < Width; x++)
                {
                    // layer en row zijn nodig voor het checken van en plaatsen in de row
                    int layer = Stacks[0, x].Id / Width;
                    int rowId = Stacks[0, x].Id - (layer * Width) + height * Width;
                    //als de linkerzijde van het schip zwaarder is moet de containers rechts geplaatst worden.
                    if (ShipBalance() == balance.Left)
                    {
                        x = Width - 1 - x;
                    }
                    if (Stacks[0,x].Containers[height]==null)
                    {
                        if (Stacks[0,x].SpotAvalable(height,container.Weight,nrOfValuable)&&Rows[rowId].SpotAvailable(layer,container.Type))
                        {
                            Stacks[0,x].Containers[height] = container;
                            Rows[rowId].Containers[layer] = container;
                            placed = true;
                            break;
                        }
                    }
                }
            }
            if (!placed) { Console.WriteLine($"Container not placed. Type: {container.Type}  Weight: {container.Weight}");}
        }

        public balance ShipBalance()
        {
            CountTotalWeight();
            int rowsToBalance = Width - (Width % 2);
            List<int> rows = new List<int>();
            for (int i = 0; i < rowsToBalance / 2; i++)
            {
                rows.Add(i);
                rows.Add(Width - 1 - i);
            }
            int leftWeight = 0;
            int rightWeight = 0;

            foreach (var x in rows)
            {
                for (int y = 0; y < Length; y++)
                {
                    foreach (var container in Stacks[y,x].Containers)
                    {
                        if (x<Width/2&&container!=null)
                        {
                            leftWeight += container.Weight;
                        }
                        else if(container != null)
                        {
                            rightWeight += container.Weight;
                        }
                    }
                }
            }
            
            //als het verschil tussen de rechter en linkerhelft minder dan of 20% van het totaal gewicht is is het in orde.
            if (Math.Abs(leftWeight - rightWeight) <= (totalWeight * 0.2)||totalWeight==0)
            {
                return balance.Center;
            }

            if (leftWeight > rightWeight)
            {
                return balance.Left;
            }

            return balance.Right;
        }

        private void CountTotalWeight()
        {
            totalWeight = 0;
            foreach (var stack in Stacks)
            {
                foreach (var container in stack.Containers)
                {
                    if (container != null)
                    {
                        totalWeight += container.Weight;
                    }
                }
            }
        }

        private bool MaxWeightExceeded(Container container)
        {
            if (totalWeight + container.Weight > MaxWeight)
            {
                return true;
            }

            return false;
        }

        private bool MinWeightReached()
        {
            if (totalWeight > MinWeight)
            {
                return true;
            }

            return false;
        }

    }
}
