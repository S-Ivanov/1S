using DataSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
