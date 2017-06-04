using Gmazon.DALFactory;
using Gmazon.IDAL;
using System.Data;

namespace Gmazon.BLL
{
    public class orderinfo
    {
        private static readonly Iorderinfo orders = DataAccess.Createorderinfo();
        public DataTable getOrderByUserName(string userName)
        {
            return orders.getOrderByUserName(userName);
        }

        public void saveOrder(string bookNames, string userName, double orderPrice)
        {
            orders.saveOrder(bookNames, userName, orderPrice);
        }
    }
}
