<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserWorkFlowSetAuthorize.aspx.cs"
    Inherits="UserWorkFlowSetAuthorize" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>流程委托授权</title>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/TICStyle.css">
    <script language="javascript" type="text/javascript" src="../../../JavaScript/My97DatePicker/WdatePicker.js"
        defer="defer"></script>
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=blue"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
    <script>
        (function (config) {
            config['fixed'] = true;
            config['resize'] = false;
            config['width'] = '600px';
            config['height'] = '400px';
            config['title'] = "选择用户";
        })(art.dialog.defaults);

        // 选择用户
        function SelectUser() {
            // 传递空间名称
            art.dialog.data('ucUserCode', 'lblToCode');
            art.dialog.data('ucHiddenCode', 'hdToCode');
            art.dialog.data('ucRealName', 'lblToRealName');
            art.dialog.data('ucDepartmentName', 'lblToDepartmentName');
            art.dialog.data('isMultiSelect', false);
            art.dialog.open('../../../Modules/Common/User/UserSelect.aspx');
        }
    </script>
</head>
<body>
    <!--startprint-->
    <form id="form2" method="post" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>流程委托授权</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" valign="top">
                <div class="tic_left">
                    <table class="table" width="100%" cellpadding="0" cellspacing="0">
                        <caption class="table_caption">
                            用户信息</caption>
                        <tr>
                            <td style="width: 150px" class="td-title">
                                工号：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblCode" runat="server" Text="工号"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                姓名：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblRealName" runat="server" Text="姓名"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                部门：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblDepartmentName" runat="server" Text="部门"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="tic_center">
                    &nbsp;</div>
                <div class="tic_right">
                    <table width="100%" class="table" cellpadding="0" cellspacing="0">
                        <caption class="table_caption">
                            委托人
                            <img src="../../../themes/default/images/useradd.png" title="点这里选择委托人" /><a href="javascript:SelectUser()">点这里选择委托人</a></caption>
                        <tr>
                            <td style="width: 150px" class="td-title">
                                工号：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblToCode" runat="server" Text=""></asp:Label>
                                <asp:HiddenField ID="hdToCode" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                姓名：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblToRealName" runat="server" Text="&nbsp;"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="td-title">
                                部门：
                            </td>
                            <td class="td-content">
                                <asp:Label ID="lblToDepartmentName" runat="server" Text="&nbsp;"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="tic_left" style="text-align: right">
                    开始日期：<asp:TextBox ID="txtStartDate" runat="server" MaxLength="4" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:true,readOnly:true,maxDate:'#F{$dp.$D(\'txtEndDate\');}'})"
                        Width="150px" /></div>
                <div class="tic_center">
                    &nbsp;</div>
                <div class="tic_right">
                    结束日期：<asp:TextBox ID="txtEndDate" runat="server" MaxLength="4" class="Wdate" onFocus="WdatePicker({dateFmt:'yyyy-MM-dd',isShowClear:true,readOnly:true,minDate:'#F{$dp.$D(\'txtStartDate\');}'})"
                        Width="150px" /></div>
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:Button ID="btnAdd" runat="server" Text="设置委托" OnClick="btnAdd_Click" CssClass="buttonlarge" />
            </td>
        </tr>
        <tr>
            <td>
                <div class="breadcrumbHeader mt10">
                    <b>委托人列表</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="grdWorkFlowAuthorize" runat="server" Width="100%" AutoGenerateColumns="False"
                        BackColor="White" BorderColor="#CCCCCC" BorderWidth="1px" CellPadding="3" DataKeyNames="ID"
                        OnRowDeleting="grdWorkFlowAuthorize_RowDeleting" OnRowDataBound="grdWorkFlowAuthorize_RowDataBound">
                        <HeaderStyle Font-Bold="False" Wrap="False" HorizontalAlign="Center" VerticalAlign="Middle"
                            BackColor="#EFEFEF" Font-Size="12px" Height="25px"></HeaderStyle>
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <SelectedRowStyle ForeColor="Blue" />
                        <Columns>
                            <asp:TemplateField HeaderText="No" InsertVisible="False">
                                <HeaderStyle Font-Bold="False" Height="22px" Wrap="false" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" Height="22px" />
                                <ItemTemplate>
                                    <asp:Label ID="lblNo" runat="server" Text='<%# this.grdWorkFlowAuthorize.PageIndex * this.grdWorkFlowAuthorize.PageSize + this.grdWorkFlowAuthorize.Rows.Count + 1%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="TargetId" HeaderText="姓名" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TargetId" HeaderText="工号" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StartDate" HeaderText="开始日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EndDate" HeaderText="结束日期" HtmlEncode="False" DataFormatString="{0:yyyy-MM-dd}">
                                <HeaderStyle Width="80px" HorizontalAlign="Center" Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TargetId" HeaderText="委托部门" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TargetId" HeaderText="委托姓名" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TargetId" HeaderText="委托工号" HtmlEncode="False">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" />
                            </asp:BoundField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True" DeleteText="&lt;img src=&quot;../../../Themes/Default/Images/Delete.gif &quot; border=&quot;0&quot; ToolTip=&quot;删除&quot;/&gt;">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" Width="40px" />
                            </asp:CommandField>
                        </Columns>
                    </asp:GridView>
                </div>
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="txtUserId" runat="server" Value="" />
    <asp:HiddenField ID="txtAuthorizeUserId" runat="server" Value="" />
    </form>
    <!--endprint-->
</body>
</html>
