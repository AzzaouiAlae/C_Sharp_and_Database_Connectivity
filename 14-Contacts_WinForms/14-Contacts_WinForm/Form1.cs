using Contacts_BusinessLayer;
using System;
using System.Data;
using System.Windows.Forms;

namespace _14_Contacts_WinForm
{
    public partial class ListContact : Form
    {
        void _RefreshDataContact()
        {
            DataTable dt = new DataTable();
            DGV.DataSource = dt;
            DGV.DataSource = clsContact.GetAllContact();
        }
        public ListContact()
        {
            InitializeComponent();
        }        
        private void ListContact_Load(object sender, EventArgs e)
        {
            _RefreshDataContact();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditContact AddEditForm = new AddEditContact(-1);

            AddEditForm.ShowDialog();

            DGV.DataSource = clsContact.GetAllContact();
        }        

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditContact AddEditForm = null;
            if (DGV.SelectedCells.Count > 0)
            {
                int Index = DGV.SelectedCells[0].RowIndex;
                if (DGV.Rows[Index].Cells[0].Value != null)
                {
                    int.TryParse(DGV.Rows[Index].Cells[0].Value.ToString(), out int ID);
                    AddEditForm = new AddEditContact(ID);
                    AddEditForm.ShowDialog();
                    DGV.DataSource = clsContact.GetAllContact();
                }
            }            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV.SelectedCells.Count > 0)
            {
                int Index = DGV.SelectedCells[0].RowIndex;
                if (DGV.Rows[Index].Cells[0].Value != null)
                {
                    int.TryParse(DGV.Rows[Index].Cells[0].Value.ToString(), out int ID);
                    clsContact.DeleteContactByID(ID);
                    DGV.DataSource = clsContact.GetAllContact();
                }
            }

        }
    }
}
