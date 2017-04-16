using System;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        conn.Open();
        SqlCommand command = new SqlCommand("select top 8 * from books order by bookID desc", conn);
        SqlDataReader rd = command.ExecuteReader();
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem1.Title = bookName;
            WebUserControlHomepageItem1.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem1.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem1.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem1.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem2.Title = bookName;
            WebUserControlHomepageItem2.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem2.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem2.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem2.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem3.Title = bookName;
            WebUserControlHomepageItem3.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem3.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem3.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem3.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem4.Title = bookName;
            WebUserControlHomepageItem4.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem4.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem4.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem4.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem5.Title = bookName;
            WebUserControlHomepageItem5.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem5.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem5.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem5.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem6.Title = bookName;
            WebUserControlHomepageItem6.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem6.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem6.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem6.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem7.Title = bookName;
            WebUserControlHomepageItem7.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem7.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem7.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem7.HyberLink = rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            string bookName;
            if (rd["bookName"].ToString().Length > 11)
            {
                bookName = rd["bookName"].ToString().Substring(0, 10) + "…";
            }
            else
            {
                bookName = rd["bookName"].ToString();
            }
            WebUserControlHomepageItem8.Title = bookName;
            WebUserControlHomepageItem8.Price = rd["bookPrice"].ToString();
            WebUserControlHomepageItem8.Bought = rd["bookBought"].ToString();
            WebUserControlHomepageItem8.ImageUrl = rd["bookImage"].ToString();
            WebUserControlHomepageItem8.HyberLink = rd["bookID"].ToString();
        }
        rd.Close();

        command = new SqlCommand("select top 14 * from books order by bookBought desc", conn);
        rd = command.ExecuteReader();
        if (rd.Read())
        {
            HyperLink1.Text = rd["bookName"].ToString();
            HyperLink1.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink2.Text = rd["bookName"].ToString();
            HyperLink2.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink3.Text = rd["bookName"].ToString();
            HyperLink3.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink4.Text = rd["bookName"].ToString();
            HyperLink4.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink5.Text = rd["bookName"].ToString();
            HyperLink5.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink6.Text = rd["bookName"].ToString();
            HyperLink6.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink7.Text = rd["bookName"].ToString();
            HyperLink7.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink8.Text = rd["bookName"].ToString();
            HyperLink8.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink9.Text = rd["bookName"].ToString();
            HyperLink9.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink10.Text = rd["bookName"].ToString();
            HyperLink10.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink11.Text = rd["bookName"].ToString();
            HyperLink11.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink12.Text = rd["bookName"].ToString();
            HyperLink12.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        if (rd.Read())
        {
            HyperLink13.Text = rd["bookName"].ToString();
            HyperLink13.NavigateUrl = "Book.aspx?bookID=" + rd["bookID"].ToString();
        }
        rd.Close();
        rd.Dispose();
        conn.Close();
        conn.Dispose();
    }
}
