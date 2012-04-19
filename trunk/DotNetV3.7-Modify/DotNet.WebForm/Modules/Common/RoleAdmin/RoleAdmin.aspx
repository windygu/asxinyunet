<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleAdmin.aspx.cs" Inherits="RoleAdmin" %>

<html>
<head>
    <title>角色管理</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />

    <script language='javascript' src='../../../JavaScript/Default.js'></script>

    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <style>
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>角色管理</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="grdRole" runat="server" Width="100%" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"
                        OnRowDeleting="grdRole_DeleteCommand" OnRowCreated="grdRole_RowCreated" OnRowCancelingEdit="grdRole_CancelCommand"
                        OnRowDataBound="grdRole_ItemDataBound" OnRowUpdating="grdRole_UpdateCommand"
                        OnRowEditing="grdRole_EditCommand" OnRowCommand="grdRole_ItemCommand">
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <SelectedRowStyle ForeColor="Blue" />
                        <Columns>
                            <asp:TemplateField HeaderText="No" InsertVisible="False">
                                <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text='<%# this.grdRole.PageIndex * this.grdRole.PageSize + this.grdRole.Rows.Count + 1%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="CheckAll" runat="server" onClick="CheckAll(this.id);" ToolTip="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" onClick="CheckItem('grdRole_ctl01_CheckAll');" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="名称">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.Realname")%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtRealname" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Realname") %>'
                                        MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                        onfocus="this.className='ColorFocus';"></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank rightBlank" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="备注">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.Description") %>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Description") %>'
                                        MaxLength="100" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                        onfocus="this.className='ColorFocus';"></asp:TextBox>
                                </EditItemTemplate>
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                            </asp:TemplateField>
                            
                            <asp:HyperLinkField HeaderText="角色成员" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="RoleUserAdmin.aspx?Id={0}"
                                Text="角色成员">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                            </asp:HyperLinkField>                            
                            
                            <asp:HyperLinkField HeaderText="模块菜单权限" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="RoleModuleAdmin.aspx?Id={0}"
                                Text="模块菜单权限">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                            </asp:HyperLinkField>
                            
                            <asp:HyperLinkField HeaderText="操作权限" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="RolePermissionAdmin.aspx?Id={0}"
                                Text="操作权限">
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                <HeaderStyle Font-Bold="False" Wrap="false" />
                            </asp:HyperLinkField>                            
                            
                            <asp:TemplateField HeaderText="有效">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.Enabled").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkEnabled" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.Enabled").ToString().Equals("1") %>' />
                                </EditItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="顺序">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lkbSetTop" runat="server" ToolTip="置顶" CommandName="SetTop" CausesValidation="true"
                                        Text="▲">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbSetUp" runat="server" ToolTip="上移" CommandName="SetUp" CausesValidation="true"
                                        Text="△">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbSetDown" runat="server" ToolTip="下移" CommandName="SetDown"
                                        CausesValidation="true" Text="▽">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lkbSetBottom" runat="server" ToolTip="置底" CommandName="SetBottom"
                                        CausesValidation="true" Text="▼">
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="80px" Wrap="False" />
                            </asp:TemplateField>
                            <asp:CommandField ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;"
                                HeaderText="编辑" UpdateText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Save.gif&quot; alt=&quot;更新&quot; /&gt;"
                                ShowCancelButton="true" CancelText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Cancel.gif&quot; alt=&quot;取消&quot; /&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="True" HorizontalAlign="Center" Width="60px" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="40px" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px">
                <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选"
                    TabIndex="1" OnClientClick="return ButtonCheckAll('grdRole_ctl01_CheckAll');"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />

                <asp:Button ID="btnAdd" runat="server" CssClass="Button" Text="添加(A)" AccessKey="A"
                    TabIndex="2" OnClick="btnAdd_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />

                
                <asp:Button ID="btnDelete" runat="server" CssClass="Button" Text="删除(D)" AccessKey="D"
                    TabIndex="3" OnClientClick="return CheckSelectAnyOne('你确定删除所选数据行吗？');" OnClick="btnDelete_Click"
                    onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
    </table>
    </form>
    <!--endprint-->
</body>
</html>
