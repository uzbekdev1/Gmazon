<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Gmazon.Cart" %>

<%@ Register Src="WebUserControlTop.ascx" TagName="WebUserControlTop" TagPrefix="uc1" %>
<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>购物车</title>
    <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0px;
            font-size: 16px;
            font-family: 微软雅黑 Light;
        }
        .gridview
        {
            text-align: center;
            width: 800px;
            margin: auto;
        }
        .btn
        {
            margin-top: 5px;
            margin-bottom: 5px;
            text-align: center;
            height: 30px;
            width: 45px;
            border-radius: 5px;
            border: solid 1px #000000;
            background-color: #f7cc68;
            cursor: pointer;
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
    <uc1:WebUserControlTop ID="WebUserControlTop1" runat="server" />
    <div style="width: 400px; margin: 0 auto; font-size: 40px; font-family: 微软雅黑; text-align: center;
        padding-top: 10px;">
        购物车</div>
    <div style="margin-top: 24px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Vertical"
            CssClass="gridview">
            <Columns>
                <asp:TemplateField HeaderText="封面">
                    <ItemTemplate>
                        <a href="Book.aspx?bookID=<%# Eval("ID") %>">
                            <img src="images/books/<%# Eval("Image") %> " alt="" /></a>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="书名">
                    <ItemTemplate>
                        <div id="title">
                            <a href="Book.aspx?bookID=<%# Eval("ID") %>">
                                <%# Eval("Name") %></a>
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Price" HeaderText="价格" />
                <asp:BoundField DataField="Num" HeaderText="数量" />
                <asp:BoundField DataField="Total" HeaderText="合计" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" ID="button1" CommandArgument='<%# Eval("ID") %>' Text="删除"
                            OnClick="ButtonDelete_Click" CssClass="btn" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
            <EditRowStyle BackColor="#2461BF" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <HeaderStyle BackColor="#f7cc68" Font-Bold="True" Font-Size="25px" ForeColor="Black" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <div style="margin-top: 200px;">
            <table width="800px" style="border-width: 0px; margin: 0 auto; padding: 0px;">
                <tr align="center">
                    <td align="center" style="font-size: 24px;">
                        总价：
                        <asp:Label ID="LabelTotal" runat="server" ForeColor="#B12704" Font-Bold="true" Font-Size="26px"></asp:Label>
                    </td>
                    <td align="center">
                        <asp:Button ID="ButtonOK" runat="server" Text="结算" CssClass="btn" OnClick="ButtonOK_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
    <div style="width: 1000px; margin: 0 auto; margin-top: 150px;">
        <uc2:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
    </div>
    </form>
</body>
</html>
