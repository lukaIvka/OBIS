using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primarna_AGS
{
    public class Test : ITest, ITest2
    {
        public string Proba()
        {
            string a = "";
            a = "Uspesna komunikacija";
            return a;
        }

        string ITest2.Proba2()
        {
            string a = "";
            a = "Uspesna komunikacija izmedju primarne i sekundarne";
            return a;
        }
    }
}
