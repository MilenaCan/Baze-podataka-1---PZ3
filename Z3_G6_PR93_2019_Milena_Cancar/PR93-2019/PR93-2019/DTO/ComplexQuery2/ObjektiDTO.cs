using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DTO.ComplexQuery2
{
    public class ObjektiDTO
    {
        public int Ido { get; set; }
        public string Idl { get; set; }
        public string NazivVo { get; set; }
        public double Vrednost { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public ObjektiDTO() { }

        public ObjektiDTO(int ido, string idl, string naziv, double vrednost, string ime, string prezime)
        {
            Ido = ido;
            Idl = idl;
            NazivVo = naziv;
            Vrednost = vrednost;
            Ime = ime;
            Prezime = prezime;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20} {2, -30} {3, -20} {4, -20} {5, 20}",
                    Ido, Idl, NazivVo, Vrednost, Ime, Prezime);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-20} {2, -30} {3, -20} {4, -20} {5, 20}",
                    "IDO", "IDL", "NAZIV", "VREDNOST", "IME", "PREZIME");
        }
    }
}
