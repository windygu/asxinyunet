<%@ Page Language="C#" AutoEventWireup="true" CodeFile="resourceURL.aspx.cs" Inherits="dotnetdemos_grid_treegrid_tree" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <link href="../../../lib/ligerUI/skins/Aqua/css/ligerui-all.css" rel="stylesheet" type="text/css" /> 
    <script src="../../../lib/jquery/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="../../../lib/ligerUI/js/core/base.js" type="text/javascript"></script>
    <script src="../../../lib/ligerUI/js/plugins/ligerGrid.js" type="text/javascript"></script>  
    <script src="../../../js/LG.js" type="text/javascript"></script>
    <script type="text/javascript">
        var manager;
        $(function ()
        {
            window['g'] = 
            manager = $("#maingrid").ligerGrid({
                columns:[
                { display: '编号', name: 'Id',type:'int', width: 70, align: 'left' },
                { display: '网址', name: 'PageURL', width: 250 ,type: 'int', align: 'left' },
                { display: '页面标题', name: 'PageTitle', width: 300, align: 'left' },
                { display: '一级大类名称', name: 'ClassName', width: 100, align: 'left' },
                { display: '子类名称', name: 'SubClassName', width:100, align: 'left' },
                { display: '资源类型', name: 'ResouceType', width: 100, align: 'left' },
                { display: '采集标志', name: 'CollectionMark', type: 'int', width: 60, align: 'left' },
                { display: '更新时间', name: 'UpdateTime',type:'date', width: 100, align: 'left' },
                { display: '资料来源', name: 'InfoOrigin', width:100, align: 'left' },
                { display: '备注', name: 'remark', width: 50, align: 'left' }
                ], 
                width: '100%', pageSizeOptions: [10, 15, 20,50], height: '97%',
                url: 'resourceURL.aspx?Action=GetData',
                dataAction: 'server', //服务器排序
                usePager: true,//服务器分页
                pageSize: 20, frozen: false,
                alternatingRow: false, checkbox: true,rownumbers:true
                //tree: { columnName: 'name' }
            }
            );
        });

        function getSelected()
        {
            var row = manager.getSelectedRow();
            if (!row) { alert('请选择行'); return; }
            alert(JSON.stringify(row));
        } 
        
    </script>
</head>
<body  style="padding:4px"> 
<div>  
   <a class="l-button" style="width:120px;float:left; margin-left:10px;" onclick="getSelected()">获取值</a>
   <div class="l-clear"></div> 
</div>
    <div id="maingrid"></div>  
</body>
</html>