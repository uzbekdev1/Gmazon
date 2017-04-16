using System;
using System.Data.SqlClient;

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
                    string strCheckUser = "SELECT * FROM Users  WHERE userName=@name";
                    string strInsertUser = "INSERT INTO Users (userName, userPwd, lastLogin) VALUES (@name,@password,'" + DateTime.Now + "')";
                    string connString = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
                    SqlConnection conn = new SqlConnection(connString);
                    SqlCommand command = new SqlCommand(strCheckUser, conn);
                    command.Parameters.AddWithValue("@name", TextBoxName.Text.Trim());
                    command.Parameters.AddWithValue("@password", TextBoxPwd.Text.Trim());
                    conn.Open();
                    SqlDataReader dr = command.ExecuteReader();

                    if (dr.Read())
                    {
                        conn.Close();
                        this.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册失败,已有该用户名！');</script>");
                    }
                    else
                    {
                        dr.Close();
                        command.CommandText = strInsertUser;
                        command.ExecuteNonQuery();
                        conn.Close();
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }
    }
}
