using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_DataTable2
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

            dt.Rows.Add(1, "Alae Azzaoui", "Morocco", 4000, DateTime.Now);
            dt.Rows.Add(2, "Salwa Azzaoui", "Morocco", 6000, DateTime.Now);
            dt.Rows.Add(3, "Oussama Azzaoui", "Morocco", 0, DateTime.Now);

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

            Console.ReadLine();
        }
    }
}
