using System;
using Contacts_BusinessLayer;

namespace _11___ContactsSolution
{
    internal class Program
    {
        static void PrintContact(clsContacts contact)
        {
            Console.WriteLine("Contact ID    : " + contact.ContactID);
            Console.WriteLine("FirstName     : " + contact.FirstName);
            Console.WriteLine("LastName      : " + contact.LastName);
            Console.WriteLine("Email         : " + contact.Email);
            Console.WriteLine("Phone         : " + contact.Phone);
            Console.WriteLine("Address       : " + contact.Address);
            Console.WriteLine("Date Of Birth : " + contact.DateOfBirth);
            Console.WriteLine("Country ID    : " + contact.CountryID);
            Console.WriteLine("Image Path    : " + contact.ImagePath);
        }
        static void PrintContactByID(int ContactID)
        {
            clsContacts Contact = clsContacts.Find(ContactID);
            if (Contact != null)            
                PrintContact(Contact);
            
            else
                Console.WriteLine($"Contact ID {ContactID} not found");
        }
        static void Main(string[] args)
        {
            PrintContactByID(10);
            Console.ReadLine();
        }
    }
}
