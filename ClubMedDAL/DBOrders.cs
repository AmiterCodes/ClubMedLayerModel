using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace ClubMedDAL
{
    public class DBOrders
    {
        public static DataTable GetOrdersByCustomer(int customerId)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM Orders WHERE CustomerID = " + customerId;

            DataTable tb = helper.GetDataTable(sql);

            helper.CloseConnection();

            return tb;
        }

        public static int AddOrder(int customerId, int week, int roomType, double price ,int resortId)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();

            string sql = $"INSERT INTO Orders (CustomerID, RequestedWeek, RoomType, OrderPrice, ResortID) VALUES('{customerId}','{week}','{roomType}','{price}','{resortId}')";
            
            int a = helper.InsertWithAutoNumKey(sql);
            helper.CloseConnection();

            if (a == -1) throw new SQLException();

            return a;
        }

        public static DataRow GetOrder(int OrderId)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM Orders WHERE ID = " + OrderId;

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }
    }
}
