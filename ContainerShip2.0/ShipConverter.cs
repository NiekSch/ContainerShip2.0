using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0
{
    class ShipConverter
    {
        public string ConvertToUrl(Ship ship)
        {
            string url =
                $"https://i872272core.venus.fhict.nl/ContainerVisualizer/index.html?length={ship.Length}&width={ship.Width}&stacks=";
            for (int width = 0; width < ship.Width; width++)
            {
                for (int length = 0; length < ship.Length; length++)
                {
                    foreach (var container in ship.Stacks[length,width].Containers)
                    {
                        if (container != null)
                        {
                            url += Convert.ToInt32(container.Type).ToString();
                        }
                    }

                    url += ",";
                }
                url = url.Substring(0, url.Length - 1);
                url += "/";
            }
            url = url.Substring(0, url.Length - 1);
            url += "&weights=";
            for (int width = 0; width < ship.Width; width++)
            {
                for (int length = 0; length < ship.Length; length++)
                {
                    foreach (var container in ship.Stacks[length, width].Containers)
                    {
                        if (container != null)
                        {
                            url += container.Weight.ToString();
                            url += "-";
                        }
                    }
                    if (url.EndsWith("-"))
                    {
                        url = url.Substring(0, url.Length - 1);
                    }
                    url += ",";
                }
                url = url.Substring(0, url.Length - 1);
                url += "/";
            }
            url = url.Substring(0, url.Length - 1);
            return url;
        }
    }
}
