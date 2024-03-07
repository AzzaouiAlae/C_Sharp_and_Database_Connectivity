using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace _27_DataAdapter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Server=.;Database=HR_Database;User Id=sa;Password=sa123456;";
            
            DataSet Data = new DataSet();
            string Query = "Select * from Employees";

            SqlDataAdapter dataAdapter = new SqlDataAdapter(Query, ConnectionString);

            SqlConnection Connection = new SqlConnection(ConnectionString);
            Console.ReadLine();
            Connection.Open();

            dataAdapter.SelectCommand.Connection = Connection;

            dataAdapter.Fill(Data, "Employees");

            Connection.Close();
            Console.ReadLine();
            DataTable EmployeesTable = Data.Tables["Employees"];
            foreach(DataRow row in EmployeesTable.Rows)
            {
                Console.WriteLine("{0}\t{1}\t{2}\t{3}", row["ID"], row["FirstName"], row["LastName"], row["MonthlySalary"]);
            }
            Console.ReadLine();
        }
    }
}
