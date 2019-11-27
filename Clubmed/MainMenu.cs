using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMedUI
{
  public  class MainMenu:Menu
    {
        public MainMenu():base("Main Menu")
        {
            //Build items in main menu!
           
            AddItem("Insert Customer", new InsertCustomer());
            AddItem("Search Customer by last Name", new SearchCustomer());
            AddItem("Display Customer and Details", new DisplayCustomer());
            AddItem("Insert Order", new InsertOrder());
            AddItem("Quit", new ExitScreen());

        }
    }
}
