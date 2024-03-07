using System;
using System.Data.SqlClient;

namespace _10___In_Statement
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
        static void DeleteContactsByFirstname(string Firstname)
        {
            try { 
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = $"Delete from Contacts where Firstname in ({Firstname})";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                if(RowsAffected > 0)                
                    Console.WriteLine($"{RowsAffected} Rows Affected");

                else
                    Console.WriteLine($"Firstname not found");

            }
            catch (Exception ex) 
            { 
                    Console.WriteLine("Error : " + ex.ToString());   
            }

        }
        static void Main()
        {
            DeleteContactsByFirstname("'Alae', 'Salwa', 'Oussama'");
            Console.ReadLine();
        }
    }
}
