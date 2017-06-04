using System;
using System.Data;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bookinfo books = new bookinfo();
            DataTable dt = books.getTopBooksOrderByID();
            if (dt.Rows.Count >= 8)
            {
                string bookName;
                if (dt.Rows[0]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[0]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[0]["bookName"].ToString();
                }
                WebUserControlHomepageItem1.Title = bookName;
                WebUserControlHomepageItem1.Price = dt.Rows[0]["bookPrice"].ToString();
                WebUserControlHomepageItem1.Bought = dt.Rows[0]["bookBought"].ToString();
                WebUserControlHomepageItem1.ImageUrl = dt.Rows[0]["bookImage"].ToString();
                WebUserControlHomepageItem1.HyberLink = dt.Rows[0]["bookID"].ToString();
                if (dt.Rows[1]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[1]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[1]["bookName"].ToString();
                }
                WebUserControlHomepageItem2.Title = bookName;
                WebUserControlHomepageItem2.Price = dt.Rows[1]["bookPrice"].ToString();
                WebUserControlHomepageItem2.Bought = dt.Rows[1]["bookBought"].ToString();
                WebUserControlHomepageItem2.ImageUrl = dt.Rows[1]["bookImage"].ToString();
                WebUserControlHomepageItem2.HyberLink = dt.Rows[1]["bookID"].ToString();
                if (dt.Rows[2]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[2]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[2]["bookName"].ToString();
                }
                WebUserControlHomepageItem3.Title = bookName;
                WebUserControlHomepageItem3.Price = dt.Rows[2]["bookPrice"].ToString();
                WebUserControlHomepageItem3.Bought = dt.Rows[2]["bookBought"].ToString();
                WebUserControlHomepageItem3.ImageUrl = dt.Rows[2]["bookImage"].ToString();
                WebUserControlHomepageItem3.HyberLink = dt.Rows[2]["bookID"].ToString();
                if (dt.Rows[3]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[3]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[3]["bookName"].ToString();
                }
                WebUserControlHomepageItem4.Title = bookName;
                WebUserControlHomepageItem4.Price = dt.Rows[3]["bookPrice"].ToString();
                WebUserControlHomepageItem4.Bought = dt.Rows[3]["bookBought"].ToString();
                WebUserControlHomepageItem4.ImageUrl = dt.Rows[3]["bookImage"].ToString();
                WebUserControlHomepageItem4.HyberLink = dt.Rows[3]["bookID"].ToString();
                if (dt.Rows[4]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[4]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[4]["bookName"].ToString();
                }
                WebUserControlHomepageItem5.Title = bookName;
                WebUserControlHomepageItem5.Price = dt.Rows[4]["bookPrice"].ToString();
                WebUserControlHomepageItem5.Bought = dt.Rows[4]["bookBought"].ToString();
                WebUserControlHomepageItem5.ImageUrl = dt.Rows[4]["bookImage"].ToString();
                WebUserControlHomepageItem5.HyberLink = dt.Rows[4]["bookID"].ToString();
                if (dt.Rows[5]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[5]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[5]["bookName"].ToString();
                }
                WebUserControlHomepageItem6.Title = bookName;
                WebUserControlHomepageItem6.Price = dt.Rows[5]["bookPrice"].ToString();
                WebUserControlHomepageItem6.Bought = dt.Rows[5]["bookBought"].ToString();
                WebUserControlHomepageItem6.ImageUrl = dt.Rows[5]["bookImage"].ToString();
                WebUserControlHomepageItem6.HyberLink = dt.Rows[5]["bookID"].ToString();
                if (dt.Rows[6]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[6]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[6]["bookName"].ToString();
                }
                WebUserControlHomepageItem7.Title = bookName;
                WebUserControlHomepageItem7.Price = dt.Rows[6]["bookPrice"].ToString();
                WebUserControlHomepageItem7.Bought = dt.Rows[6]["bookBought"].ToString();
                WebUserControlHomepageItem7.ImageUrl = dt.Rows[6]["bookImage"].ToString();
                WebUserControlHomepageItem7.HyberLink = dt.Rows[6]["bookID"].ToString();
                if (dt.Rows[7]["bookName"].ToString().Length > 11)
                {
                    bookName = dt.Rows[7]["bookName"].ToString().Substring(0, 10) + "…";
                }
                else
                {
                    bookName = dt.Rows[7]["bookName"].ToString();
                }
                WebUserControlHomepageItem8.Title = bookName;
                WebUserControlHomepageItem8.Price = dt.Rows[7]["bookPrice"].ToString();
                WebUserControlHomepageItem8.Bought = dt.Rows[7]["bookBought"].ToString();
                WebUserControlHomepageItem8.ImageUrl = dt.Rows[7]["bookImage"].ToString();
                WebUserControlHomepageItem8.HyberLink = dt.Rows[7]["bookID"].ToString();
            }

            dt = books.getTopBooksOrderByBought();
            if (dt.Rows.Count >= 13)
            {
                HyperLink1.Text = dt.Rows[0]["bookName"].ToString();
                HyperLink1.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[0]["bookID"].ToString();
                HyperLink2.Text = dt.Rows[1]["bookName"].ToString();
                HyperLink2.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[1]["bookID"].ToString();
                HyperLink3.Text = dt.Rows[2]["bookName"].ToString();
                HyperLink3.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[2]["bookID"].ToString();
                HyperLink4.Text = dt.Rows[3]["bookName"].ToString();
                HyperLink4.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[3]["bookID"].ToString();
                HyperLink5.Text = dt.Rows[4]["bookName"].ToString();
                HyperLink5.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[4]["bookID"].ToString();
                HyperLink6.Text = dt.Rows[5]["bookName"].ToString();
                HyperLink6.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[5]["bookID"].ToString();
                HyperLink7.Text = dt.Rows[6]["bookName"].ToString();
                HyperLink7.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[6]["bookID"].ToString();
                HyperLink8.Text = dt.Rows[7]["bookName"].ToString();
                HyperLink8.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[7]["bookID"].ToString();
                HyperLink9.Text = dt.Rows[8]["bookName"].ToString();
                HyperLink9.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[8]["bookID"].ToString();
                HyperLink10.Text = dt.Rows[9]["bookName"].ToString();
                HyperLink10.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[9]["bookID"].ToString();
                HyperLink11.Text = dt.Rows[10]["bookName"].ToString();
                HyperLink11.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[10]["bookID"].ToString();
                HyperLink12.Text = dt.Rows[11]["bookName"].ToString();
                HyperLink12.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[12]["bookID"].ToString();
                HyperLink13.Text = dt.Rows[12]["bookName"].ToString();
                HyperLink13.NavigateUrl = "Book.aspx?bookID=" + dt.Rows[12]["bookID"].ToString();
            }
        }
    }
}
