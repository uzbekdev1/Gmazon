<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="My.aspx.cs" Inherits="Gmazon.My" %>

<%@ Register Src="WebUserControlTop.ascx" TagName="WebUserControlTop" TagPrefix="uc1" %>
<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>个人中心</title>
    <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0px;
            font-family: 微软雅黑 Light;
        }
        .btn
        {
            margin-top: 5px;
            margin-bottom: 5px;
            text-align: center;
            height: 30px;
            width: 64px;
            border-radius: 5px;
            border: solid 1px #000000;
            background-color: #f7cc68;
            cursor: pointer;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:WebUserControlTop ID="WebUserControlTop1" runat="server" />
    <div style="margin-top: 20px">
        <table width="800px" style="border-width: 0px; margin: 0 auto; padding: 0px;">
            <tr align="center">
                <td align="center">
                    <asp:Label ID="LabelTotal" runat="server" Font-Bold="true" Font-Size="26px" Text="我的订单"></asp:Label>
                </td>
                <td align="center">
                    <asp:Button ID="ButtonOK" runat="server" Text="退出登录" CssClass="btn" OnClick="ButtonQuit_Click" />
                </td>
            </tr>
        </table>
    </div>
    <div style="margin-top: 20px;">
        <div style="width: 800px; margin: 0 auto;">
            <asp:GridView ID="GridView1" runat="server" AllowSorting="False" AutoGenerateColumns="False"
                CellPadding="4" DataKeyNames="orderID" ForeColor="#333333" GridLines="None" Width="800px"
                Font-Size="15px">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <Columns>
                    <asp:BoundField DataField="bookNames" HeaderText="订单内容" SortExpression="bookNames" />
                    <asp:BoundField DataField="orderPrice" HeaderText="订单价格" SortExpression="orderPrice" />
                    <asp:BoundField DataField="orderTime" HeaderText="完成日期" SortExpression="orderTime" />
                </Columns>
                <RowStyle BackColor="#EFF3FB" HorizontalAlign="Center" />
                <EditRowStyle BackColor="#2461BF" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#f7cc68" Font-Bold="True" ForeColor="Black" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
    </div>
    <div style="width: 1000px; margin: 0 auto; margin-top: 150px;">
        <uc2:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
    </div>
    </form>
</body>
</html>
