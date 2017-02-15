using DataSource;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WriteToSQLBulkCopy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Прямая запись данных в SQL - BulkCopy.");

            Console.Write("Количество компаний: ");
            int companyCount = int.Parse(Console.ReadLine());
            Console.Write("Количество продукции: ");
            int productCount = int.Parse(Console.ReadLine());

            ИсходныеДанные_Генератор исходныеДанные = new ИсходныеДанные_Генератор
            {
                КоличествоКомпаний = companyCount,
                КоличествоПродукции = productCount
            };
            var продукция = исходныеДанные.ПолучитьПродукцию().ToArray();
            var компании = продукция.Select(p => p.Компания).Distinct();

            Данные данные = new Данные();
            foreach (var c in компании)
            {
                данные.Компании.AddКомпанииRow(
                    c._IDRRef.ToByteArray(),
                    null,
                    new byte[1],
                    new byte[16],
                    c.Код.ToString("D9"),
                    c.Наименование);
            }
            foreach (var p in продукция)
            {
                данные.Продукция.AddПродукцияRow(
                    p._IDRRef.ToByteArray(),
                    null,
                    new byte[1],
                    new byte[16],
                    p.Код.ToString("D9"),
                    p.Наименование,
                    p.Компания._IDRRef.ToByteArray());
            }

            DateTime start = DateTime.Now;

            using (SqlConnection con = new SqlConnection(@"Server=.\sqlexpress;Database=Test1S;Trusted_Connection=True;"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "TRUNCATE TABLE [dbo].[_Reference19]";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "TRUNCATE TABLE [dbo].[_Reference7]";
                cmd.ExecuteNonQuery();

                SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con, SqlBulkCopyOptions.TableLock, null);
                sqlBulkCopy.DestinationTableName = "_Reference7";
                sqlBulkCopy.WriteToServer(данные.Компании);

                sqlBulkCopy.DestinationTableName = "_Reference19";
                sqlBulkCopy.WriteToServer(данные.Продукция);
            }

            Console.WriteLine(DateTime.Now - start);

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine(); 
        }
    }
}
