using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_DataTable3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Country", typeof(string));
            dt.Columns.Add("Salary", typeof(decimal));
            dt.Columns.Add("Date", typeof(DateTime));

            dt.Rows.Add(1, "Mohammed Abu-Hadhoud", "Jordan", 5000, DateTime.Now);
            dt.Rows.Add(2, "Ali Maher", "KAS", 525.5, DateTime.Now);
            dt.Rows.Add(3, "Lina Kamal", "Jordan", 730.5, DateTime.Now);
            dt.Rows.Add(4, "Fadi Jameel", "Egypt", 800, DateTime.Now);
            dt.Rows.Add(5, "Omar Mahmoud", "Lebanon", 7000, DateTime.Now);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tID : {0}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            int EmpNum = dt.Rows.Count;
            double TotalSalary = Convert.ToDouble(dt.Compute("SUM(Salary)", ""));
            double AverageSalary = Convert.ToDouble(dt.Compute("AVG(Salary)", ""));
            double MinSalary = Convert.ToDouble(dt.Compute("MIN(Salary)", ""));
            double MaxSalary = Convert.ToDouble(dt.Compute("MAX(Salary)", ""));

            Console.WriteLine("\nEmployees Number : " + EmpNum);
            Console.WriteLine("Total Salary     : " + TotalSalary);
            Console.WriteLine("Average Salary   : " + AverageSalary);
            Console.WriteLine("Min Salary       : " + MinSalary);
            Console.WriteLine("Max Salary       : " + MaxSalary);

            Console.WriteLine("\n\n\nSelect where Country = Jordan\n");

            DataRow[] DR = dt.Select("Country='Jordan'");

            foreach (DataRow row in DR)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tID : {0}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            EmpNum = DR.Length;
            TotalSalary = Convert.ToDouble(dt.Compute("SUM(Salary)", "Country='Jordan'"));
            AverageSalary = Convert.ToDouble(dt.Compute("AVG(Salary)", "Country='Jordan'"));
            MinSalary = Convert.ToDouble(dt.Compute("MIN(Salary)", "Country='Jordan'"));
            MaxSalary = Convert.ToDouble(dt.Compute("MAX(Salary)", "Country='Jordan'"));

            Console.WriteLine("\nEmployees Number : " + EmpNum);
            Console.WriteLine("Total Salary     : " + TotalSalary);
            Console.WriteLine("Average Salary   : " + AverageSalary);
            Console.WriteLine("Min Salary       : " + MinSalary);
            Console.WriteLine("Max Salary       : " + MaxSalary);

            Console.WriteLine("\n\n\nSelect where Country = Jordan or Country = Egypt\n");

            DR = dt.Select("Country='Jordan' or Country='Egypt'");

            foreach (DataRow row in DR)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tID : {0}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            EmpNum = DR.Length;
            TotalSalary = Convert.ToDouble(dt.Compute("SUM(Salary)", "Country='Jordan' or Country='Egypt'"));
            AverageSalary = Convert.ToDouble(dt.Compute("AVG(Salary)", "Country='Jordan' or Country='Egypt'"));
            MinSalary = Convert.ToDouble(dt.Compute("MIN(Salary)", "Country='Jordan' or Country='Egypt'"));
            MaxSalary = Convert.ToDouble(dt.Compute("MAX(Salary)", "Country='Jordan' or Country='Egypt'"));

            Console.WriteLine("\nEmployees Number : " + EmpNum);
            Console.WriteLine("Total Salary     : " + TotalSalary);
            Console.WriteLine("Average Salary   : " + AverageSalary);
            Console.WriteLine("Min Salary       : " + MinSalary);
            Console.WriteLine("Max Salary       : " + MaxSalary);


            Console.WriteLine("\n\n\nSelect where ID = 1\n");

            DR = dt.Select("ID=1");

            foreach (DataRow row in DR)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tID : {0}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            EmpNum = DR.Length;
            TotalSalary = Convert.ToDouble(dt.Compute("SUM(Salary)", "ID=1"));
            AverageSalary = Convert.ToDouble(dt.Compute("AVG(Salary)", "ID=1"));
            MinSalary = Convert.ToDouble(dt.Compute("MIN(Salary)", "ID=1"));
            MaxSalary = Convert.ToDouble(dt.Compute("MAX(Salary)", "ID=1"));

            Console.WriteLine("\nEmployees Number : " + EmpNum);
            Console.WriteLine("Total Salary     : " + TotalSalary);
            Console.WriteLine("Average Salary   : " + AverageSalary);
            Console.WriteLine("Min Salary       : " + MinSalary);
            Console.WriteLine("Max Salary       : " + MaxSalary);
            Console.ReadLine();
        }
    }
}
