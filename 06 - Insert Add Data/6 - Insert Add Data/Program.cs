using System;
using System.Data.SqlClient;

namespace _6___Insert_Add_Data
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
            public int ContryID;
        }

        static void AddDataToContact(ref stContact NewContact)
        {
            NewContact.Firstname = "Alae";
            NewContact.Lastname = "Azzaoui";
            NewContact.Email = "Azzaoui@outlook.com";
            NewContact.Phone = "0622437387";
            NewContact.Address = "Fadila 41, Temara, Morocco";
            NewContact.ContryID = 1;
        }
        static void AddParametrsToCommand(ref SqlCommand Command, stContact NewContact)
        {
            Command.Parameters.AddWithValue("@Firstname", NewContact.Firstname);
            Command.Parameters.AddWithValue("@Lastname", NewContact.Lastname);
            Command.Parameters.AddWithValue("@Email", NewContact.Email);
            Command.Parameters.AddWithValue("@Phone", NewContact.Phone);
            Command.Parameters.AddWithValue("@Address", NewContact.Address);
            Command.Parameters.AddWithValue("@ContryID", NewContact.ContryID);
        }
        static void AddContactToDatabase(stContact NewContact)
        {
            try
            {
                SqlConnection Connection = new SqlConnection(ConnectionString);
                string Query = "insert into Contacts values (@Firstname, @Lastname, @Email, @Phone, @Address, @ContryID)";
                SqlCommand Command = new SqlCommand(Query, Connection);
                AddParametrsToCommand(ref Command, NewContact);

                Connection.Open();

                int RowsAffected = Command.ExecuteNonQuery();

                if (RowsAffected > 0)
                {
                    Console.WriteLine($"{RowsAffected} Row(s) Added Successfully");
                }
                else
                    Console.WriteLine("Added Failed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.ToString());
            }
        }
        static void Main()
        {
            stContact NewContact = new stContact();
            AddDataToContact(ref NewContact);

            AddContactToDatabase(NewContact);
            Console.ReadLine();
        }
    }
}
