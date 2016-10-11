using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteTraining.Model
{
    class ParseRowFromListBox
    {
        public static Person Parse(string row)
        {
            Person temporary = new Person();
            string[] splited = row.Split(';');
            temporary.Name = splited[0];
            temporary.Surname = splited[1];
            temporary.PhoneNo = splited[2];

            return temporary;
        }
    }
}
