<%@ Page Language="C#" AutoEventWireup="true" Inherits="Admin.admin_main" Title="南昌大学生物信息学查询后台管理系统" Codebehind="main.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理系统</title>
</head>
<body leftmargin="0" topmargin="0">
    <form id="form1" runat="server">
    <div>
        <div>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 1002px">
                <tr>
                    <td style="width: 409px">
                        <img alt="" src="images/Blue/top1.jpg" /></td>
                    <td align="right" style="background-position: left top; background-image: url(images/Blue/top_bg.jpg);
                        background-repeat: repeat-x">&nbsp;
                        
                    </td>
                    <td style="width: 30px">
                        <img alt="" src="images/Blue/top2.jpg" /></td>
                </tr>
            </table>
        </div>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 1002px">
            <tr>
                <td align="left" style="padding-right: 5px; padding-left: 7px; background-image: url(images/Blue/left_bg.jpg);
                    padding-bottom: 5px; width: 172px; padding-top: 10px; background-repeat: repeat-y;
                    height: 511px" valign="top">
                    <asp:TreeView ID="menuTree" runat="server" BorderStyle="None" Font-Size="12px" ImageSet="Simple"
                        NodeIndent="12" ShowLines="True" Width="100%">
                        <ParentNodeStyle Font-Bold="False" Font-Size="12px" />
                        <HoverNodeStyle Font-Size="12px" Font-Underline="True" ForeColor="#5555DD" />
                        <SelectedNodeStyle Font-Size="12px" Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px"
                            VerticalPadding="0px" />
                        <Nodes>
                        </Nodes>
                        <NodeStyle Font-Names="Tahoma" Font-Size="12px" ForeColor="Black" HorizontalPadding="0px"
                            NodeSpacing="0px" VerticalPadding="0px" />
                        <RootNodeStyle Font-Size="12px" />
                        <LeafNodeStyle Font-Size="12px" />
                    </asp:TreeView>
                </td>
                <td align="left" colspan="2" style="padding-right: 3px; padding-left: 3px; padding-bottom: 5px;
                    width: 810px; padding-top: 1px; height: 511px" valign="top">
                    <iframe name="content" id="content" frameborder="0" width="100%" height="800"></iframe>
                </td>
            </tr>
        </table>
        <table border="0" cellpadding="0" cellspacing="0" style="width: 1002px">
            <tr>
                <td style="font-size: 12px; background-image: url(images/Blue/bottom.jpg);
                    color: gray; background-repeat: no-repeat; height: 10px; text-align: center">
                    <br /></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
