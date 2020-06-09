using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContainerShip2._0.Tests
{
    class RowData
    {
    }

    public class ValuableClosedInData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Row(1,
                    new Container[]{new Container(Container.ContainerType.Valuable,30),
                        new Container(Container.ContainerType.Valuable,30),
                        null
                    }),
                false
            };
            yield return new object[]
            {
                new Row(2,
                    new Container[]
                    {
                        new Container(Container.ContainerType.Valuable, 30),
                        new Container(Container.ContainerType.Normal,30),
                        null
                    }),
                true
            };
            yield return new object[]
            {
                new Row(3,
                    new Container[]
                    {
                        null,
                        new Container(Container.ContainerType.Valuable, 30),
                        null
                    }),
                true
            };
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
