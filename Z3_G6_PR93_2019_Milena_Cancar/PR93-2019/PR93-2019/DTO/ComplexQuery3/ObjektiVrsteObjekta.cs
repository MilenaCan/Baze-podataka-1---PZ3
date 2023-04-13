using PR93_2019.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.DTO.ComplexQuery3
{
    public class ObjektiVrsteObjekta
    {
        private List<Objekat> listaObjekata = new List<Objekat>();
        private double prosijecnaVrijednost;

        public ObjektiVrsteObjekta()
        {
        }

        public List<Objekat> ListaObjekata { get => listaObjekata; set => listaObjekata = value; }
        public double ProsijecnaVrijednost { get => prosijecnaVrijednost; set => prosijecnaVrijednost = value; }
    }
}
