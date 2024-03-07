using System;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using Contacts_BusinessLayer;

namespace _13_ContactsConsoleApp
{
    internal class Program
    {
        static void PrintContact(clsContact Contact)
        {
            Console.WriteLine("Contact ID  : " + Contact.ID);
            Console.WriteLine("FirstName   : " + Contact.FirstName);
            Console.WriteLine("Contact ID  : " + Contact.LastName);
            Console.WriteLine("Email       : " + Contact.Email);
            Console.WriteLine("Phone       : " + Contact.Phone);
            Console.WriteLine("Address     : " + Contact.Address);
            Console.WriteLine("DateOfBirth : " + Contact.DateOfBirth);
            Console.WriteLine("Contry ID   : " + Contact.CountryID);
            Console.WriteLine("ImagePath   :" + Contact.ImagePath);
        }
        static void Find(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if(Contact != null)            
                PrintContact(Contact);
            
        }
        static void AddNewContact()
        {
            clsContact Contact = new clsContact();
            Contact.FirstName = "ZZ";
            Contact.LastName = "YY";
            Contact.Email = "Z@Z";
            Contact.Phone = "+212622437387";
            Contact.Address = "Mo Te Fa 41";
            Contact.DateOfBirth = new DateTime(1996, 1, 7);
            Contact.CountryID = 1;
            Contact.ImagePath = "C:\\A.jpg";

            if (Contact.Save())
                Console.WriteLine($"Contact Added successfully with ID {Contact.ID}");
            else
                Console.WriteLine("Failed Added new contact");
        }
        static void UpdateContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);

            if (Contact != null)
            {
                Contact.FirstName = "AlaeEddine";
                Contact.LastName = "AZZAOUI";
                Contact.Email = "azzaoui@outlook.com";

                if (Contact.Save())
                    Console.WriteLine("Contact Updated Successfully");
                else
                    Console.WriteLine("Failed Update Contact");
            }
            else
                Console.WriteLine($"Contact ID {ID} not found!!!");
        }
        static void DeleteContact(int ID)
        {
            if (clsContact.DeleteContactByID(ID))
                Console.WriteLine($"Contact ID {ID} Deleted Successfully");

            else
                Console.WriteLine("Failed Delete contact!!");
        }
        static void ListContact()
        {
            DataTable DT = clsContact.GetAllContact();

            foreach(DataRow dr in DT.Rows) 
            {
                Console.WriteLine($"{dr["ContactID"]}\t{dr["FirstName"]}\t{dr["LastName"]}");
            }
        }
        static void IsContactExist(int ID)
        {
            if (clsContact.IsContactExist(ID))
                Console.WriteLine($"Contact ID {ID} is Exist");

            else
                Console.WriteLine($"Contact ID {ID} is not exist");
        }
        static void PrintCountry(clsCountry Country)
        {
            Console.WriteLine("ID   : " + Country.ID);
            Console.WriteLine("Name : " + Country.Name);
        }
        static void FindCountry()
        {
            Console.WriteLine("Country by ID");
            clsCountry Country1 = clsCountry.Find(6);

            if(Country1 != null)
                PrintCountry(Country1);

            Console.WriteLine("\nCountry by Name");
            clsCountry Country2 = clsCountry.Find("Canada");
            if (Country2 != null)
                PrintCountry(Country2);
        }
        static void AddNewCountry()
        {
            clsCountry Country = new clsCountry();

            Country.Name = "Morocco";

            if (Country.Save())
                Console.WriteLine("Country Added successfully");

            else
                Console.WriteLine("Country failed Added");
        }
        static void UpdateCountry(int ID)
        {
            clsCountry Country = clsCountry.Find(ID);
            Country.Name = "Maroc";

            if (Country.Save())
                Console.WriteLine("Country Updated successfully");

            else
                Console.WriteLine("Country failed Updated");
        }
        static void DeleteCountry(int ID)
        {
            if(clsCountry.IsCountryExist(ID))
            {
                if (clsCountry.DeleteCountry(ID))
                    Console.WriteLine("Country Deleted Successfully");

                else
                    Console.WriteLine("Failed Deleted Country");
            }
            else
                Console.WriteLine($"Country ID {ID} is not found");
        }
        static void ListCountry()
        {
            DataTable DT = clsCountry.GetListCountry();

            if(DT != null)
            {
                Console.WriteLine("Country");
                foreach (DataRow dr in DT.Rows)
                {
                    Console.WriteLine($"{dr["CountryID"]}\t{dr["CountryName"]}");
                }
            }
        }
        static void IsCountryExist(int ID)
        {
            if(clsCountry.IsCountryExist(ID))            
                Console.WriteLine($"Country ID {ID} is found"); 
            else
                Console.WriteLine($"Country ID {ID} is not found");
        }
        static void Main(string[] args)
        {
            //Find(1);
            //AddNewContact();
            //UpdateContact(15);
            //DeleteContact(15);
            //ListContact();
            //IsContactExist(8);
            //FindCounry();
            //AddNewCounry();
            //UpdateCountry(6);
            //DeleteCountry(6);
            //ListCountry();
            //IsCountryExist(5);

            Console.ReadLine();
        }
    }
}
