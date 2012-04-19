<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RoleModuleAdmin.aspx.cs"
    Inherits="RoleModuleAdmin" %>

<html>
<head>
    <title>角色模块访问权限配置</title>
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
        <script type="text/javascript">
            function public_GetParentByTagName(element, tagName) {
                var parent = element.parentNode;
                var upperTagName = tagName.toUpperCase();
                //如果这个元素还不是想要的tag就继续上溯 
                while (parent && (parent.tagName.toUpperCase() != upperTagName)) {
                    parent = parent.parentNode ? parent.parentNode : parent.parentElement;
                }
                return parent;
            }

            //设置节点的父节点Cheched——该节点不可访问，则他的父节点也不能访问 
            function setParentUnChecked(objNode) {
                var objParentDiv = public_GetParentByTagName(objNode, "div");
                if (objParentDiv == null || objParentDiv == "undefined") {
                    return;
                }
                var objID = objParentDiv.getAttribute("ID");
                objID = objID.substring(0, objID.indexOf("Nodes"));
                objID = objID + "CheckBox";
                var objParentCheckBox = document.getElementById(objID);
                if (objParentCheckBox == null || objParentCheckBox == "undefined") {
                    return;
                }
                if (objParentCheckBox.tagName != "INPUT" && objParentCheckBox.type == "checkbox")
                    return;
                objParentCheckBox.checked = false;
                setParentChecked(objParentCheckBox);
            }

            //设置节点的父节点Cheched——该节点可访问，则他的父节点也必能访问 
            function setParentChecked(objNode) {
                var objParentDiv = public_GetParentByTagName(objNode, "div");
                if (objParentDiv == null || objParentDiv == "undefined") {
                    return;
                }
                var objID = objParentDiv.getAttribute("ID");
                objID = objID.substring(0, objID.indexOf("Nodes"));
                objID = objID + "CheckBox";
                var objParentCheckBox = document.getElementById(objID);
                if (objParentCheckBox == null || objParentCheckBox == "undefined") {
                    return;
                }
                if (objParentCheckBox.tagName != "INPUT" && objParentCheckBox.type == "checkbox")
                    return;
                objParentCheckBox.checked = true;
                setParentChecked(objParentCheckBox);
            }

            //设置节点的子节点uncheched——该节点不可访问，则他的子节点也不能访问 
            function setChildUnChecked(divID) {
                var objchild = divID.children;
                var count = objchild.length;
                for (var i = 0; i < objchild.length; i++) {
                    var tempObj = objchild[i];
                    if (tempObj.tagName == "INPUT" && tempObj.type == "checkbox") {
                        tempObj.checked = false;
                    }
                    setChildUnChecked(tempObj);
                }
            }

            //设置节点的子节点cheched——该节点可以访问，则他的子节点也都能访问 
            function setChildChecked(divID) {
                var objchild = divID.children;
                var count = objchild.length;
                for (var i = 0; i < objchild.length; i++) {
                    var tempObj = objchild[i];
                    if (tempObj.tagName == "INPUT" && tempObj.type == "checkbox") {
                        tempObj.checked = true;
                    }
                    setChildChecked(tempObj);
                }
            }

            //触发事件 
            function CheckEvent() {
                var objNode = event.srcElement;

                if (objNode.tagName != "INPUT" || objNode.type != "checkbox")
                    return;

                if (objNode.checked == true) {
                    //setParentChecked(objNode); 
                    var objID = objNode.getAttribute("ID");
                    var objID = objID.substring(0, objID.indexOf("CheckBox"));
                    var objParentDiv = document.getElementById(objID + "Nodes");
                    if (objParentDiv == null || objParentDiv == "undefined") {
                        return;
                    }
                    setChildChecked(objParentDiv);
                }
                else {
                    setParentUnChecked(objNode);
                    var objID = objNode.getAttribute("ID");
                    var objID = objID.substring(0, objID.indexOf("CheckBox"));
                    var objParentDiv = document.getElementById(objID + "Nodes");
                    if (objParentDiv == null || objParentDiv == "undefined") {
                        return;
                    }
                    setChildUnChecked(objParentDiv);
                }
            } 
    </script>
</head>
<body topmargin="0" bottommargin="0" leftmargin="0" rightmargin="0">
    <!--startprint-->
    <form id="form1" method="post" runat="server">
    <table width="100%" height="100%">
        <tr>
            <td>
                <div class="breadcrumbHeader">
                    <b>角色模块访问权限配置</b>
                </div>
            </td>
        </tr>
        <tr>
            <td width="100%" height="100%" valign="top">
                <div style="overflow: auto; width: 100%; height: 100%">
                    <asp:TreeView BorderWidth="0" ID="tvModule" runat="server" 
                        ShowCheckBoxes="All" ShowLines="True">
                    </asp:TreeView>
                </div>
            </td>
        </tr>
        <tr>
            <td align="center" valign="middle" style="height: 20px">
                <asp:Button ID="btnSave" runat="server" Text="保存&amp;返回" OnClick="btnSave_Click" />
                <asp:Button ID="btnReturn" runat="server" Text="返回" OnClick="btnReturn_Click" CssClass="Button" />
            </td>
        </tr>
    </table>    
    <asp:HiddenField ID="txtId" runat="server"/>
    <asp:HiddenField ID="txtReturnURL" runat="server" Value="RoleAdmin.aspx" />
    </form>
    <!--endprint-->
</body>
</html>
