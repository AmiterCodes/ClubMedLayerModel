using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMedBL;

namespace ClubMedUI
{
   public class UIMain
    {
        Screen initialScreen;
        public UIMain(Screen initial)
        {
            this.initialScreen = initial;
        }
        public void ApplicationStart()
        {

            while (true)
            {
                try
                {
                    initialScreen.Show();


                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("(--==(!) Error (!)==--)");
                    Console.WriteLine($"Error Message: {e.Message}");
                    Console.WriteLine("(--==(!) Error (!)==--)");
                    Console.ReadKey();
                    Console.ResetColor();
                }
            }
        }
    }
    
}
