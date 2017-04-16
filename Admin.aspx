<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin" %>

<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gmazon 管理</title>
    <style type="text/css">
        #logo
        {
            margin: 0px;
            padding: 0px;
            font-size: 12px;
            font-family: 微软雅黑;
        }
        .btn
        {
            text-align: center;
            height: 30px;
            border-radius: 5px;
            border: solid 1px #000000;
            cursor: pointer;
        }
        a
        {
            color:Black;	
        }
        a:visited
        {
            color: Black;
        }
        a:hover
        {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="logo" style="text-align: center; font-size: 40px;">
        <a href="Default.aspx">
            <img src="images/logo.png" alt="" /></a>图书管理系统</div>
    <div>
        <table width="100%" style="border-width: 0px; margin: 0 auto; padding: 0px;">
            <tr align="center">
                <td align="center">
                    <asp:Button runat="server" PostBackUrl="Default.aspx" Text="返回首页" CssClass="btn" />
                </td>
                <td align="center">
                    <asp:Button runat="server" PostBackUrl="ModifyBook.aspx?mess=0" Text="添加新书" CssClass="btn" />
                </td>
                <td align="center">
                    <asp:Button runat="server" OnClick="Quit_Click" Text="退出登录" CssClass="btn" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="False" AutoGenerateColumns="False"
            CellPadding="4" DataKeyNames="bookID" ForeColor="#333333" GridLines="None" Width="100%"
            Font-Size="15px" OnRowDeleting="GridView1_RowDeleting">
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="封面">
                    <ItemTemplate>
                        <a href="Book.aspx?bookID=<%# Eval("bookID") %>">
                            <img src="images/books/<%# Eval("bookImage") %> " alt="" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="书名">
                    <ItemTemplate>
                        <div id="title">
                            <a href="Book.aspx?bookID=<%# Eval("bookID") %>">
                                <%# Eval("bookName") %></a>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="bookAuthor" HeaderText="作者" SortExpression="bookAuthor" />
                <asp:BoundField DataField="bookPrice" HeaderText="价格" SortExpression="bookPrice" />
                <asp:HyperLinkField DataNavigateUrlFields="bookID" DataNavigateUrlFormatString="ModifyBook.aspx?mess=1&id={0}"
                    Text="编辑" />
                <asp:CommandField ShowDeleteButton="True" />
            </Columns>
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#f7cc68" Font-Bold="True" ForeColor="Black" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <div style="width: 1000px; margin: 0 auto; margin-top: 100px;">
            <uc1:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
        </div>
    </div>
    </form>
</body>
</html>
