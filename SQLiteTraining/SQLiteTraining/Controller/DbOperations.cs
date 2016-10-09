using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using SQLiteTraining.Model;

namespace SQLiteTraining.Controller
{
    class DbOperations
    {
        public static void InsertOneRow(Person p, SQLiteConnection conn)
        {
            if (p.Name != "" && p.Surname != "" && p.PhoneNo != "")
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(conn);
                    string query = "INSERT INTO Contacts (Name, Surname, PhoneNo) VALUES('" + p.Name + "','" + p.Surname + "','" + p.PhoneNo + "');";
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            else
                MessageBox.Show("Error");
        }

        public static void ReadAllRows(ListBox lb, SQLiteConnection conn)
        {
            lb.Items.Clear();
            try
            {
                SQLiteCommand command = new SQLiteCommand(conn);
                string query = "SELECT * FROM Contacts";
                command.CommandText = query;
                SQLiteDataReader sdr = command.ExecuteReader();
                while (sdr.Read())
                {
                    string row = String.Format("{0} -> {1} ; {2} ; {3}", sdr.GetInt32(0), sdr.GetString(1), sdr.GetString(2), sdr.GetString(3));
                    lb.Items.Add(row);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
