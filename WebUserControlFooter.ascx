<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControlFooter.ascx.cs"
    Inherits="WebUserControlFooter" %>
<style type="text/css">
    #container
    {
    	float:left;
        width:1000px;
        height:50px;
        margin: 0 auto;
    }
    #footer
    {
    	margin-top:5px;
        float: left;
        height: 40px;
        font-size: 18px;
        font-family: 微软雅黑;
        line-height: 40px;
        text-align: center;
    }
</style>
<div id="container">
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
                <div style="color:#7A7A7A; margin-left:10px;">版权所有 © 2016，冠马逊公司或其关联公司</div>
            </td>
        </tr>
    </table>
</div>
