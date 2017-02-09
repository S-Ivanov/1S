using System;
using System.Collections.Generic;
using System.Linq;

namespace DataSource
{
    public class ИсходныеДанные_Генератор : IИсходныеДанные
    {
        public int КоличествоКомпаний { get; set; }
        public int КоличествоПродукции { get; set; }

        public IEnumerable<КомпанияDTO> ПолучитьКомпании()
        {
            return Enumerable.Range(1, КоличествоКомпаний).Select(x => new КомпанияDTO { _IDRRef = Guid.NewGuid(), Код = x, Наименование = string.Format("Компания {0}", x) });
        }

        public IEnumerable<ПродукцияDTO> ПолучитьПродукцию(КомпанияDTO компания = null)
        {
            IEnumerable<КомпанияDTO> компании = компания == null ? ПолучитьКомпании() : new[] { компания };
            return компании
                .SelectMany(o => Enumerable.Range((o.Код - 1) * КоличествоПродукции + 1, КоличествоПродукции)
                    .Select(x => new ПродукцияDTO { _IDRRef = Guid.NewGuid(), Код = x, Наименование = string.Format("Продукция {0}-{1}", o.Код, x), Компания = o }));
        }
    }
}
