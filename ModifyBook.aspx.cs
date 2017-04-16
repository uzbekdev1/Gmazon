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

public partial class ModifyBook : System.Web.UI.Page
{
    string message;

    protected void Page_Load(object sender, EventArgs e)
    {
        if ((Session["userName"] == null) || (Session["userName"].ToString() == ""))
        {
            Response.Redirect("Login.aspx");
        }
        else
        {
            string strName = Session["userName"].ToString();
            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            string strSelect = "SELECT * FROM Users WHERE userName=@username";
            SqlCommand command = new SqlCommand(strSelect, conn);
            command.Parameters.AddWithValue("@username", strName);
            conn.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                if (dr["isAdmin"].ToString() != "True")
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }
    }

    protected void TextBox_Init(object sender, EventArgs e)
    {
        TextBoxInit();
    }

    protected void TextBoxInit()
    {
        message = Request.QueryString["mess"];
        Session["id"] = Request.QueryString["id"];
        switch (message)
        {
            case "0":
                {
                    LabelTitle.Text = "添加图书";
                    break;
                }
            case "1":  //修改新闻
                {
                    LabelTitle.Text = "修改图书";
                    string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connString);
                    SqlCommand command = new SqlCommand("select * from Books where bookID=@id", conn);
                    command.Parameters.AddWithValue("@id", Session["id"].ToString());
                    conn.Open();
                    SqlDataReader rd = command.ExecuteReader();
                    if (rd.Read())
                    {
                        bookName.Text = rd["bookName"].ToString();
                        bookAuthor.Text = rd["bookAuthor"].ToString();
                        bookClass.Text = rd["bookClass"].ToString();
                        bookSetPrice.Text = rd["bookSetPrice"].ToString();
                        bookPrice.Text = rd["bookPrice"].ToString();
                        bookImage.Text = rd["bookImage"].ToString();
                        bookSummary.Text = rd["bookSummary"].ToString();
                        bookPreview.Text = rd["bookPreview"].ToString();

                        rd.Close();
                    }
                    else
                    {
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('无此记录！');</script>");
                    }
                    conn.Close();
                    break;
                }
        }
    }

    protected void ButtonOK_Click(object sender, System.EventArgs e)
    {
        if (message == "0")
        {
            if (isBookNameExist() == true)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('库中已经有要发布的标题，无法重复发布！');</script>");
                return;
            }
            else
            {
                string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
                SqlConnection conn = new SqlConnection(connString);
                conn.Open();
                SqlCommand command = new SqlCommand("insert into Books(bookName,bookAuthor,bookClass,bookSetPrice,bookPrice,bookImage,bookSummary,bookPreview) values(@bookName,@bookAuthor,@bookClass,@bookSetPrice,@bookPrice,@bookImage,@bookSummary,@bookPreview)", conn);
                command.CommandType = CommandType.Text;
                command.Parameters.AddWithValue("@bookName", this.bookName.Text.Trim());
                command.Parameters.AddWithValue("@bookAuthor", this.bookAuthor.Text.Trim());
                command.Parameters.AddWithValue("@bookClass", this.bookClass.Text.Trim());
                command.Parameters.AddWithValue("@bookSetPrice", this.bookSetPrice.Text.Trim());
                command.Parameters.AddWithValue("@bookPrice", this.bookPrice.Text.Trim());
                command.Parameters.AddWithValue("@bookImage", this.bookImage.Text.Trim());
                command.Parameters.AddWithValue("@bookSummary", this.bookSummary.Text.Trim());
                command.Parameters.AddWithValue("@bookPreview", this.bookPreview.Text.Trim());
                command.ExecuteNonQuery();
                conn.Close();
                Response.Redirect("Admin.aspx");
            }
        }
        else if (message == "1")
        {
            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            SqlCommand command = new SqlCommand("update Books set bookName=@bookName,bookAuthor=@bookAuthor,bookClass=@bookClass,bookSetPrice=@bookSetPrice,bookPrice=@bookPrice,bookImage=@bookImage,bookSummary=@bookSummary,bookPreview=@bookPreview where bookID=@id", conn);
            command.CommandType = CommandType.Text;
            command.Parameters.AddWithValue("@bookName", this.bookName.Text.Trim());
            command.Parameters.AddWithValue("@bookAuthor", this.bookAuthor.Text.Trim());
            command.Parameters.AddWithValue("@bookClass", this.bookClass.Text.Trim());
            command.Parameters.AddWithValue("@bookSetPrice", this.bookSetPrice.Text.Trim());
            command.Parameters.AddWithValue("@bookPrice", this.bookPrice.Text.Trim());
            command.Parameters.AddWithValue("@bookImage", this.bookImage.Text.Trim());
            command.Parameters.AddWithValue("@bookSummary", this.bookSummary.Text.Trim());
            command.Parameters.AddWithValue("@bookPreview", this.bookPreview.Text.Trim());
            command.Parameters.AddWithValue("@id", Session["id"].ToString());
            command.ExecuteNonQuery();
            conn.Close();
            Response.Redirect("Admin.aspx");
        }
    }

    private bool isBookNameExist()
    {
        bool isFind = false;
        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand command = new SqlCommand("select bookName from Books order by bookName", conn);
        SqlDataReader rd = null;
        conn.Open();
        rd = command.ExecuteReader();
        while (rd.Read())
        {
            if (rd["bookName"].ToString().Trim() == this.bookName.Text.Trim())
            {
                isFind = true;
                break;
            }
        }
        rd.Close();
        conn.Close();
        return isFind;
    }

    protected void ButtonCancel_Click(object sender, System.EventArgs e)
    {
        Response.Redirect("Admin.aspx");
    }
}
