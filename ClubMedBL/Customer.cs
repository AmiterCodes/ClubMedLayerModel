using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubMedDAL;
using System.Data;

namespace ClubMedBL
{
    public class Customer
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Address { get; set; }

        public List<Order> Orders { 
        get {
                List<Order> orders = new List<Order>();
                foreach(DataRow row in DBOrders.GetOrdersByCustomer(ID).Rows)
                {
                    orders.Add(new Order(row));
                }

                return orders;
            }

}

        public static List<Customer> GetCustomersByLastName(string LName)
        {
            List<Customer> list = new List<Customer>();

            foreach(DataRow row in DBCustomers.GetCustomersByLastName(LName).Rows)
            {
                list.Add(new Customer(row));
            }

            return list;
        }
        
        public Customer(string fname, string lname, string address)
        {
            ID = DBCustomers.InsertCustomer(fname, lname, address);
            this.FName = fname;
            this.LName = lname;
            this.Address = address;
        }

        public Customer(int Id)
        {
            this.ID = Id;

            DataRow row = DBCustomers.GetCustomersById(Id);

            this.FName = (string)row["FName"];
            this.LName = (string)row["LName"];
            this.Address = (string)row["Address"];
        }

        public Customer(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.FName = (string)row["FName"];
            this.LName = (string)row["LName"];
            this.Address = (string)row["Address"];
        }

        public override string ToString()
        {
            return $"#{ID} {FName} {LName}";
        }
    }
}
