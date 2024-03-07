using System;
using System.Linq;
using System.Data;

namespace _23_DataView1
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
            dt.Rows.Add(2, "Ali Maher\t", "KAS\t", 525.5, DateTime.Now);
            dt.Rows.Add(3, "Lina Kamal\t", "Jordan", 730.5, DateTime.Now);
            dt.Rows.Add(4, "Fadi Jameel\t", "Egypt\t", 800, DateTime.Now);
            dt.Rows.Add(5, "Omar Mahmoud\t", "Lebanon", 7000, DateTime.Now);

            Console.WriteLine("\nEmployees List");

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine("ID : {0}\tName : {1}\tCountry : {2}\tSalary : {3}\tDate : {4}", row["ID"], row["Name"], row["Country"], row["Salary"], row["Date"]);
            }

            DataView DV = dt.DefaultView;


            Console.WriteLine("\n\n\nEmployees List DataView");

            for (int i= 0; i < DV.Count; i++)
            {
                Console.WriteLine("{0},\t{1},\t{2},\t{3}", DV[i][0], DV[i][1], DV[i][2], DV[i][3], DV[i][4]);
            }

            Console.ReadLine();

        }

    }
}
