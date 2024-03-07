using System;
using System.Data.SqlClient;

namespace _9___Delete_Data
{
    internal class Program
    {
        static string ConnectonString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
        static string SetQuery()
        {
            return "Delete Contacts where ContactID = @ContactID";
        }
        static void SetParameters(ref SqlCommand Command, int Contact)
        {
            Command.Parameters.AddWithValue("@ContactID", Contact);
        }
        static void DeleteContactsByID(int Contact)
        {
            try {
                SqlConnection Connection = new SqlConnection(ConnectonString);
                string Query = SetQuery();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SetParameters(ref Command, Contact);
                Connection.Open();
                int RowsAffected = Command.ExecuteNonQuery();
                if (RowsAffected > 0)
                    Console.WriteLine($"{RowsAffected} Rows Affected");
                else
                    Console.WriteLine($"Contact Not found");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
            
        }
        static void Main()
        {
            DeleteContactsByID(7);
            Console.ReadLine();
        }
    }
}
