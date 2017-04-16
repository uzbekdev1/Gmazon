<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ModifyBook.aspx.cs" Inherits="ModifyBook" %>

<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>修改图书信息</title>
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
            cursor:pointer;
        }
        .txtdiv
        {
            width: 300px;
            height: 24px;
            border-radius: 5px;
            border: solid 1px #000000;
            padding-left: 5px;
        }
        #content
        {
            width: 760px;
            margin: 0 auto;
            height: 500px;
        }
        .style2
        {
            margin-left: 50px;
            width: 80%;
            height: 300px;
            border-radius: 5px;
            border: solid 1px #000000;
            padding-left: 5px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="logo" style="text-align: center;">
        <a href="Default.aspx">
            <img src="images/logo.png" alt="" />
        </a>
        <asp:Label ID="LabelTitle" Font-Size="40px" runat="server"></asp:Label>
    </div>
    <div id="content">
        <div style="text-align: center;">
            <asp:Label ID="Label1" runat="server"></asp:Label>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px; text-align: center;">
            书 名
            <asp:TextBox ID="bookName" runat="server" OnInit="TextBox_Init" CssClass="txtdiv"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px; text-align: center;">
            作 者
            <asp:TextBox ID="bookAuthor" runat="server" CssClass="txtdiv"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px; text-align: center;">
            类 别
            <asp:TextBox ID="bookClass" runat="server" CssClass="txtdiv"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px; text-align: center;">
            &nbsp;定 价
            <asp:TextBox ID="bookSetPrice" runat="server" CssClass="txtdiv"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px; text-align: center;">
            &nbsp;售 价
            <asp:TextBox ID="bookPrice" runat="server" CssClass="txtdiv"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px; text-align: center;">
            &nbsp;封 面
            <asp:TextBox ID="bookImage" runat="server" CssClass="txtdiv"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px;">
            <div style="float: left; margin-top: 130px;">
                简 介
            </div>
            <asp:TextBox ID="bookSummary" runat="server" CssClass="style2" TextMode="MultiLine"></asp:TextBox>
        </div>
        <div style="width: 90%; margin: 0 auto; margin-top: 30px;">
            <div style="float: left; margin-top: 130px;">
                试 读
            </div>
            <asp:TextBox ID="bookPreview" runat="server" CssClass="style2" TextMode="MultiLine"></asp:TextBox>
        </div>
        &nbsp;<div style="width: 80%; margin: 0 auto; margin-top: 30px; text-align: center;">
            &nbsp;&nbsp;
            <asp:Button ID="ButtonOK" runat="server" Text="确定" CssClass="ipt" Height="35px" BackColor="#f7cc68"
                Width="250px" OnClick="ButtonOK_Click" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="ButtonCancel" runat="server" Text="放弃" CssClass="ipt" Height="35px"
                Width="250px" OnClick="ButtonCancel_Click" />
        </div>
        <div style="width: 1000px; margin: 0 auto; margin-top: 100px; margin-left:-100px;">
            <uc1:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
