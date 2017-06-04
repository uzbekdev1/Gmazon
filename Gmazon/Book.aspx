<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="Gmazon.Book" %>

<%@ Register Src="WebUserControlFooter.ascx" TagName="WebUserControlFooter" TagPrefix="uc2" %>
<%@ Register Src="WebUserControlTop.ascx" TagName="WebUserControlTop" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Gmazon 图书</title>
    <style type="text/css">
        *
        {
            margin: 0px;
            padding: 0px;
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
        .style1
        {
            height: 58px;
            font-size: 24px;
            font-family: 微软雅黑 Light;
        }
        .style2
        {
            height: 30px;
            font-size: 24px;
            font-family: 微软雅黑 Light;
        }
        div, ul, li
        {
            margin: 0 auto;
            padding: 0;
        }
        ul
        {
            list-style: none;
        }
        .main
        {
            clear: both;
            padding: 8px;
            text-align: left;
            height: 31px;
            width: 1200px;
        }
        #tabs0
        {
            margin-top: 50px;
            height: 550px;
            width: 1200px;
            border: 1px solid #cbcbcb;
        }
        .menu0
        {
            width: 1200px;
        }
        .menu0 li
        {
            display: block;
            float: left;
            padding: 4px 0;
            width: 160px;
            font-size: 20px;
            text-align: center;
            cursor: pointer;
            background: #FFFFFF;
        }
        .menu0 li.hover
        {
            background: #f2f6fb;
        }
        #main0 ul
        {
            display: none;
        }
        #main0 ul.block
        {
            display: block;
        }
    </style>

    <script type="text/javascript">

    function setTab(m,n){
        var tli=document.getElementById("menu"+m).getElementsByTagName("li");
        var mli=document.getElementById("main"+m).getElementsByTagName("ul");
        for(i=0;i<tli.length;i++){
            tli[i].className=i==n?"hover":"";
            mli[i].style.display=i==n?"block":"none";
        }
    }

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div id="bodydiv">
        <uc3:WebUserControlTop ID="WebUserControlTop1" runat="server" />
        <div style="margin-top: 20px; margin-left: 100px;">
            <table width="1200px" border="0" style="margin: 0 auto;">
                <tr>
                    <td>
                        <div style="text-align: center">
                            <asp:Image ID="bookImage" runat="server" Height="500px" Width="360px" ImageUrl="~/images/books/large/large-abl.jpg" /></div>
                    </td>
                    <td>
                        <div>
                            <table border="0" style="width: 700px; margin-left: 50px;">
                                <tr>
                                    <td colspan="2" class="style1">
                                        <label>
                                            书名:</label>
                                        <asp:Label ID="bookName" runat="server" Text="1" Font-Size="32px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="style1">
                                        <label>
                                            作者:</label>
                                        <asp:Label ID="bookAuthor" runat="server" Text="1" Font-Size="24px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <label>
                                            原价:</label>
                                        <asp:Label ID="bookSetPrice" runat="server" Text="￥1" ForeColor="#B12704" Font-Size="24px"></asp:Label>
                                    </td>
                                    <td class="style1">
                                        <label>
                                            现价:</label>
                                        <asp:Label ID="bookPrice" runat="server" Text="￥1" ForeColor="#B12704" Font-Size="24px"></asp:Label>
                                        &nbsp;&nbsp;<asp:Label ID="LabelDiscount" runat="server" Text="￥1" Font-Size="18px"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" class="style1">
                                        <label>
                                            已售出</label>
                                        <asp:Label ID="bookBought" runat="server" Text="1" Font-Size="20px" ForeColor="#B12704"></asp:Label>
                                        <label>
                                            本</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="style1">
                                        <asp:Button ID="ButtonBuy" runat="server" BackColor="#f7cc68" ForeColor="Black" Height="35px"
                                            Text="立即购买" Width="200px" CssClass="ipt" OnClick="AddToCartAndGo" />
                                    </td>
                                    <td class="style1">
                                        <asp:Button ID="ButtonCart" runat="server" BackColor="#f7cc68" ForeColor="Black"
                                            Height="35px" Text="加入购物车" Width="200px" CssClass="ipt" OnClick="AddToCart" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </div>
        <div id="tabs0" class="style2">
            <ul class="menu0" id="menu0">
                <li onclick="setTab(0,0)">书籍简介</li>
                <li onclick="setTab(0,1)">在线试读</li>
            </ul>
            <div class="main" id="main0">
                <ul class="block">
                    <li>
                        <asp:TextBox ID="TextSummary" runat="server" Width="1183px" Height="500px" TextMode="MultiLine"
                            BorderWidth="0" ReadOnly="true" Font-Size="16px"></asp:TextBox>
                    </li>
                </ul>
                <ul>
                    <li>
                        <asp:TextBox ID="TextPreview" runat="server" Width="1183px" Height="500px" TextMode="MultiLine"
                            BorderWidth="0" ReadOnly="true" Font-Size="16px"></asp:TextBox>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div style="width: 1000px; margin: 0 auto; margin-top: 50px;">
        <uc2:WebUserControlFooter ID="WebUserControlFooter1" runat="server" />
    </div>
    </form>
</body>
</html>
