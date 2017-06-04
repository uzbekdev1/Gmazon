using System;
using System.Data;
using System.Data.SqlClient;
using Gmazon.DBUtility;

namespace Gmazon.SQLDAL
{
    class bookinfo : Gmazon.IDAL.Ibookinfo
    {
        public DataTable getBooks()
        {
            return SQLDbHelper.ExecuteDt("select * from Books order by bookID desc");
        }

        public DataTable getTopBooksOrderByID()
        {
            return SQLDbHelper.ExecuteDt("select top 8 * from books order by bookID desc");
        }

        public DataTable getTopBooksOrderByBought()
        {
            return SQLDbHelper.ExecuteDt("select top 13 * from books order by bookBought desc");
        }

        public DataTable getBookByID(string Id)
        {
            String str = "select * from Books where bookID=@id";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@id", SqlDbType.Int, 32, "bookID", Convert.ToInt32(Id))
                                  };
            return SQLDbHelper.ExecuteDt(str, param);
        }

        public DataTable getBookByName(string bookName)
        {
            String str = "select 1 from Books where bookName=@bookName";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@bookName", SqlDbType.NVarChar, 50, "bookName", bookName)
                                  };
            return SQLDbHelper.ExecuteDt(str, param);
        }

        public DataTable getBookByAuthor(string author)
        {
            String str = "select * from Books where bookAuthor like '%'+@message+'%' order by bookID desc";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@message", SqlDbType.NVarChar, 50, "bookAuthor", author)
                                  };
            return SQLDbHelper.ExecuteDt(str, param);
        }

        public DataTable getBookByClass(string bookClass)
        {
            String str = "select * from Books where bookClass=@message order by bookID desc";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@message", SqlDbType.NVarChar, 50, "bookAuthor", bookClass)
                                  };
            return SQLDbHelper.ExecuteDt(str, param);
        }

        public DataTable getBooksByKeyword(string keyword)
        {
            String str = "select * from Books where bookName like '%'+@message+'%' or bookSummary like '%'+@message+'%' or bookAuthor like '%'+@message+'%' order by bookID desc";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@message", keyword);
            return SQLDbHelper.ExecuteDt(str, param);
        }

        public void addBook(string bookName, string bookAuthor, string bookClass, string bookSetPrice, string bookPrice, string bookImage, string bookSummary, string bookPreview)
        {
            double temp = 0;
            String str = "insert into Books (bookName,bookAuthor,bookClass,bookSetPrice,bookPrice,bookImage,bookSummary,bookPreview) values (@bookName,@bookAuthor,@bookClass,@bookSetPrice,@bookPrice,@bookImage,@bookSummary,@bookPreview)";
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@bookName", bookName);
            param[1] = new SqlParameter("@bookAuthor", bookAuthor);
            param[2] = new SqlParameter("@bookClass", bookClass);
            double.TryParse(bookSetPrice, out temp);
            param[3] = new SqlParameter("@bookSetPrice", temp);
            double.TryParse(bookPrice, out temp);
            param[4] = new SqlParameter("@bookPrice", temp);
            param[5] = new SqlParameter("@bookImage", bookImage);
            param[6] = new SqlParameter("@bookSummary", bookSummary);
            param[7] = new SqlParameter("@bookPreview", bookPreview);
            SQLDbHelper.ExecuteSql(str, param);
        }

        public void updateBook(string bookName, string bookAuthor, string bookClass, string bookSetPrice, string bookPrice, string bookImage, string bookSummary, string bookPreview, string id)
        {
            double temp = 0;
            String str = "update Books set bookName=@bookName,bookAuthor=@bookAuthor,bookClass=@bookClass,bookSetPrice=@bookSetPrice,bookPrice=@bookPrice,bookImage=@bookImage,bookSummary=@bookSummary,bookPreview=@bookPreview where bookID=@id";
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@bookName", bookName);
            param[1] = new SqlParameter("@bookAuthor", bookAuthor);
            param[2] = new SqlParameter("@bookClass", bookClass);
            double.TryParse(bookSetPrice, out temp);
            param[3] = new SqlParameter("@bookSetPrice", temp);
            double.TryParse(bookPrice, out temp);
            param[4] = new SqlParameter("@bookPrice", temp);
            param[5] = new SqlParameter("@bookImage", bookImage);
            param[6] = new SqlParameter("@bookSummary", bookSummary);
            param[7] = new SqlParameter("@bookPreview", bookPreview);
            param[8] = new SqlParameter("@id", Convert.ToInt32(id));
            SQLDbHelper.ExecuteSql(str, param);
        }

        public void updateBookBought(int id, int bought)
        {
            String str = "update Books set bookBought=@bookBought where bookID=@id";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@bookBought", SqlDbType.Int, 32, "bookBought", bought),
                                      SQLDbHelper.GetParameter("@id", SqlDbType.Int, 32, "bookID", id)
                                  };
            SQLDbHelper.ExecuteSql(str, param);
        }

        public void deteleBookByID(string Id)
        {
            String str = "delete from Books where bookID=@id";
            SqlParameter[] param ={
                                      SQLDbHelper.GetParameter("@id", SqlDbType.Int, 32, "bookID", Convert.ToInt32(Id))
                                  };
            SQLDbHelper.ExecuteSql(str, param);
        }
    }
}
