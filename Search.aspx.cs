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

public partial class Search : System.Web.UI.Page
{
    DataTable dt;
    protected void Page_Load(object sender, EventArgs e)
    {
        LabelTitle.Text = @"""" + Request.QueryString["s"] + @"""的搜索结果";

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
        string message = Request.QueryString["s"];
        if (message == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn;
            SqlCommand cmd;
            SqlDataReader sdr;

            string sql = "select * from Books where bookName like '%'+@message+'%' or bookSummary like '%'+@message+'%' or bookAuthor like '%'+@message+'%' order by bookID desc";
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
