<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserSelect.aspx.cs" Inherits="UserSelect" %>

<%@ Register Src="../ControlsNavigator/ControlsNavigator.ascx" TagName="Navigator"
    TagPrefix="ControlsNavigator" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta name="Coding" content="杭州海日涵科技有限公司" />
    <meta name="Author" content="JiRiGaLa_Bao@Hotmail.com">
    <title>选择用户</title>
    <script language='javascript' src='../../../JavaScript/Default.js'></script>
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/Global.css">
    <link rel="stylesheet" type="text/css" href="../../../Themes/Default/TICStyle.css">
    <script language="javascript" src="../../../javascript/artdialog/artDialog.js?skin=default"></script>
    <script language="javascript" src="../../../javascript/artdialog/plugins/iframeTools.js"></script>
</head>
<body>
    <form id="form1" method="post" runat="server" style=" margin:0; padding:0">
    <table width="100%" height="100%">
        <tr>
            <td nowrap="nowrap" align="center">
                部门：<asp:DropDownList ID="cmbDepartment" Width="200px" TabIndex="2" runat="server"
                    AutoPostBack="True" OnSelectedIndexChanged="cmbDepartment_SelectedIndexChanged">
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
                <div style="overflow: auto; width:100%; height:100%;">
                    <asp:GridView ID="gridView" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        DataKeyNames="ID" Width="95%" CellPadding="1" BorderColor="#CCCCCC" BorderWidth="1px"
                        BackColor="White" OnRowDataBound="gridView_RowDataBound" AllowSorting="True"
                        OnSorting="gridView_Sorting" CssClass="center">
                        <Columns>
                            <asp:TemplateField HeaderText="No">
                                <ItemTemplate>
                                    <%# (this.gridView.PageSize * this.gridView.PageIndex) + this.gridView.Rows.Count + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="40px" Wrap="False" />
                                <HeaderStyle Wrap="False" Font-Bold="False" />
                                <FooterStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <asp:CheckBox ID="chkAll" onClick="CheckAll(this.id);" runat="server" ToolTip="全选" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelected" onClick="CheckSingleItem(this);" runat="server" />
                                </ItemTemplate>
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Id" HeaderText="Id">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Code" HeaderText="工号" HtmlEncode="False" SortExpression="Code">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle CssClass="leftBlank" Wrap="False" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Realname" HeaderText="姓名" HtmlEncode="False" SortExpression="Realname">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" HorizontalAlign="left" CssClass="leftBlank" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DepartmentId" HeaderText="DepartmentId">
                                <FooterStyle CssClass="hidden" />
                                <HeaderStyle CssClass="hidden" />
                                <ItemStyle CssClass="hidden" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DepartmentName" HeaderText="所属部门" HtmlEncode="False" SortExpression="DepartmentName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" HorizontalAlign="left" CssClass="leftBlank" />
                            </asp:BoundField>
                            <%-- <asp:BoundField HeaderText="默认角色" DataField="RoleName" SortExpression="RoleName">
                                <HeaderStyle Font-Bold="False" />
                                <ItemStyle Wrap="False" CssClass="leftBlank" />
                            </asp:BoundField>--%>
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
        var isMultiSelect = art.dialog.data('isMultiSelect');
        if (isMultiSelect == undefined) {
            isMultiSelect = false;
        } // 默认单选

        var table = document.getElementById('gridView');
        // 单选的话禁用全选功能
        if (!isMultiSelect) {
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
                var userId = "";
                var userCode = "";
                var userRealName = "";
                var userOrganizeId = "";
                var userOrganizeName = "";

                // i 要从第一行开始
                for (var i = 1; i < table.rows.length; i++) {
                    var input = table.rows[i].cells[1].getElementsByTagName("input")[0].checked;
                    if (input == true) {
                        // 如果是单选
                        if (!isMultiSelect) {
                            userId = table.rows[i].cells[2].innerHTML;
                            userCode = table.rows[i].cells[3].innerHTML;
                            userRealName = table.rows[i].cells[4].innerHTML;
                            userOrganizeId = table.rows[i].cells[5].innerHTML;
                            userOrganizeName = table.rows[i].cells[6].innerHTML;
                            break;

                        }
                        else {
                            userId += table.rows[i].cells[2].innerHTML + ",";
                            userCode += table.rows[i].cells[3].innerHTML + ",";
                            userRealName += table.rows[i].cells[4].innerHTML + ",";
                            userOrganizeId += table.rows[i].cells[5].innerHTML + ",";
                            userOrganizeName += table.rows[i].cells[6].innerHTML + ",";
                        }
                    }
                }

                if (isMultiSelect) {
                    // 这里还需要判断是否选的比1个人多，而且有，
                    if (userId.length > 0) {
                        userId = userId.substring(0, userId.length - 1);
                    }
                    if (userCode.length > 0) {
                        userCode = userCode.substring(0, userCode.length - 1);
                    }
                    if (userRealName.length > 0) {
                        userRealName = userRealName.substring(0, userRealName.length - 1);
                    }
                    if (userOrganizeId.length > 0) {
                        userOrganizeId = userOrganizeId.substring(0, userDepName.length - 1);
                    }
                    if (userOrganize.length > 0) {
                        userOrganizeName = userOrganizeName.substring(0, userDepName.length - 1);
                    }
                }

                // 根据主页控件名称来更新数据
                var hdUserId = art.dialog.data('hdUserId');
                var hdUserCode = art.dialog.data('hdUserCode')
                var ucUserCode = art.dialog.data('ucUserCode')
                var hdRealName = art.dialog.data('hdRealName');
                var ucRealName = art.dialog.data('ucRealName');
                var hdOrganizeId = art.dialog.data('hdOrganizeId');
                var ucOrganizeName = art.dialog.data('ucOrganizeName');

                // 更新主页数据,根据控件名称
                var origin = artDialog.open.origin;
                if (hdUserId != undefined) {
                    origin.document.getElementById(hdUserId).value = userId;
                    origin.document.getElementById(hdUserId).fireEvent("onchange");
                }

                if (hdUserCode != undefined) {
                    origin.document.getElementById(hdUserCode).value = userCode;
                    origin.document.getElementById(hdUserCode).fireEvent("onchange");
                }
                if (ucUserCode != undefined) {
                    origin.document.getElementById(ucUserCode).innerHTML = userCode;
                }
                
                if (hdRealName != undefined) {
                    origin.document.getElementById(hdRealName).value = userRealName;
                    origin.document.getElementById(hdRealName).fireEvent("onchange");
                }
                if (ucRealName != undefined) {
                    origin.document.getElementById(ucRealName).innerHTML = userRealName;
                }

                if (hdOrganizeId != undefined) {
                    origin.document.getElementById(hdOrganizeId).value = userOrganizeId;
                    origin.document.getElementById(hdOrganizeId).fireEvent("onchange");
                }
                if (ucOrganizeName != undefined) {
                    origin.document.getElementById(ucOrganizeName).innerHTML = userOrganizeName;
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
            if (!isMultiSelect) {
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
