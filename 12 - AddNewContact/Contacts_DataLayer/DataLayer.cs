using System;
using System.Data.SqlClient;
using System.Data;

namespace Contacts_DataLayer
{
    public struct stContact
    {
        public int ID;
        public string FirstName;
        public string LastName;
        public string Email;
        public string Phone;
        public string Address;
        public DateTime DateOfBirth;
        public int CountryID;
        public string ImagePath;
    }
    public class DataLayer
    {        
        static void _SetDataToContact(ref stContact Contact, SqlDataReader Reader)
        {
            Contact.FirstName = (string)Reader["FirstName"];
            Contact.LastName = (string)Reader["LastName"];
            Contact.Email = (string)Reader["Email"];
            Contact.Phone = (string)Reader["Phone"];
            Contact.Address = (string)Reader["Address"];
            Contact.DateOfBirth = (DateTime)Reader["DateOfBirth"];
            Contact.CountryID = (int)Reader["CountryID"];

            if (Reader["ImagePath"] != DBNull.Value)
                Contact.ImagePath = (string)Reader["ImagePath"];

            else
                Contact.ImagePath = "";
        }
        public static bool GetContactByID(ref stContact Contact)
        {
            SqlConnection Connection = null;
            SqlDataReader Reader = null;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Select * from Contacts where ContactID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ID", Contact.ID);
                Connection.Open();
                Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    _SetDataToContact(ref Contact, Reader);
                    return true;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();

                if(Reader != null && !Reader.IsClosed )
                    Reader.Close();
            }
            return false;
        }
        static void _SetParameterToCommand(ref SqlCommand Command, stContact Contact)
        {
            Command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
            Command.Parameters.AddWithValue("@LastName", Contact.LastName);
            Command.Parameters.AddWithValue("@Email", Contact.Email);
            Command.Parameters.AddWithValue("@Phone", Contact.Phone);
            Command.Parameters.AddWithValue("@Address", Contact.Address);
            Command.Parameters.AddWithValue("@DateOfBirth", Contact.DateOfBirth);
            Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);
            if(Contact.ImagePath == null || Contact.ImagePath == "")
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            else
                Command.Parameters.AddWithValue("@ImagePath", Contact.ImagePath);
        }
        public static bool AddNewContact(ref stContact Contact)
        {
            SqlConnection Connection = null;
            try {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "insert into Contacts values (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath) select SCOPE_IDENTITY()";
                SqlCommand Command = new SqlCommand(Query, Connection);
                _SetParameterToCommand(ref Command, Contact);
                Connection.Open();
                Object Result = Command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int ID))
                {
                    Contact.ID = ID;
                    return true;
                }
            }
            catch //(Exception ex) 
            { 

            }
            finally
            {
                if(Connection != null && Connection.State != ConnectionState.Closed)
                    Connection.Close();
            }
            return false;
        }
    }
}
