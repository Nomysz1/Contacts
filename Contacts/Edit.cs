using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using Contacts.View;
using Contacts.Model;

namespace Contacts
{
    public partial class Edit : Form
    {
        Person previousDetails;
        public Edit(string name, string surname, string PhoneNo)
        {
            InitializeComponent();

            previousDetails = new Person();
            previousDetails.Name = name;
            previousDetails.Surname = surname;
            previousDetails.PhoneNo = PhoneNo;

            textBoxName.Text = previousDetails.Name;
            textBoxSurname.Text = previousDetails.Surname;
            textBoxPhoneNo.Text = previousDetails.PhoneNo;

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            if (culture.ToString() == "pl-PL")
            {
                this.Text = GUI_pl.FormName; //Set up the title
                labelName.Text = GUI_pl.LabelName;
                labelSurname.Text = GUI_pl.LabelSurname;
                labelPhoneNo.Text = GUI_pl.LabelPhoneNo;
                buttonSave.Text = GUI_pl.ButtonSave;
            }
            else if (culture.ToString() == "en-US")
            {
                this.Text = GUI_en.FormName; //Set up the title
                labelName.Text = GUI_en.LabelName;
                labelSurname.Text = GUI_en.LabelSurname;
                labelPhoneNo.Text = GUI_en.LabelPhoneNo;
                buttonSave.Text = GUI_en.ButtonSave;
            }

            this.buttonSave.Click += new EventHandler(buttonSave_Click);
        }


        void buttonSave_Click(object sender, EventArgs e)
        {
            Person curr = new Person();
            curr.Name = textBoxName.Text;
            curr.Surname = textBoxSurname.Text;
            curr.PhoneNo = textBoxPhoneNo.Text;

            SQLiteConnection conn = Connection.connect();
            DBQueries.UpdateRow(previousDetails, curr, conn);
            Connection.Close(conn);

            this.Close();
        }
    }
}
