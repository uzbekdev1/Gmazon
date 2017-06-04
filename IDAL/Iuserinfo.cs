using System.Data;

namespace Gmazon.IDAL
{
    public interface Iuserinfo
    {
        DataTable validUser(string username, string password);
        int saveUserInfo(string username, string password);
    }
}
