using System;
using System.Data.SqlClient;

namespace _7___Retrive_Auto_Number_after_insering_Data
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
            string Query = "insert into Contacts values (@Firstname, @Lastname, @Email, @Phone, @Address, @CountryID) Select SCOPE_IDENTITY()";
            return Query;
        }
        static void SetParameterToCommand(ref SqlCommand Command, stContact Contact)
        {
            Command.Parameters.AddWithValue("@Firstname", Contact.Firstname);
            Command.Parameters.AddWithValue("@Lastname", Contact.Lastname);
            Command.Parameters.AddWithValue("@Email", Contact.Email);
            Command.Parameters.AddWithValue("@Phone", Contact.Phone);
            Command.Parameters.AddWithValue("@Address", Contact.Address);
            Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
        }
        static stContact SetNewContact()
        {
            stContact Contact = new stContact();
            Contact.Firstname = "Alae";
            Contact.Lastname = "Azzaoui";
            Contact.Email = "Azzaoui@outlook.com";
            Contact.Phone = "0622437387";
            Contact.Address = "Fadila 41, Temara";
            Contact.CountryID = 1;
            return Contact;
        }
        static void AddNewContactAndPrintID(stContact Contact)
        {
            try {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = SetQuery();
                SqlCommand Command = new SqlCommand(Query, Connection);
                SetParameterToCommand(ref Command, Contact);
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString(), out int ContactID))
                    Console.WriteLine($"The Contact Added Successfully ContactID : {ContactID}");
                else
                    Console.WriteLine("Failure");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void Main(string[] args)
        {
            stContact Contact = SetNewContact();

            AddNewContactAndPrintID(Contact);
            Console.ReadLine();
        }
    }
}
