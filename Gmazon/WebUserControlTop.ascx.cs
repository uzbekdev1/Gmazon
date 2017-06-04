using System;
using System.Collections;

namespace Gmazon
{
    public partial class WebUserControlTop : System.Web.UI.UserControl
    {
        private bool isAdmin = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["shopcar"] == null)
            {
                labCart.Text = "0";
            }
            else
            {
                int sum = 0;
                Hashtable ht = (Hashtable)Session["shopcar"];
                foreach (object item in ht.Keys)
                {
                    sum += Convert.ToInt32((ht[item].ToString()));
                }
                labCart.Text = sum.ToString();
            }


            if ((Session["userName"] == null) || (Session["userName"].ToString() == ""))
            {
                btnLogin.Text = "您好，请登陆";
            }
            else
            {
                btnLogin.Text = "您好，" + Session["userName"].ToString();
                if (Session["isAdmin"].ToString() == "true")
                {
                    isAdmin = true;
                }
            }
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            if ((Session["userName"] == null) || (Session["userName"].ToString() == ""))
            {
                Response.Redirect("Login.aspx");
            }
            else if (isAdmin)
            {
                Response.Redirect("Admin.aspx");
            }
            else
            {
                Response.Redirect("My.aspx");
            }
        }

        public int setBookNumber
        {
            set
            {
                labCart.Text = value.ToString();
            }
            get
            {
                return Convert.ToInt32(labCart.Text.Trim());
            }
        }

        protected void ButtonSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search.aspx?s=" + txtBoxSearch.Text);
        }
    }
}