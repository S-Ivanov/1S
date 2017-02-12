using DataSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace WriteToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Прямая запись данных в SQL.");

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

                cmd.CommandText =
                    @"INSERT INTO [dbo].[_Reference7]
                            ([_IDRRef]
                            ,[_Marked]
                            ,[_PredefinedID]
                            ,[_Code]
                            ,[_Description])
                        VALUES
                            (@_IDRRef
                            ,@_Marked
                            ,@_PredefinedID
                            ,@_Code
                            ,@_Description)";
                cmd.Parameters.Add("@_IDRRef", SqlDbType.Binary, 16);
                cmd.Parameters.AddWithValue("@_Marked", new byte[] { 0 });
                cmd.Parameters.AddWithValue("@_PredefinedID", Guid.Empty.ToByteArray());
                cmd.Parameters.Add("@_Code", SqlDbType.NVarChar, 9);
                cmd.Parameters.Add("@_Description", SqlDbType.NVarChar, 25);

                foreach (var c in компании)
                {
                    cmd.Parameters[0].Value = c._IDRRef.ToByteArray();
                    cmd.Parameters[3].Value = c.Код.ToString("D9");
                    cmd.Parameters[4].Value = c.Наименование;
                    cmd.ExecuteNonQuery();
                }

                cmd.CommandText =
                    @"INSERT INTO [dbo].[_Reference19]
                            ([_IDRRef]
                            ,[_Marked]
                            ,[_PredefinedID]
                            ,[_Code]
                            ,[_Description]
                            ,[_Fld20RRef])
                        VALUES
                            (@_IDRRef
                            ,@_Marked
                            ,@_PredefinedID
                            ,@_Code
                            ,@_Description
                            ,@_Fld20RRef)";
                cmd.Parameters.Add("@_Fld20RRef", SqlDbType.Binary, 16);

                foreach (var p in продукция)
                {
                    cmd.Parameters[0].Value = p._IDRRef.ToByteArray();
                    cmd.Parameters[3].Value = p.Код.ToString("D9");
                    cmd.Parameters[4].Value = p.Наименование;
                    cmd.Parameters[5].Value = p.Компания._IDRRef.ToByteArray();
                    cmd.ExecuteNonQuery();
                }
            }

            Console.WriteLine(DateTime.Now - start);

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
