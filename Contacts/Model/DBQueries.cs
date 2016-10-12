using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Contacts.Model
{
    class DBQueries
    {
        public static void InsertOneRow(Person p, SQLiteConnection conn)
        {
            if (p.Name != "" && p.Surname != "" && p.PhoneNo != "")
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(conn);
                    string query = string.Format("INSERT INTO Contacts (Name, Surname, PhoneNo) VALUES('{0}', '{1}', '{2}');", p.Name, p.Surname, p.PhoneNo);
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
                    string row = String.Format("{0};{1};{2}", sdr.GetString(1), sdr.GetString(2), sdr.GetString(3));
                    lb.Items.Add(row);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static void UpdateRow(Person prev, Person p, SQLiteConnection conn)
        {
            if (p.Name != "" && p.Surname != "" && p.PhoneNo != "")
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(conn);
                    string query = string.Format("UPDATE Contacts SET Name='{0}', Surname='{1}', PhoneNo='{2}' WHERE Name='{3}' AND Surname='{4}' AND PhoneNo='{5}';" 
                        ,p.Name, p.Surname, p.PhoneNo, prev.Name, prev.Surname, prev.PhoneNo);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        public static void DeleteSelectedRow(Person p, SQLiteConnection conn)
        {
            if (p.Name != "" && p.Surname != "" && p.PhoneNo != "")
            {
                try
                {
                    SQLiteCommand command = new SQLiteCommand(conn);
                    string query = String.Format("DELETE FROM Contacts WHERE Name='{0}' AND Surname='{1}' AND PhoneNo='{2}';", p.Name, p.Surname, p.PhoneNo);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
