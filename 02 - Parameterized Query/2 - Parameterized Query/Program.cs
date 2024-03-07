using System;
using System.Data.SqlClient;


namespace _2___Parameterized_Query
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
        static void GetAllContactsFromDB()
        {
            try
            {
                SqlConnection connection = new SqlConnection(ConnectionString);
                string Query = "Select * from Contacts";

                SqlCommand Commande = new SqlCommand(Query, connection);

                connection.Open();
                SqlDataReader reader = Commande.ExecuteReader();

                while (reader.Read())
                {                    
                    stContact MyContact = LoadContactsFromDR(reader);
                    PrintContact(MyContact);
                }
                connection.Close();
            }
            catch (Exception ex)
            { 
                Console.WriteLine ("Error : " + ex.Message);
            }
        }
        static void GetContactsByFirstName(string firstName)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "Select * from Contacts where Firstname = @FirstName";

                SqlCommand Commande = new SqlCommand(Query, Connection);

                Commande.Parameters.AddWithValue("@FirstName", firstName);
                Connection.Open();
                SqlDataReader reader = Commande.ExecuteReader();

                while(reader.Read())
                {
                    stContact Contact = LoadContactsFromDR(reader);
                    PrintContact(Contact);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error" + ex.Message);
            }
        }
        static void GetContactsByFirstNameAndCountryID(string firstName, int CountryID)
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            string Query = "Select * from Contacts where FirstName = @FirstName and CountryID = @CountryID";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@FirstName", firstName);
            Command.Parameters.AddWithValue("@CountryID", CountryID);

            connection.Open();

            SqlDataReader reader = Command.ExecuteReader();

            while(reader.Read())
            {
                stContact MyContact = LoadContactsFromDR(reader);

                PrintContact(MyContact);
            }
        }
        static void Main(string[] args)
        {
            //GetAllContactsFromDB();
            //GetContactsByFirstName("Jane");
            GetContactsByFirstNameAndCountryID("Jane", 1);

            Console.ReadLine();
        }
    }
}
