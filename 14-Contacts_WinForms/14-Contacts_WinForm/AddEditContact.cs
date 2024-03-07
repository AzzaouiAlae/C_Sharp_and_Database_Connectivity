using System;
using System.Data;
using System.Windows.Forms;
using Contacts_BusinessLayer;

namespace _14_Contacts_WinForm
{
    public partial class AddEditContact : Form
    {
        int _ContactID;
        public AddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;
        }

        private void AddEditContact_Load(object sender, EventArgs e)
        {
            if(_ContactID != -1)
            {
                lbl_AddEdit.Text = "Edit New Contact";
                clsContact Contact = clsContact.Find(_ContactID);
                lbl_ContactID.Text = Contact.ID.ToString();
                txt_Address.Text = Contact.Address;
                txt_Email.Text = Contact.Email;
                txt_FirstName.Text = Contact.FirstName;
                txt_LastName.Text = Contact.LastName;
                txt_Phone.Text = Contact.Phone;
                dtp_DateOfBirth.Value = Contact.DateOfBirth;
                lbl_SetImage.Tag = Contact.ImagePath;

                if (clsCountry.Find(Contact.CountryID) != null)
                    cb_Country.Text = clsCountry.Find(Contact.CountryID).Name;                
            }
            DataTable DTcountry = clsCountry.GetListCountry();
            foreach (DataRow drc in DTcountry.Rows)
            {
                cb_Country.Items.Add(drc[1].ToString());
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsContact Contact;
            if (_ContactID == -1)
                Contact = new clsContact();
            else
                Contact = clsContact.Find(_ContactID);

            Contact.FirstName = txt_FirstName.Text;
            Contact.LastName = txt_LastName.Text;
            Contact.Email = txt_Email.Text;
            Contact.Phone = txt_Phone.Text;
            Contact.Address = txt_Address.Text;
            Contact.DateOfBirth = dtp_DateOfBirth.Value;
            Contact.CountryID = clsCountry.Find(cb_Country.Text).ID;

            if (lbl_SetImage.Tag != null)
                Contact.ImagePath = lbl_SetImage.Tag.ToString();

            else
                Contact.ImagePath = "";

            if(Contact.Save())
            {
                MessageBox.Show("Contact Saved successfully");
                lbl_ContactID.Text = Contact.ID.ToString();
                lbl_AddEdit.Text = "Edit New Contact";
            }
            else
                MessageBox.Show("Failed Saved Contact");            
        }

        private void lbl_SetImage_Click(object sender, EventArgs e)
        {
            if (lbl_SetImage.Tag != null)
                Image.ImageLocation = lbl_SetImage.Tag.ToString();
            else
            {
                if(openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Image.ImageLocation = openFileDialog1.FileName;
                    lbl_SetImage.Tag = openFileDialog1.FileName;
                }
            }
        }
    }
}
