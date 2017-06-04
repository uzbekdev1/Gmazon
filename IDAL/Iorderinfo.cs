using System.Data;

namespace Gmazon.IDAL
{
    public interface Iorderinfo
    {
        DataTable getOrderByUserName(string userName);
        void saveOrder(string bookNames, string userName, double orderPrice);
    }
}
