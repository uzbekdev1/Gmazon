using System;
using System.Data;
using System.Data.SqlClient;
using Gmazon.DBUtility;

namespace Gmazon.SQLDAL
{
    class orderinfo : Gmazon.IDAL.Iorderinfo
    {
        public DataTable getOrderByUserName(string userName)
        {
            String str = "select * from Orders where userName=@userName order by orderID desc";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@userName", SqlDbType.NVarChar, 100, "userName", userName)
                                  };
            return SQLDbHelper.ExecuteDt(str, param); ;
        }

        public void saveOrder(string bookNames, string userName, double orderPrice)
        {
            String str = "insert into Orders(bookNames, userName, orderPrice, orderTime) values (@bookNames, @userName, @orderPrice, '" + DateTime.Now + "')";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@bookNames", SqlDbType.NVarChar, 1000, "bookNames", bookNames),
                                      SQLDbHelper.GetParameter("@userName", SqlDbType.NVarChar, 32, "userName", userName),
                                      SQLDbHelper.GetParameter("@orderPrice", SqlDbType.Float, orderPrice)
                                  };
            SQLDbHelper.ExecuteSql(str, param);
        }
    }
}
