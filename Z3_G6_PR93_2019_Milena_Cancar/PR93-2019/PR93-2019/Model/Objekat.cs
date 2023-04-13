using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.Model
{
    public class Objekat
    {
        public int Ido { get; set; }
        public string Idl { get; set; }
        public int Idvo { get; set; }
        public double Povrsina { get; set; }
        public string Adresa { get; set; }
        public double Vrednost { get; set; }

        public Objekat() { }

        public Objekat(int ido, string idl, int idvo, double povrsina, string adresa, double vrednost)
        {
            Ido = ido;
            Idl = idl;
            Idvo = idvo;
            Povrsina = povrsina;
            Adresa = adresa;
            Vrednost = vrednost;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20} {2, -20} {3, -20} {4, -20} {5, 20}",
                    Ido, Idl, Idvo, Povrsina, Adresa, Vrednost);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-20} {2, -20} {3, -20} {4, -20} {5, 20}",
                    "IDO", "IDL", "IDVO", "POVRSINA", "ADRESA", "VREDNOST (eur)");
        }

        public override bool Equals(object obj)
        {
            var objekat = obj as Objekat;
            return objekat != null &&
                   Ido == objekat.Ido &&
                   Idl == objekat.Idl &&
                   Idvo == objekat.Idvo &&
                   Povrsina == objekat.Povrsina &&
                   Adresa == objekat.Adresa &&
                   Vrednost == objekat.Vrednost;
        }
    }
}
