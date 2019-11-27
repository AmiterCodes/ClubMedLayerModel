using ClubMedBL;
using System;
namespace ClubMedUI
{
    public class InsertCustomer : Screen
    {
        public InsertCustomer() : base("Insert Customer Menu")
        {
            
        }

        public override void Show()
        {
            base.Show();

            string fname = UIHelper.InputString("What is your first name?");
            string lname = UIHelper.InputString("What is your last name?");
            string address = UIHelper.InputString("Where do you live?");

            Customer customer = new Customer(fname, lname, address);

            UIHelper.Success();
            Console.ReadKey();
        }
    }
}