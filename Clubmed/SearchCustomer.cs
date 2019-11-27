using ClubMedBL;
using System.Collections.Generic;
using System;

namespace ClubMedUI
{
    public class SearchCustomer : Screen
    {
        public SearchCustomer() : base("Search Customer Menu")
        {
        }

        public override void Show()
        {
            base.Show();
            string name = UIHelper.InputString("Please enter your wanted Last Name: ");

            List<Customer> customers = Customer.GetCustomersByLastName(name);

            TableView view = new TableView("Customers", customers);
            view.Show();
            Console.ReadKey();

        }
    }
}