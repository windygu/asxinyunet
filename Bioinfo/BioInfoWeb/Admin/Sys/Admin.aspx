﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Pages_Admin"
    Title="管理员管理" MasterPageFile="~/Admin/ManagerPage.master" %>

<asp:Content ID="C" ContentPlaceHolderID="C" runat="server">
    <div class="toolbar">
        <asp:Label Text="关键字" runat="server" />
        &nbsp;<asp:TextBox runat="server" ID="txtKey" />
        角色：<XCL:DropDownList ID="ddlRole" runat="server" DataSourceID="odsRole"
            AppendDataBoundItems="true" DataTextField="Name" DataValueField="ID" 
            AutoPostBack="True">
            <asp:ListItem Value="0">请选择</asp:ListItem>
        </XCL:DropDownList>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="查询" />
        <XCL:LinkBox ID="lbAdd" runat="server" BoxHeight="370px" BoxWidth="440px" Url="AdminForm.aspx"
            IconLeft="~/Admin/images/icons/new.gif"><b>添加管理员</b></XCL:LinkBox>
        &nbsp;<asp:Button ID="btnDelete" runat="server" Text="批量删除" OnClientClick='return confirm("确定批量删除吗？")'
            OnClick="btnDelete_Click" />
        &nbsp;<asp:Button ID="btnEnable" runat="server" Text="批量启用" OnClientClick='return confirm("确定批量启用吗？")'
            OnClick="btnEnable_Click" />
        &nbsp;<asp:Button ID="btnDisable" runat="server" Text="批量禁用" OnClientClick='return confirm("确定批量禁用吗？")'
            OnClick="btnDisable_Click" />
        &nbsp;<asp:Button ID="btnUpgradeToRole" runat="server" Text="批量升级为角色" OnClientClick='return confirm("确定批量升级吗？")'
            OnClick="btnUpgradeToRole_Click" Visible="false" />
        &nbsp;<asp:Button ID="btnChangePass" Visible="false" runat="server" Text="批量修改密码"
            OnClientClick='return confirm("确定批量修改密码吗？")' OnClick="btnChangePass_Click" />
    </div>
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="ods" CssClass="m_table" CellPadding="0" GridLines="None" EnableModelValidation="True"
        EnableViewState="False">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:CheckBox ID="cb" runat="server" />
                </ItemTemplate>
                <HeaderStyle Width="20px" />
                <ItemStyle HorizontalAlign="Center" />
            </asp:TemplateField>
            <asp:BoundField DataField="ID" HeaderText="编号" SortExpression="ID" InsertVisible="False"
                ReadOnly="True">
                <HeaderStyle Width="40px" />
                <ItemStyle CssClass="key" HorizontalAlign="Center" />
            </asp:BoundField>
            <XCL:LinkBoxField HeaderText="用户名" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AdminForm.aspx?ID={0}"
                Height="400px" DataTextField="Name" Width="370px" Title="编辑管理员">
                <ItemStyle HorizontalAlign="Center" />
            </XCL:LinkBoxField>
            <XCL:LinkBoxField HeaderText="友好名称" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AdminForm.aspx?ID={0}"
                Height="400px" DataTextField="FriendName" Text="友好名称" Width="370px" Title="编辑管理员">
                <ItemStyle HorizontalAlign="Center" />
            </XCL:LinkBoxField>
            <asp:BoundField DataField="RoleName" HeaderText="角色" SortExpression="RoleID" />
            <asp:BoundField DataField="Logins" HeaderText="登录次数" SortExpression="Logins" />
            <asp:BoundField DataField="LastLogin" HeaderText="最后登录" SortExpression="LastLogin"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            <asp:BoundField DataField="LastLoginIP" HeaderText="最后登陆IP" SortExpression="LastLoginIP" />
            <asp:TemplateField HeaderText="是否启用" SortExpression="IsEnable">
                <ItemTemplate>
                    <asp:CheckBox ID="checkbox1" runat="server" Enabled="false" Checked='<%# Bind("IsEnable")%>' />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:CheckBox ID="checkbox2" runat="server" Checked='<%# Bind("IsEnable")%>' />
                </EditItemTemplate>
            </asp:TemplateField>
            <XCL:LinkBoxField HeaderText="编辑" DataNavigateUrlFields="ID" DataNavigateUrlFormatString="AdminForm.aspx?ID={0}"
                Height="400px" Text="编辑" Width="370px" Title="编辑管理员">
                <ItemStyle HorizontalAlign="Center" />
            </XCL:LinkBoxField>
            <asp:TemplateField HeaderText="删除" ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                        OnClientClick="return confirm('确定删除？');" Text="删除"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            没有数据!
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ods" runat="server" SelectMethod="Search" DeleteMethod="Delete">
        <SelectParameters>
            <asp:ControlParameter ControlID="txtKey" Name="key" Type="String" PropertyName="Text" />
            <asp:ControlParameter ControlID="ddlRole" Name="roleID" Type="Int32" PropertyName="SelectedValue" />
            <asp:Parameter Name="orderClause" Type="String" DefaultValue="ID Desc" />
            <asp:Parameter DefaultValue="0" Name="startRowIndex" Type="Int32" />
            <asp:Parameter DefaultValue="0" Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsRole" runat="server" SelectMethod="FindAllByName">
        <SelectParameters>
            <asp:Parameter Name="name" Type="String" />
            <asp:Parameter Name="value" Type="Object" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" />
            <asp:Parameter Name="maximumRows" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
