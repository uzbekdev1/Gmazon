using System;
using System.Data;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Category : System.Web.UI.Page
    {
        DataTable dt;
        bookinfo books = new bookinfo();
        protected string pageTitle;
        private string author;
        private string bookClass;

        protected void Page_Load(object sender, EventArgs e)
        {
            author = Request.QueryString["author"];
            bookClass = Request.QueryString["class"];
            if (bookClass != null)
            {
                if (bookClass == "xs")
                {
                    pageTitle = "小说";
                    LabelTitle.Text = @"""" + pageTitle + @"""类图书";
                }
                else if (bookClass == "wx")
                {
                    pageTitle = "文学";
                    LabelTitle.Text = @"""" + pageTitle + @"""类图书";
                }
                else if (bookClass == "zj")
                {
                    pageTitle = "传记";
                    LabelTitle.Text = @"""" + pageTitle + @"""类图书";
                }
            }
            else if (author != null)
            {
                pageTitle = author + "作品";
                LabelTitle.Text = @"""" + author + @"""作品";
            }
            else
            {
                pageTitle = "图书分类";
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
            if (bookClass == null && author == null)
            {
                Response.Redirect("Default.aspx");
            }
            else if (bookClass != null)
            {
                DataTable bdt = books.getBookByClass(bookClass);
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
            else if (author != null)
            {
                DataTable bdt = books.getBookByAuthor(author);
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
