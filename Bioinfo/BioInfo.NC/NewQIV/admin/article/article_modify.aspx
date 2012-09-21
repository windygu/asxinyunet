<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_article_article_modify" ValidateRequest="false" Codebehind="article_modify.aspx.cs" %>

<%@ Register Assembly="CuteEditor" Namespace="CuteEditor" TagPrefix="CE" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <div>
                <div>
                    <div>
                        <table id="InsertTable">
                            <tr>
                                <td id="InsertHeader" colspan="2">
                                    修改文章</td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 104px">
                                    标题：</td>
                                <td>
                                    <asp:TextBox ID="arti_title" runat="server" Width="413px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="arti_title"
                                        ErrorMessage="*必填"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 104px">
                                    作者：</td>
                                <td>
                                    <asp:TextBox ID="arti_author" runat="server" Width="413px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 104px">
                                    文章来源：</td>
                                <td>
                                    <asp:TextBox ID="arti_source" runat="server" Width="413px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 104px">
                                    最后更新时间：</td>
                                <td>
                                    <asp:TextBox ID="arti_time2" runat="server" Enabled="False" ReadOnly="True" Width="145px"></asp:TextBox>点击“确定”后，文章的“最后更新时间”将自动设置为当前系统时间</td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 104px">
                                    文章内容：</td>
                                <td>
                                    <CE:Editor ID="arti_content" runat="server" AutoConfigure="Simple" Width="100%">
                                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                    </CE:Editor>
                                    <a href="~/Bin/CuteEditor.dll"><span style="color: #0000ff; text-decoration: underline"></span></a></td>
                            </tr>
                            <tr>
                                <td id="InsertFooter" colspan="2" style="height: 30px">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" SkinID="InsertButton"
                                        Text="确定" />&nbsp;</td>
                            </tr>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    
    </div>
    </form>
</body>
</html>
