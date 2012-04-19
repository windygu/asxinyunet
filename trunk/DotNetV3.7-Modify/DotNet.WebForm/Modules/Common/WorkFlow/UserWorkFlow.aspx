<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserWorkFlow.aspx.cs" Inherits="UserWorkFlow" %>

<html>
<head>
    <title>审批流程设置</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Portal.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Style.css">
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
    <style>
        .Button
        {
            background-image: url(../../../Themes/Default/Images/Button.gif);
        }
    </style>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0" style="overflow: hidden;">
    <!--startprint-->
    <form id="form2" method="post" runat="server">
    <table style="height: 100%; width: 100%; margin-top: 1px;">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>目标用户信息</b><span>
                        <img id="img" src="../../../Themes/Default/Images/close.gif" alt="隐藏" onmouseover="this.style.cursor='hand'"
                            onclick="displayTable()" /></span>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <table id="table" class="table" width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            姓名：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblRealName" runat="server" Text="姓名"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" nowrap="nowrap" class="td-title">
                            部门：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblDepartmentName" runat="server" Text="部门"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td height="25" align="right" nowrap="nowrap" style="width: 150px" class="td-title">
                            工号：
                        </td>
                        <td class="td-content" style="padding-top: 3">
                            <asp:Label ID="lblCode" runat="server" Text="工号"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>审批流程设置</b>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center">
                单据分类：<asp:DropDownList ID="cmbCategory" Width="200px" TabIndex="1" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="cmbCategory_SelectedIndexChanged">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="grdWorkFlow" runat="server" Width="100%" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="Id"
                        OnRowEditing="grdWorkFlow_RowEditing" OnRowDeleting="grdWorkFlow_DeleteCommand"
                        OnRowDataBound="grdWorkFlow_RowDataBound">
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <SelectedRowStyle ForeColor="Blue" />
                        <Columns>
                            <asp:TemplateField HeaderText="No" InsertVisible="False">
                                <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text='<%# this.grdWorkFlow.PageIndex * this.grdWorkFlow.PageSize + this.grdWorkFlow.Rows.Count + 1%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Title" HeaderText="单据" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="发布" SortExpression="Enabled">
                                <ItemTemplate>
                                    <%# DataBinder.Eval(Container, "DataItem.Enabled").ToString().Equals("1") ? Utilities.EnableState : Utilities.DisableState%>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="审核流程" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" CssClass="leftBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ModifiedOn" HeaderText="修改日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:CommandField ShowEditButton="true" EditText="&lt;img border=0 src=&quot;../../../Themes/Default/Images/Edit.gif&quot; alt=&quot;设置流程&quot; /&gt;"
                                HeaderText="设置流程" ShowCancelButton="false">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="60px" />
                            </asp:CommandField>
                            <asp:CommandField HeaderText="清除流程" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;清除流程&quot;/&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="60px" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtUserId" runat="server" Value="" />
    </form>
    <!--endprint-->
</body>
</html>
