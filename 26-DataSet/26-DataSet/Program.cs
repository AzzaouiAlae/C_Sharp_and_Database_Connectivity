using System;
using System.Data;
using System.Linq;

namespace _26_DataSet
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable DtEmployees = new DataTable("Employees");
            DtEmployees.Columns.Add("ID", typeof(int));
            DtEmployees.Columns.Add("Name", typeof(string));
            DtEmployees.Columns.Add("Country", typeof(string));
            DtEmployees.Columns.Add("Salary", typeof(decimal));
            DtEmployees.Columns.Add("Date", typeof(DateTime));

            DtEmployees.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            DtEmployees.Rows.Add(2, "Ali Maher\t", "KAS\t", 525.5, DateTime.Now);
            DtEmployees.Rows.Add(3, "Lina Kamal\t", "Jordan", 730.5, DateTime.Now);
            DtEmployees.Rows.Add(4, "Fadi Jameel\t", "Egypt\t", 800, DateTime.Now);
            DtEmployees.Rows.Add(5, "Omar Mahmoud\t", "Lebanon", 7000, DateTime.Now);

            Console.WriteLine("\nEmployees List");

            foreach (DataRow row in DtEmployees.Rows)
            {
                Console.WriteLine("ID : {0}\t\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }            

            DataTable DtDepartment = new DataTable("Department");
            DtDepartment.Columns.Add("ID", typeof(int));
            DtDepartment.Columns.Add("Name", typeof(string));

            DtDepartment.Rows.Add(1, "Marketing");
            DtDepartment.Rows.Add(2, "IT");
            DtDepartment.Rows.Add(3, "HR");


            Console.WriteLine("\nDepartment");
            foreach (DataRow row in DtDepartment.Rows)
            {
                Console.WriteLine("ID : {0}\t\tName : {1}", row["ID"], row["Name"]);
            }

            DataSet dataSet = new DataSet();

            dataSet.Tables.Add(DtEmployees);

            dataSet.Tables.Add(DtDepartment);

            Console.WriteLine("\n\n\nEmployees List from dataSet");
            foreach (DataRow row in dataSet.Tables["Employees"].Rows)
            {
                Console.WriteLine("ID : {0}\t\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            Console.WriteLine("\n\n\nDepartment from dataSet");
            foreach (DataRow row in dataSet.Tables["Department"].Rows)
            {
                Console.WriteLine("ID : {0}\t\tName : {1}", row["ID"], row["Name"]);
            }


            Console.ReadKey();
        }
    }
}
