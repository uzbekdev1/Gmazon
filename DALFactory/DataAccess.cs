using System.Configuration;
using System.Reflection;

namespace Gmazon.DALFactory
{
    public class DataAccess
    {
        //以下是连接SQLserver数据库的命名空间路径
        private static readonly string path = ConfigurationSettings.AppSettings["SQLDAL"];
        public static Gmazon.IDAL.Iuserinfo Createuserinfo()
        {
            string className = path + ".userinfo";
            return (Gmazon.IDAL.Iuserinfo)Assembly.Load(path).CreateInstance(className);
        }

        public static Gmazon.IDAL.Ibookinfo Createbookinfo()
        {
            string className = path + ".bookinfo";
            return (Gmazon.IDAL.Ibookinfo)Assembly.Load(path).CreateInstance(className);
        }

        public static Gmazon.IDAL.Iorderinfo Createorderinfo()
        {
            string className = path + ".orderinfo";
            return (Gmazon.IDAL.Iorderinfo)Assembly.Load(path).CreateInstance(className);
        }
    }
}
