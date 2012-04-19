<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ItemDetailsManager.aspx.cs" Inherits="ItemDetailsManager" %>
<html>
<head>
    <title>编码管理</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
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
                        <%-- <b>编码管理(<asp:Label ID="lblTitle" runat="server"></asp:Label>)</b> --%>
                        <b><asp:Label ID="lblTitle" runat="server"></asp:Label>设置</b>
                    </div>
                </td>
            </tr>
            <tr>
                <td width="100%" height="100%" valign="top">                    
                    <div style="overflow: auto; width: 100%; height: 100%">
                        <asp:GridView ID="grdItemDetails" runat="server" Width="100%" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"
                            OnRowDeleting="grdItemDetails_DeleteCommand" OnRowCreated="grdItemDetails_RowCreated" 
                            OnRowCancelingEdit="grdItemDetails_CancelCommand"
                            OnRowDataBound="grdItemDetails_ItemDataBound" OnRowUpdating="grdItemDetails_UpdateCommand"
                            OnRowEditing="grdItemDetails_EditCommand" OnRowCommand="grdItemDetails_ItemCommand">
                            <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"                            
                                BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>   
                            <AlternatingRowStyle BackColor="WhiteSmoke" />                             
                            <SelectedRowStyle ForeColor="Blue" />
                            <Columns>
                                <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# (this.grdItemDetails.PageSize * this.grdItemDetails.PageIndex) + this.grdItemDetails.Rows.Count + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="50px" Wrap="False" />
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                            </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="CheckAll" runat="server" onClick="CheckAll(this.id);" ToolTip="全选" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkSelected" onClick="CheckItem('grdItemDetails_ctl01_CheckAll');"
                                            runat="server" />
                                    </ItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" Width="30px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="编号">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.ItemCode")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemCode") %>'
                                            MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                            onfocus="this.className='ColorFocus';"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle CssClass="leftBlank"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="名称">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.ItemName")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemName") %>'
                                            MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                            onfocus="this.className='ColorFocus';"></asp:TextBox>
                                    </EditItemTemplate>
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle CssClass="leftBlank"/>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="值">
                                    <ItemTemplate>
                                        <%# DataBinder.Eval(Container, "DataItem.ItemValue")%>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtItemValue" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.ItemValue") %>'
                                            MaxLength="30" Width="100%" CssClass="ColorBlur" onBlur="this.className='ColorBlur';"
                                            onfocus="this.className='ColorFocus';"></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemStyle CssClass="leftBlank"/>
                                    <HeaderStyle Font-Bold="False" />
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
                                    <HeaderStyle Font-Bold="False" />
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
                                    <itemtemplate>
                                        <asp:LinkButton ID="lkbSetTop" runat="server" ToolTip="置顶"  CommandName="SetTop" CausesValidation="true" Text="▲">
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lkbSetUp" runat="server" ToolTip="上移"  CommandName="SetUp" CausesValidation="true"  Text="△">
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="lkbSetDown" runat="server"  ToolTip="下移"  CommandName="SetDown" CausesValidation="true"  Text="▽">
                                        </asp:LinkButton>                                        
                                        <asp:LinkButton ID="lkbSetBottom" runat="server"  ToolTip="置底" CommandName="SetBottom" CausesValidation="true" Text="▼">
                                        </asp:LinkButton>
                                    </itemtemplate>               
                                    <HeaderStyle Font-Bold="False" />                       
                                    <ItemStyle HorizontalAlign="Center" Width="80px"  Wrap="False"/>
                                </asp:TemplateField>
                                <asp:CommandField  ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;编辑&quot; /&gt;"
                                    HeaderText="编辑" UpdateText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Save.gif&quot; alt=&quot;更新&quot; /&gt;"
                                    ShowCancelButton="true" CancelText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Cancel.gif&quot; alt=&quot;取消&quot; /&gt;">
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle Wrap="True" HorizontalAlign="Center" Width="60px" />
                                </asp:CommandField>
                                <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; alt=&quot;删除&quot;/&gt;">
                                    <HeaderStyle Font-Bold="False" />
                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="40px" />
                                </asp:CommandField>
                            </Columns>
                        </asp:GridView>
                        <asp:HiddenField ID="txtCode" Value="" runat="server" />
                        <asp:HiddenField ID="txtTableName" Value="BaseItemDetails" runat="server" />
                        <asp:HiddenField ID="txtUseItemCode" Value="0" runat="server" />
                        <asp:HiddenField ID="txtUseItemName" Value="0" runat="server" />
                        <asp:HiddenField ID="txtUseItemValue" Value="1" runat="server" />
                        <asp:HiddenField ID="txtReturnURL" runat="server" />
                    </div>
                </td>
            </tr>
            <tr>
                <td align="center" valign="middle" style="height: 20px">
                    <asp:Button ID="btnCheckAll" runat="server" CssClass="Button" Text="全选(A)" AccessKey="A"
                        TabIndex="1" OnClientClick="return ButtonCheckAll('grdItemDetails_ctl01_CheckAll');"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnDelete" runat="server" CssClass="Button" Text="删除(D)" AccessKey="D"
                        TabIndex="2" OnClientClick="return CheckSelectAnyOne('你确定删除所选数据行吗？');" OnClick="btnDelete_Click"
                        onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnPrint" runat="server" CssClass="ButtonLarge" Text="屏幕打印(P)" Visible="false" AccessKey="P" 
                        TabIndex="3" OnClientClick="return pagePrint()" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLargem.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/ButtonLarge.gif)';" />
                    <asp:Button ID="btnExportCSV" runat="server" CssClass="Button" Text="导出(E)"
                        AccessKey="E" TabIndex="4" OnClick="btnExportCSV_Click" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
                    <asp:Button ID="btnReturn" runat="server" CssClass="Button" Text="返回(R)"
                        AccessKey="R" TabIndex="5" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                        onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" 
                        onclick="btnReturn_Click" />
                </td>
            </tr>
        </table>
    </form>
    </div>    
<!--endprint-->
</body>
</html>
