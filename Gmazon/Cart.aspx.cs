using System;
using System.Collections;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Cart : System.Web.UI.Page
    {
        Hashtable ht;
        DataTable dt;
        bookinfo books = new bookinfo();
        private static string bookNames = "";
        private static double priceTotal;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            dt = new DataTable();
            DataColumn col1 = new DataColumn();
            col1.ColumnName = "Image";
            col1.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col1);
            DataColumn col2 = new DataColumn();
            col2.ColumnName = "ID";
            col2.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col2);
            DataColumn col = new DataColumn();
            col.ColumnName = "Name";
            col.DataType = System.Type.GetType("System.String");
            dt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "Num";
            col.DataType = System.Type.GetType("System.Int32");
            dt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "Price";
            col.DataType = System.Type.GetType("System.Double");
            dt.Columns.Add(col);
            col = new DataColumn();
            col.ColumnName = "Total";
            col.DataType = System.Type.GetType("System.Double");
            dt.Columns.Add(col);

            if (!Page.IsPostBack)
            {
                Bind();
            }
        }

        private void setTotal(double totalPrice)
        {
            LabelTotal.Text = "￥" + totalPrice.ToString();
        }

        public void Bind()
        {
            bookNames = "";
            if (Session["shopcar"] == null)
            {
                ButtonOK.Enabled = false;
                setTotal(0);
            }
            else
            {
                ht = (Hashtable)Session["shopcar"];
                double sum = 0;
                foreach (object item in ht.Keys)
                {
                    string id = item.ToString();
                    DataTable bdt = books.getBookByID(id);
                    int num = Convert.ToInt32((ht[item].ToString()));

                    if (bdt.Rows.Count > 0)
                    {
                        DataRow row = dt.NewRow();
                        row["Image"] = bdt.Rows[0]["bookImage"];
                        row["ID"] = id;
                        row["Name"] = bdt.Rows[0]["bookName"];
                        row["Num"] = num;
                        row["Price"] = Convert.ToDouble(bdt.Rows[0]["bookPrice"].ToString());
                        row["Total"] = num * (Convert.ToDouble(bdt.Rows[0]["bookPrice"].ToString()));
                        sum += num * Convert.ToDouble(bdt.Rows[0]["bookPrice"].ToString());
                        dt.Rows.Add(row);

                        bookNames += bdt.Rows[0]["bookName"].ToString() + "×" + num + ", ";
                    }
                }
                setTotal(sum);
                priceTotal = sum;
                if (ht.Count > 0)
                {
                    bookNames = bookNames.Substring(0, bookNames.Length - 2);
                }
            }
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            string id = ((Button)sender).CommandArgument;
            Hashtable ht = (Hashtable)Session["shopcar"];
            if (ht == null)
            {
                return;
            }
            ht.Remove(id);
            Session["shopcar"] = ht;
            int sum = 0;
            foreach (object item in ht.Keys)
            {
                sum += Convert.ToInt32((ht[item].ToString()));
            }
            WebUserControlTop1.setBookNumber = sum;
            bookNames = "";
            priceTotal = 0;

            if (ht.Count == 0)
            {
                ButtonOK.Enabled = false;
            }

            Bind();
        }

        protected void ButtonOK_Click(object sender, EventArgs e)
        {
            if (Session["userName"] != null)
            {
                new orderinfo().saveOrder(bookNames, Session["userName"].ToString(), priceTotal);
                Hashtable ht = (Hashtable)Session["shopcar"];

                foreach (object item in ht.Keys)
                {
                    int bought = 0;
                    string id = item.ToString();
                    DataTable bdt = books.getBookByID(id);
                    if (bdt.Rows.Count > 0)
                    {
                        bought = Convert.ToInt32(bdt.Rows[0]["bookBought"].ToString());
                    }
                    bought += Convert.ToInt32((ht[item].ToString()));
                    books.updateBookBought(Convert.ToInt32(id), bought);
                }
                Session["shopcar"] = null;
                ht = null;
                dt = null;
                bookNames = "";
                priceTotal = 0;
                Response.Redirect("My.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}
