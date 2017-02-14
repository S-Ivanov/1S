using DataSource;
using System;
using System.Linq;

namespace CheckUniqueGUID
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Количество компаний: ");
            int companyCount = int.Parse(Console.ReadLine());
            Console.Write("Количество продукции: ");
            int productCount = int.Parse(Console.ReadLine());

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companyCount,
                КоличествоПродукции = productCount
            };
            var companies = исходныеДанные.ПолучитьКомпании().ToList();
            var products = исходныеДанные.ПолучитьПродукцию().ToList();

            bool cUnique = companies.Select(x => x._IDRRef).Distinct().Count() == companies.Count;
            if (!cUnique)
                Console.WriteLine("Компании не уникальны.");

            bool pUnique = products.Select(x => x._IDRRef).Distinct().Count() == products.Count;
            if (!cUnique)
                Console.WriteLine("Продукция не уникальна.");

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
