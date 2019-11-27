using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Reflection;

namespace ClubMedUI
{
    class FormView : Screen
    {
        private object obj;
        public FormView(string title, object obj):base(title)
        {
            this.obj = obj;
        }


        public override void Show()
        {
            int size = 30;
            //Display title
            Console.WriteLine($"\t{Title}");
            //Get the type of the object!
            Console.WriteLine("╔" + new string('═', size) + "╗");
            Type t = obj.GetType();

            // Get the public properties of the instance (not only related to Object).

            PropertyInfo[] propInfos = t.GetProperties(BindingFlags.Public | BindingFlags.Instance);

            // Display information for all properties.
            foreach (PropertyInfo propInfo in propInfos)
            {
                bool readable = propInfo.CanRead;
                bool writable = propInfo.CanWrite;

                if (readable)
                {
                    Object prop = propInfo.GetValue(obj);
                    //Do not display lists, arrays, etc...
                    if (!(prop is IList))
                        Console.WriteLine($"║  {propInfo.Name.PadRight(10)}| {propInfo.GetValue(obj).ToString()}".PadRight(size + 1) + "║");
                    else
                    {
                        var view = new TableView(propInfo.Name, (IList)prop);
                        view.Show();

                        Console.WriteLine();
                    }

                }
            }
            Console.Write("╚" + new string('═', size) + "╝");
        }
    }
}
