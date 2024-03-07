using System;
using System.Data.SqlClient;

namespace _8___Update_Data
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
        static string SetQuery()
        {
            return "Update Contacts set Firstname = @Firstname, Lastname = @Lastname, Email = @Email, Phone = @Phone, Address = @Address, CountryID = @CountryID Where ContactID= @ContactID";
        }
        static void SetParametersCommand(ref SqlCommand Command, stContact Contact)
        {
            Command.Parameters.AddWithValue("@ContactID", Contact.ContactID);
            Command.Parameters.AddWithValue("@Firstname", Contact.Firstname);
            Command.Parameters.AddWithValue("@Lastname", Contact.Lastname);
            Command.Parameters.AddWithValue("@Email", Contact.Email);
            Command.Parameters.AddWithValue("@Phone", Contact.Phone);
            Command.Parameters.AddWithValue("@Address", Contact.Address);
            Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
        }
        static stContact SetContactData()
        {
            stContact Contact = new stContact();
            Contact.ContactID = 8;
            Contact.Firstname = "AlaeEddine";
            Contact.Lastname = "AZZAOUI";
            Contact.Email = "AZZAOUI@outlook.com";
            Contact.Phone = "+212622437387";
            Contact.Address = "Fadila41";
            Contact.CountryID = 3;
            return Contact;
        }
        static void UpdateContact(stContact Contact)
        {
            try {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = SetQuery();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SetParametersCommand(ref Command, Contact);
                Connection.Open();
                int Result = Command.ExecuteNonQuery();
                if(Result > 0) 
                    Console.WriteLine($"Update Successful {Result} rows affected");
                
                else 
                    Console.WriteLine("{Result} row affected");                 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            stContact Contact = SetContactData();

            UpdateContact(Contact);
            Console.ReadLine();
        }
    }
}
