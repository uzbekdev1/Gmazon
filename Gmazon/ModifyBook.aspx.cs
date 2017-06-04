using System;
using System.Data;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class ModifyBook : System.Web.UI.Page
    {
        private string id;
        private string message;
        bookinfo book = new bookinfo();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["userName"] == null) || (Session["userName"].ToString() == ""))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["isAdmin"].ToString() != "true")
                {
                    Response.Redirect("Default.aspx");
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
            id = Request.QueryString["id"];
            switch (message)
            {
                case "0":
                    {
                        LabelTitle.Text = "添加图书";
                        break;
                    }
                case "1":
                    {
                        LabelTitle.Text = "修改图书";
                        DataTable dt = book.getBookByID(id);
                        if (dt.Rows.Count > 0)
                        {
                            bookName.Text = dt.Rows[0]["bookName"].ToString();
                            bookAuthor.Text = dt.Rows[0]["bookAuthor"].ToString();
                            bookClass.Text = dt.Rows[0]["bookClass"].ToString();
                            bookSetPrice.Text = dt.Rows[0]["bookSetPrice"].ToString();
                            bookPrice.Text = dt.Rows[0]["bookPrice"].ToString();
                            bookImage.Text = dt.Rows[0]["bookImage"].ToString();
                            bookSummary.Text = dt.Rows[0]["bookSummary"].ToString();
                            bookPreview.Text = dt.Rows[0]["bookPreview"].ToString();
                        }
                        else
                        {
                            Response.Redirect("Admin.aspx");
                        }
                        break;
                    }
            }
        }

        protected void ButtonOK_Click(object sender, System.EventArgs e)
        {
            if (message == "0")
            {
                if (isBookNameExist())
                {
                    this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('库中已经有要发布的标题，无法重复发布！');</script>");
                    return;
                }
                else
                {
                    book.addBook(this.bookName.Text.Trim(), this.bookAuthor.Text.Trim(), this.bookClass.Text.Trim(), this.bookSetPrice.Text.Trim(), this.bookPrice.Text.Trim(), this.bookImage.Text.Trim(), this.bookSummary.Text.Trim(), this.bookPreview.Text.Trim());
                    Response.Redirect("Admin.aspx");
                }
            }
            else if (message == "1")
            {
                book.updateBook(this.bookName.Text.Trim(), this.bookAuthor.Text.Trim(), this.bookClass.Text.Trim(), this.bookSetPrice.Text.Trim(), this.bookPrice.Text.Trim(), this.bookImage.Text.Trim(), this.bookSummary.Text.Trim(), this.bookPreview.Text.Trim(), id);
                Response.Redirect("Admin.aspx");
            }
        }

        private bool isBookNameExist()
        {
            return book.getBookByName(this.bookName.Text.Trim()).Rows.Count > 0 ? true : false;
        }

        protected void ButtonCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("Admin.aspx");
        }
    }
}
