<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Gmazon._Default" %>

<%@ Register src="WebUserControlTop.ascx" tagname="WebUserControlTop" tagprefix="uc1" %>
<%@ Register src="WebUserControlNav.ascx" tagname="WebUserControlNav" tagprefix="uc2" %>
<%@ Register src="WebUserControlHomepageItem.ascx" tagname="WebUserControlHomepageItem" tagprefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>冠马逊-网上书店</title>
    <style type="text/css">
        *
        {
            margin: 0;
            padding: 0;
            text-decoration: none;
        }
        body
        {
        	width:1200px;
        	margin: 0 auto;
            font-size: 12px;
            font-family: 微软雅黑;
        }
        ul
        {
            list-style: none;
        }
        #container
        {
        	float:left;
            position: relative;
            margin-top:10px;
            margin-left:25px;
            border: solid 1px black;
            width: 750px;
            height: 315px;
            overflow: hidden;
        }
        .pic{
            width:3000px;
            position: absolute;
            left:0;
            animation-name: focusmap;
            animation-duration: 12s;
            animation-iteration-count: infinite;
        }
        @keyframes focusmap {
            0%,27%{
                left: 0;
            }
            33%,60%{
                left: -750px;
            }
            66%,93%{
                left: -1500px;
            }
            100%{
                left: -2250px;
            } 
        }
        .pic li{
            float: left;
            background: #ffffff;
        }
        .pic li img
        {
            width: 750px;
            height: 315px;
        }
        #title1
        {
        	float:left;
        	width: 750px;
        	margin-top:10px;
        	margin-left:25px;
        	font-size: 36px;
        	color:#E27926;
        }
        #title2
        {
        	float:left;
        	width: 750px;
        	margin-top:10px;
        	margin-left:25px;
        	font-size: 36px;
        	color:#E27926;
        }
        #list
        {
        	float:right;
        	margin-right:10px;
        	margin-top:-374px;
        	padding-top:5px;
        	padding-left:10px;
        	width:160px;
        	height:850px;
        	border: solid 1px #dddddd;
        	font-size:18px;
        	font-weight:bold;
        }
        #listitle
        {
        	margin-top:30px;
        	margin-left:14px;
        	line-height:24px;
        	float:left;
        	color:#D52B37;
        	font-size:20px;
        	font-weight:bold;
        }
        #footerdiv
        {
        	width:1200px; 
        	height:42px; 
        	margin-top:20px;
        	padding-bottom:20px;
        	float:left;
        }
        .link
        {
        	display:block;
        	font-size:18px;	
        	font-weight:normal;
        }
        .fontfirst
        {
        	margin-top:0px;
        	display:block;
        	font-size:24px;
        	color:#B12704;	
        	font-weight:bold;
        }
        .fontred
        {
        	margin-top:10px;
        	display:block;
        	font-size:20px;
        	color:#B12704;	
        	font-weight:bold;
        }
        .font
        {
        	margin-top:10px;
        	display:block;
        	font-size:20px;	
        	font-weight:bold;
        }
        a
        {
            color:Black;	
        }
        a:visited
        {
        	color:Black;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <uc1:WebUserControlTop ID="WebUserControlTop1" runat="server" />
    <uc2:WebUserControlNav ID="WebUserControlNav1" runat="server" />
    <div id="title1">
        最新推荐
    </div>
    <div id="listitle">
        好书热卖榜
    </div>
    <div id="container">
        <ul class="pic">
            <li><a href="Book.aspx?bookid=13">
                <img src="images/recommended/a.jpg" alt="pic1" /></a></li>
            <li><a href="Book.aspx?bookid=12">
                <img src="images/recommended/b.jpg" alt="pic2" /></a></li>
            <li><a href="Book.aspx?bookid=11">
                <img src="images/recommended/c.jpg" alt="pic3" /></a></li>
            <li><a href="Book.aspx?bookid=13">
                <img src="images/recommended/a.jpg" alt="pic1" /></a></li><!-- 克隆第一张 -->
        </ul>
    </div>
    <div id="title2">新品图书</div>
    <div id="content" style="width:750px; margin-left:25px; margin-top:10px; float:left;">
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem1" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem2" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem3" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem4" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem5" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem6" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem7" runat="server" />
        <uc3:WebUserControlHomepageItem ID="WebUserControlHomepageItem8" runat="server" />
    </div>
    <div id="list">
        <div class="fontfirst">1</div><asp:HyperLink ID="HyperLink1" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="fontred">2</div><asp:HyperLink ID="HyperLink2" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="fontred">3</div><asp:HyperLink ID="HyperLink3" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">4</div><asp:HyperLink ID="HyperLink4" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">5</div><asp:HyperLink ID="HyperLink5" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">6</div><asp:HyperLink ID="HyperLink6" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">7</div><asp:HyperLink ID="HyperLink7" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">8</div><asp:HyperLink ID="HyperLink8" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">9</div><asp:HyperLink ID="HyperLink9" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">10</div><asp:HyperLink ID="HyperLink10" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">11</div><asp:HyperLink ID="HyperLink11" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">12</div><asp:HyperLink ID="HyperLink12" runat="server" CssClass="link" Text="1"></asp:HyperLink>
        <div class="font">13</div><asp:HyperLink ID="HyperLink13" runat="server" CssClass="link" Text="1"></asp:HyperLink>
    </div>
    <div id="footerdiv">
        <table style="margin:0 auto; width:auto">
            <tr>
                <td>
                    <img src="images/cnlogo.png" style="float: left; height: 40px; cursor: pointer" onclick="window.open('Default.aspx', '_self');"
                        alt="" />
                </td>
                <td>
                    <div id="footer">
                        旗下公司
                    </div>
                </td>
                <td>
                    <div style="color:#7A7A7A; margin-left:10px;">版权所有 © 2017，冠马逊公司或其关联公司</div>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

