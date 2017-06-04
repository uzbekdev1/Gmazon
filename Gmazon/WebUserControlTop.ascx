<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlTop.ascx.cs"
    Inherits="Gmazon.WebUserControlTop" %>
<style type="text/css">
    *
    {
        margin: 0px;
        padding: 0px;
    }
    .border
    {
        float: left;
        width: 520px;
        height: 45px;
        border-radius: 10px;
        border-color: Black;
        border-width: 1px;
        padding-left: 14px;
        margin-top: 12px;
        font-size: 30px;
        font-weight: lighter;
    }
    .search
    {
        float: left;
        margin-top: 12px;
        margin-left: -80px;
        width: 80px;
        height: 47px;
        background-color: #6A7077;
        border: none;
        border-width: 0px;
        border-radius: 10px;
        font-family: 微软雅黑 Light;
        font-size: 30px;
        color: white;
        cursor: pointer;
    }
    .search:hover
    {
        background-color: #424953;
    }
    .login
    {
        float: left;
        margin-top: 10px;
        margin-left: 20px;
        width: 90px;
        height: 50px;
        border-style: none;
        border-radius: 10px;
        font-size: 12px;
        font-family: 微软雅黑 Light;
        cursor: pointer;
    }
    .login:hover
    {
        border-style: solid;
        border-width: 1px;
        border-color: Black;
    }
    .cart
    {
        float: left;
        width: 100px;
        height: 50px;
        margin-top: 10px;
        border-style: none;
        border-radius: 10px;
        background: url( "images/cart.jpg" ) no-repeat;
        color: #E27926;
        cursor: pointer;
        font-size: 18px;
        font-family: 微软雅黑;
        margin-left: 10px;
        padding-left: 30px;
    }
    .cart:hover
    {
        border-style: solid;
        border-width: 1px;
        border-color: Black;
    }
</style>
<div>
    <table width="1200px" style="border-width: 0px; padding-top: 10px; margin: 0 auto;
        border-bottom: solid 1px #dddddd;">
        <tr>
            <td style="width: 200px;">
                <img src="images/cnlogo.png" style="height: 80px; margin-left: 24px; float: left;
                    cursor: pointer" onclick="window.open('Default.aspx', '_self');" alt="" />
            </td>
            <td style="width: 520px;">
                <asp:TextBox ID="txtBoxSearch" runat="server" CssClass="border"></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="找书" CssClass="search" OnClick="ButtonSearch_Click" />
            </td>
            <td style="width: 120px;">
                <asp:Button ID="btnLogin" runat="server" Text="您好，请登陆" CssClass="login" OnClick="ButtonLogin_Click" />
            </td>
            <td style="width: 150px;">
                <a href="Cart.aspx">
                    <asp:Label ID="labCart" runat="server" CssClass="cart" Text="0"></asp:Label></a>
            </td>
            <td>
                <iframe name="weather_inc" src="http://i.tianqi.com/index.php?c=code&id=2&num=1"
                    frameborder="0" marginwidth="0" marginheight="0" scrolling="no" style="height: 80px;
                    width: 220px"></iframe>
            </td>
        </tr>
    </table>
</div>
