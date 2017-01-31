using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

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
