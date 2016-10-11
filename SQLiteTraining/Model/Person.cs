using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SQLiteTraining.Model
{
    class Person
    {
        private string name, surname, phoneNo;

        private bool ContainsNumbers(string str)
        {
            int length = str.Length;
            for (int i = 0; i < length; ++i)
                if (Char.IsDigit(str[i]))
                    return false;
            return true;
        }

        private bool ContainsAlphabet(string str)
        {
            int length = str.Length;
            for (int i = 0; i < length; ++i)
                if(Char.IsLetter(str[i]))
                    return false;
            return true;
        }

        public string Name
        {
            get
            {
                return name;
            }
            set 
            {
                if(ContainsNumbers(value))
                    name = value;
            }
        }

        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                if(ContainsNumbers(value))
                    surname = value;
            }
        }

        public string PhoneNo
        {
            get
            {
                return phoneNo;
            }
            set
            {
                if(ContainsAlphabet(value))
                    phoneNo = value;
            }
        }
    }
}
