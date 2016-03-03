using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Contact
    {
        public string Name;
        public string Number;
        public Contact(string Name, string Number)
        {
            this.Name = Name;
            this.Number = Number;
        }
        public override string ToString()
        {
            App.i = App.i + 1;
            int numberOfLetters = this.Name.Length;
            
            
            string spaces = "";
            for(int j=0; j<(40-numberOfLetters); j++)
            {
                spaces += " ";
            }
            return App.i + ")" + "           " + this.Name;
            
        }
        public string ToString1()
        {
            return "                " + this.Number;

        }
    }
}
