using ClubMedBL;
using System;

namespace ClubMedUI
{
    public class DisplayCustomer : Screen
    {
        public DisplayCustomer() : base("Display Customer Menu")
        {
        }

        public override void Show()
        {
            base.Show();

            int id = UIHelper.InputInt("What is the id of the customer");
            Customer customer = new Customer(id);

            FormView view = new FormView("Customer", customer);

            view.Show();


            Console.ReadKey();
        }
    }

}