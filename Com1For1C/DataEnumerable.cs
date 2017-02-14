using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace Com1For1C
{
    [ComVisible(true)]
    public class DataEnumerable : IEnumerable
    {
        public DataEnumerable(IEnumerable data)
        {
            this.data = data;
        }

        public IEnumerator GetEnumerator()
        {
            return data.GetEnumerator();
        }

        IEnumerable data;
    }
}
