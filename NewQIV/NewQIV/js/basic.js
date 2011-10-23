function onFocus()
{
	var oId = document.getElementById("searchInput");
	oId.value = "";
}
function offFocus()
{
	var oId = document.getElementById("searchInput");
	oId.value = "搜索";
}
function showNav()
{
	var oNav = document.getElementById("hiddenNav1");	
	oNav.style.display = "block";
	//var x = document.getElementsByName("hiddenNav");
}

    
function changeDisplayStyle(n)
{
    var s=document.getElementById(n);
    with(s.style)
    {
        if(display=="none")
        {
            display="block";
        }
        else
        {
            display="none";
        }
    }
}


