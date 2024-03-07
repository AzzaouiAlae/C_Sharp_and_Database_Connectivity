using System;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;

namespace _4___Retrieve_a_Single_Value
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";

        static string GetFirstNameOfID(int ContactID)
        {
            string FirstName = "";
            try
            {                
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select FirstName From Contacts where ContactID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ID", ContactID);
                
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result != null)
                {
                    FirstName = (string)Result;
                }
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
            
            return FirstName;
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetFirstNameOfID(3));
            Console.ReadKey();
        }
    }
}
