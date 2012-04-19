<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrganizeSelect.aspx.cs" Inherits="OrganizeSelect" %>

<%@ Register Src="../ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <title>选择部门</title>
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/TICStyle.css">
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=default"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <form id="form1" method="post" runat="server" style=" margin:0; padding:0">
    <table width="100%" height="100%">
        <tr>
            <td nowrap="nowrap" align="center">
                部门：<asp:DropDownList ID="cmbOrganize" Width="200px" TabIndex="2" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="cmbOrganize_SelectedIndexChanged">
                </asp:DropDownList>
                &nbsp;&nbsp;查询内容：<asp:TextBox ID="txtSearch" runat="server" Width="150px" EnableTheming="True"
                    TabIndex="1" CssClass="ColorBlur" onBlur="this.className='ColorBlur';" onfocus="this.className='ColorFocus';"
                    MaxLength="20"></asp:TextBox>
                &nbsp;
                <asp:Button ID="btnSearch" runat="server" Text="查询(Q)" CssClass="button" OnClick="btnSearch_Click"
                    TabIndex="2" AccessKey="Q" onmouseover="this.style.backgroundImage='url(../../../Themes/Default/Images/Buttonm.gif)';"
                    onmouseout="this.style.backgroundImage='url(../../../Themes/Default/Images/Button.gif)';" />
            </td>
        </tr>
        <tr>
            <td width="100%" height="350px" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="ID" Width="95%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
                        BackColor="White" OnRowDataBound="gridView_RowDataBound" AllowSorting="True"
                        OnSorting="gridView_Sorting">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# (this.gridView.PageSize * this.gridView.PageIndex) + this.gridView.Rows.Count + 1%>
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                                <ItemStyle Width="40px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id);" runat="server" ToolTip="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" onClick="CheckSingleItem(this);" runat="server" />
                                </ItemTemplate>
                                <ItemStyle Width="40px" HorizontalAlign="Center"/>
                            </asp:TemplateField>
                             <asp:BoundField DataField="Id" HeaderText="Id">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="编号" >
                                <ItemTemplate>
                                     <asp:Literal ID="lblCode" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.Code").ToString()%>' />
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                                <ItemStyle Width="60px"/>
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" Visible="false">
                            </asp:BoundField> 
                           <asp:TemplateField HeaderText="部门名称" >
                                <ItemTemplate>
                                     <asp:Literal ID="lblFullName" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.FullName").ToString()%>' />
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="所属部门" >
                                <ItemTemplate>
                                     <asp:Literal ID="lblParent" runat="server" Text='<%# GetOrganizeName(DataBinder.Eval(Container, "DataItem.ParentId").ToString())%>' />
                                </ItemTemplate>
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                            </asp:TemplateField>
                        </Columns>
                        <HeaderStyle Font-Bold="False"  Wrap="False" VerticalAlign="Middle"></HeaderStyle>
                        <RowStyle VerticalAlign="Middle" Wrap="True" />
                        <AlternatingRowStyle BackColor="WhiteSmoke" />
                        <PagerSettings Visible="False" />
                    </asp:GridView>
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <ControlsNavigator:Navigator ID="myNavigator" runat="server" PageChange="myNavigator_PageChange">
                </ControlsNavigator:Navigator>
            </td>
        </tr>
        <tr>
            <td style="text-align: center">
                <input type="button" class="button" id="btnCheckAll" runat="server" onclick="return ButtonCheckAll('gridView_ctl01_chkAll');"
                    value="全选" />
                <input type="button" class="button" id="btnConfirm" runat="server" value="确定" />
                <input type="button" class="button" id="btnCancel" value="取消" />
            </td>
        </tr>
    </table>
    </form>
    <script type="text/javascript">
        var isMulti = art.dialog.data('isMultiSelect');
        if (isMulti == undefined)
        { isMulti == false; } // 默认单选

        var table = document.getElementById('gridView');
        // 单选的话禁用全选功能
        if (!isMulti) {
            if (table != undefined) {
                document.getElementById('gridView_ctl01_chkAll').style.display = "none";
            }
            document.getElementById('btnCheckAll').style.display = "none";
        }
        // 获得数据，更新主页数据
        document.getElementById('btnConfirm').onclick = function () {
            // 检查选择：至少选择一条记录，单选时不能选择多条记录。
            if (CheckInput()) {
                var rowIndex = 0;
                //定义返回值变量
                var organizeId = "";
                var organizeFullName = "";

                // i 要从第一行开始
                for (var i = 1; i < table.rows.length; i++) {
                    var input = table.rows[i].cells[1].getElementsByTagName("input")[0].checked;
                    if (input == true) {
                        // 如果是单选
                        if (!isMulti) {
                            organizeId = table.rows[i].cells[2].innerHTML;
                            organizeFullName = table.rows[i].cells[4].innerHTML;
                            break;
                        }
                        else
                        {
                            organizeId += table.rows[i].cells[2].innerHTML + ";";
                            organizeFullName += table.rows[i].cells[4].innerHTML + ";";
                        }
                    }
                }

                // 根据主页控件名称来更新数据
                var hdOrganizeId = art.dialog.data('hdOrganizeId');
                var lblOrganizeFullName = art.dialog.data('lblOrganizeFullName');
                var txtOrganizeFullName = art.dialog.data('txtOrganizeFullName');

                // 更新主页数据,根据控件名称
                var origin = artDialog.open.origin;
                if (hdOrganizeId != undefined) {
                    origin.document.getElementById(hdOrganizeId).value = organizeId;
                }
                if (lblOrganizeFullName != undefined) {
                    origin.document.getElementById(lblOrganizeFullName).innerHTML = organizeFullName;
                }
                if (txtOrganizeFullName != undefined) {
                    origin.document.getElementById(txtOrganizeFullName).value = organizeFullName;
                }
                art.dialog.close();
            }
        };

        // 关闭
        document.getElementById('btnCancel').onclick = function () {
            art.dialog.close();
        };

        function CheckInput() {
            var j = 0;
            for (var i = 1; i < table.rows.length; i++) {
                var input = table.rows[i].cells[1].getElementsByTagName("input")[0].checked;
                if (input == true) {
                    j++;
                    break;
                }
            }
            if (j == 0) {
                alert("至少选择一条记录！");
                return false;
            }
            return true;
        }

        // 单选的时候，不允许选择第二个
        function CheckSingleItem(tempControl) {
            if (!isMulti) {
                var theBox = tempControl;
                var xState = theBox.checked;
                elem = theBox.form.elements;
                for (i = 0; i < elem.length; i++) {
                    if (elem[i].type == "checkbox" && elem[i].id != theBox.id && elem[i].id != "gridView_ctl01_chkAll") {
                        elem[i].checked = false;
                    }
                }
            }
        }
    </script>
</body>
</html>
