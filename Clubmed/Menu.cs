using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubMedUI
{
    class MenuItem
    {
        public string MenuTitle { get; set; }
        public Screen Screen { get; set; }
        public MenuItem() { }
        public MenuItem(string title, Screen screen)
        {
            MenuTitle = title;
            Screen = screen;
        }
    }

   public class Menu:Screen
    {
        //List contains all menu items
        private List<MenuItem> items;
        public Menu(string title):base(title)
        {
            this.items = new List<MenuItem>();
        }
        //Use this methos to add an item to the menu
        public void AddItem(string title, Screen screen)
        {
            
            items.Add(new MenuItem(title, screen));
        }
        //Show the menu on screen!
        public override void Show()
        {
            bool exit = false;
            while (!exit) //Loop until user press the exit option (last option)
            {
                base.Show();
                Console.WriteLine("\tMenu");
                MenuSelector menu = new MenuSelector(1,3, items);
                int option = menu.Select();
                items[option].Screen.Show();
            }
        }
    }
}
