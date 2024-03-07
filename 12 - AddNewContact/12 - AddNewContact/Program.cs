using System;
using Cantacts_BusinessLayer;

namespace _12___AddNewContact
{
    internal class Program
    {
        static void PrintContact(clsContact Contact)
        {
            Console.WriteLine("Contact ID  :" + Contact.ID);
            Console.WriteLine("FirstName   :" + Contact.FirstName);
            Console.WriteLine("LastName    :" + Contact.LastName);
            Console.WriteLine("Email       :" + Contact.Email);
            Console.WriteLine("Phone       :" + Contact.Phone);
            Console.WriteLine("Address     :" + Contact.Address);
            Console.WriteLine("DateOfBirth :" + Contact.DateOfBirth);
            Console.WriteLine("CountryID   :" + Contact.CountryID);
            Console.WriteLine("ImagePath   :" + Contact.ImagePath);
        }
        static void FindContact(int ID)
        {
            clsContact Contact = clsContact.Find(ID);
            if (Contact != null)
                PrintContact(Contact);

            else
                Console.WriteLine($"Contact ID {ID} not found!!");
            
        }
        static void AddNewContact()
        {
            clsContact Contact = new clsContact();

            Contact.FirstName = "Alaeeddine";
            Contact.LastName = "Azzaoui";
            Contact.Email = "Azzaoui@outlook.com";
            Contact.Phone = "0622437387";
            Contact.Address = "Fadila 41";
            Contact.DateOfBirth = new DateTime(1996, 01, 07);
            Contact.CountryID = 2;
            Contact.ImagePath = "";

            if(Contact.Save())            
                Console.WriteLine($"Contact Added successfully whith ID {Contact.ID}");

            else            
                Console.WriteLine("Failed to save new conatct");
            
        }
        static void Main(string[] args)
        {
            //FindContact(10);
            AddNewContact();
            Console.ReadLine();
        }
    }
}
