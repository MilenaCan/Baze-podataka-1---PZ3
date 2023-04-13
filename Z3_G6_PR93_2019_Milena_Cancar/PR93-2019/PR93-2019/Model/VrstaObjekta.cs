using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.Model
{
    public class VrstaObjekta
    {
        public int Idvo { get; set; }
        public string NazivVO { get; set; }

        public VrstaObjekta() { }

        public VrstaObjekta(int idvo, string nazivVO)
        {
            Idvo = idvo;
            NazivVO = nazivVO;
        }

        public override string ToString()
        {
            return string.Format("{0,-6} {1,-20}",
                Idvo, NazivVO);
        }

        public static string GetFormattedHeader()
        {
            return string.Format("{0,-6} {1,-20}",
               "IDVO", "NAZIVVO");
        }

        public override bool Equals(object obj)
        {
            var vrstaObjekta = obj as VrstaObjekta;
            return vrstaObjekta != null &&
                   Idvo == vrstaObjekta.Idvo &&
                   NazivVO == vrstaObjekta.NazivVO;
        }
    }
}
