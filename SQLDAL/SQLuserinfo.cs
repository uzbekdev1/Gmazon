using System;
using System.Data;
using System.Data.SqlClient;
using Gmazon.DBUtility;

namespace Gmazon.SQLDAL
{
    public class userinfo : Gmazon.IDAL.Iuserinfo
    {
        public DataTable validUser(string username, string password)
        {
            string str = "select * from Users where userName=@username and userPwd=@password";
            SqlParameter[] param = {
                                        SQLDbHelper.GetParameter("@username", SqlDbType.NVarChar, 100, "userName",username),
                                        SQLDbHelper.GetParameter("@password", SqlDbType.NVarChar, 100, "userPwd",password),
                                    };
            return SQLDbHelper.ExecuteDt(str, param);
        }

        public int saveUserInfo(string username, string password)
        {
            string str = "SELECT * FROM Users WHERE userName=@username";
            SqlParameter[] param = {
                                         SQLDbHelper.GetParameter("@username", SqlDbType.NVarChar,100, "userName", username)
                                     };
            DataTable table = SQLDbHelper.ExecuteDt(str, param);
            if (table.Rows.Count > 0)
            {
                return 0;
            }
            else
            {
                str = "INSERT INTO Users (userName, userPwd, lastLogin) VALUES (@name,@password,'" + DateTime.Now + "')";
                SqlParameter[] param1 = {
                            SQLDbHelper.GetParameter("@name", SqlDbType.NVarChar, 100, "userName", username),
                            SQLDbHelper.GetParameter("@password", SqlDbType.NVarChar, 100, "userPwd", password)
                        };
                return SQLDbHelper.ExecuteSql(str, param1);
            }
        }
    }
}
