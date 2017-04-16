using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    Hashtable ht;
    DataTable dt;
    string connstr = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
    SqlConnection conn;
    SqlCommand cmd;
    SqlDataReader sdr;
    private static string bookNames = "";
    private static float priceTotal;

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
        col.DataType = System.Type.GetType("System.Single");
        dt.Columns.Add(col);
        col = new DataColumn();
        col.ColumnName = "Total";
        col.DataType = System.Type.GetType("System.Single");
        dt.Columns.Add(col);

        if (!Page.IsPostBack)
        {
            Bind();
        }
    }

    private void setTotal(float totalPrice)
    {
        LabelTotal.Text = "￥" + totalPrice.ToString();
    }

    public void Bind()
    {
        if (Session["shopcar"] == null)
        {
            ButtonOK.Enabled = false;
            setTotal(0);
        }
        else
        {
            ht = (Hashtable)Session["shopcar"];
            float sum = 0;
            foreach (object item in ht.Keys)
            {
                string id = item.ToString();

                int num = int.Parse((ht[item].ToString()));
                string sql = "select bookName,bookPrice,bookImage from Books where bookID='" + id + "'";
                conn = new SqlConnection(connstr);

                cmd = new SqlCommand(sql, conn);
                conn.Open();

                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                {
                    sdr.Read();
                    DataRow row = dt.NewRow();
                    row["Image"] = sdr.GetString(2);
                    row["ID"] = id;
                    row["Name"] = sdr.GetString(0);
                    row["Num"] = num;
                    row["Price"] = float.Parse(sdr[1].ToString());
                    row["Total"] = num * (float.Parse(sdr[1].ToString()));
                    sum += num * float.Parse(sdr[1].ToString());
                    dt.Rows.Add(row);

                    bookNames += sdr.GetString(0) + "×" + num + ", ";

                }
                sdr.Close();
                conn.Close();
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
        int sum = 0;
        foreach (object item in ht.Keys)
        {
            sum += int.Parse((ht[item].ToString()));
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
        if (Session["userID"] != null)
        {
            string userID = Session["userID"].ToString();

            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand command = new SqlCommand("insert into Orders(bookNames, userID, orderPrice, orderTime) values(@bookNames, @userID, @orderPrice, @date)", conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@bookNames", bookNames);
            command.Parameters.AddWithValue("@userID", userID);
            command.Parameters.AddWithValue("@orderPrice", priceTotal.ToString());
            command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            command.ExecuteNonQuery();

            Hashtable ht = (Hashtable)Session["shopcar"];
            foreach (object item in ht.Keys)
            {
                int bought = 0;
                string id = item.ToString();
                command = new SqlCommand("select bookBought from Books where bookID=@id", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@id", id);
                SqlDataReader rd = command.ExecuteReader();
                if (rd.Read())
                {
                    bought = int.Parse(rd["bookBought"].ToString());
                }
                rd.Close();
                bought += int.Parse((ht[item].ToString()));

                command = new SqlCommand("update Books set bookBought=@bookBought where bookID=@id", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@bookBought", bought.ToString());
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }

            conn.Close();
            Session["shopcar"] = null;
            Response.Redirect("My.aspx");
            bookNames = "";
            priceTotal = 0;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
}  
