using DataSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace DataGeneratorXML
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Генерация данных для тестирования 1С. Запись в XML-файл.");

            Console.Write("Количество компаний: ");
            int companyCount = int.Parse(Console.ReadLine());
            Console.Write("Количество продукции: ");
            int productCount = int.Parse(Console.ReadLine());
            Console.Write("Файл данных: ");
            string xmlFile = Console.ReadLine();

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companyCount,
                КоличествоПродукции = productCount
            };
            var products = исходныеДанные.ПолучитьПродукцию().ToList();
            var companies = products.GroupBy(p => p.Компания);

            Данные данные = new Данные
            {
                Компания = companies.Select(
                    g => new ДанныеКомпания
                    {
                        код = g.Key.Код,
                        наименование = g.Key.Наименование,
                        Продукция = g.Select(
                            p => new ДанныеКомпанияПродукция
                            {
                                код = p.Код,
                                наименование = p.Наименование
                            }).ToArray()
                    }).ToArray()
            };

            using (TextWriter writer = new StreamWriter(xmlFile))
            {
                (new XmlSerializer(typeof(Данные))).Serialize(writer, данные);
            }

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
