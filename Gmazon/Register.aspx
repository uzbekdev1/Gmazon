<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Gmazon.Register" %>

<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf8" />
    <title>Gmazon 注册</title>
    <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
            font-family: 微软雅黑;
        }
        #logo
        {
            height: 100px;
        }
        input.ipt
        {
            width: 300px;
            height: 24px;
            border-radius: 5px;
            border: solid 1px #000000;
            padding-left: 5px;
            cursor: pointer;
        }
        .textboxdiv
        {
            width: 300px;
            height: 24px;
            border-radius: 5px;
            border: solid 1px #000000;
            padding-left: 5px;
        }
        .STYLE6
        {
            font-family: "宋体";
            font-weight: bold;
        }
        .STYLE8
        {
            font-family: 微软雅黑 light;
            font-weight: bold;
            font-size: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="logo" style="text-align: center">
        <a href="Default.aspx">
            <img src="images/logo.png" alt="" /></a></div>
    <table width="350" border="0" style="margin: 0 auto;" cellspacing="15">
        <tr>
            <td>
                <label>
                    <span class="STYLE8">创建账户</span>
                </label>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    <span class="STYLE6">用户名&nbsp;</span></label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxName" runat="server" CssClass="textboxdiv"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空！"
                    ControlToValidate="TextBoxName"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    <span class="STYLE6">密&nbsp;码&nbsp;</span></label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxPwd" runat="server" CssClass="textboxdiv" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空！"
                    ControlToValidate="TextBoxPwd"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBoxPwd"
                    Display="Dynamic" ErrorMessage="3到10个字母或数字！" ValidationExpression="[0-9a-zA-Z]{3,10}"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    <span class="STYLE6">确认密码</span></label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="TextBoxRePwd" runat="server" CssClass="textboxdiv" TextMode="Password">  </asp:TextBox>
                <asp:Label ID="LabelState" runat="server"></asp:Label>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="密码前后输入不一致！"
                    ControlToCompare="TextBoxPwd" ControlToValidate="TextBoxRePwd"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>
                <label>
                    <span class="STYLE6">验证码&nbsp;</span></label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox ID="txtCheckCode" runat="server" CssClass="textboxdiv" />
                <asp:Label ID="LabelStateCode" runat="server"></asp:Label>
            </td>
            <td>
                <img id="Image" runat="server" height="25" width="80" onclick="javascript:this.src=this.src+'?'"
                    src="~/ValidateNum.aspx" alt="" style="cursor: pointer;" />
            </td>
        </tr>
        <tr align="center">
            <td style="padding-top: 20px;">
                <asp:Button ID="ButtonRegister" runat="server" Text="确定" CssClass="ipt" BackColor="#f7cc68"
                    Height="35px" OnClick="ButtonRegister_Click" />
            </td>
        </tr>
    </table>
    <div style="width: 1000px; margin: 0 auto; margin-top: 100px;">
        <uc1:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
    </div>
    </form>
</body>
</html>
