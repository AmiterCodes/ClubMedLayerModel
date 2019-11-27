using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace ClubMedDAL
{
    public class DBRooms
    {
        public static DataRow GetRoom(int RoomsId)
        {
            DBHelper helper = new DBHelper(Constants.PROVIDER, Constants.PATH);
            
            if (!helper.OpenConnection()) throw new ConnectionException();
            string sql = $"SELECT * FROM Rooms WHERE RoomType = " + RoomsId;

            DataTable tb = helper.GetDataTable(sql);
            helper.CloseConnection();
            if (tb.Rows.Count == 0) return null;
            return tb.Rows[0];
        }
    }
}
