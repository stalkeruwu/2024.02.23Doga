using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    internal class Tabor
    {
        public int kezdeshonap { get; set; }
        public int kezdesnap { get; set; }
        public int vegehonap { get; set; }
        public int vegenap { get; set; }
        public string diakbetujel { get; set; }
        public string tabortema { get; set; }

        public DateTime DateKezdes
        {
            get
            {
                return new DateTime(2020, kezdeshonap, kezdesnap);
            }
        }

        public DateTime DateVege
        {
            get
            {
                return new DateTime(2020, vegehonap, vegenap);
            }
        }




        public Tabor(string src)
        {
            var split = src.Split('\t');
            kezdeshonap = int.Parse(split[0]);
            kezdesnap = int.Parse(split[1]);
            vegehonap = int.Parse(split[2]);
            vegenap = int.Parse(split[3]);
            diakbetujel = split[4];
            tabortema = split[5];
        }

    }
}
