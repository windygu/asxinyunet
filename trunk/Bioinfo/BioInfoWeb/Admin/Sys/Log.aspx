﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Log.aspx.cs" Inherits="Pages_Log"
    Title="日志查看" MasterPageFile="~/Admin/ManagerPage.master" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="C" runat="server">
    <div class="toolbar">
        类别：<asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True"
            DataSourceID="ObjectDataSource3" DataTextField="Category" DataValueField="Category">
            <asp:ListItem>全部</asp:ListItem>
        </asp:DropDownList>
        &nbsp;管理员：<asp:DropDownList ID="DropDownList2" runat="server" AppendDataBoundItems="True"
            DataSourceID="ObjectDataSource2" DataTextField="FriendName" DataValueField="ID">
            <asp:ListItem Value="0">全部</asp:ListItem>
        </asp:DropDownList>
        &nbsp;关键字：<asp:TextBox ID="key" runat="server" CssClass="textfield" Width="70px"></asp:TextBox>
        &nbsp;时间：<XCL:DateTimePicker ID="StartDate" runat="server" LongTime="False">
        </XCL:DateTimePicker>
        &nbsp;至
        <XCL:DateTimePicker ID="EndDate" runat="server" LongTime="False">
        </XCL:DateTimePicker>
        &nbsp;<asp:Button ID="Button1" runat="server" Text="查询" />
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
        DataSourceID="ObjectDataSource1" AllowPaging="True" AllowSorting="True" CssClass="m_table"
        CellPadding="0" CellSpacing="1" GridLines="None" PageSize="20" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="ID" HeaderText="序号" InsertVisible="False" ReadOnly="True"
                SortExpression="ID">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="60px" CssClass="key" />
            </asp:BoundField>
            <asp:BoundField DataField="Category" HeaderText="类别" SortExpression="Category" />
            <asp:BoundField DataField="Action" HeaderText="操作" SortExpression="Action" />
            <asp:BoundField DataField="UserName" HeaderText="管理员" SortExpression="UserName">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="IP" HeaderText="IP地址" SortExpression="IP">
                <ItemStyle VerticalAlign="Middle" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="OccurTime" HeaderText="时间" SortExpression="OccurTime"
                DataFormatString="{0:yyyy-MM-dd HH:mm:ss}">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Remark" HeaderText="详细信息" SortExpression="Remark">
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:BoundField>
        </Columns>
        <EmptyDataTemplate>
            没有符合条件的数据！
        </EmptyDataTemplate>
    </asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" OldValuesParameterFormatString="original_{0}"
        SelectCountMethod="SearchCount" SelectMethod="Search" SortParameterName="orderClause"
        TypeName="">
        <SelectParameters>
            <asp:ControlParameter ControlID="key" Name="key" PropertyName="Text" Type="String" />
            <asp:ControlParameter ControlID="DropDownList2" Name="adminid" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="DropDownList1" Name="category" PropertyName="SelectedValue"
                Type="String" />
            <asp:ControlParameter ControlID="StartDate" Name="start" PropertyName="Text" Type="DateTime" />
            <asp:ControlParameter ControlID="EndDate" Name="end" PropertyName="Text" Type="DateTime" />
            <asp:Parameter Name="orderClause" Type="String" />
            <asp:Parameter Name="startRowIndex" Type="Int32" DefaultValue="0" />
            <asp:Parameter Name="maximumRows" Type="Int32" DefaultValue="200000" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource2" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="FindAll" TypeName="" DataObjectTypeName=""></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ObjectDataSource3" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="FindAllCategory" TypeName=""></asp:ObjectDataSource>
    <XCL:GridViewExtender ID="gvExt" runat="server">
    </XCL:GridViewExtender>
</asp:Content>
