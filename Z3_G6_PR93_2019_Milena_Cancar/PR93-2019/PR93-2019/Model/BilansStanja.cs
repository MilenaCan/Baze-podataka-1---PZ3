using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.Model
{
    public class BilansStanja
    {
        public int Idbs { get; set; }
        public string Idl { get; set; }
        public double Saldo { get; set; }
        public double Dug { get; set; }
        public double Kamata { get; set; }

        public BilansStanja(){ }

        public BilansStanja(int idbs, string idl, double saldo, double dug, double kamata)
        {
            Idbs = idbs;
            Idl = idl;
            Saldo = saldo;
            Dug = dug;
            Kamata = kamata;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20} {2,-10} {3,-10} {4,-10}",
                Idbs, Idl, Saldo, Dug, Kamata);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-20} {2,-10} {3,-10} {4,-20}",
               "IDBS", "IDLSALDO (din)", "DUG (din)", "KAMATA (din)");
        }

        public override bool Equals(object obj)
        {
            var bilansStanja = obj as BilansStanja;
            return bilansStanja != null &&
                   Idbs == bilansStanja.Idbs &&
                   Idl == bilansStanja.Idl &&
                   Saldo == bilansStanja.Saldo &&
                   Dug == bilansStanja.Dug &&
                   Kamata == bilansStanja.Kamata;
        }

    }
}
