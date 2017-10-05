using System;
using System.Runtime.InteropServices;

namespace Com1For1C
{
    /// <summary>
    /// Интерфейс COM-загрузчика данных
    /// </summary>
    [Guid("AC2275BD-D8E9-4EC5-988C-3BCE4E1E92BE"),
        ComVisible(true)]
    public interface IDataLoader
    {
        [DispId(0x10000001)]
        int GetInt();
        [DispId(0x10000002)]
        void SetInt(int value);
        [DispId(0x10000003)]
        int IntValue { get; set; }
        [DispId(0x10000004)]
        string StrValue { get; set; }
        [DispId(0x10000005)]
        double DoubleValue { get; set; }
        [DispId(0x10000006)]
        DateTime DateTimeValue { get; set; }
        [DispId(0x10000007)]
        int[] IntArray { get; }
        [DispId(0x10000008)]
        int[] GetIntArray();
        [DispId(0x10000009)]
        object[] ObjectArray { get; }
        [DispId(0x1000000A)]
        object[,] ObjectArray2 { get; }
        [DispId(0x1000000B)]
        void InitData(int companies, int products);
        [DispId(0x1000000C)]
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
