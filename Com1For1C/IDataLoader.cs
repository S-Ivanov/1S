using System;
using System.Collections;
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

        [DispId(11)]
        void InitData(int companies, int products);

        [DispId(12)]
        DataEnumerable GetCompanies(int maxCode);

        /// <summary>
        /// Получить комплексные данные
        /// </summary>
        /// <returns></returns>
        /// <example>
        /// МойОбъект = Новый COMОбъект("Com1For1C.DataLoader");
        /// Компании = МойОбъект.GetData();
        /// Для Каждого КомпанияДанные из Компании Цикл
        ///     Компания = Справочники.Компании.СоздатьЭлемент();
        ///     Компания.Код = КомпанияДанные.GetValue(0);
        ///     Компания.Наименование = КомпанияДанные.GetValue(1);
        ///     Компания.Записать();
        ///     
        ///     КомпанияСсылка = Компания.Ссылка;
        ///     
        ///     ПродукцияКомпании = КомпанияДанные.GetValue(2);
        ///     Для Каждого ПродукцияДанные из ПродукцияКомпании Цикл
        ///         Продукция = Справочники.Продукция.СоздатьЭлемент();
        ///         Продукция.Код = ПродукцияДанные.GetValue(0);
        ///         Продукция.Наименование = ПродукцияДанные.GetValue(1);
        ///         Продукция.Компания = КомпанияСсылка;
        ///         Продукция.Записать();
        ///     КонецЦикла;
        /// КонецЦикла;
        /// 
        /// Сообщить("Ok");
        /// </example>
        [DispId(13)]
        DataEnumerable GetData();
    }
}
