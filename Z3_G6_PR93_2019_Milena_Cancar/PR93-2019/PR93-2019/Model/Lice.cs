using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.Model
{
    public class Lice
    {
        public string Idl { get; set; }
        public string Imel { get; set; }
        public string PrzL { get; set; }
        public string VrstaL { get; set; }
        public int MesPrihodiL { get; set; }

        Lice() { }

        public Lice(string idl, string imel, string przL, string vrstaL, int mesPrihodiL)
        {
            Idl = idl;
            Imel = imel;
            PrzL = przL;
            VrstaL = vrstaL;
            MesPrihodiL = mesPrihodiL;
        }

        public override string ToString()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",
               Idl, Imel, PrzL, VrstaL, MesPrihodiL);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-20} {1,-20} {2,-20} {3,-20} {4,-20}",
               "IDL", "IMEL", "PRZL", "VRSTAL", "MES_PRIHODIL");
        }

        public override bool Equals(object obj)
        {
            var lice = obj as Lice;
            return lice != null &&
                   Idl == lice.Idl &&
                   Imel == lice.Imel &&
                   PrzL == lice.PrzL &&
                   VrstaL == lice.VrstaL &&
                   MesPrihodiL == lice.MesPrihodiL;
        }

    }
}
