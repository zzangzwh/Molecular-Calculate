using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Git_first
{
    public class Element
    {
        //Initializing the Variables to be needed( automatic properties )
        public int Atomic { get; private set; }
        public double Mass { get; private set; }
        public string symbol { get; private set; }
        public string name { get; private set; }

        public Element(string[] files)
        {
            //parsing the string as integer since we are going to use it as our Atomic Number.
            Atomic = int.Parse(files[0]);
            //Getting the second value and assigning it as symbol filtering out the empty spaces.
            symbol = files[1];
            //Getting the third value in the string array and assigning it a s name.
            name = files[2];
            //parsing the string as doublc since we are going to use it as our mass.
            Mass = double.Parse(files[3].Trim(new char[] { '(', ')' }));
        }
    }
}
