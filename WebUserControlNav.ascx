<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControlNav.ascx.cs"
    Inherits="WebUserControlNav" %>
<style type="text/css">
    *
    {
        margin: 0px;
        padding: 0px;
    }
    #navborder
    {
    	float:left;
    	border-right: solid 1px #DDDDDD;
    	margin-left: 5px;
        margin-top: 10px;
        width: 225px;
    }
    #nav
    {
        width: 200px;
        float: left;
    }
    #navhead
    {
        color:white;
        padding-left:10px;
        background-color:#A8A8A8;
        height: 60px;
        line-height: 60px;
        font-size: 24px;
    }
    #navcontent
    {
    	padding-top:10px;
    	padding-left:10px;
    	padding-bottom:10px;
        background-color: #f0f0f0;
    }
</style>
<div id="navborder">
<div id="nav">
    <div id="navhead">
        所有分类</div>
    <div id="navcontent">
        <asp:TreeView ID="TreeView1" runat="server" ExpandDepth="1" Width="200px" 
            ShowExpandCollapse="False">
            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                VerticalPadding="0px" />
            <Nodes>
                <asp:TreeNode Text="图书" Value="图书" SelectAction="None">
                    <asp:TreeNode Text="文学" Value="文学" NavigateUrl="Category.aspx?class=wx"></asp:TreeNode>
                    <asp:TreeNode Text="小说" Value="小说" NavigateUrl="Category.aspx?class=xs"></asp:TreeNode>
                    <asp:TreeNode Text="传记" Value="传记" NavigateUrl="Category.aspx?class=zj"></asp:TreeNode>
                    <asp:TreeNode Text="青春动漫" Value="青春动漫" NavigateUrl="Category.aspx?class=qcdm"></asp:TreeNode>
                    <asp:TreeNode Text="艺术与摄影" Value="艺术与摄影" NavigateUrl="Category.aspx?class=ysysy"></asp:TreeNode>
                    <asp:TreeNode Text="少儿" Value="少儿" NavigateUrl="Category.aspx?class=se"></asp:TreeNode>
                    <asp:TreeNode Text="家庭教育" Value="家庭教育" NavigateUrl="Category.aspx?class=jtjy"></asp:TreeNode>
                    <asp:TreeNode Text="孕产育儿" Value="孕产育儿" NavigateUrl="Category.aspx?class=ycye"></asp:TreeNode>
                    <asp:TreeNode Text="社会科学" Value="社会科学" NavigateUrl="Category.aspx?class=shkx"></asp:TreeNode>
                    <asp:TreeNode Text="哲学与宗教" Value="哲学与宗教" NavigateUrl="Category.aspx?class=zxyzj"></asp:TreeNode>
                    <asp:TreeNode Text="心理学" Value="心理学" NavigateUrl="Category.aspx?class=xlx"></asp:TreeNode>
                    <asp:TreeNode Text="历史" Value="历史" NavigateUrl="Category.aspx?class=ls"></asp:TreeNode>
                    <asp:TreeNode Text="法律" Value="法律" NavigateUrl="Category.aspx?class=fl"></asp:TreeNode>
                    <asp:TreeNode Text="国学" Value="国学" NavigateUrl="Category.aspx?class=gx"></asp:TreeNode>
                    <asp:TreeNode Text="经济管理" Value="经济管理" NavigateUrl="Category.aspx?class=jjgl"></asp:TreeNode>
                    <asp:TreeNode Text="励志与成功" Value="励志与成功" NavigateUrl="Category.aspx?class=lzycg"></asp:TreeNode>
                    <asp:TreeNode Text="考试辅导" Value="考试辅导" NavigateUrl="Category.aspx?class=ksfd"></asp:TreeNode>
                    <asp:TreeNode Text="外语学习" Value="外语学习" NavigateUrl="Category.aspx?class=wyxx"></asp:TreeNode>
                    <asp:TreeNode Text="中小学教辅" Value="中小学教辅" NavigateUrl="Category.aspx?class=zxxjf"></asp:TreeNode>
                    <asp:TreeNode Text="大中专教材" Value="大中专教材" NavigateUrl="Category.aspx?class=dzzjc"></asp:TreeNode>
                    <asp:TreeNode Text="辞典与工具书" Value="辞典与工具书" NavigateUrl="Category.aspx?class=cdygjs"></asp:TreeNode>
                    <asp:TreeNode Text="科技" Value="科技" NavigateUrl="Category.aspx?class=kj"></asp:TreeNode>
                    <asp:TreeNode Text="科学与自然" Value="科学与自然" NavigateUrl="Category.aspx?class=kxyzr"></asp:TreeNode>
                    <asp:TreeNode Text="计算机与互联网" Value="计算机与互联网" NavigateUrl="Category.aspx?class=jsjyhlw"></asp:TreeNode>
<%--                    <asp:TreeNode Text="医学" Value="医学" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="旅游与地图" Value="旅游与地图" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="烹饪美食与酒" Value="烹饪美食与酒" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="时尚" Value="时尚" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="运动健身" Value="运动健身" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="恋爱与婚姻" Value="恋爱与婚姻" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="家居休闲" Value="家居休闲" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="娱乐" Value="娱乐" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="养生保健" Value="养生保健" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="体育" Value="体育" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="期刊杂志" Value="期刊杂志" NavigateUrl="#"></asp:TreeNode>
                    <asp:TreeNode Text="进口原版" Value="进口原版" NavigateUrl="#"></asp:TreeNode>--%>
                </asp:TreeNode>
                <asp:TreeNode Text="作者" Value="作者" SelectAction="None">
                    <asp:TreeNode Text="郭敬明" Value="郭敬明" NavigateUrl="Category.aspx?author=gjm"></asp:TreeNode>
                    <asp:TreeNode Text="李玉刚" Value="李玉刚" NavigateUrl="Category.aspx?author=lyg"></asp:TreeNode>
                    <asp:TreeNode Text="东野圭吾" Value="东野圭吾" NavigateUrl="Category.aspx?author=dygw"></asp:TreeNode>
                </asp:TreeNode>
            </Nodes>
            <NodeStyle Font-Names="微软雅黑" Font-Size="14pt" ForeColor="Black" HorizontalPadding="2px"
                NodeSpacing="0px" VerticalPadding="2px" />
        </asp:TreeView>
    </div>
</div>
</div>