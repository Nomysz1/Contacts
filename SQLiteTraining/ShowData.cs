using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SQLiteTraining.Model;
using SQLiteTraining.View;
using SQLiteTraining.Controller;
using System.Data.SQLite;

namespace SQLiteTraining
{
    public partial class FormSave : Form
    {
        public FormSave()
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
                    break;
                case "buttonDelete":
                    int selectedIndex = listBoxData.SelectedIndex;
                    string rowOfListBox = listBoxData.Items[selectedIndex].ToString();
                    DBQueries.DeleteSelectedRow(ParseRowFromListBox.Parse(rowOfListBox), conn);
                    DBQueries.ReadAllRows(listBoxData, conn);
                    Connection.Close(conn);
                    break;
            }
        }

    }
}
