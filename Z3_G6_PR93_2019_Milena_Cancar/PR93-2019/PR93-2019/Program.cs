using PR93_2019.UIHandler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR93_2019
{
    class Program
    {
        static void Main(string[] args)
        {
            MainUIHandler mainUIHandler = new MainUIHandler();
            mainUIHandler.HandleMainMenu();
            Console.WriteLine("Kraj programa");
            Console.ReadKey();
        }
    }
}
