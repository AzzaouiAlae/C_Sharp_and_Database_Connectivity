using System;
using System.Data.SqlClient;

namespace Contacts_DataLayer
{
    public class ContactsData
    {
        public struct stContacts
        {
            public int ContactID;
            public string FirstName;
            public string LastName;
            public string Email;
            public string Phone;
            public string Address;
            public DateTime DateOfBirth;
            public int CountryID;
            public string ImagePath;
        }

        static void SetDataContact(ref stContacts Contact, SqlDataReader reader)
        {
            Contact.FirstName = (string)reader[1];

            Contact.LastName = (string)reader[2];

            Contact.Email = (string)reader[3];

            Contact.Phone = (string)reader[4];

            Contact.Address = (string)reader[5];

            Contact.DateOfBirth = (DateTime)reader[6];

            Contact.CountryID = (int)reader[7];

            if (reader.IsDBNull(8))
                Contact.ImagePath = (string)reader[8];
        }

        public static bool GetContactsByID(ref stContacts Contact)
        {
            SqlConnection connection = null;
            SqlDataReader reader = null;
            try {
                connection = new SqlConnection(DataAccessSetteings.ConnectionString);
                string Query = "Select * from Contacs where ContactsID = @ID";
                SqlCommand Command = new SqlCommand(Query, connection);
                Command.Parameters.AddWithValue("@ID", Contact.ContactID);
                reader = Command.ExecuteReader();
                if (reader.Read())
                {
                    SetDataContact(ref Contact, reader);
                    return true;
                }
                else
                    return false;
            }
            catch {
                return false;
            }
            finally {
                connection.Close();
                if(reader != null && !reader.IsClosed)
                    reader.Close();
            }
        }
    }
}
