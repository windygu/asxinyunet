<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Tag.ascx.cs" Inherits="Cube_Tag" %>
<style type="text/css">
    .tag
    {
        background-image: url(images/tab1.gif);
        height: 29px;
        /*padding-left: 50px;*/
    }
    .tag ul
    {
        overflow: auto;
        margin: 0;
    }
    .tag li
    {
        float: left;
        background-image: url(images/tab2.gif);
        height: 26px;
        line-height: 25px;
        border-left: 1px solid #8db2e3;
        border-top: 1px solid #8db2e3;
        border-right: 1px solid #8db2e3;
        margin-right: 6px;
        display: inline;
        margin-top: 2px;
        padding: 0px 8px;
        color: #6087bb;
        cursor: pointer;
    }
    .tag li.current
    {
        background-image: url(images/tab3.gif);
        font-weight: bold;
    }
</style>
<div class="tag">
    <asp:Repeater ID="Tag" runat="server">
        <HeaderTemplate>
            <ul>
        </HeaderTemplate>
        <ItemTemplate>
            <li<%#BindAtt(Container.DataItem) %>>
                <span class="icon"></span>
                <%# Eval("Key") %>
            </li>
        </ItemTemplate>
        <FooterTemplate>
            </ul></FooterTemplate>
    </asp:Repeater>
</div>
<script type="text/javascript">
    //后台切换
    jQuery(function ($) {
        $('.tag li').each(function () {
            var tabt = $('.tag li');
            var box = $('.tab-box');

            tabt.click(function () {
                var index = tabt.index(this);
                tabt.not(this).removeClass('current');
                $(this).addClass('current');

                box.not(':eq(' + index + ')').hide();
                box.eq(index).show();
            });

            var curr = tabt.filter('.current');
            if (!curr[0]) {
                curr = tabt.eq(0);
            } else {

            }
            curr.triggerHandler('click');
        });
    });
</script>