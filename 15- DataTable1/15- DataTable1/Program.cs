using System;
using System.Data;
using System.Linq;

namespace _15__DataTable1
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

            Console.ReadLine();
        }
    }
}
