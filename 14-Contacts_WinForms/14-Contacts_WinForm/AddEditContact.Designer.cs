namespace _14_Contacts_WinForm
{
    partial class AddEditContact
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_AddEdit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_ContactID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_FirstName = new System.Windows.Forms.TextBox();
            this.txt_LastName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.dtp_DateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_Country = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lbl_SetImage = new System.Windows.Forms.Label();
            this.Image = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Image)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_AddEdit
            // 
            this.lbl_AddEdit.AutoSize = true;
            this.lbl_AddEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_AddEdit.Location = new System.Drawing.Point(119, 18);
            this.lbl_AddEdit.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lbl_AddEdit.Name = "lbl_AddEdit";
            this.lbl_AddEdit.Size = new System.Drawing.Size(283, 37);
            this.lbl_AddEdit.TabIndex = 0;
            this.lbl_AddEdit.Text = "Add New Contact";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 78);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "ContactID";
            // 
            // lbl_ContactID
            // 
            this.lbl_ContactID.AutoSize = true;
            this.lbl_ContactID.Location = new System.Drawing.Point(116, 78);
            this.lbl_ContactID.Name = "lbl_ContactID";
            this.lbl_ContactID.Size = new System.Drawing.Size(37, 19);
            this.lbl_ContactID.TabIndex = 2;
            this.lbl_ContactID.Text = ".......";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 19);
            this.label2.TabIndex = 3;
            this.label2.Text = "FirstName";
            // 
            // txt_FirstName
            // 
            this.txt_FirstName.Location = new System.Drawing.Point(120, 118);
            this.txt_FirstName.Name = "txt_FirstName";
            this.txt_FirstName.Size = new System.Drawing.Size(199, 26);
            this.txt_FirstName.TabIndex = 4;
            // 
            // txt_LastName
            // 
            this.txt_LastName.Location = new System.Drawing.Point(120, 163);
            this.txt_LastName.Name = "txt_LastName";
            this.txt_LastName.Size = new System.Drawing.Size(199, 26);
            this.txt_LastName.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 167);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "LastName";
            // 
            // txt_Email
            // 
            this.txt_Email.Location = new System.Drawing.Point(120, 203);
            this.txt_Email.Name = "txt_Email";
            this.txt_Email.Size = new System.Drawing.Size(199, 26);
            this.txt_Email.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Email";
            // 
            // txt_Phone
            // 
            this.txt_Phone.Location = new System.Drawing.Point(120, 243);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(199, 26);
            this.txt_Phone.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Phone";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 287);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(98, 19);
            this.label6.TabIndex = 11;
            this.label6.Text = "DateOfBirth";
            // 
            // dtp_DateOfBirth
            // 
            this.dtp_DateOfBirth.Location = new System.Drawing.Point(120, 283);
            this.dtp_DateOfBirth.Name = "dtp_DateOfBirth";
            this.dtp_DateOfBirth.Size = new System.Drawing.Size(272, 26);
            this.dtp_DateOfBirth.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 327);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(71, 19);
            this.label7.TabIndex = 13;
            this.label7.Text = "Country";
            // 
            // cb_Country
            // 
            this.cb_Country.FormattingEnabled = true;
            this.cb_Country.Location = new System.Drawing.Point(120, 323);
            this.cb_Country.Name = "cb_Country";
            this.cb_Country.Size = new System.Drawing.Size(272, 27);
            this.cb_Country.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 367);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Address";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(120, 363);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(272, 82);
            this.txt_Address.TabIndex = 16;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 467);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 33);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(194, 467);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 33);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lbl_SetImage
            // 
            this.lbl_SetImage.AutoSize = true;
            this.lbl_SetImage.BackColor = System.Drawing.Color.White;
            this.lbl_SetImage.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_SetImage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lbl_SetImage.Location = new System.Drawing.Point(346, 78);
            this.lbl_SetImage.Name = "lbl_SetImage";
            this.lbl_SetImage.Size = new System.Drawing.Size(84, 19);
            this.lbl_SetImage.TabIndex = 19;
            this.lbl_SetImage.Text = "Set Image";
            this.lbl_SetImage.Click += new System.EventHandler(this.lbl_SetImage_Click);
            // 
            // Image
            // 
            this.Image.Location = new System.Drawing.Point(341, 117);
            this.Image.Name = "Image";
            this.Image.Size = new System.Drawing.Size(156, 148);
            this.Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Image.TabIndex = 20;
            this.Image.TabStop = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AddEditContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(519, 517);
            this.Controls.Add(this.Image);
            this.Controls.Add(this.lbl_SetImage);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cb_Country);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtp_DateOfBirth);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_Phone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Email);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_LastName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_FirstName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_ContactID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_AddEdit);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "AddEditContact";
            this.Text = "AddEditContact";
            this.Load += new System.EventHandler(this.AddEditContact_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_AddEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_ContactID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_FirstName;
        private System.Windows.Forms.TextBox txt_LastName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Email;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtp_DateOfBirth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cb_Country;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lbl_SetImage;
        private System.Windows.Forms.PictureBox Image;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}