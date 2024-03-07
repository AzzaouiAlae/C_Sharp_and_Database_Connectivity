using System;
using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace _5___Find_Single_Contact
{
    internal class Program
    {
        static string ConnectionString = "Server=.;Database=ContactsDB;User Id=sa;Password=sa123456";
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
        static stContact LoadContactsFromDR(SqlDataReader reader)
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
        static bool FindContactByID(ref stContact MyContact, int ContactID)
        {
            bool isFound = false;
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select * from Contacts where ContactID = @ContactID";

                SqlCommand command = new SqlCommand(Query, Connection);
                command.Parameters.AddWithValue("@ContactID", ContactID);

                Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    MyContact = LoadContactsFromDR(reader);
                    isFound = true;
                }
                Connection.Close();
                reader.Close();
            }

            catch(Exception ex)
            {
                Console.WriteLine("Error : " +  ex.Message);
            }
            
            return isFound;
        }
        static void Main(string[] args)
        {
            stContact MyContact = new stContact();
            
            if (FindContactByID(ref MyContact, 10))            
                PrintContact(MyContact);
            
            else            
                Console.WriteLine("Contact ID not Found!");
            
            Console.ReadLine();
        }
    }
}
