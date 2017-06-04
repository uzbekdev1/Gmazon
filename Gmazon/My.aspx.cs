using System;
using System.Data;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class My : System.Web.UI.Page
    {
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
                    DataBinding();
                }
                else
                {
                    Response.Redirect("Admin.aspx");
                }
            }
        }

        private new void DataBinding()
        {
            DataTable dt = new orderinfo().getOrderByUserName(Session["userName"].ToString());
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["orderPrice"] = Math.Round(new decimal(Convert.ToDouble(dt.Rows[i]["orderPrice"].ToString())), 2).ToString();        
            }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ButtonQuit_Click(object sender, EventArgs e)
        {
            Session["userName"] = "";
            Response.Redirect("Default.aspx");
        }
    }
}
