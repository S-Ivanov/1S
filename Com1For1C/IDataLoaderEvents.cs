using System;
using System.Runtime.InteropServices;

namespace Com1For1C
{
    [Guid("3FFA5DFA-ED70-4E68-8297-3800DFDF628E"),
        ComVisible(true),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface IDataLoaderEvents
    {
        [DispId(0x00000001)]
        void OnDataLoaded(int code1, int code2);
    }
}
