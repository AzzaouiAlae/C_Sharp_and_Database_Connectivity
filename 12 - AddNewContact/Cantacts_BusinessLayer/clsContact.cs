using System;
using Contacts_DataLayer;

namespace Cantacts_BusinessLayer
{
    public class clsContact
    {
        enum enMode { enUpdate, enAddNew }
        public int ID {  get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryID {  get; set; }
        public string ImagePath { get; set; }
        enMode Mode { get; set; }        
        public clsContact() 
        { 
            ID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            Address = "";
            DateOfBirth = DateTime.Now;
            CountryID = 0;
            ImagePath = "";

            Mode = enMode.enAddNew;
        }
        clsContact(stContact Contact)
        {
            ID = Contact.ID;
            FirstName = Contact.FirstName;
            LastName = Contact.LastName;
            Email = Contact.Email;
            Phone = Contact.Phone;
            Address = Contact.Address;
            DateOfBirth = Contact.DateOfBirth;
            CountryID = Contact.CountryID;
            ImagePath = Contact.ImagePath;

            Mode = enMode.enUpdate;
        }
        static public clsContact Find(int ID)
        {
            //stContact is a global struct in Contacts_DataLayer
            stContact Contact = new stContact();
            Contact.ID = ID;

            if(DataLayer.GetContactByID(ref Contact))            
                return new clsContact(Contact);            

            return null;
        }
        stContact _ThisObjectToStContact()
        {
            stContact Contact = new stContact();
            Contact.ID = ID;
            Contact.FirstName = FirstName;
            Contact.LastName = LastName;
            Contact.Email = Email;
            Contact.Phone = Phone;
            Contact.Address = Address;
            Contact.DateOfBirth = DateOfBirth;
            Contact.CountryID = CountryID;
            Contact.ImagePath = ImagePath;
            return Contact;
        }
        bool _AddNewContact()
        {
            stContact Contact = _ThisObjectToStContact();
            if(DataLayer.AddNewContact(ref Contact))
            {
                ID = Contact.ID;
                return true;
            }
            return false;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.enAddNew:
                    if (_AddNewContact())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    break;

                case enMode.enUpdate:
                    return true;
            }
            return false;
        }
    }
}
