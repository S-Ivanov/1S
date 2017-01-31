using DataSource;
using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Com1For1C
{
    /// <summary>
    /// http://easyprog.ru/index.php?option=com_content&task=view&id=1452&Itemid=48
    /// </summary>
    [Guid("0D569C21-0DD4-4E14-8338-5B7A70CB0433"), ClassInterface(ClassInterfaceType.None)]
    public class DataLoader : IDataLoader
    {
        public DataLoader()
        {
            StrValue = "проверка";
            DoubleValue = 1.5;
            DateTimeValue = DateTime.Now;
        }

        public int IntValue
        {
            get
            {
                return intValue;
            }
            set
            {
                intValue = value;
            }
        }

        public string StrValue { get; set; }

        public double DoubleValue { get; set; }

        public DateTime DateTimeValue { get; set; }

        public int[] IntArray
        {
            get
            {
                return new[] { 0, 1, 2 };
            }
        }

        public int[] GetIntArray()
        {
            return new[] { 0, 1, 2 };
        }

        public object[] ObjectArray
        {
            get
            {
                return new object[] { 10, 1.5, DateTime.Now, "проверка" };
            }
        }

        public object[,] ObjectArray2
        {
            get
            {
                return new object[,]
                {
                    { "Целое",  "Вещ.",     "Дата",         "Строка",   "Булево"},
                    { 10,       1.5,        DateTime.Now,   "проверка", true },
                    { 20,       2.5,        DateTime.Now,   "test",     false },
                };
            }
        }

        public int GetInt()
        {
            return intValue;
        }

        public void SetInt(int value)
        {
            intValue = value;
        }

        int intValue = 10;

        ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
        {
            КоличествоКомпаний = 10,
            КоличествоПродукции = 10
        };

        public void InitData(int companies, int products)
        {
            исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companies,
                КоличествоПродукции = products
            };
        }

        public DataEnumerable GetCompanies(int maxCode)
        {
            return new DataEnumerable(
                исходныеДанные
                .ПолучитьКомпании()
                .Select(
                    company => new object[] 
                    {
                        maxCode + company.Код,
                        company.Наименование
                    }));
        }

        public DataEnumerable GetData()
        {
            return new DataEnumerable(
                исходныеДанные.ПолучитьКомпании()
                .Select(
                    company => new object[]
                    {
                        company.Код,
                        company.Наименование,
                        new DataEnumerable(
                            исходныеДанные.ПолучитьПродукцию(company)
                            .Select(
                                product => new object[]
                                {
                                    product.Код,
                                    product.Наименование
                                }))
                    }));
        }

    }
}
