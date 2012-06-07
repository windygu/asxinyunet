<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Left.aspx.cs" Inherits="Model_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>模型中心菜单</title>
    <link href="<%= ResolveUrl("~/css/reset.css")%>" rel="stylesheet" type="text/css" />
    <link href="images/left.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="<%= ResolveUrl("~/Scripts/jquery-1.4.1.min.js")%>"></script>
    <script type="text/javascript">

        //var openmenu; //打开菜单
        //var openbox; //打开菜单

        function showcd(o) {
            var h = $(o);

            tdselect(o)

            if (h.children("div").first().attr("class") == "icon-open") {

                h.children("div:eq(1)").attr("class", "dir-close");
                h.children("div:eq(0)").attr("class", "icon-close");
                h.addClass("tdselect");
                h.parent().children("ul").slideUp("fast");
                return;
            }

            h.children("div:eq(1)").attr("class", "dir-open");
            h.children("div:eq(0)").attr("class", "icon-open");
            h.addClass("tdselect");
            h.parent().children("ul").slideDown("fast");
            return;
        }

        function tdselect(o) {
            $(".tdselect").removeClass("tdselect");
            $(o).addClass("tdselect");
        }


        function tdonmouseover(o) {
            $(o).addClass("tdonmouseover");
        }

        function tdonmouseout(o) {
            $(o).removeClass("tdonmouseover");
        }


        $(document).ready(
            function () {
                modefHeight();
            }
        )

        function modefHeight() {
            $("#menu").height($(window).height() - $(".toolbar").height() - 5);
        }
    </script>
</head>
<body onresize="modefHeight();">
    <form id="form1" runat="server">
    <div class="toolbar">
        模型中心
    </div>
    <ul id="menu" style="height: 100px; overflow: auto;">
        <asp:Repeater runat="server" ID="menu" OnItemDataBound="menu_ItemDataBound">
            <ItemTemplate>
                <li>
                    <h3 onclick="showcd(this)" onmouseover="tdonmouseover(this)" onmouseout="tdonmouseout(this)">
                        <div class="icon-close">
                        </div>
                        <div class="dir-close">
                        </div>
                        <div class="title">
                            <%# Eval("Name") %></div>
                    </h3>
                    <ul id='cd_<%# Eval("ID") %>' style="display: none;">
                        <asp:Repeater runat="server" ID="menuItem">
                            <ItemTemplate>
                                <li onmouseover="tdonmouseover(this)" onmouseout="tdonmouseout(this)" onclick="tdselect(this)">
                                    <div class="item">
                                    </div>
                                    <a href='<%# Eval("Url") %>' target="main" style="color: Black;">
                                        <%# Eval("Name") %></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater runat="server" ID="menu2" OnItemDataBound="menu2_ItemDataBound">
            <ItemTemplate>
                <li>
                    <h3 onclick="showcd(this)" onmouseover="tdonmouseover(this)" onmouseout="tdonmouseout(this)">
                        <div class="icon-close">
                        </div>
                        <div class="dir-close">
                        </div>
                        <div class="title">
                            <%# Eval("DisplayName")%></div>
                    </h3>
                    <ul id='cd_<%# Eval("ID") %>' style="display: none;">
                        <li onmouseover="tdonmouseover(this)" onmouseout="tdonmouseout(this)" onclick="tdselect(this)">
                            <div class="item">
                            </div>
                            <a href='../CustomForm/ModelTable.aspx?DataModelID=<%# Eval("ID") %>' target="main" style="color: Blue; font-weight: bold;">
                                表单管理</a> </li>
                        <asp:Repeater runat="server" ID="menuItem">
                            <ItemTemplate>
                                <li onmouseover="tdonmouseover(this)" onmouseout="tdonmouseout(this)" onclick="tdselect(this)">
                                    <div class="item">
                                    </div>
                                    <a href='../CustomForm/ModelData.aspx?ID=<%# Eval("ID") %>' target="main"
                                        style="color: Black;">
                                        <%# Eval("DisplayName")%></a> </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </li>
            </ItemTemplate>
        </asp:Repeater>
    </ul>
    </form>
</body>
</html>
