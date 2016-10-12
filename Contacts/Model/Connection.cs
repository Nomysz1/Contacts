using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Contacts.Model
{
    class Connection
    {
        private static string strbuilder = "DataSource=Mydb.db;";

        public static SQLiteConnection connect()
        {
            SQLiteConnection conn = new SQLiteConnection(strbuilder);
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return conn;
        }

        public static void Close(SQLiteConnection conn)
        {
            try
            {
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
