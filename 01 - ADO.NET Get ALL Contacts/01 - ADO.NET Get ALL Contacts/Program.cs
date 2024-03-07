using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _01___ADO.NET_Get_ALL_Contacts
{
    
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";

        static void PrintAllContacts()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);

                string Query = "SELECT * from Contacts";

                SqlCommand command = new SqlCommand(Query, Connection);
            
                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    int ContactID = (int)reader[0];
                    string firstname = (string)reader[1];
                    string lastname = (string)reader[2];
                    string Email = (string)reader[3];
                    string Phone = (string)reader[4];
                    string Address = (string)reader[5];
                    int CountryID = (int)reader[6];

                    Console.WriteLine($"Contact ID:{ContactID}");
                    Console.WriteLine($"firstname :{firstname}");
                    Console.WriteLine($"lastname  :{lastname}");
                    Console.WriteLine($"Email     :{Email}");
                    Console.WriteLine($"Phone     :{Phone}");
                    Console.WriteLine($"Address   :{Address}");
                    Console.WriteLine($"CountryID :{CountryID}\n");
                }
                Connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " +  ex.Message);
            }
            
        }
        static void Main(string[] args)
        {
            PrintAllContacts();
            Console.ReadKey();
        }
    }
}
