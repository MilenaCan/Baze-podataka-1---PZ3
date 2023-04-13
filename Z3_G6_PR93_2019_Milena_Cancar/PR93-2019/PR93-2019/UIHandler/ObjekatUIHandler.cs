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
    public class ObjekatUIHandler
    {
        private static readonly ObjekatService objekatService = new ObjekatService();

        public void HandleMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite funkcionalnost:");
                Console.WriteLine("1  - Prikaz svih");
                Console.WriteLine("2  - Prikaz po identifikatoru");
                Console.WriteLine("3  - Unos jednog");
                Console.WriteLine("4  - Unos vise");
                Console.WriteLine("5  - Izmjena po identifikatoru");
                Console.WriteLine("6  - Brisanje po identifikatoru");
                Console.WriteLine("X  - Izlazak");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowById();
                        break;
                    case "3":
                        HandleSingleInsert();
                        break;
                    case "4":
                        HandleMultipleInserts();
                        break;
                    case "5":
                        HandleUpdate();
                        break;
                    case "6":
                        HandleDelete();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
        private void ShowAll()
        {
            try
            {
                List<Objekat> objekti = objekatService.FindAll().ToList();
                Console.WriteLine(Objekat.GetFormattedHeader());
                foreach (var item in objekti)
                {
                    Console.WriteLine(item);
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void ShowById()
        {
            try
            {
                Console.WriteLine("Unesite id: ");
                int id = Convert.ToInt32(Console.ReadLine());
                Objekat objekat = objekatService.FindById(id);
                if (objekat == null)
                {
                    Console.WriteLine("Objekat ne postoji");
                    return;
                }
                Console.WriteLine(Objekat.GetFormattedHeader());
                Console.WriteLine(objekat);

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void HandleSingleInsert()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (!objekatService.ExistsById(id))
                {
                    Console.WriteLine("Unesi ID lica:");
                    string idl = Console.ReadLine();
                    Console.WriteLine("Unesi ID vrste objekta:");
                    int idvo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesi povrsinu objekta:");
                    double pov = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Unesi adresu objekta:");
                    string adr = Console.ReadLine();
                    Console.WriteLine("Unesi vrijednost objekta:");
                    double vr = Convert.ToDouble(Console.ReadLine());
                    Objekat s = new Objekat(id, idl, idvo, pov, adr, vr);
                    objekatService.Save(s);
                }
                else
                {
                    Console.WriteLine("Objekat sa unijetim ID-om vec postoji");
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleUpdate()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (objekatService.ExistsById(id))
                {
                    Console.WriteLine("Unesi ID lica:");
                    string idl = Console.ReadLine();
                    Console.WriteLine("Unesi ID vrste objekta:");
                    int idvo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Unesi povrsinu objekta:");
                    double pov = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Unesi adresu objekta:");
                    string adr = Console.ReadLine();
                    Console.WriteLine("Unesi vrijednost objekta:");
                    double vr = Convert.ToDouble(Console.ReadLine());
                    Objekat s = new Objekat(id, idl, idvo, pov, adr, vr);
                    objekatService.Save(s);
                }
                else
                {
                    Console.WriteLine("Objekat sa unijetim ID-om ne postoji");
                }

            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleDelete()
        {
            Console.WriteLine("Unesite id:");
            int id = Convert.ToInt32(Console.ReadLine());
            try
            {
                if (objekatService.ExistsById(id))
                {
                    objekatService.DeleteById(id);
                    Console.WriteLine("Uspjesno brisanje");
                }
                else
                {
                    Console.WriteLine("Objekat sa unijetim ID-om ne postoji");
                }
            }
            catch (DbException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private void HandleMultipleInserts()
        {
            {
                int op;
                while (true)
                {
                    Console.WriteLine("[1] Dodaj");
                    Console.WriteLine("[0] Kraj dodavanja");
                    Console.WriteLine("Izaberi opciju");
                    op = Convert.ToInt32(Console.ReadLine());
                    if (op == 0)
                        break;
                    HandleSingleInsert();
                }
            }
        }
    }
}
