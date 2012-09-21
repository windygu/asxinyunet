<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_others_config" Codebehind="config.aspx.cs" %>

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
                                    修改<%=cate %></td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 104px">
                                    内容：</td>
                                <td>
                                    <CE:Editor ID="cfg_content" runat="server" AutoConfigure="Simple" Width="100%">
                                        <FrameStyle BackColor="White" BorderColor="#DDDDDD" BorderStyle="Solid" BorderWidth="1px"
                                            CssClass="CuteEditorFrame" Height="100%" Width="100%" />
                                    </CE:Editor>
                                    <a href="~/Bin/CuteEditor.dll"><span style="color: #0000ff; text-decoration: underline"></span></a></td>
                            </tr>
                            <tr>
                                <td id="InsertFooter" colspan="2" style="height: 30px">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" SkinID="InsertButton"
                                        Text="确定" /></td>
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
