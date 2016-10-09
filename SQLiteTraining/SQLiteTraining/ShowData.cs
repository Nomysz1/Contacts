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

namespace SQLiteTraining
{
    public partial class FormSave : Form
    {
        public FormSave()
        {
            InitializeComponent();

            this.Text = GUI_pl.FormName;

            AddToolStripMenuItem.Text = GUI_pl.AddToolStripMenuItem;
            EditToolStripMenuItem.Text = GUI_pl.EditToolStripMenuItem;
            DeleteToolStripMenuItem.Text = GUI_pl.DeleteToolStripMenuItem;
            ExitToolStripMenuItem.Text = GUI_pl.ExitToolStripMenuItem;

            AddToolStripMenuItem.Click += new EventHandler(ToolsStripMenuItem_Click);
            EditToolStripMenuItem.Click += new EventHandler(ToolsStripMenuItem_Click);
            DeleteToolStripMenuItem.Click += new EventHandler(ToolsStripMenuItem_Click);
            ExitToolStripMenuItem.Click += new EventHandler(ToolsStripMenuItem_Click);
        }

        void ToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
            string name = tsmi.Name;
            switch (name)
            {
                case "AddToolStripMenuItem":
                    Add add = new Add();
                    add.Show();
                    break;
                case "EditToolStripMenuItem":
                    break;
                case "DeleteToolStripMenuItem":
                    break;
                case "ExitToolStripMenuItem":
                    Application.Exit();
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DbOperations.ReadAllRows(listBoxData, Connection.connect());
            Connection.Close();
        }
    }
}
