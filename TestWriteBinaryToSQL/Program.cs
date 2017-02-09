using System;
using System.Data.SqlClient;

namespace TestWriteBinaryToSQL
{
    /// <summary>
    /// Сохранение в базу данных двоичных данных
    /// http://metanit.com/sharp/adonet/2.14.php
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection con = new SqlConnection(@"Server=.\sqlexpress;Database=Test1S;Trusted_Connection=True;"))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
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
                cmd.Parameters.AddWithValue("@_IDRRef", Guid.NewGuid().ToByteArray());
                cmd.Parameters.AddWithValue("@_Marked", new byte[] { 0 });
                cmd.Parameters.AddWithValue("@_PredefinedID", Guid.Empty.ToByteArray());
                cmd.Parameters.AddWithValue("@_Code", "000000002");
                cmd.Parameters.AddWithValue("@_Description", "Компания 2");

                cmd.ExecuteNonQuery();
            }

            Console.WriteLine();
            Console.Write("Press Enter to exit ...");
            Console.ReadLine();
        }
    }
}
