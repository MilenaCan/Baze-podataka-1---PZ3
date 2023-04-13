using PR93_2019.DTO.ComplexQuery1;
using PR93_2019.DTO.ComplexQuery2;
using PR93_2019.DTO.ComplexQuery3;
using PR93_2019.Model;
using PR93_2019.Service;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.UIHandler
{
    class ComplexQueryUIHandler
    {
        private static readonly ComplexQueryService complexQueryService = new ComplexQueryService();
        private static readonly ObjekatService objekatService = new ObjekatService();
        public void HandleMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite funkcionalnost:");
                Console.WriteLine("1  - Izvjestaj svih objekata jednog lica");
                Console.WriteLine("2  - Izvjestaj po vrsti lica");
                Console.WriteLine("3  - Kupovina objekta");
                Console.WriteLine("4  - Svi objekti jedne vrste");
                Console.WriteLine("X  - Izlazak");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        SviObjektiJednogLica();
                        break;
                    case "2":
                        ObjektiPoVrstiLica();
                        break;
                    case "3":
                        KupovinaObjekta();
                        break;
                    case "4":
                        SviObjektiVrsteObjekta();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }

        private void SviObjektiJednogLica()
        {
            try
            {
                Console.WriteLine("Unesi ID lica:");
                string idl = Console.ReadLine();
                LicaObjekti licaObjekti = complexQueryService.SviObjektiJednogLica(idl);

                if(licaObjekti.objekti.Count == 0)
                {
                    Console.WriteLine("Lice sa ID: " + idl + " nema objekte.");
                    return;
                }

                Console.WriteLine(Objekat.GetFormattedHeader());
                foreach (var item in licaObjekti.objekti)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("Ukupna vrijednost objekata: " + licaObjekti.UkupnaCijena);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ObjektiPoVrstiLica()
        {
            try
            {
                List<VrstaLicaObjekti> vrstaLicaObjekti = complexQueryService.ObjektiPoVrstiLica();

                foreach (VrstaLicaObjekti item in vrstaLicaObjekti)
                {
                    List<ObjektiDTO> sviObjektiZaVrstuLicu = objekatService.FindAllByVrstaLica(item.VrstaLica).ToList();

                    Console.WriteLine("Objekti za vrstu licu: " + item.VrstaLica);
                    Console.WriteLine(ObjektiDTO.GetFormattedHeader());
                    foreach (var objekat in sviObjektiZaVrstuLicu)
                    {
                        Console.WriteLine(objekat);
                    }
                    Console.WriteLine("Ukupan broj objekata: " + sviObjektiZaVrstuLicu.Count + ", Ukupan dug: " + item.UkupanDug);
                    Console.WriteLine();
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void KupovinaObjekta()
        {
            try
            {
                Console.WriteLine("Unesi ID lica:");
                string idl = Console.ReadLine();
                Console.WriteLine("Unesi ID objekta:");
                int ido = Convert.ToInt32(Console.ReadLine());

                complexQueryService.KupovinaObjekta(ido, idl);
                Console.WriteLine("Lice sa ID: " + idl + " je uspjesno kupilo objekat ID: " + ido);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void SviObjektiVrsteObjekta()
        {
            try
            {
                Console.WriteLine("Unesi vrstu objekta: ");
                string naziv = Console.ReadLine();
                ObjektiVrsteObjekta objekti = complexQueryService.SviObjektiJedneVrste(naziv);
                Objekat.GetFormattedHeader();
                foreach(Objekat o in objekti.ListaObjekata)
                {
                    Console.WriteLine(o);
                }
                Console.WriteLine("Prosjecna vrijednost je: "+ objekti.ProsijecnaVrijednost);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
