<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_system_admin_modify" Codebehind="admin_modify.aspx.cs" %>

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
                                    添加管理员</td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 130px">
                                    姓名：</td>
                                <td>
                                    <asp:TextBox ID="admin_name" runat="server" Width="310px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 130px">
                                    登陆账号：</td>
                                <td>
                                    <asp:TextBox ID="admin_uid" runat="server" Width="309px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="admin_uid"
                                        ErrorMessage="*必填"></asp:RequiredFieldValidator></td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 130px">
                                    密码：</td>
                                <td>
                                    <asp:TextBox ID="admin_pwd" runat="server" TextMode="Password" Width="309px"></asp:TextBox>
                                    *不修改请留空</td>
                            </tr>
                            <tr>
                                <td class="InsertTitle" style="width: 130px">
                                    再次输入密码：</td>
                                <td>
                                    <asp:TextBox ID="admin_pwd2" runat="server" TextMode="Password" Width="309px"></asp:TextBox>
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="admin_pwd2"
                                        ControlToValidate="admin_pwd" ErrorMessage="两次输入的密码不一样"></asp:CompareValidator></td>
                            </tr>
                            <tr>
                                <td id="InsertFooter" colspan="2">
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
