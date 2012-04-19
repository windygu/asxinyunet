<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemsManager.aspx.cs" Inherits="ItemsManager" %>

<html>
<head>
    <title>编码管理</title>
    <meta name="Coding" content="宁波市科技园区吉日软件开发有限公司" />
    <meta name="Author" content="JiRiGaLa@Hotmail.com">
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
        .ButtonLarge
        {
            background-image: url(../../../Themes/Default/Images/ButtonLarge.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <div id="content" style="overflow: auto; width: 100%; height: 100%">
        <form id="form1" method="post" runat="server">
        <table width="100%" height="100%">
            <tr>
                <td>
                    <div class="breadcrumbHeader">
                        <b>编码管理(<asp:Label ID="lblTitle" runat="server"></asp:Label>)</b>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="100%" height="100%" valign="top">
                    <div style="overflow: auto; width: 100%; height: 100%">
                        <asp:GridView ID="grdItems_" runat="server" Width="100%" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="ID,Code"
                            OnRowDeleting="grdItems_DeleteCommand" OnRowCreated="grdItems_RowCreated" OnRowCancelingEdit="grdItems_CancelCommand"
                            OnRowDataBound="grdItems_ItemDataBound" OnRowUpdating="grdItems_UpdateCommand"
                            OnRowEditing="grdItems_EditCommand" OnRowCommand="grdItems_ItemCommand">
                            <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                                BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
                            <AlternatingRowStyle BackColor="WhiteSmoke" />
                            <SelectedRowStyle ForeColor="Blue" />
                            <Columns>
                                <asp:TemplateField HeaderText="序号">
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAll" runat="server" onClick="CheckAll(this.id);" ToolTip="全选" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" onClick="CheckItem('grdItems_ctl01_CheckAll');" runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编号">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.Code")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Code") %>'
                                            MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                            onfocus="this.className='ColorFocus';"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" Wrap="false" />
                                    <ItemStyle Font-Bold="False" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lkbItemDetails" runat="server" CommandName="ItemDetails" CausesValidation="true"
                                            Text='<%# DataBinder.Eval(Container, "DataItem.FullName")%>'>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FullName") %>'
                                            MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                            onfocus="this.className='ColorFocus';"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" Wrap="false" />
                                    <ItemStyle Font-Bold="False" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="值">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.TargetTable")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemValue" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TargetTable") %>'
                                            MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                            onfocus="this.className='ColorFocus';"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" Wrap="false" />
                                    <ItemStyle Font-Bold="False" Wrap="false" />
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
                                    <ItemStyle Font-Bold="False" Wrap="false" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编号">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.UseItemCode").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkUseItemCode" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.UseItemCode").ToString().Equals("1") %>' />
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="名字">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.UseItemName").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkUseItemName" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.UseItemName").ToString().Equals("1") %>' />
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="值">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.UseItemValue").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkUseItemValue" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.UseItemValue").ToString().Equals("1") %>' />
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="树">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.IsTree").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkIsTree" runat="server" Checked='<%# DataBinder.Eval(Container, "DataItem.IsTree").ToString().Equals("1") %>' />
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Wrap="False" Width="40px" />
                                </asp:TemplateField>
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
                                    <HeaderStyle Font-Bold="False" Wrap="false" />
                                    <ItemStyle Font-Bold="False" Wrap="false" />
                                </asp:TemplateField>
                                <asp:CommandField ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;"
                                    HeaderText="编辑" UpdateText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Save.gif&quot; alt=&quot;更新&quot; /&gt;"
                                    ShowCancelButton="true" CancelText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Cancel.gif&quot; alt=&quot;取消&quot; /&gt;">
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" Width="40px" />
                                </asp:CommandField>
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="40px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="txtItemCode" Value="Items" runat="server" />
                        <asp:HiddenField ID="txtTableName" Value="BaseItems" runat="server" />
                        <asp:HiddenField ID="txtCategoryId" Value="Items" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" style="height: 20px">
                    <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" AccessKey="A"
                        TabIndex="1" OnClientClick="return ButtonCheckAll('grdItems_ctl01_CheckAll');"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="Button" Text="删除(D)" AccessKey="D"
                        TabIndex="2" OnClientClick="return CheckSelectAnyOne('你确定删除所选数据行吗？');" OnClick="btnDelete_Click"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnPrint" runat="server" CssClass="ButtonLarge" Text="屏幕打印(P)" AccessKey="P"
                        TabIndex="3" OnClientClick="return pagePrint()" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                    <asp:Button ID="btnExportCSV" runat="server" CssClass="ButtonLarge" Text="导出(E)"
                        AccessKey="E" TabIndex="4" OnClick="btnExportCSV_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                </td>
            </tr>
        </table>
        </form>
    </div>
    <!--endprint-->
</body>
</html>
