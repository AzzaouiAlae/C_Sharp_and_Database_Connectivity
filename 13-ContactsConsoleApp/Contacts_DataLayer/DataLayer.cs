using System;
using System.Data;
using System.Data.SqlClient;

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
        static void _SetParametersToCommand(ref SqlCommand Command, stContact Contact)
        {
            Command.Parameters.AddWithValue("@ID", Contact.ID);
            Command.Parameters.AddWithValue("@FirstName", Contact.FirstName);
            Command.Parameters.AddWithValue("@LastName", Contact.LastName);
            Command.Parameters.AddWithValue("@Email", Contact.Email);
            Command.Parameters.AddWithValue("@Phone", Contact.Phone);
            Command.Parameters.AddWithValue("@Address", Contact.Address);
            Command.Parameters.AddWithValue("@DateOfBirth", Contact.DateOfBirth);
            Command.Parameters.AddWithValue("@CountryID", Contact.CountryID);

            if (Contact.ImagePath != "" || Contact.ImagePath != null)
                Command.Parameters.AddWithValue("@ImagePath", Contact.ImagePath);

            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
        }
        public static bool FindContactByID(ref stContact Contact)
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
                if(Reader.Read())
                {
                    _SetDataToContact(ref Contact, Reader);
                    return true;
                }
            }
            catch
            {


            }
            finally
            {
                if(Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();

                if( Reader != null && !Reader.IsClosed) 
                    Reader.Close();
            }
            return false;
        }
        public static bool AddNewContact(ref stContact Contact)
        {
            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "insert into Contacts values (@FirstName, @LastName, @Email, @Phone, @Address, @DateOfBirth, @CountryID, @ImagePath) Select SCOPE_IDENTITY()";
                SqlCommand Command = new SqlCommand(Query, Connection);
                _SetParametersToCommand(ref Command, Contact);
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result != null && int.TryParse(Result.ToString() , out int ID))
                {
                    Contact.ID = ID;
                    return true;
                }
            }
            catch
            {


            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return false;
        }
        public static bool UpdateContact(ref stContact Contact)
        {
            SqlConnection Connection = null;
            int Result = 0;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "update Contacts set FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, Address = @Address, DateOfBirth = @DateOfBirth, CountryID = @CountryID, ImagePath = @ImagePath Where ContactID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                _SetParametersToCommand(ref Command, Contact);
                Connection.Open();
                Result = Command.ExecuteNonQuery();                
            }
            catch
            {

            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return (Result > 0);
        }
        public static bool DeleteContact(int ID)
        {
            SqlConnection Connection = null;
            int Result = 0;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Delete from Contacts Where ContactID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ID", ID);
                Connection.Open();
                Result = Command.ExecuteNonQuery();
            }
            catch
            {

            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return (Result > 0);
        }
        public static DataTable GetAllContact()
        {
            SqlConnection Connection = null;
            SqlDataReader Reader = null;
            DataTable DT = new DataTable();
            try
            {                
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Select * from Contacts";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();

                if(Reader.HasRows)                
                    DT.Load(Reader);                
            }
            catch
            {

            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();

                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }
            return DT;
        }
        public static bool IsContactExist(int ID)
        {
            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Select ContactID from Contacts where ContactID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ID", ID);
                Connection.Open();
                Object Result = Command.ExecuteScalar();
                if (Result != null)                
                    return true;                
            }
            catch
            {


            }
            finally
            {
                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return false;
        }
    }
}
