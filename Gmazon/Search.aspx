<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="Gmazon.Search" %>

<%@ Register Src="WebUserControlTop.ascx" TagName="WebUserControlTop" TagPrefix="uc1" %>
<%@ Register Src="WebUserControlNav.ascx" TagName="WebUserControlNav" TagPrefix="uc2" %>
<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gmazon 搜索</title>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            text-decoration: none;
        }
        body
        {
            width: 1200px;
            margin: 0 auto;
            font-size: 12px;
            font-family: 微软雅黑;
        }
        .gridview
        {
            text-align: center;
            width: 950px;
            margin: auto;
        }
        #title
        {
            text-decoration: none;
            color: Black;
            font-size: 22px;
            height: 200px;
            line-height: 200px;
        }
        a
        {
            color: Black;
        }
        a:visited
        {
            color: Black;
        }
        a:hover
        {
            text-decoration: underline;
        }
        .title
        {
            float: left;
            width: 750px;
            margin-left: 20px;
            margin-bottom: 15px;
            font-size: 36px;
            color: #E27926;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:WebUserControlTop ID="WebUserControlTop1" runat="server" />
        <div style="width: 1200px; display: block;">
            <uc2:WebUserControlNav ID="WebUserControlNav1" runat="server" />
            <div style="width: 950px; float: right; margin-top: 20px;">
                <div>
                    <asp:Label ID="LabelTitle" runat="server" CssClass="title"></asp:Label>
                </div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal"
                    CssClass="gridview" ShowHeader="false">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href="Book.aspx?bookID=<%# Eval("ID") %>">
                                    <img src="images/books/<%# Eval("Image") %>" alt="" /></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div id="title">
                                    <a href="Book.aspx?bookID=<%# Eval("ID") %>">
                                        <%# Eval("Name") %></a>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Author" ItemStyle-Font-Size="18px" />
                        <asp:BoundField DataField="Price" ItemStyle-ForeColor="#B12704" ItemStyle-Font-Size="24px"
                            ItemStyle-Font-Bold="true" />
                    </Columns>
                    <RowStyle BackColor="#ffffff" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                    <PagerStyle BackColor="#000000" ForeColor="White" HorizontalAlign="Center" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </div>
        </div>
        <div style="margin-top: 200px;">
            <div style="width: 1000px; margin: 0 auto;">
                <uc3:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
            </div>
        </div>
    </div>
    </form>
</body>
</html>
