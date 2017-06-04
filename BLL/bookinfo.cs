using Gmazon.DALFactory;
using Gmazon.IDAL;
using System.Data;

namespace Gmazon.BLL
{
    public class bookinfo
    {
        private static readonly Ibookinfo books = DataAccess.Createbookinfo();

        public DataTable getBooks()
        {
            return books.getBooks();
        }

        public DataTable getTopBooksOrderByID()
        {
            return books.getTopBooksOrderByID();
        }

        public DataTable getTopBooksOrderByBought()
        {
            return books.getTopBooksOrderByBought();
        }

        public DataTable getBookByID(string Id)
        {
            return books.getBookByID(Id);
        }

        public DataTable getBookByName(string bookName)
        {
            return books.getBookByName(bookName);
        }

        public DataTable getBookByAuthor(string author)
        {
            return books.getBookByAuthor(author);
        }

        public DataTable getBookByClass(string bookClass)
        {
            return books.getBookByClass(bookClass);
        }

        public DataTable getBooksByKeyword(string keyword)
        {
            return books.getBooksByKeyword(keyword);
        }

        public void addBook(string bookName, string bookAuthor, string bookClass, string bookSetPrice, string bookPrice, string bookImage, string bookSummary, string bookPreview)
        {
            books.addBook(bookName, bookAuthor, bookClass, bookSetPrice, bookPrice, bookImage, bookSummary, bookPreview);
        }

        public void updateBook(string bookName, string bookAuthor, string bookClass, string bookSetPrice, string bookPrice, string bookImage, string bookSummary, string bookPreview, string id)
        {
            books.updateBook(bookName, bookAuthor, bookClass, bookSetPrice, bookPrice, bookImage, bookSummary, bookPreview, id);
        }

        public void updateBookBought(int id, int bought)
        {
            books.updateBookBought(id, bought);
        }

        public void deteleBookByID(string Id)
        {
            books.deteleBookByID(Id);
        }
    }
}
