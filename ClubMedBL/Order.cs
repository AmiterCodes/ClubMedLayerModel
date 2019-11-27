using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ClubMedDAL;
using System.Threading.Tasks;

namespace ClubMedBL
{
    public class Order
    {
        public int ID { get; set; }

        private int customerId; 

        public Customer Customer {
            get
            {
                Customer customer = new Customer(customerId);
                return customer;
            }
        }

        public int RequestedWeek { get; set; }
        public int RoomType { get; set; }
        public double OrderPrice { get; set; }
        public int ResortID { get; set; }

        public Order(DataRow row)
        {
            ID = (int)row["ID"];
            customerId = (int)row["CustomerID"];
            RequestedWeek = (int)row["RequestedWeek"];
            RoomType = (int)row["RoomType"];
            OrderPrice = (double)row["OrderPrice"];
            ResortID = (int)row["ResortID"];

        }

        public Order(int customerID, int requestedWeek, int roomType, int resortId)
        {
            DataRow row = DBRooms.GetRoom(roomType);
            double price = (double)row["ListPrice"];

             ID = DBOrders.AddOrder(customerID, requestedWeek, roomType, price, resortId);
            this.customerId = customerID;
            this.RequestedWeek = requestedWeek;
            this.RoomType = roomType;
            this.OrderPrice = price;
            this.ResortID = resortId;

        }

        public Order(int id)
        {
            DataRow row = DBOrders.GetOrder(id);

            ID = id;
            customerId = (int)row["CustomerID"];

            RequestedWeek = (int)row["RequestedWeek"];
            RoomType = (int)row["RoomType"];

            OrderPrice = (double)row["OrderPrice"];
            ResortID = (int)row["ResortID"];
        }




    }
}
