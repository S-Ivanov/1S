using DataSource;
using System;
using System.Configuration;
using System.Linq;
using System.Runtime.InteropServices;
using V83;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["количествоКомпаний"]) || string.IsNullOrEmpty(ConfigurationManager.AppSettings["количествоПродукции"]))
            {
                Console.WriteLine("Ошибка конфигурации источника данных.");
                goto Exit;
            }

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = int.Parse(ConfigurationManager.AppSettings["количествоКомпаний"]),
                КоличествоПродукции = int.Parse(ConfigurationManager.AppSettings["количествоПродукции"])
            };

            var продукция = исходныеДанные.ПолучитьПродукцию().ToList();
            if (продукция.Count == 0)
            {
                Console.WriteLine("Отсутствуют данные о продукции.");
                goto Exit;
            }

            var компанииПродукция = 
                from x in продукция
                group x by x.Компания;

            DateTime start = DateTime.Now;

            COMConnector comConnector = null;
            dynamic v8_base, newCompany, newProduct;
            try
            {
                comConnector = new COMConnector();
                // емкость пула COM-соединений с 1С
                //comConnector.PoolCapacity = 10;
                // время хранения в пуле COM-соединений с 1С
                //comConnector.PoolTimeout = 60;
                comConnector.MaxConnections = 2;

                string каталогБД = ConfigurationManager.AppSettings["каталогБД"];
                Console.WriteLine("Добавление {0} записей в БД \"{1}\"", 
                    исходныеДанные.КоличествоКомпаний + исходныеДанные.КоличествоКомпаний * исходныеДанные.КоличествоПродукции, 
                    каталогБД);
                v8_base = comConnector.Connect(string.Format("File=\"{0}\"", каталогБД));

                int компанииМаксКод = GetMaxCode(v8_base, "Справочник.Компании");
                int продукцияМаксКод = GetMaxCode(v8_base, "Справочник.Продукция");

                foreach (var company in компанииПродукция)
                {
                    var компания = company.Key;

                    newCompany = v8_base.Справочники.Компании.СоздатьЭлемент();
                    newCompany.Код = компанииМаксКод + компания.Код;
                    newCompany.Наименование = компания.Наименование;
                    newCompany.Записать();
                    object ссылка = newCompany.Ссылка;

                    foreach (var product in company)
                    {
                        newProduct = v8_base.Справочники.Продукция.СоздатьЭлемент();
                        newProduct.Код = продукцияМаксКод + product.Код;
                        newProduct.Наименование = product.Наименование;
                        // ссылка на родительскую запись
                        newProduct.Компания = ссылка;
                        newProduct.Записать();
                    }
                }
            }
            finally
            {
                newProduct = null;
                newCompany = null;
                v8_base = null;

                if (comConnector != null)
                {
                    Marshal.FinalReleaseComObject(comConnector);
                    comConnector = null;
                    GC.Collect();
                }

                Console.WriteLine("Время выполнения: {0}", DateTime.Now - start);
            }

            Exit:
            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }

        static int GetMaxCode(dynamic v8_base, string tableName)
        {
            dynamic v8_Query, v8_QueryResult;
            try
            {
                v8_Query = v8_base.NewObject("Запрос", "ВЫБРАТЬ МАКСИМУМ(Код) КАК МаксКод ИЗ " + tableName);
                v8_QueryResult = v8_Query.Выполнить().Выбрать();
                v8_QueryResult.Следующий();
                return v8_QueryResult.МаксКод.GetType() == typeof(int) ? (int)v8_QueryResult.МаксКод : 0;
            }
            finally
            {
                v8_QueryResult = null;
                v8_Query = null;
            }
        }
    }
}
