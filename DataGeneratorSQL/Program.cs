using DataSource;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataGeneratorSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Генерация данных для тестирования 1С. Запись в Microsoft SQL Server.");

            Console.Write("Количество компаний: ");
            int companyCount = int.Parse(Console.ReadLine());
            Console.Write("Количество продукции: ");
            int productCount = int.Parse(Console.ReadLine());

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companyCount,
                КоличествоПродукции = productCount
            };
            var products = исходныеДанные.ПолучитьПродукцию().ToList();
            var companies = products.GroupBy(p => p.Компания);

            Данные данные = new Данные();
            foreach (var c in companies)
            {
                var cRow = данные.Компании.AddКомпанииRow(c.Key.Код, c.Key.Наименование);
                foreach (var p in c)
                {
                    данные.Продукция.AddПродукцияRow(p.Код, p.Наименование, cRow);
                }
            }

            using (SqlConnection con = new SqlConnection(@"Server=.\sqlexpress;Database=Test1S;Trusted_Connection=True;"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "TRUNCATE TABLE [dbo].[Продукция]";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "TRUNCATE TABLE [dbo].[Компании]";
                cmd.ExecuteNonQuery();

                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.TableLock, null);
                sqlBulkCopy.DestinationTableName = "Компании";
                sqlBulkCopy.WriteToServer(данные.Компании);

                sqlBulkCopy.DestinationTableName = "Продукция";
                sqlBulkCopy.WriteToServer(данные.Продукция);
            }

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine(); 
        }
    }
}
