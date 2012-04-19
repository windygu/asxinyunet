var biaoqin = false;
//start 添加鼠标划过展开的功能
//lorgine 与2011-10-12日晚上完成
//Email:lorgine@yahoo.cn
//擅长c#,asp.net,js,jquery,css等

//显示浮动条
function SetTdV() {    
    if (obj)
        $(obj).removeClass("hidden").addClass("show");
}
//隐藏浮动条
function UnSetTdV() {
    window.parent.frames["topFrame"].InitToggleTree();       
}
function HiddenDiv() {
    if (obj) {
        $(obj).removeClass("show").addClass("hidden");
    }
}
var fdic = "<div id='divFixd' class=\"divFixd \" ></div>";
var obj;
function AddDiv() {
    if (!biaoqin) {
        //obj = $(fdic).mouseout(UnSetTdV);
        obj = $(fdic).hover(UnSetTdV);
        obj.appendTo($("body"));
        biaoqin = true;
    }    
}