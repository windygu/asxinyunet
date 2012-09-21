<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_system_admin_list" Codebehind="admin_list.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/data/main_data.mdb"
            SelectCommand="SELECT * FROM [admin] ORDER BY [admin_id] DESC" DeleteCommand="delete from admin where admin_id = ? ">
            <DeleteParameters>
                <asp:ControlParameter ControlID="GridView1" Name="admin_id" PropertyName="SelectedValue" />
            </DeleteParameters>
        </asp:AccessDataSource>
        &nbsp;</div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="admin_id" DataSourceID="AccessDataSource1" SkinID="BlueGridView" AllowPaging="True" AllowSorting="True" PageSize="15">
            <Columns>
                <asp:BoundField DataField="admin_name" HeaderText="姓名" SortExpression="admin_name" />
                <asp:BoundField DataField="admin_uid" HeaderText="登陆账号" SortExpression="admin_uid" />
                <asp:BoundField DataField="usergroup" HeaderText="类型" SortExpression="usergroup" ReadOnly="true" />
                <asp:HyperLinkField DataNavigateUrlFields="admin_id" DataNavigateUrlFormatString="admin_modify.aspx?admin_id={0}"
                    DataTextField="admin_id" DataTextFormatString="[修改]" HeaderText="修改" />
                <asp:TemplateField HeaderText="删除">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("admin_id") %>'
                            CommandName="Delete" OnClientClick='return confirm("确实要删除吗？");'>[删除]</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
