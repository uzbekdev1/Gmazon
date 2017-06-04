using System.Data;
using Gmazon.DALFactory;
using Gmazon.IDAL;

namespace Gmazon.BLL
{
    public class userinfo
    {
        private static readonly Iuserinfo user = DataAccess.Createuserinfo();
        public DataTable validUser(string username, string password)
        {
            return user.validUser(username, password);
        }

        public int saveUserInfo(string username, string password)
        {
            return user.saveUserInfo(username, password);
        }
    }
}
