using System;
using ClubMedBL;


namespace ClubMedUI
{
    public class InsertOrder : Screen
    {
        public InsertOrder() : base("Order Menu")
        {
        }
        
        public override void Show()
        {
            base.Show();

            int customerID = UIHelper.InputInt("Please insert your customer ID");
            int resortId = UIHelper.InputInt("Please enter your Resort's ID?");
            int requestedWeek = UIHelper.InputInt("Would you kindly fill in your desired week sir", a => a < 52 && a > 0);
            int type = UIHelper.InputInt("Hey shamen insert your room type's ID! :)");

            Order order = new Order(customerID, requestedWeek, type, resortId);
            UIHelper.Success(); 
            FormView view = new FormView("Here's your order", order);
            view.Show();

            Console.ReadKey();
        }
    }
}
 