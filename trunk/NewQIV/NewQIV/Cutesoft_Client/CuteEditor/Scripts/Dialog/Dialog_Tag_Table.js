var OxOc8ad=["","removeNode","parentNode","firstChild","nodeName","TABLE","length","Can\x27t Get The Position ?","Map","RowCount","ColCount","rows","cells","Unknown Error , pos ",":"," already have cell","rowSpan","colSpan","Unknown Error , Unable to find bestpos","inp_cellspacing","inp_cellpadding","inp_id","inp_border","inp_bgcolor","inp_bordercolor","sel_rules","inp_collapse","inp_summary","btn_editcaption","btn_delcaption","btn_insthead","btn_instfoot","inp_class","inp_width","sel_width_unit","inp_height","sel_height_unit","sel_align","sel_textalign","sel_float","inp_tooltip","onclick","tHead","tFoot","caption","innerHTML","[[Caption]]","innerText","Unable to delete the caption. Please remove it in HTML source.","[[Delete]]","[[Insert]]","[[Edit]]","display","style","none","disabled","cellSpacing","value","cellPadding","id","border","borderColor","backgroundColor","bgColor","borderCollapse","checked","collapse","rules","summary","className","width","options","selectedIndex","height","align","styleFloat","cssFloat","textAlign","title","bordercolor","[[ValidID]]","0","%","class","CaptionTable"]; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxOc8ad[0x0];} ;return Ox8+OxOc8ad[0x0];}  ; function Element_RemoveNode(element,Ox48c){if(element[OxOc8ad[0x1]]){ element.removeNode(Ox48c) ;return ;} ;var p=element[OxOc8ad[0x2]];if(!p){return ;} ;if(Ox48c){ p.removeChild(element) ;return ;} ;while(true){var Ox1b6=element[OxOc8ad[0x3]];if(!Ox1b6){break ;} ; p.insertBefore(Ox1b6,element) ;} ; p.removeChild(element) ;}  ; function Table_GetTable(Ox42){for(;Ox42!=null;Ox42=Ox42[OxOc8ad[0x2]]){if(Ox42[OxOc8ad[0x4]]==OxOc8ad[0x5]){return Ox42;} ;} ;return null;}  ; function Table_GetCellPositionFromMap(Ox486,Ox30d){for(var y=0x0;y<Ox486[OxOc8ad[0x6]];y++){var Ox489=Ox486[y];for(var x=0x0;x<Ox489[OxOc8ad[0x6]];x++){if(Ox489[x]==Ox30d){return {rowIndex:y,cellIndex:x};} ;} ;} ;throw ( new Error(-0x1,OxOc8ad[0x7]));}  ; function Table_GetCellMap(Ox30b){return Table_CalculateTableInfo(Ox30b)[OxOc8ad[0x8]];}  ; function Table_GetRowCount(Ox42){return Table_CalculateTableInfo(Ox42)[OxOc8ad[0x9]];}  ; function Table_GetColCount(Ox42){return Table_CalculateTableInfo(Ox42)[OxOc8ad[0xa]];}  ; function Table_CalculateTableInfo(Ox42){var Ox30b=Table_GetTable(Ox42);var Ox499=Ox30b[OxOc8ad[0xb]];for(var Oxa=Ox499[OxOc8ad[0x6]]-0x1;Oxa>=0x0;Oxa--){var Ox2fd=Ox499.item(Oxa);if(Ox2fd[OxOc8ad[0xc]][OxOc8ad[0x6]]==0x0){ Element_RemoveNode(Ox2fd,true) ;continue ;} ;} ;var Ox49a=Ox499[OxOc8ad[0x6]];var Ox49b=0x0;var Ox49c= new Array(Ox499.length);for(var Ox49d=0x0;Ox49d<Ox49a;Ox49d++){ Ox49c[Ox49d]=[] ;} ; function Ox49e(Oxa,Ox1b6,Ox30d){while(Oxa>=Ox49a){ Ox49c[Ox49a]=[] ; Ox49a++ ;} ;var Ox49f=Ox49c[Oxa];if(Ox1b6>=Ox49b){ Ox49b=Ox1b6+0x1 ;} ;if(Ox49f[Ox1b6]!=null){throw ( new Error(-0x1,OxOc8ad[0xd]+Oxa+OxOc8ad[0xe]+Ox1b6+OxOc8ad[0xf]));} ; Ox49f[Ox1b6]=Ox30d ;}  ; function Ox4a0(Oxa,Ox1b6){var Ox49f=Ox49c[Oxa];if(Ox49f){return Ox49f[Ox1b6];} ;}  ;for(var Ox49d=0x0;Ox49d<Ox499[OxOc8ad[0x6]];Ox49d++){var Ox2fd=Ox499.item(Ox49d);var Ox4a1=Ox2fd[OxOc8ad[0xc]];for(var Ox311=0x0;Ox311<Ox4a1[OxOc8ad[0x6]];Ox311++){var Ox30d=Ox4a1.item(Ox311);var Ox4a2=Ox30d[OxOc8ad[0x10]];var Ox4a3=Ox30d[OxOc8ad[0x11]];var Ox49f=Ox49c[Ox49d];var Ox4a4=-0x1;for(var Ox4a5=0x0;Ox4a5<Ox49b+Ox4a3+0x1;Ox4a5++){if(Ox4a2==0x1&&Ox4a3==0x1){if(Ox49f[Ox4a5]==null){ Ox4a4=Ox4a5 ;break ;} ;} else {var Ox4a6=true;for(var Ox4a7=0x0;Ox4a7<Ox4a2;Ox4a7++){for(var Ox4a8=0x0;Ox4a8<Ox4a3;Ox4a8++){if(Ox4a0(Ox49d+Ox4a7,Ox4a5+Ox4a8)!=null){ Ox4a6=false ;break ;} ;} ;} ;if(Ox4a6){ Ox4a4=Ox4a5 ;break ;} ;} ;} ;if(Ox4a4==-0x1){throw ( new Error(-0x1,OxOc8ad[0x12]));} ;if(Ox4a2==0x1&&Ox4a3==0x1){ Ox49e(Ox49d,Ox4a4,Ox30d) ;} else {for(var Ox4a7=0x0;Ox4a7<Ox4a2;Ox4a7++){for(var Ox4a8=0x0;Ox4a8<Ox4a3;Ox4a8++){ Ox49e(Ox49d+Ox4a7,Ox4a4+Ox4a8,Ox30d) ;} ;} ;} ;} ;} ;var Ox130={}; Ox130[OxOc8ad[0x9]]=Ox49a ; Ox130[OxOc8ad[0xa]]=Ox49b ; Ox130[OxOc8ad[0x8]]=Ox49c ;for(var Oxa=0x0;Oxa<Ox49a;Oxa++){var Ox49f=Ox49c[Oxa];for(var Ox1b6=0x0;Ox1b6<Ox49b;Ox1b6++){} ;} ;return Ox130;}  ;var inp_cellspacing=Window_GetElement(window,OxOc8ad[0x13],true);var inp_cellpadding=Window_GetElement(window,OxOc8ad[0x14],true);var inp_id=Window_GetElement(window,OxOc8ad[0x15],true);var inp_border=Window_GetElement(window,OxOc8ad[0x16],true);var inp_bgcolor=Window_GetElement(window,OxOc8ad[0x17],true);var inp_bordercolor=Window_GetElement(window,OxOc8ad[0x18],true);var sel_rules=Window_GetElement(window,OxOc8ad[0x19],true);var inp_collapse=Window_GetElement(window,OxOc8ad[0x1a],true);var inp_summary=Window_GetElement(window,OxOc8ad[0x1b],true);var btn_editcaption=Window_GetElement(window,OxOc8ad[0x1c],true);var btn_delcaption=Window_GetElement(window,OxOc8ad[0x1d],true);var btn_insthead=Window_GetElement(window,OxOc8ad[0x1e],true);var btn_instfoot=Window_GetElement(window,OxOc8ad[0x1f],true);var inp_class=Window_GetElement(window,OxOc8ad[0x20],true);var inp_width=Window_GetElement(window,OxOc8ad[0x21],true);var sel_width_unit=Window_GetElement(window,OxOc8ad[0x22],true);var inp_height=Window_GetElement(window,OxOc8ad[0x23],true);var sel_height_unit=Window_GetElement(window,OxOc8ad[0x24],true);var sel_align=Window_GetElement(window,OxOc8ad[0x25],true);var sel_textalign=Window_GetElement(window,OxOc8ad[0x26],true);var sel_float=Window_GetElement(window,OxOc8ad[0x27],true);var inp_tooltip=Window_GetElement(window,OxOc8ad[0x28],true); function insertOneRow(Ox59b,Ox386){var Ox2fd=Ox59b.insertRow(-0x1);for(var i=0x0;i<Ox386;i++){ Ox2fd.insertCell() ;} ;}  ; btn_insthead[OxOc8ad[0x29]]=function btn_insthead_onclick(){if(element[OxOc8ad[0x2a]]){ element.deleteTHead() ;} else {var Ox59d=Table_GetColCount(element);var Ox59e=element.createTHead(); insertOneRow(Ox59e,Ox59d) ;} ;}  ; btn_instfoot[OxOc8ad[0x29]]=function btn_instfoot_onclick(){if(element[OxOc8ad[0x2b]]){ element.deleteTFoot() ;} else {var Ox59d=Table_GetColCount(element);var Ox5a0=element.createTFoot(); insertOneRow(Ox5a0,Ox59d) ;} ;}  ; btn_editcaption[OxOc8ad[0x29]]=function btn_editcaption_onclick(){var Ox5a2=element[OxOc8ad[0x2c]];if(Ox5a2!=null){var Ox1f8=editor.EditInWindow(Ox5a2.innerHTML,window);if(Ox1f8!=null&&Ox1f8!==false){ Ox5a2[OxOc8ad[0x2d]]=Ox1f8 ;} ;} else {var Ox5a2=element.createCaption();if(Browser_IsGecko()){ Ox5a2[OxOc8ad[0x2d]]=OxOc8ad[0x2e] ;} else { Ox5a2[OxOc8ad[0x2f]]=OxOc8ad[0x2e] ;} ;} ;}  ; btn_delcaption[OxOc8ad[0x29]]=function btn_delcaption_onclick(){if(element[OxOc8ad[0x2c]]!=null){ alert(OxOc8ad[0x30]) ;} ;}  ; UpdateState=function UpdateState_Table(){if(Browser_IsGecko()){ btn_insthead[OxOc8ad[0x2d]]=element[OxOc8ad[0x2a]]?OxOc8ad[0x31]:OxOc8ad[0x32] ; btn_instfoot[OxOc8ad[0x2d]]=element[OxOc8ad[0x2b]]?OxOc8ad[0x31]:OxOc8ad[0x32] ;} else { btn_insthead[OxOc8ad[0x2f]]=element[OxOc8ad[0x2a]]?OxOc8ad[0x31]:OxOc8ad[0x32] ; btn_instfoot[OxOc8ad[0x2f]]=element[OxOc8ad[0x2b]]?OxOc8ad[0x31]:OxOc8ad[0x32] ;} ;if(element[OxOc8ad[0x2c]]!=null){if(Browser_IsGecko()){ btn_editcaption[OxOc8ad[0x2d]]=OxOc8ad[0x33] ;} else { btn_editcaption[OxOc8ad[0x2f]]=OxOc8ad[0x33] ;} ; btn_editcaption[OxOc8ad[0x35]][OxOc8ad[0x34]]=OxOc8ad[0x36] ; btn_delcaption[OxOc8ad[0x37]]=false ;} else {if(Browser_IsGecko()){ btn_editcaption[OxOc8ad[0x2d]]=OxOc8ad[0x32] ;} else { btn_editcaption[OxOc8ad[0x2f]]=OxOc8ad[0x32] ;} ; btn_delcaption[OxOc8ad[0x37]]=true ;} ;}  ;var t_inp_width=OxOc8ad[0x0];var t_inp_height=OxOc8ad[0x0]; SyncToView=function SyncToView_Table(){ inp_cellspacing[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x38]) ; inp_cellpadding[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x3a]) ; inp_id[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x3b]) ; inp_border[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x3c]) ; inp_bordercolor[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x3d]) ; inp_bordercolor[OxOc8ad[0x35]][OxOc8ad[0x3e]]=inp_bordercolor[OxOc8ad[0x39]] ; inp_bgcolor[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x3f])||element[OxOc8ad[0x35]][OxOc8ad[0x3e]] ; inp_bgcolor[OxOc8ad[0x35]][OxOc8ad[0x3e]]=inp_bgcolor[OxOc8ad[0x39]] ; inp_collapse[OxOc8ad[0x41]]=element[OxOc8ad[0x35]][OxOc8ad[0x40]]==OxOc8ad[0x42] ; sel_rules[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x43]) ; inp_summary[OxOc8ad[0x39]]=element.getAttribute(OxOc8ad[0x44]) ; inp_class[OxOc8ad[0x39]]=element[OxOc8ad[0x45]] ;if(element.getAttribute(OxOc8ad[0x46])){ t_inp_width=element.getAttribute(OxOc8ad[0x46]) ;} else {if(element[OxOc8ad[0x35]][OxOc8ad[0x46]]){ t_inp_width=element[OxOc8ad[0x35]][OxOc8ad[0x46]] ;} ;} ;if(t_inp_width){ inp_width[OxOc8ad[0x39]]=ParseFloatToString(t_inp_width) ;for(var i=0x0;i<sel_width_unit[OxOc8ad[0x47]][OxOc8ad[0x6]];i++){var Ox134=sel_width_unit[OxOc8ad[0x47]][i][OxOc8ad[0x39]];if(Ox134&&t_inp_width.indexOf(Ox134)!=-0x1){ sel_width_unit[OxOc8ad[0x48]]=i ;break ;} ;} ;} ;if(element.getAttribute(OxOc8ad[0x49])){ t_inp_height=element.getAttribute(OxOc8ad[0x49]) ;} else {if(element[OxOc8ad[0x35]][OxOc8ad[0x49]]){ t_inp_height=element[OxOc8ad[0x35]][OxOc8ad[0x49]] ;} ;} ;if(t_inp_height){ inp_height[OxOc8ad[0x39]]=ParseFloatToString(t_inp_height) ;for(var i=0x0;i<sel_height_unit[OxOc8ad[0x47]][OxOc8ad[0x6]];i++){var Ox134=sel_height_unit[OxOc8ad[0x47]][i][OxOc8ad[0x39]];if(Ox134&&t_inp_height.indexOf(Ox134)!=-0x1){ sel_height_unit[OxOc8ad[0x48]]=i ;break ;} ;} ;} ; sel_align[OxOc8ad[0x39]]=element[OxOc8ad[0x4a]] ;if(Browser_IsWinIE()){ sel_float[OxOc8ad[0x39]]=element[OxOc8ad[0x35]][OxOc8ad[0x4b]] ;} else { sel_float[OxOc8ad[0x39]]=element[OxOc8ad[0x35]][OxOc8ad[0x4c]] ;} ; sel_textalign[OxOc8ad[0x39]]=element[OxOc8ad[0x35]][OxOc8ad[0x4d]] ; inp_tooltip[OxOc8ad[0x39]]=element[OxOc8ad[0x4e]] ;}  ; SyncTo=function SyncTo_Table(element){if(Browser_IsWinIE()){ element[OxOc8ad[0x3d]]=inp_bordercolor[OxOc8ad[0x39]] ;} else { element.setAttribute(OxOc8ad[0x4f],inp_bordercolor.value) ;} ;if(inp_bgcolor[OxOc8ad[0x39]]){if(element[OxOc8ad[0x35]][OxOc8ad[0x3e]]){ element[OxOc8ad[0x35]][OxOc8ad[0x3e]]=inp_bgcolor[OxOc8ad[0x39]] ;} else { element[OxOc8ad[0x3f]]=inp_bgcolor[OxOc8ad[0x39]] ;} ;} else { element.removeAttribute(OxOc8ad[0x3f]) ;} ; element[OxOc8ad[0x35]][OxOc8ad[0x40]]=inp_collapse[OxOc8ad[0x41]]?OxOc8ad[0x42]:OxOc8ad[0x0] ; element[OxOc8ad[0x43]]=sel_rules[OxOc8ad[0x39]]||OxOc8ad[0x0] ; element[OxOc8ad[0x44]]=inp_summary[OxOc8ad[0x39]] ; element[OxOc8ad[0x45]]=inp_class[OxOc8ad[0x39]] ; element[OxOc8ad[0x38]]=inp_cellspacing[OxOc8ad[0x39]] ; element[OxOc8ad[0x3a]]=inp_cellpadding[OxOc8ad[0x39]] ;var Ox2ec=/[^a-z\d]/i;if(Ox2ec.test(inp_id.value)){ alert(OxOc8ad[0x50]) ;return ;} ; element[OxOc8ad[0x3b]]=inp_id[OxOc8ad[0x39]] ;if(inp_border[OxOc8ad[0x39]]==OxOc8ad[0x0]){ element[OxOc8ad[0x3c]]=OxOc8ad[0x51] ;} else { element[OxOc8ad[0x3c]]=inp_border[OxOc8ad[0x39]] ;} ;if(inp_width[OxOc8ad[0x39]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x46]) ; element[OxOc8ad[0x35]][OxOc8ad[0x46]]=OxOc8ad[0x0] ;} else {try{ t_inp_width=inp_width[OxOc8ad[0x39]] ;if(sel_width_unit[OxOc8ad[0x39]]==OxOc8ad[0x52]){ t_inp_width=inp_width[OxOc8ad[0x39]]+sel_width_unit[OxOc8ad[0x39]] ;} ;if(element[OxOc8ad[0x35]][OxOc8ad[0x46]]&&element[OxOc8ad[0x46]]){ element[OxOc8ad[0x35]][OxOc8ad[0x46]]=t_inp_width ; element[OxOc8ad[0x46]]=t_inp_width ;} else {if(element[OxOc8ad[0x35]][OxOc8ad[0x46]]){ element[OxOc8ad[0x35]][OxOc8ad[0x46]]=t_inp_width ;} else { element[OxOc8ad[0x46]]=t_inp_width ;} ;} ;} catch(x){} ;} ;if(inp_height[OxOc8ad[0x39]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x49]) ; element[OxOc8ad[0x35]][OxOc8ad[0x49]]=OxOc8ad[0x0] ;} else {try{ t_inp_height=inp_height[OxOc8ad[0x39]] ;if(sel_height_unit[OxOc8ad[0x39]]==OxOc8ad[0x52]){ t_inp_height=inp_height[OxOc8ad[0x39]]+sel_height_unit[OxOc8ad[0x39]] ;} ; t_inp_height=inp_height[OxOc8ad[0x39]]+sel_height_unit[OxOc8ad[0x39]] ;if(element[OxOc8ad[0x35]][OxOc8ad[0x49]]&&element[OxOc8ad[0x49]]){ element[OxOc8ad[0x35]][OxOc8ad[0x49]]=t_inp_height ; element[OxOc8ad[0x49]]=t_inp_height ;} else {if(element[OxOc8ad[0x35]][OxOc8ad[0x49]]){ element[OxOc8ad[0x35]][OxOc8ad[0x49]]=t_inp_height ;} else { element[OxOc8ad[0x49]]=t_inp_height ;} ;} ;} catch(x){} ;} ; element[OxOc8ad[0x4a]]=sel_align[OxOc8ad[0x39]] ;if(Browser_IsWinIE()){ element[OxOc8ad[0x35]][OxOc8ad[0x4b]]=sel_float[OxOc8ad[0x39]] ;} else { element[OxOc8ad[0x35]][OxOc8ad[0x4c]]=sel_float[OxOc8ad[0x39]] ;} ; element[OxOc8ad[0x35]][OxOc8ad[0x4d]]=sel_textalign[OxOc8ad[0x39]] ; element[OxOc8ad[0x4e]]=inp_tooltip[OxOc8ad[0x39]] ;if(element[OxOc8ad[0x4e]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x4e]) ;} ;if(element[OxOc8ad[0x44]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x44]) ;} ;if(element[OxOc8ad[0x45]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x45]) ;} ;if(element[OxOc8ad[0x45]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x53]) ;} ;if(element[OxOc8ad[0x3b]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x3b]) ;} ;if(element[OxOc8ad[0x4a]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x4a]) ;} ;if(element[OxOc8ad[0x43]]==OxOc8ad[0x0]){ element.removeAttribute(OxOc8ad[0x43]) ;} ;}  ;if(!Browser_IsWinIE()){ inp_bgcolor[OxOc8ad[0x29]]=function inp_bgcolor_onclick(){ SelectColor(inp_bgcolor) ;}  ; inp_bordercolor[OxOc8ad[0x29]]=function inp_bordercolor_onclick(){ SelectColor(inp_bordercolor) ;}  ; Window_GetElement(window,OxOc8ad[0x54],true)[OxOc8ad[0x35]][OxOc8ad[0x34]]=OxOc8ad[0x36] ;} ;