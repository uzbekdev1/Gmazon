using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string strName = TextBoxUsername.Text.Trim();
            byte[] result = Encoding.Default.GetBytes(TextBoxPassword.Text.Trim());
            byte[] output = new MD5CryptoServiceProvider().ComputeHash(result);
            DataTable dt = new userinfo().validUser(strName, BitConverter.ToString(output).Replace("-", ""));
            if (dt.Rows.Count > 0)
            {
                Session["userName"] = strName;
                if (dt.Rows[0]["isAdmin"].ToString() == "True")
                {
                    Session["isAdmin"] = "true";
                    Response.Redirect("Admin.aspx");
                }
                Session["isAdmin"] = "false";
                if (Session["shopcar"] == null)
                {
                    Response.Redirect("Default.aspx");
                }
                Response.Redirect("Cart.aspx");
            }
            else
            {
                Session["userName"] = "";
                LabelState.Text = "用户名或密码不正确！如没有账户请<a href='register.aspx'>注册</a>";
                LabelState.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
