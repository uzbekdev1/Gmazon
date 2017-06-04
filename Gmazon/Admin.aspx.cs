using System;
using System.Web.UI.WebControls;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["userName"] == null) || (Session["userName"].ToString() == ""))
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                if (Session["isAdmin"].ToString() == "true")
                {
                    DataBinding();
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        private new void DataBinding()
        {
            GridView1.DataSource = new bookinfo().getBooks();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            new bookinfo().deteleBookByID(GridView1.DataKeys[e.RowIndex].Value.ToString());
            DataBinding();
        }

        protected void Quit_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Session["isAdmin"] = "false";
            Response.Redirect("Default.aspx");
        }
    }
}
