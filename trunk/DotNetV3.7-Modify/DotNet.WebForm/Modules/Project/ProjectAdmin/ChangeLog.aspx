<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChangeLog.aspx.cs" Inherits="ChangeLog" %>
<html>
<head id="Head1" runat="server">
    <title>工作流程审批系统 - 修改记录</title>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <base target="_self" />

    <script language='javascript' src='../../../JavaScript/Default.js'></script>

    <script language="javascript" type="text/javascript" src="../../../JavaScript/My97DatePicker/WdatePicker.js"
        defer="defer"></script>

    <link type="text/css" rel="Stylesheet" href="../../../JavaScript/My97DatePicker/skin/WdatePicker.css" />
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
    <link href="../../../Themes/Blue/CoolBlueMenu.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue.css" type="text/css" rel="stylesheet" />
    <link href="../../../Themes/Blue/Blue_tmp.css" type="text/css" rel="stylesheet" />
</head>
<body leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%" cellspacing="2">
        <tr>
            <td colspan="2">
                <div class="breadcrumbHeader">
                    <b>工作流程审批系统 - 修改记录</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top" colspan="2">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="Id" Width="100%" CellPadding="1" BorderColor="#CCCCCC"
                        BorderWidth="1px" BackColor="White" OnRowDataBound="gridView_RowDataBound"
                        >
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# (this.gridView.PageSize * this.gridView.PageIndex) + this.gridView.Rows.Count + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="修改记录" SortExpression="Title">
                                <ItemTemplate>
                                    <a href="#none" onclick="return showName('<%# DataBinder.Eval(Container.DataItem, "id")%>')">
                                        <%# DataBinder.Eval(Container.DataItem, "Title")%></a>
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Left" Wrap="False"  CssClass="leftBlank rightBlank"/>
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="修改时间" DataField="CreateDate" SortExpression="CreateDate"
                                DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="修改人" DataField="CreateUserRealName" SortExpression="CreateUserRealName">
                                <HeaderStyle Font-Bold="False" Wrap="False" />
                                <ItemStyle  Wrap="False"  CssClass = "leftBlank rightBlank"/>
                            </asp:BoundField>
                        </Columns>
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px; margin: auto auto auto auto"
                colspan="2">
                
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtId" runat="server" />
    </form>
</body>
</html>
