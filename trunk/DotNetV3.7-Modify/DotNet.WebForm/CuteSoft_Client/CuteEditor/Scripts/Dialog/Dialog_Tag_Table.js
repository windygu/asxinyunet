var OxOecb2=["","removeNode","parentNode","firstChild","nodeName","TABLE","length","Can\x27t Get The Position ?","Map","RowCount","ColCount","rows","cells","Unknown Error , pos ",":"," already have cell","rowSpan","colSpan","Unknown Error , Unable to find bestpos","inp_cellspacing","inp_cellpadding","inp_id","inp_border","inp_bgcolor","inp_bordercolor","sel_rules","inp_collapse","inp_summary","btn_editcaption","btn_delcaption","btn_insthead","btn_instfoot","inp_class","inp_width","sel_width_unit","inp_height","sel_height_unit","sel_align","sel_textalign","sel_float","inp_tooltip","onclick","tHead","tFoot","caption","innerHTML","[[Caption]]","innerText","Unable to delete the caption. Please remove it in HTML source.","[[Delete]]","[[Insert]]","[[Edit]]","display","style","none","disabled","cellSpacing","value","cellPadding","id","border","borderColor","backgroundColor","bgColor","borderCollapse","checked","collapse","rules","summary","className","width","options","selectedIndex","height","align","styleFloat","cssFloat","textAlign","title","bordercolor","[[ValidID]]","0","%","class","CaptionTable"]; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxOecb2[0x0];} ;return Ox8+OxOecb2[0x0];}  ; function Element_RemoveNode(element,Ox48d){if(element[OxOecb2[0x1]]){ element.removeNode(Ox48d) ;return ;} ;var p=element[OxOecb2[0x2]];if(!p){return ;} ;if(Ox48d){ p.removeChild(element) ;return ;} ;while(true){var Ox1b6=element[OxOecb2[0x3]];if(!Ox1b6){break ;} ; p.insertBefore(Ox1b6,element) ;} ; p.removeChild(element) ;}  ; function Table_GetTable(Ox42){for(;Ox42!=null;Ox42=Ox42[OxOecb2[0x2]]){if(Ox42[OxOecb2[0x4]]==OxOecb2[0x5]){return Ox42;} ;} ;return null;}  ; function Table_GetCellPositionFromMap(Ox487,Ox30e){for(var y=0x0;y<Ox487[OxOecb2[0x6]];y++){var Ox48a=Ox487[y];for(var x=0x0;x<Ox48a[OxOecb2[0x6]];x++){if(Ox48a[x]==Ox30e){return {rowIndex:y,cellIndex:x};} ;} ;} ;throw ( new Error(-0x1,OxOecb2[0x7]));}  ; function Table_GetCellMap(Ox30c){return Table_CalculateTableInfo(Ox30c)[OxOecb2[0x8]];}  ; function Table_GetRowCount(Ox42){return Table_CalculateTableInfo(Ox42)[OxOecb2[0x9]];}  ; function Table_GetColCount(Ox42){return Table_CalculateTableInfo(Ox42)[OxOecb2[0xa]];}  ; function Table_CalculateTableInfo(Ox42){var Ox30c=Table_GetTable(Ox42);var Ox49a=Ox30c[OxOecb2[0xb]];for(var Oxa=Ox49a[OxOecb2[0x6]]-0x1;Oxa>=0x0;Oxa--){var Ox2fe=Ox49a.item(Oxa);if(Ox2fe[OxOecb2[0xc]][OxOecb2[0x6]]==0x0){ Element_RemoveNode(Ox2fe, true) ;continue ;} ;} ;var Ox49b=Ox49a[OxOecb2[0x6]];var Ox49c=0x0;var Ox49d= new Array(Ox49a.length);for(var Ox49e=0x0;Ox49e<Ox49b;Ox49e++){ Ox49d[Ox49e]=[] ;} ; function Ox49f(Oxa,Ox1b6,Ox30e){while(Oxa>=Ox49b){ Ox49d[Ox49b]=[] ; Ox49b++ ;} ;var Ox4a0=Ox49d[Oxa];if(Ox1b6>=Ox49c){ Ox49c=Ox1b6+0x1 ;} ;if(Ox4a0[Ox1b6]!=null){throw ( new Error(-0x1,OxOecb2[0xd]+Oxa+OxOecb2[0xe]+Ox1b6+OxOecb2[0xf]));} ; Ox4a0[Ox1b6]=Ox30e ;}  ; function Ox4a1(Oxa,Ox1b6){var Ox4a0=Ox49d[Oxa];if(Ox4a0){return Ox4a0[Ox1b6];} ;}  ;for(var Ox49e=0x0;Ox49e<Ox49a[OxOecb2[0x6]];Ox49e++){var Ox2fe=Ox49a.item(Ox49e);var Ox4a2=Ox2fe[OxOecb2[0xc]];for(var Ox312=0x0;Ox312<Ox4a2[OxOecb2[0x6]];Ox312++){var Ox30e=Ox4a2.item(Ox312);var Ox4a3=Ox30e[OxOecb2[0x10]];var Ox4a4=Ox30e[OxOecb2[0x11]];var Ox4a0=Ox49d[Ox49e];var Ox4a5=-0x1;for(var Ox4a6=0x0;Ox4a6<Ox49c+Ox4a4+0x1;Ox4a6++){if(Ox4a3==0x1&&Ox4a4==0x1){if(Ox4a0[Ox4a6]==null){ Ox4a5=Ox4a6 ;break ;} ;} else {var Ox4a7=true;for(var Ox4a8=0x0;Ox4a8<Ox4a3;Ox4a8++){for(var Ox4a9=0x0;Ox4a9<Ox4a4;Ox4a9++){if(Ox4a1(Ox49e+Ox4a8,Ox4a6+Ox4a9)!=null){ Ox4a7=false ;break ;} ;} ;} ;if(Ox4a7){ Ox4a5=Ox4a6 ;break ;} ;} ;} ;if(Ox4a5==-0x1){throw ( new Error(-0x1,OxOecb2[0x12]));} ;if(Ox4a3==0x1&&Ox4a4==0x1){ Ox49f(Ox49e,Ox4a5,Ox30e) ;} else {for(var Ox4a8=0x0;Ox4a8<Ox4a3;Ox4a8++){for(var Ox4a9=0x0;Ox4a9<Ox4a4;Ox4a9++){ Ox49f(Ox49e+Ox4a8,Ox4a5+Ox4a9,Ox30e) ;} ;} ;} ;} ;} ;var Ox130={}; Ox130[OxOecb2[0x9]]=Ox49b ; Ox130[OxOecb2[0xa]]=Ox49c ; Ox130[OxOecb2[0x8]]=Ox49d ;for(var Oxa=0x0;Oxa<Ox49b;Oxa++){var Ox4a0=Ox49d[Oxa];for(var Ox1b6=0x0;Ox1b6<Ox49c;Ox1b6++){} ;} ;return Ox130;}  ;var inp_cellspacing=Window_GetElement(window,OxOecb2[0x13], true);var inp_cellpadding=Window_GetElement(window,OxOecb2[0x14], true);var inp_id=Window_GetElement(window,OxOecb2[0x15], true);var inp_border=Window_GetElement(window,OxOecb2[0x16], true);var inp_bgcolor=Window_GetElement(window,OxOecb2[0x17], true);var inp_bordercolor=Window_GetElement(window,OxOecb2[0x18], true);var sel_rules=Window_GetElement(window,OxOecb2[0x19], true);var inp_collapse=Window_GetElement(window,OxOecb2[0x1a], true);var inp_summary=Window_GetElement(window,OxOecb2[0x1b], true);var btn_editcaption=Window_GetElement(window,OxOecb2[0x1c], true);var btn_delcaption=Window_GetElement(window,OxOecb2[0x1d], true);var btn_insthead=Window_GetElement(window,OxOecb2[0x1e], true);var btn_instfoot=Window_GetElement(window,OxOecb2[0x1f], true);var inp_class=Window_GetElement(window,OxOecb2[0x20], true);var inp_width=Window_GetElement(window,OxOecb2[0x21], true);var sel_width_unit=Window_GetElement(window,OxOecb2[0x22], true);var inp_height=Window_GetElement(window,OxOecb2[0x23], true);var sel_height_unit=Window_GetElement(window,OxOecb2[0x24], true);var sel_align=Window_GetElement(window,OxOecb2[0x25], true);var sel_textalign=Window_GetElement(window,OxOecb2[0x26], true);var sel_float=Window_GetElement(window,OxOecb2[0x27], true);var inp_tooltip=Window_GetElement(window,OxOecb2[0x28], true); function insertOneRow(Ox59c,Ox387){var Ox2fe=Ox59c.insertRow(-0x1);for(var i=0x0;i<Ox387;i++){ Ox2fe.insertCell() ;} ;}  ; btn_insthead[OxOecb2[0x29]]=function btn_insthead_onclick(){if(element[OxOecb2[0x2a]]){ element.deleteTHead() ;} else {var Ox59e=Table_GetColCount(element);var Ox59f=element.createTHead(); insertOneRow(Ox59f,Ox59e) ;} ;}  ; btn_instfoot[OxOecb2[0x29]]=function btn_instfoot_onclick(){if(element[OxOecb2[0x2b]]){ element.deleteTFoot() ;} else {var Ox59e=Table_GetColCount(element);var Ox5a1=element.createTFoot(); insertOneRow(Ox5a1,Ox59e) ;} ;}  ; btn_editcaption[OxOecb2[0x29]]=function btn_editcaption_onclick(){var Ox5a3=element[OxOecb2[0x2c]];if(Ox5a3!=null){var Ox1f8=editor.EditInWindow(Ox5a3.innerHTML,window);if(Ox1f8!=null&&Ox1f8!==false){ Ox5a3[OxOecb2[0x2d]]=Ox1f8 ;} ;} else {var Ox5a3=element.createCaption();if(Browser_IsGecko()){ Ox5a3[OxOecb2[0x2d]]=OxOecb2[0x2e] ;} else { Ox5a3[OxOecb2[0x2f]]=OxOecb2[0x2e] ;} ;} ;}  ; btn_delcaption[OxOecb2[0x29]]=function btn_delcaption_onclick(){if(element[OxOecb2[0x2c]]!=null){ alert(OxOecb2[0x30]) ;} ;}  ; UpdateState=function UpdateState_Table(){if(Browser_IsGecko()){ btn_insthead[OxOecb2[0x2d]]=element[OxOecb2[0x2a]]?OxOecb2[0x31]:OxOecb2[0x32] ; btn_instfoot[OxOecb2[0x2d]]=element[OxOecb2[0x2b]]?OxOecb2[0x31]:OxOecb2[0x32] ;} else { btn_insthead[OxOecb2[0x2f]]=element[OxOecb2[0x2a]]?OxOecb2[0x31]:OxOecb2[0x32] ; btn_instfoot[OxOecb2[0x2f]]=element[OxOecb2[0x2b]]?OxOecb2[0x31]:OxOecb2[0x32] ;} ;if(element[OxOecb2[0x2c]]!=null){if(Browser_IsGecko()){ btn_editcaption[OxOecb2[0x2d]]=OxOecb2[0x33] ;} else { btn_editcaption[OxOecb2[0x2f]]=OxOecb2[0x33] ;} ; btn_editcaption[OxOecb2[0x35]][OxOecb2[0x34]]=OxOecb2[0x36] ; btn_delcaption[OxOecb2[0x37]]=false ;} else {if(Browser_IsGecko()){ btn_editcaption[OxOecb2[0x2d]]=OxOecb2[0x32] ;} else { btn_editcaption[OxOecb2[0x2f]]=OxOecb2[0x32] ;} ; btn_delcaption[OxOecb2[0x37]]=true ;} ;}  ;var t_inp_width=OxOecb2[0x0];var t_inp_height=OxOecb2[0x0]; SyncToView=function SyncToView_Table(){ inp_cellspacing[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x38]) ; inp_cellpadding[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x3a]) ; inp_id[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x3b]) ; inp_border[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x3c]) ; inp_bordercolor[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x3d]) ; inp_bordercolor[OxOecb2[0x35]][OxOecb2[0x3e]]=inp_bordercolor[OxOecb2[0x39]] ; inp_bgcolor[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x3f])||element[OxOecb2[0x35]][OxOecb2[0x3e]] ; inp_bgcolor[OxOecb2[0x35]][OxOecb2[0x3e]]=inp_bgcolor[OxOecb2[0x39]] ; inp_collapse[OxOecb2[0x41]]=element[OxOecb2[0x35]][OxOecb2[0x40]]==OxOecb2[0x42] ; sel_rules[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x43]) ; inp_summary[OxOecb2[0x39]]=element.getAttribute(OxOecb2[0x44]) ; inp_class[OxOecb2[0x39]]=element[OxOecb2[0x45]] ;if(element.getAttribute(OxOecb2[0x46])){ t_inp_width=element.getAttribute(OxOecb2[0x46]) ;} else {if(element[OxOecb2[0x35]][OxOecb2[0x46]]){ t_inp_width=element[OxOecb2[0x35]][OxOecb2[0x46]] ;} ;} ;if(t_inp_width){ inp_width[OxOecb2[0x39]]=ParseFloatToString(t_inp_width) ;for(var i=0x0;i<sel_width_unit[OxOecb2[0x47]][OxOecb2[0x6]];i++){var Ox134=sel_width_unit[OxOecb2[0x47]][i][OxOecb2[0x39]];if(Ox134&&t_inp_width.indexOf(Ox134)!=-0x1){ sel_width_unit[OxOecb2[0x48]]=i ;break ;} ;} ;} ;if(element.getAttribute(OxOecb2[0x49])){ t_inp_height=element.getAttribute(OxOecb2[0x49]) ;} else {if(element[OxOecb2[0x35]][OxOecb2[0x49]]){ t_inp_height=element[OxOecb2[0x35]][OxOecb2[0x49]] ;} ;} ;if(t_inp_height){ inp_height[OxOecb2[0x39]]=ParseFloatToString(t_inp_height) ;for(var i=0x0;i<sel_height_unit[OxOecb2[0x47]][OxOecb2[0x6]];i++){var Ox134=sel_height_unit[OxOecb2[0x47]][i][OxOecb2[0x39]];if(Ox134&&t_inp_height.indexOf(Ox134)!=-0x1){ sel_height_unit[OxOecb2[0x48]]=i ;break ;} ;} ;} ; sel_align[OxOecb2[0x39]]=element[OxOecb2[0x4a]] ;if(Browser_IsWinIE()){ sel_float[OxOecb2[0x39]]=element[OxOecb2[0x35]][OxOecb2[0x4b]] ;} else { sel_float[OxOecb2[0x39]]=element[OxOecb2[0x35]][OxOecb2[0x4c]] ;} ; sel_textalign[OxOecb2[0x39]]=element[OxOecb2[0x35]][OxOecb2[0x4d]] ; inp_tooltip[OxOecb2[0x39]]=element[OxOecb2[0x4e]] ;}  ; SyncTo=function SyncTo_Table(element){if(Browser_IsWinIE()){ element[OxOecb2[0x3d]]=inp_bordercolor[OxOecb2[0x39]] ;} else { element.setAttribute(OxOecb2[0x4f],inp_bordercolor.value) ;} ;if(inp_bgcolor[OxOecb2[0x39]]){if(element[OxOecb2[0x35]][OxOecb2[0x3e]]){ element[OxOecb2[0x35]][OxOecb2[0x3e]]=inp_bgcolor[OxOecb2[0x39]] ;} else { element[OxOecb2[0x3f]]=inp_bgcolor[OxOecb2[0x39]] ;} ;} else { element.removeAttribute(OxOecb2[0x3f]) ;} ; element[OxOecb2[0x35]][OxOecb2[0x40]]=inp_collapse[OxOecb2[0x41]]?OxOecb2[0x42]:OxOecb2[0x0] ; element[OxOecb2[0x43]]=sel_rules[OxOecb2[0x39]]||OxOecb2[0x0] ; element[OxOecb2[0x44]]=inp_summary[OxOecb2[0x39]] ; element[OxOecb2[0x45]]=inp_class[OxOecb2[0x39]] ; element[OxOecb2[0x38]]=inp_cellspacing[OxOecb2[0x39]] ; element[OxOecb2[0x3a]]=inp_cellpadding[OxOecb2[0x39]] ;var Ox2ed=/[^a-z\d]/i;if(Ox2ed.test(inp_id.value)){ alert(OxOecb2[0x50]) ;return ;} ; element[OxOecb2[0x3b]]=inp_id[OxOecb2[0x39]] ;if(inp_border[OxOecb2[0x39]]==OxOecb2[0x0]){ element[OxOecb2[0x3c]]=OxOecb2[0x51] ;} else { element[OxOecb2[0x3c]]=inp_border[OxOecb2[0x39]] ;} ;if(inp_width[OxOecb2[0x39]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x46]) ; element[OxOecb2[0x35]][OxOecb2[0x46]]=OxOecb2[0x0] ;} else {try{ t_inp_width=inp_width[OxOecb2[0x39]] ;if(sel_width_unit[OxOecb2[0x39]]==OxOecb2[0x52]){ t_inp_width=inp_width[OxOecb2[0x39]]+sel_width_unit[OxOecb2[0x39]] ;} ;if(element[OxOecb2[0x35]][OxOecb2[0x46]]&&element[OxOecb2[0x46]]){ element[OxOecb2[0x35]][OxOecb2[0x46]]=t_inp_width ; element[OxOecb2[0x46]]=t_inp_width ;} else {if(element[OxOecb2[0x35]][OxOecb2[0x46]]){ element[OxOecb2[0x35]][OxOecb2[0x46]]=t_inp_width ;} else { element[OxOecb2[0x46]]=t_inp_width ;} ;} ;} catch(x){} ;} ;if(inp_height[OxOecb2[0x39]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x49]) ; element[OxOecb2[0x35]][OxOecb2[0x49]]=OxOecb2[0x0] ;} else {try{ t_inp_height=inp_height[OxOecb2[0x39]] ;if(sel_height_unit[OxOecb2[0x39]]==OxOecb2[0x52]){ t_inp_height=inp_height[OxOecb2[0x39]]+sel_height_unit[OxOecb2[0x39]] ;} ; t_inp_height=inp_height[OxOecb2[0x39]]+sel_height_unit[OxOecb2[0x39]] ;if(element[OxOecb2[0x35]][OxOecb2[0x49]]&&element[OxOecb2[0x49]]){ element[OxOecb2[0x35]][OxOecb2[0x49]]=t_inp_height ; element[OxOecb2[0x49]]=t_inp_height ;} else {if(element[OxOecb2[0x35]][OxOecb2[0x49]]){ element[OxOecb2[0x35]][OxOecb2[0x49]]=t_inp_height ;} else { element[OxOecb2[0x49]]=t_inp_height ;} ;} ;} catch(x){} ;} ; element[OxOecb2[0x4a]]=sel_align[OxOecb2[0x39]] ;if(Browser_IsWinIE()){ element[OxOecb2[0x35]][OxOecb2[0x4b]]=sel_float[OxOecb2[0x39]] ;} else { element[OxOecb2[0x35]][OxOecb2[0x4c]]=sel_float[OxOecb2[0x39]] ;} ; element[OxOecb2[0x35]][OxOecb2[0x4d]]=sel_textalign[OxOecb2[0x39]] ; element[OxOecb2[0x4e]]=inp_tooltip[OxOecb2[0x39]] ;if(element[OxOecb2[0x4e]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x4e]) ;} ;if(element[OxOecb2[0x44]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x44]) ;} ;if(element[OxOecb2[0x45]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x45]) ;} ;if(element[OxOecb2[0x45]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x53]) ;} ;if(element[OxOecb2[0x3b]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x3b]) ;} ;if(element[OxOecb2[0x4a]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x4a]) ;} ;if(element[OxOecb2[0x43]]==OxOecb2[0x0]){ element.removeAttribute(OxOecb2[0x43]) ;} ;}  ;if(!Browser_IsWinIE()){ inp_bgcolor[OxOecb2[0x29]]=function inp_bgcolor_onclick(){ SelectColor(inp_bgcolor) ;}  ; inp_bordercolor[OxOecb2[0x29]]=function inp_bordercolor_onclick(){ SelectColor(inp_bordercolor) ;}  ; Window_GetElement(window,OxOecb2[0x54], true)[OxOecb2[0x35]][OxOecb2[0x34]]=OxOecb2[0x36] ;} ;