<%@ Page Language="C#" AutoEventWireup="true" Inherits="admin_article_article_list" Codebehind="article_list.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>�ޱ���ҳ</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:AccessDataSource ID="AccessDataSource1" runat="server" DataFile="~/data/main_data.mdb"
            SelectCommand="SELECT [arti_id], [arti_title], [arti_source], [arti_author],  [arti_time], [arti_time2] FROM [article] WHERE ([cate_id] = ?) ORDER BY [arti_id] DESC" DeleteCommand="delete from article where arti_id = ? ">
            <SelectParameters>
                <asp:QueryStringParameter Name="cate_id" QueryStringField="cate_id" />
            </SelectParameters>
            <DeleteParameters>
                <asp:ControlParameter ControlID="GridView1" Name="arti_id" PropertyName="SelectedValue" />
            </DeleteParameters>
        </asp:AccessDataSource>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="����������" SkinID="InsertButton" /></div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="arti_id" DataSourceID="AccessDataSource1" SkinID="BlueGridView" AllowPaging="True" PageSize="15" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="arti_id" HeaderText="ID" SortExpression="arti_id" />
                <asp:HyperLinkField DataNavigateUrlFields="arti_id" DataNavigateUrlFormatString="../../d.aspx?aid={0}"
                    DataTextField="arti_title" DataTextFormatString="{0}" HeaderText="����" Target="_blank" SortExpression="arti_title">
                    <ControlStyle ForeColor="Blue" />
                </asp:HyperLinkField>
                <asp:BoundField DataField="arti_source" HeaderText="������Դ" SortExpression="arti_source" />
                <asp:BoundField DataField="arti_author" HeaderText="����" SortExpression="arti_author" />
                <asp:BoundField DataField="arti_time" HeaderText="����ʱ��" SortExpression="arti_time" />
                <asp:BoundField DataField="arti_time2" HeaderText="����޸�ʱ��" SortExpression="arti_time2" />
                <asp:HyperLinkField DataNavigateUrlFields="arti_id" DataNavigateUrlFormatString="article_modify.aspx?arti_id={0}"
                    DataTextField="arti_id" DataTextFormatString="[�޸�]" HeaderText="�޸�" Text="[�޸�]" />
                <asp:TemplateField HeaderText="ɾ��">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("arti_id") %>'
                            CommandName="Delete" OnClientClick='return confirm("ȷʵҪɾ����");'>[ɾ��]</asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
