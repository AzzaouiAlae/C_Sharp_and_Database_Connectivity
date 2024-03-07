using System;
using System.Data;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using Contacts_DataLayer;

namespace Contacts_BusinessLayer
{
    public class clsCountry
    {
        enum enMode { enUpdate, enAddNew }
        public int ID { get; private set; }
        public string Name { get; set;}
        enMode Mode { get; set;}
        public clsCountry()
        {
            ID = -1; 
            Name = "";
            Mode = enMode.enAddNew;
        }
        clsCountry(int id, string name)
        {
            ID = id;
            Name = name;
            Mode = enMode.enUpdate;
        }
        public static clsCountry Find(int ID)
        {
            string Name = "";
            if(CountryDataLayer.FindCountry(ref ID, ref Name))                
                return new clsCountry(ID, Name);
            
            return null;
        }
        public static clsCountry Find(string Name)
        {
            int ID = 0;
            if (CountryDataLayer.FindCountry(ref ID, ref Name))
                return new clsCountry(ID, Name);

            return null;
        }
        bool _AddNewCountry()
        {
            int id = ID;
            string name = Name;

            if(CountryDataLayer.AddNewCountry(ref id, ref name))
            {
                ID = id;
                return true;
            }
            return false;
        }
        bool _UpdateCountry()
        {
            int id = ID;
            string name = Name;

            if (CountryDataLayer.UpdateCountry(ref id, ref name))
            {
                ID = id;
                return true;
            }
            return false;
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.enUpdate:
                    return _UpdateCountry();

                case enMode.enAddNew:
                    return _AddNewCountry();            
            }
            return false;
        }        
        public static bool DeleteCountry(int ID)
        {
            return CountryDataLayer.DeleteCountry(ID);
        }
        public static DataTable GetListCountry()
        {
            return CountryDataLayer.GetAllCountry();
        }
        public static bool IsCountryExist(int ID)
        {
            string Name = "";
            return CountryDataLayer.IsCountryExist(ID, Name);
        }
        public static bool IsCountryExist(string Name)
        {
            int ID = 0;
            return CountryDataLayer.IsCountryExist(ID, Name);
        }
    }
}