using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace Contacts_DataLayer
{    
    public class CountryDataLayer
    {
        public static bool FindCountry(ref int ID, ref string Name)
        {
            SqlConnection Connection = null;
            SqlDataReader Reader = null;
            try {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Select * from Countries Where CountryName = @Name or CountryID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ID", ID);
                Command.Parameters.AddWithValue("@Name", Name);
                Connection.Open();
                Reader = Command.ExecuteReader();
                if(Reader.Read())
                {
                    ID = (int)Reader["CountryID"];
                    Name = (string)Reader["CountryName"];
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

                if(Reader != null && !Reader.IsClosed)
                    Reader.Close();
            }
            return false;
        }
        public static bool AddNewCountry(ref int ID, ref string Name)
        {
            SqlConnection Connection = null;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "insert into Countries values (@Name) Select SCOPE_IDENTITY()";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Name", Name);
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if(Result != null && int.TryParse(Result.ToString(), out int id))
                {
                    ID = id;
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
        public static bool UpdateCountry(ref int ID, ref string Name)
        {
            SqlConnection Connection = null;
            int Result = 0;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "update Countries set CountryName = @Name where CountryID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@Name", Name);
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
            return Result > 0;
        }
        public static bool DeleteCountry(int ID)
        {
            SqlConnection Connection = null;
            int Result = 0;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "delete from Countries where CountryID = @ID";
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
            return Result > 0;
        }
        public static DataTable GetAllCountry()
        {
            SqlConnection Connection = null;
            SqlDataReader Reader = null;
            DataTable DT = null;
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Select * from Countries ";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Connection.Open();
                Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                {
                    DT = new DataTable();
                    DT.Load(Reader);
                }
            }
            catch
            {

            }
            finally
            {
                if (Reader != null && !Reader.IsClosed)
                    Reader.Close();

                if (Connection != null && Connection.State == ConnectionState.Open)
                    Connection.Close();
            }
            return DT;
        }
        public static bool IsCountryExist(int ID, string Name)
        {
            SqlConnection Connection = null;            
            try
            {
                Connection = new SqlConnection(DataAccessSettings.ConnectionString);
                string Query = "Select Found = 1 from Countries Where CountryName = @Name or CountryID = @ID";
                SqlCommand Command = new SqlCommand(Query, Connection);
                Command.Parameters.AddWithValue("@ID", ID);
                Command.Parameters.AddWithValue("@Name", Name);
                Connection.Open();
                object Result = Command.ExecuteScalar();
                if (Result  != null)                
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
