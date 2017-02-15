using DataSource;
using System;
using System.IO;
using System.Linq;

namespace DataGeneratorCSV
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Генерация данных для тестирования 1С. Запись в CSV-файлы.");

            Console.Write("Количество компаний: ");
            int companyCount = int.Parse(Console.ReadLine());
            Console.Write("Файл компаний: ");
            string companyFile = Console.ReadLine();
            Console.Write("Количество продукции: ");
            int productCount = int.Parse(Console.ReadLine());
            Console.Write("Файл компаний: ");
            string productFile = Console.ReadLine();

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companyCount,
                КоличествоПродукции = productCount
            };
            var companies = исходныеДанные.ПолучитьКомпании().ToList();
            var products = исходныеДанные.ПолучитьПродукцию().OrderBy(p => p.Компания.Код).ToList();

            using (StreamWriter cFile = new StreamWriter(companyFile))
            {
                foreach (var company in companies)
                {
                    cFile.WriteLine("{0}|{1}", company.Код, company.Наименование);
                }
            }

            using (StreamWriter pFile = new StreamWriter(productFile))
            {
                foreach (var product in products)
                {
                    pFile.WriteLine("{0}|{1}|{2}", product.Код, product.Наименование, product.Компания.Код);
                }
            }

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
