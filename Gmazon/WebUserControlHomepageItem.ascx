<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebUserControlHomepageItem.ascx.cs"
    Inherits="Gmazon.WebUserControlHomepageItem" %>
<style type="text/css">
    *
    {
        margin: 0px;
        padding: 0px;
        font-size: 12px;
        font-family: 微软雅黑;
    }
    #imageItem
    {
        margin-top: 10px;
        margin-bottom: 15px;
        width: 175px;
        padding-left: 10px;
        height: 200px;
        font-size: 12px;
        line-height: 20px;
        float: left;
    }
    #image
    {
        height: 160px;
    }
    #description
    {
        height: 70px;
        padding-top: 5px;
        margin-left: 10px;
    }
    .title
    {
        font-size: 14px;
        font-weight: bold;
        display: block;
    }
    .title:hover
    {
        text-decoration: underline;
        cursor: pointer;
    }
    .bought
    {
        float: right;
        margin-right: 5px;
    }
    .price
    {
        float: left;
        font-weight: bold;
        font-size: 18px;
        color: #B12704;
    }
    .img
    {
        cursor: pointer;
    }
</style>
<div id="imageItem">
    <div id="image">
        <asp:HyperLink ID="Image" runat="server" ImageUrl="~/images/books/xsd2.jpg" NavigateUrl=""
            CssClass="img"></asp:HyperLink>
    </div>
    <div id="description">
        <asp:HyperLink ID="HyperLinkTitle" runat="server" Text="小时代2.0：虚铜时代" NavigateUrl=""
            CssClass="title"></asp:HyperLink>
        <asp:Label ID="LabelPrice" runat="server" Text="20.50" CssClass="price"></asp:Label>
        <asp:Label ID="LabelBought" runat="server" Text="0人已买" CssClass="bought"></asp:Label>
    </div>
</div>
