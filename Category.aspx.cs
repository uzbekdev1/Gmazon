using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class Category : System.Web.UI.Page
{
    DataTable dt;
    protected string PageTitle;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["class"] != null)
        {
            if (Request.QueryString["class"] == "xs")
            {
                PageTitle = "小说";
                LabelTitle.Text = @"""" + PageTitle + @"""类图书";
            }
            else if (Request.QueryString["class"] == "wx")
            {
                PageTitle = "文学";
                LabelTitle.Text = @"""" + PageTitle + @"""类图书";
            }
            else if (Request.QueryString["class"] == "zj")
            {
                PageTitle = "传记";
                LabelTitle.Text = @"""" + PageTitle + @"""类图书";
            }
        }
        else if (Request.QueryString["author"] != null)
        {
            if (Request.QueryString["author"] == "gjm")
            {
                PageTitle = "郭敬明小说";
                LabelTitle.Text = @"""" + "郭敬明" + @"""小说";
            }
            else if (Request.QueryString["author"] == "lyg")
            {
                PageTitle = "李玉刚文学";
                LabelTitle.Text = @"""" + "李玉刚" + @"""文学";
            }
            else if (Request.QueryString["class"] == "dygw")
            {
                PageTitle = "东野圭吾小说";
                LabelTitle.Text = @"""" + "东野圭吾" + @"""小说";
            }
        }
        else
        {
            PageTitle = "图书分类";
        }

        dt = new DataTable();
        DataColumn col1 = new DataColumn();
        col1.ColumnName = "Image";
        col1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(col1);
        col1 = new DataColumn();
        col1.ColumnName = "ID";
        col1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(col1);
        col1 = new DataColumn();
        col1.ColumnName = "Name";
        col1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(col1);
        col1 = new DataColumn();
        col1.ColumnName = "Price";
        col1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(col1);
        col1 = new DataColumn();
        col1.ColumnName = "Author";
        col1.DataType = System.Type.GetType("System.String");
        dt.Columns.Add(col1);

        Bind();
    }

    public void Bind()
    {
        if (Request.QueryString["class"] == null && Request.QueryString["author"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else if (Request.QueryString["class"] != null)
        {
            string message = Request.QueryString["class"];
            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader sdr;

            string sql = "select * from Books where bookClass=@message order by bookID desc";
            conn = new SqlConnection(connString);

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@message", message);
            conn.Open();

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                DataRow row = dt.NewRow();
                row["ID"] = sdr["bookID"].ToString();
                row["Name"] = sdr["bookName"].ToString();
                row["Price"] = "￥" + sdr["bookPrice"].ToString();
                row["Image"] = sdr["bookImage"].ToString();
                row["Author"] = sdr["bookAuthor"].ToString();
                dt.Rows.Add(row);

            }
            sdr.Close();
            conn.Close();

        }
        else if (Request.QueryString["author"] != null)
        {
            string message = Request.QueryString["author"];

            if (message == "gjm")
            {
                message = "郭敬明";
            }
            else if (message == "lyg")
            {
                message = "李玉刚";
            }
            else if (message == "dygw")
            {
                message = "东野圭吾";
            }

            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader sdr;

            string sql = "select * from Books where bookAuthor like '%'+@message+'%' order by bookID desc";
            conn = new SqlConnection(connString);

            cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@message", message);
            conn.Open();

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                DataRow row = dt.NewRow();
                row["ID"] = sdr["bookID"].ToString();
                row["Name"] = sdr["bookName"].ToString();
                row["Price"] = "￥" + sdr["bookPrice"].ToString();
                row["Image"] = sdr["bookImage"].ToString();
                row["Author"] = sdr["bookAuthor"].ToString();
                dt.Rows.Add(row);

            }
            sdr.Close();
            conn.Close();

        }
        GridView1.DataSource = dt.DefaultView;
        GridView1.DataBind();

    }
}
