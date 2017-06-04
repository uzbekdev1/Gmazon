using System;
using System.Collections;
using System.Data;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Book : System.Web.UI.Page
    {
        private string IDBook;

        protected void Page_Load(object sender, EventArgs e)
        {
            string bookID = Request.QueryString["bookID"];
            IDBook = bookID;

            if (bookID != null)
            {
                DataTable dt = new bookinfo().getBookByID(bookID);
                if (dt.Rows.Count > 0)
                {
                    bookImage.ImageUrl = "~/images/books/large/large-" + dt.Rows[0]["bookImage"].ToString();
                    bookName.Text = dt.Rows[0]["bookName"].ToString();
                    bookAuthor.Text = dt.Rows[0]["bookAuthor"].ToString();
                    bookSetPrice.Text = dt.Rows[0]["bookSetPrice"].ToString();
                    bookPrice.Text = dt.Rows[0]["bookPrice"].ToString();
                    bookBought.Text = dt.Rows[0]["bookBought"].ToString();
                    double price = Convert.ToDouble(dt.Rows[0]["bookPrice"].ToString());
                    double setPrice = Convert.ToDouble(dt.Rows[0]["bookSetPrice"].ToString());
                    LabelDiscount.Text = "(" + Math.Round(price / setPrice, 2) * 10 + "折)";

                    TextSummary.Text = dt.Rows[0]["bookSummary"].ToString();
                    TextPreview.Text = dt.Rows[0]["bookPreview"].ToString();
                }
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
                    int count = Convert.ToInt32(ht[id].ToString());
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
}
