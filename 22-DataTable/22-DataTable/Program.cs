using System;
using System.Data;
using System.Linq;


namespace _22_DataTable
{
    internal class Program
    {

        static void Main(string[] args)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("ID", typeof(int));
            //dt.Columns.Add("Name", typeof(string));
            //dt.Columns.Add("Country", typeof(string));
            //dt.Columns.Add("Salary", typeof(decimal));
            //dt.Columns.Add("Date", typeof(DateTime));

            DataColumn DtColumn;

            DtColumn = new DataColumn();
            DtColumn.ColumnName = "ID";
            DtColumn.DataType = typeof(int);
            DtColumn.AutoIncrement = true;
            DtColumn.AutoIncrementSeed = 1;
            DtColumn.AutoIncrementStep = 1;

            DtColumn.Caption = "EmployeeID";
            DtColumn.ReadOnly = true;
            DtColumn.Unique = true;
            dt.Columns.Add(DtColumn);



            DtColumn = new DataColumn();
            DtColumn.ColumnName = "Name";
            DtColumn.DataType = typeof(string);
            DtColumn.AutoIncrement = false;
            DtColumn.Caption = "Name";
            DtColumn.ReadOnly = false;
            DtColumn.Unique = false;
            dt.Columns.Add(DtColumn);


            DtColumn = new DataColumn();
            DtColumn.ColumnName = "Country";
            DtColumn.DataType = typeof(string);
            DtColumn.AutoIncrement = false;
            DtColumn.Caption = "Country";
            DtColumn.ReadOnly = false;
            DtColumn.Unique = false;
            dt.Columns.Add(DtColumn);


            DtColumn = new DataColumn();
            DtColumn.ColumnName = "Salary";
            DtColumn.DataType = typeof(decimal);
            DtColumn.AutoIncrement = false;
            DtColumn.Caption = "Salary";
            DtColumn.ReadOnly = false;
            DtColumn.Unique = false;
            dt.Columns.Add(DtColumn);


            DtColumn = new DataColumn();
            DtColumn.ColumnName = "Date";
            DtColumn.DataType = typeof(DateTime);
            DtColumn.AutoIncrement = false;
            DtColumn.Caption = "Date";
            DtColumn.ReadOnly = false;
            DtColumn.Unique = false;
            dt.Columns.Add(DtColumn);


            DataColumn[] dc_arr = { dt.Columns["ID"] };
            dt.PrimaryKey = dc_arr;


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

            Console.ReadLine();
        }
    }
}
