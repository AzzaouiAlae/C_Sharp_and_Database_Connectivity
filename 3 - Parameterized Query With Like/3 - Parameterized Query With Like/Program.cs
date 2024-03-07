using System;
using System.Data.SqlClient;

namespace _3___Parameterized_Query_With_Like
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
        static void PrintContactsFirstNameStartWith(string Start)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select * from Contacts where FirstName Like @Start + '%'";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Start", Start);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    stContact MyContact = LoadContactsFromDR(Reader);
                    PrintContact(MyContact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
        }
        static void PrintContactsFirstNameEndWith(string End)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select * from Contacts where FirstName Like '%' + @End + ''";

                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@End", End);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    stContact MyContact = LoadContactsFromDR(Reader);
                    PrintContact(MyContact);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " +  ex.Message);
            }
        }
        static void PrintContactsFirstNameContains(String Text)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select * from Contacts where FirstName Like '%' + @Text + '%'";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Text", Text);
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    stContact MyContact = LoadContactsFromDR(Reader);
                    PrintContact(MyContact);
                }
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Error : " +  Ex.Message);
            }

        }
        static void Main(string[] args)
        {
            //PrintContactsFirstNameStartWith("J");
            //PrintContactsFirstNameEndWith("e");
            PrintContactsFirstNameContains("ae");
            Console.ReadLine();
        }
    }
}
