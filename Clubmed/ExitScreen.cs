using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Diagnostics;

namespace ClubMedUI
{
    class ExitScreen : Screen
    {

        public ExitScreen() : base("Sorry mate. you decided to exit so you gotta pay the price.")
        {

        }

        public override void Show()
        {
            base.Show();
            Console.WriteLine("Goodbye! (your computer will turn off in 10 seconds)");
            Thread.Sleep(10000);
            Console.Beep();

            //Process.Start("shutdown", "/s /t 0");

            Environment.Exit(0);

        }
        
    }
}
