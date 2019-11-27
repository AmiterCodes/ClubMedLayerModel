using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ClubMedUI
{
    public class TableView<T> : Screen
    {
        protected ICollection<T> data;
        public TableView(string title, ICollection<T> data):base(title)
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
            Type t = data.ElementAt(0).GetType();
            // Get the public properties of the instance (not only related to Object).
            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            // Display information for all properties.
            foreach (PropertyInfo propInfo in propInfos)
            {
                bool readable = propInfo.CanRead;
                if (readable)
                {
                    Console.Write("{0}\t\t", propInfo.Name);
                }
            }

            //list values for all data objects
            
            foreach (Object obj in data)
            {
                Console.WriteLine();
                Console.Write("\t");
                foreach (PropertyInfo propInfo in propInfos)
                {
                    bool readable = propInfo.CanRead;
                    if (readable)
                    {
                        Console.Write("{0}\t\t", propInfo.GetValue(obj));
                    }
                }
            }
        }
    }
    
}
