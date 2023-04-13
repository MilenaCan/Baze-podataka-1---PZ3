using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019.UIHandler
{
    public class MainUIHandler
    {
        private readonly ComplexQueryUIHandler izvjestajUIHandler = new ComplexQueryUIHandler();
        private readonly ObjekatUIHandler objekatUIHandler = new ObjekatUIHandler();

        public void HandleMainMenu()
        {
            string answer;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine("1 - Rukovanje objektima");
                Console.WriteLine("2 - Kompleksni upiti");
                Console.WriteLine("X - Izlazak iz programa");

                answer = Console.ReadLine();

                switch (answer)
                {
                    case "1":
                        objekatUIHandler.HandleMenu();
                        break;
                    case "2":
                        izvjestajUIHandler.HandleMenu();
                        break;
                }

            } while (!answer.ToUpper().Equals("X"));
        }
    }
}
