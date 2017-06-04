using System.Data;

namespace Gmazon.IDAL
{
    public interface Ibookinfo
    {
        DataTable getBooks();
        DataTable getTopBooksOrderByID();
        DataTable getTopBooksOrderByBought();
        DataTable getBookByID(string Id);
        DataTable getBookByName(string bookName);
        DataTable getBookByAuthor(string author);
        DataTable getBookByClass(string bookClass);
        DataTable getBooksByKeyword(string keyword);
        void addBook(string bookName, string bookAuthor, string bookClass, string bookSetPrice, string bookPrice, string bookImage, string bookSummary, string bookPreview);
        void updateBook(string bookName, string bookAuthor, string bookClass, string bookSetPrice, string bookPrice, string bookImage, string bookSummary, string bookPreview, string id);
        void updateBookBought(int id, int bought);
        void deteleBookByID(string Id);
    }
}
