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
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            var culture = System.Globalization.CultureInfo.CurrentCulture;
            if (culture.ToString() == "pl-PL")
            {
                this.Text = GUI_pl.FormName;
                this.buttonAdd.Text = GUI_pl.ButtonAdd;
                this.buttonEdit.Text = GUI_pl.ButtonEdit;
                this.buttonRefresh.Text = GUI_pl.ButtonRefresh;
                this.buttonDelete.Text = GUI_pl.ButtonDelete;
            }
            else if (culture.ToString() == "en-US")
            {
                this.Text = GUI_en.FormName;
                this.buttonAdd.Text = GUI_en.ButtonAdd;
                this.buttonEdit.Text = GUI_en.ButtonEdit;
                this.buttonRefresh.Text = GUI_en.ButtonRefresh;
                this.buttonDelete.Text = GUI_en.ButtonDelete;
            }

            this.buttonRefresh.Click += new EventHandler(buttons_Click);
            this.buttonAdd.Click += new EventHandler(buttons_Click);
            this.buttonEdit.Click += new EventHandler(buttons_Click);
            this.buttonDelete.Click += new EventHandler(buttons_Click);
        }

        void buttons_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string name = btn.Name;
            SQLiteConnection conn = Connection.connect();


            switch (name)
            {
                case "buttonRefresh":
                    DBQueries.ReadAllRows(listBoxData, conn);
                    Connection.Close(conn);
                    break;
                case "buttonAdd":
                    Add add = new Add();
                    add.Show();
                    break;
                case "buttonEdit":
                    string rowOfListBox = listBoxData.SelectedItem.ToString();
                    Edit edit = new Edit
                            (ParseRowFromListBox.Parse(rowOfListBox).Name,
                            ParseRowFromListBox.Parse(rowOfListBox).Surname,
                            ParseRowFromListBox.Parse(rowOfListBox).PhoneNo);
                    edit.Show();
                    break;
                case "buttonDelete":
                    string rowOfListBox1 = listBoxData.SelectedItem.ToString();
                    DBQueries.DeleteSelectedRow(ParseRowFromListBox.Parse(rowOfListBox1), conn);
                    DBQueries.ReadAllRows(listBoxData, conn);
                    Connection.Close(conn);
                    break;
            }
        }
    }
}
