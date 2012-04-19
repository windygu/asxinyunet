<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeftSubMenu.aspx.cs" Inherits="LeftSubMenu" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>工作流程审批系统 - 左侧子菜单</title>
    <style type="text/css">
        html, body
        {
            height: 100%;
            overflow: visible;
            margin: 0;
          
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:TreeView ID="tvModules" runat="server" ShowLines="True" NodeIndent="18" ExpandDepth="1">
        <NodeStyle Height="1px" Font-Names="Arial" Font-Size="10pt" ForeColor="Black" HorizontalPadding="5px"
            VerticalPadding="0px" />
        <RootNodeStyle ImageUrl="Themes/Blue/Images/Tree/icon_root.gif" />
        <ParentNodeStyle Font-Bold="False" ImageUrl="Themes/Blue/Images/Tree/icon_node.gif" />
        <LeafNodeStyle ImageUrl="Themes/Blue/Images/Tree/icon_files.gif" />
        <NodeStyle HorizontalPadding="3px" />
        <Nodes>
        </Nodes>
        <NodeStyle HorizontalPadding="3px" />
    </asp:TreeView>
    </form>
</body>
</html>
