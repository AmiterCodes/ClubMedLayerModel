using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMedUI
{
    public static class UIHelper
    {
        
        public static void Success()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("(!) Task Successfully Done");
            Console.ResetColor();
        }

        public static int InputInt(string ask)
        {
            Console.WriteLine(ask);
            int output = 0;

            while(!int.TryParse(Console.ReadLine(), out output)) { }

            return output;
        }

        public static int InputInt(string ask, Func<int, bool> validator)
        {
            Console.WriteLine(ask);
            int output = 0;

            while (!int.TryParse(Console.ReadLine(), out output) && !validator(output)) { }

            return output;
        }

        public static double InputDouble(string ask)
        {
            Console.WriteLine(ask);
            double output = 0;

            while (!double.TryParse(Console.ReadLine(), out output)) { }

            return output;
        }

        public static string InputString(string ask)
        {
            Console.WriteLine(ask);
            string a = Console.ReadLine();

            while (a == string.Empty) a = Console.ReadLine();

            return a;
        }
    }
}
