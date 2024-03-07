using System;
using Contacts_DataLayer;

namespace Contacts_BusinessLayer
{
    public class clsContacts
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID { get; set; }
        public string ImagePath { get; set; }
        clsContacts()
        {
        }
        clsContacts(int contactID, string firstName, string lastName, string email, string phone,
                    string address, DateTime dateOfBirth, int countryID, string imagePath) 
        {
            ContactID = contactID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Phone = phone;
            Address = address;
            DateOfBirth = dateOfBirth;
            CountryID = countryID;
            ImagePath = imagePath;            
        }
        clsContacts(ContactsData.stContacts Contact)
        {
            ContactID = Contact.ContactID;
            FirstName = Contact.FirstName;
            LastName = Contact.LastName;
            Email = Contact.Email;
            Phone = Contact.Phone;
            Address = Contact.Address;
            DateOfBirth = Contact.DateOfBirth;
            CountryID = Contact.CountryID;
            ImagePath = Contact.ImagePath;
        }

        static public clsContacts Find(int ContactID)
        {
            ContactsData.stContacts Contact = new ContactsData.stContacts();

            if (ContactsData.GetContactsByID(ref Contact))
            {
                return new clsContacts(Contact);
            }
            return null;
        }
    }
}
