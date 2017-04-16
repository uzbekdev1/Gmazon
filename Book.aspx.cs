using System;
using System.Collections;
using System.Data.SqlClient;

public partial class Book : System.Web.UI.Page
{
    private string IDBook;

    protected void Page_Load(object sender, EventArgs e)
    {
        string bookID = Request.QueryString["bookID"];
        IDBook = bookID;

        if (bookID != null)
        {

            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand command = new SqlCommand("select * from Books where bookID=@id", conn);
            command.Parameters.AddWithValue("@id", bookID);
            conn.Open();
            SqlDataReader rd = command.ExecuteReader();
            if (rd.Read())
            {
                bookImage.ImageUrl = "~/images/books/large/large-" + rd["bookImage"].ToString();
                bookName.Text = rd["bookName"].ToString();
                bookAuthor.Text = rd["bookAuthor"].ToString();
                bookSetPrice.Text = rd["bookSetPrice"].ToString();
                bookPrice.Text = rd["bookPrice"].ToString();
                bookBought.Text = rd["bookBought"].ToString();
                float price = float.Parse(rd["bookPrice"].ToString());
                float setPrice = float.Parse(rd["bookSetPrice"].ToString());
                LabelDiscount.Text = "(" + Math.Round(price / setPrice, 2) * 10 + "折)";

                TextSummary.Text = rd["bookSummary"].ToString();
                TextPreview.Text = rd["bookPreview"].ToString();

                rd.Close();
            }
            conn.Close();
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }

    protected void AddToCart(object sender, EventArgs e)
    {
        string id = IDBook;
        Hashtable ht;

        WebUserControlTop1.setBookNumber += 1;

        if (Session["shopcar"] == null)
        {
            ht = new Hashtable();
            ht.Add(id, 1);
            Session["shopcar"] = ht;
        }
        else
        {
            ht = (Hashtable)Session["shopcar"];
            if (ht.Contains(id))
            {
                int count = int.Parse(ht[id].ToString());
                ht[id] = count + 1;
                Session["shopcar"] = ht;
            }
            else
            {
                ht.Add(id, 1);
                Session["shopcar"] = ht;
            }
        }
    }

    protected void AddToCartAndGo(object sender, EventArgs e)
    {
        this.AddToCart(sender, e);
        Response.Redirect("Cart.aspx");

    }
}
