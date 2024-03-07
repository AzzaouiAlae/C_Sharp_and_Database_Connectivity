using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace _01___Get_All_Contacts
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456;";
        struct stContact
        {
            public int ContactID;
            public string Firstname;
            public string Lastname;
            public string Email;
            public string Phone;
            public string Address;
            public int CountryID;
        }
        static stContact LoadContactsFromDR(SqlDataReader reader  )
        {
            stContact MyContact = new stContact();
            MyContact.ContactID = (int)reader[0];
            MyContact.Firstname = (string)reader[1];
            MyContact.Lastname = (string)reader[2];
            MyContact.Email = (string)reader[3];
            MyContact.Phone = (string)reader[4];
            MyContact.Address = (string)reader[5];
            MyContact.CountryID = (int)reader[6];
            return MyContact;
        }
        static void PrintContact(stContact MyContact)
        {
            Console.WriteLine("ContactID: " + MyContact.ContactID);
            Console.WriteLine("Firstname: " + MyContact.Firstname);
            Console.WriteLine("Lastname : " + MyContact.Lastname);
            Console.WriteLine("Email    : " + MyContact.Email);
            Console.WriteLine("Phone    : " + MyContact.Phone);
            Console.WriteLine("Address  : " + MyContact.Address);
            Console.WriteLine("CountryID: " + MyContact.CountryID + "\n");
        }
        static void GetAllContacts()
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select * From Contacts";

                SqlCommand command = new SqlCommand(Query, Connection);

                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    PrintContact(LoadContactsFromDR(reader));
                }
                Connection.Close();
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }

        static void Main(string[] args)
        {
            GetAllContacts();
            Console.ReadLine();
        }
    }
}
