using DataSource;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace DataGeneratorJSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Генерация данных для тестирования 1С. Запись в JSON-файл.");

            Console.Write("Количество компаний: ");
            int companyCount = int.Parse(Console.ReadLine());
            Console.Write("Количество продукции: ");
            int productCount = int.Parse(Console.ReadLine());
            Console.Write("Файл данных: ");
            string jsonFile = Console.ReadLine();

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companyCount,
                КоличествоПродукции = productCount
            };
            var products = исходныеДанные.ПолучитьПродукцию().ToList();
            var companies = products.GroupBy(p => p.Компания);

            var data = companies.Select(
                g => new КомпанияJSON
                {
                    код = g.Key.Код,
                    наименование = g.Key.Наименование,
                    Продукция = g.Select(p => new ПродукцияJSON { код = p.Код, наименование = p.Наименование }).ToArray()
                }).ToArray();

            using (FileStream fs = File.Create(jsonFile))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(КомпанияJSON[]));
                ser.WriteObject(fs, data);
            }

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
