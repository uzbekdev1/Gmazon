using System;
using System.Data;
using System.Data.SqlClient;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Search : System.Web.UI.Page
    {
        DataTable dt;
        private string message;

        protected void Page_Load(object sender, EventArgs e)
        {
            message = Request.QueryString["s"];
            LabelTitle.Text = @"""" + message + @"""的搜索结果";

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
            if (message == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                DataTable bdt = new bookinfo().getBooksByKeyword(message);
                for (int i = 0; i < bdt.Rows.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = bdt.Rows[i]["bookID"].ToString();
                    row["Name"] = bdt.Rows[i]["bookName"].ToString();
                    row["Price"] = "￥" + bdt.Rows[i]["bookPrice"].ToString();
                    row["Image"] = bdt.Rows[i]["bookImage"].ToString();
                    row["Author"] = bdt.Rows[i]["bookAuthor"].ToString();
                    dt.Rows.Add(row);
                }
            }
            GridView1.DataSource = dt.DefaultView;
            GridView1.DataBind();
        }
    }
}
