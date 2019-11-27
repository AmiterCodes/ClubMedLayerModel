using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMedUI
{
    class Program
    {
        static void Main(string[] args)
        {

            //Create UI with main menu as starting screen!
            UIMain ui = new UIMain(new MainMenu());
            ui.ApplicationStart();

        }
    }
}
