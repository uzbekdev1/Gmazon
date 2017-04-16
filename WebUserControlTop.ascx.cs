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

public partial class WebUserControlTop : System.Web.UI.UserControl
{
    private bool isAdmin = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["shopcar"] == null)
        {
            labCart.Text = "0";
        } else
        {
            int sum = 0;
            Hashtable ht = (Hashtable)Session["shopcar"];
            foreach (object item in ht.Keys)
            {
                sum += int.Parse((ht[item].ToString()));
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

            string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn = new SqlConnection(connString);
            string strSelect = "SELECT * FROM Users WHERE userName=@username";
            SqlCommand command = new SqlCommand(strSelect, conn);
            command.Parameters.AddWithValue("@username", Session["userName"].ToString());
            conn.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                if (dr["isAdmin"].ToString() == "True")
                {
                    isAdmin = true;
                }
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
            return Int32.Parse(labCart.Text.Trim());
        }
    }

    protected void ButtonSearch_Click(object sender, EventArgs e)
    {
        Response.Redirect("Search.aspx?s=" + txtBoxSearch.Text);
    }
}
