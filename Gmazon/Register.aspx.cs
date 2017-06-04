using System;
using System.Security.Cryptography;
using System.Text;
using Gmazon.BLL;

namespace Gmazon
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            if (TextBoxPwd.Text != TextBoxRePwd.Text)
            {
                LabelState.Text = "密码前后输入不一致！";
                LabelState.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                if (txtCheckCode.Text != null)
                {
                    if (Session["CheckCode"].ToString().ToLower() != txtCheckCode.Text.ToLower())
                    {
                        LabelStateCode.Text = "验证码有误！";
                        LabelStateCode.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        byte[] result = Encoding.Default.GetBytes(TextBoxPwd.Text.Trim());
                        byte[] output = new MD5CryptoServiceProvider().ComputeHash(result);
                        if (new userinfo().saveUserInfo(TextBoxName.Text.Trim(), BitConverter.ToString(output).Replace("-", "")) == 0)
                        {
                            this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册失败,已有该用户名！');</script>");
                        }
                        else
                        {
                            Session["isAdmin"] = "false";
                            Response.Redirect("Login.aspx");
                        }
                    }
                }
            }
        }
    }
}
