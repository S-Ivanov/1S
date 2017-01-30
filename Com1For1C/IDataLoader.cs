using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace Com1For1C
{
    /// <summary>
    /// Интерфейс COM-загрузчика данных
    /// </summary>
    [Guid("AC2275BD-D8E9-4EC5-988C-3BCE4E1E92BE")]
    public interface IDataLoader
    {
        [DispId(1)]
        int GetInt();

        [DispId(2)]
        void SetInt(int value);

        [DispId(3)]
        int IntValue { get; set; }

        [DispId(4)]
        string StrValue { get; set; }

        [DispId(5)]
        double DoubleValue { get; set; }

        [DispId(6)]
        DateTime DateTimeValue { get; set; }

        [DispId(7)]
        int[] IntArray { get; }

        [DispId(8)]
        int[] GetIntArray();

        [DispId(9)]
        object[] ObjectArray { get; }

        [DispId(10)]
        object[,] ObjectArray2 { get; }
    }
}
