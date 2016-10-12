using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using Contacts.Model;
using Contacts.View;

namespace Contacts
{
    public partial class Add : Form
    {
        Person person;

        public Add()
        {
            InitializeComponent();

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
            person = new Person();
            person.Name = textBoxName.Text;
            person.Surname = textBoxSurname.Text;
            person.PhoneNo = textBoxPhoneNo.Text;

            SQLiteConnection conn = Connection.connect();

            DBQueries.InsertOneRow(person, conn);
            Connection.Close(conn);

            textBoxName.Text = textBoxSurname.Text = textBoxPhoneNo.Text = "";
        }
    }
}
