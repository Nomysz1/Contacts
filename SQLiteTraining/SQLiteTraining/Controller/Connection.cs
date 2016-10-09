using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;
using System.Windows.Forms;
using SQLiteTraining.Model;

namespace SQLiteTraining.Controller
{
    class Connection
    {
        private static string strbuilder = "DataSource=Mydb.db;";
        private static SQLiteConnection conn;
        public static SQLiteConnection connect()
        {
            conn = new SQLiteConnection(strbuilder);
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

        public static void Close()
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
