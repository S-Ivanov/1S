using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataSource
{
    public interface IИсходныеДанные
    {
        IEnumerable<КомпанияDTO> ПолучитьКомпании();
        IEnumerable<ПродукцияDTO> ПолучитьПродукцию(КомпанияDTO компания = null);
    }
}
