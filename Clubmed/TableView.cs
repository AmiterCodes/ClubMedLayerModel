using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections;

namespace ClubMedUI
{
    public class TableView : Screen
    {

        private static string PadString(string s)
        {
            s = s.PadLeft(10);
            s = s.PadRight(20);
            return s;
        }
        protected IList data;
        public TableView(string title, IList data):base(title)
        {
            this.data = data;
        }
        public override void Show()
        {
            //Display title
            Console.WriteLine($"\t{Title}");
            //check if list contains data
            if (data.Count == 0)
            {
                Console.WriteLine("\tNo Data Found");
                return;
            }
            //Get the type of the object!
            Type t = data[0].GetType();
            // Get the public properties of the instance (not only related to Object).
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            int length = 0;
            foreach(var info in propInfos)
            {
                if (!(info.GetValue(data[0]) is ICollection)) length++;
            }

            for (int i = 0; i < length; i++)
            {
                Console.Write(new string('═', 20) + "╦");
            }


            Console.WriteLine();
            // Display information for all properties.
            foreach (PropertyInfo propInfo in propInfos)
            {
                bool readable = propInfo.CanRead;
                if (readable && !(propInfo.GetValue(data[0]) is ICollection))
                {
                    Console.Write(PadString(propInfo.Name) + "║");
                }
            }
            Console.WriteLine();
            for (int i = 0; i < length; i++)
            {
                Console.Write(new string('═', 20) + "╬");
            }

            //list values for all data objects

            foreach (Object obj in data)
            {
                Console.WriteLine();
                foreach (PropertyInfo propInfo in propInfos)
                {
                    object val = propInfo.GetValue(obj);
                    bool readable = propInfo.CanRead;
                    if (readable && !(val is ICollection))
                    {

                        Console.Write(PadString(val.ToString()) + "║");
                    }
                }
            }
            Console.WriteLine();
            for(int i = 0; i < length; i++)
            {
                Console.Write(new string('═', 20) + "╩");
            }
        }
    }
    
}
