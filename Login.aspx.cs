using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void ButtonLogin_Click(object sender, EventArgs e)
    {
        string strName = TextBoxUsername.Text;
        string strPwd = TextBoxPassword.Text;
        string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
        SqlConnection conn = new SqlConnection(connString);
        string strSelect = "SELECT * FROM Users WHERE userName=@username and userPwd=@password";
        SqlCommand command = new SqlCommand(strSelect, conn);
        command.Parameters.AddWithValue("@username", strName);
        command.Parameters.AddWithValue("@password", strPwd);
        conn.Open();
        SqlDataReader dr = command.ExecuteReader();
        if (dr.Read())
        {
            Session["userName"] = strName;
            Session["userID"] = dr["userID"];
            if (dr["isAdmin"].ToString() == "True")
            {
               Response.Redirect("Admin.aspx");
            }
            Response.Redirect("Default.aspx");
        }
        else
        {
            Session["userName"] = "";
            Session["userID"] = "";
            //Response.Write("<script>alert('登录失败，无此用户名或密码不正确');location='javascript:history.go(-1)';</script>");
            LabelState.Text = "用户名或密码不正确！如没有账户请<a href='register.aspx'>注册</a>";
            LabelState.ForeColor = System.Drawing.Color.Red;
        }
        conn.Close();
    }

    protected void ButtonRegister_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}
