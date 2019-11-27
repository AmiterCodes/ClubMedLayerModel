using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ClubMedDAL
{
    public class DBCustomers
    {
        public static int InsertCustomer(string fName, string lName, string address)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"INSERT INTO Customers (FName,LName,Address) VALUES('{fName}','{lName}','{address}')";

            int a = helper.InsertWithAutoNumKey(sql);
            helper.CloseConnection();

            if (a == -1) throw new SQLException();
            return a;
        }

        public static DataTable GetCustomersByLastName(string lName)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM Customers WHERE LName = '" + lName + "'";

            DataTable tb = helper.GetDataTable(sql);

            helper.CloseConnection();
            
            return tb;
        }
        
        public static DataRow GetCustomersById(int id)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);

            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM Customers WHERE ID = " + id;

            DataTable tb = helper.GetDataTable(sql);

            helper.CloseConnection();

            if (tb.Rows.Count == 0) return null;


            return tb.Rows[0];
        }



    }
}
