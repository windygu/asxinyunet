var OxOe4f9=["","sel_position","sel_display","sel_float","sel_clear","tb_top","sel_top_unit","tb_height","sel_height_unit","tb_left","sel_left_unit","tb_width","sel_width_unit","tb_cliptop","sel_cliptop_unit","tb_clipbottom","sel_clipbottom_unit","tb_clipleft","sel_clipleft_unit","tb_clipright","sel_clipright_unit","sel_overflow","tb_zindex","sel_pagebreakbefore","sel_pagebreakafter","outer","div_demo","cssText","style","position","value","display","styleFloat","cssFloat","clear","left","top","width","height","length","tb_","sel_","_unit","selectedIndex","options","right","bottom","clip","tb_clip","sel_clip","currentStyle","overflow","zIndex","pageBreakBefore","pageBreakAfter"]; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxOe4f9[0x0];} ;return Ox8+OxOe4f9[0x0];}  ;var sel_position=Window_GetElement(window,OxOe4f9[0x1], true);var sel_display=Window_GetElement(window,OxOe4f9[0x2], true);var sel_float=Window_GetElement(window,OxOe4f9[0x3], true);var sel_clear=Window_GetElement(window,OxOe4f9[0x4], true);var tb_top=Window_GetElement(window,OxOe4f9[0x5], true);var sel_top_unit=Window_GetElement(window,OxOe4f9[0x6], true);var tb_height=Window_GetElement(window,OxOe4f9[0x7], true);var sel_height_unit=Window_GetElement(window,OxOe4f9[0x8], true);var tb_left=Window_GetElement(window,OxOe4f9[0x9], true);var sel_left_unit=Window_GetElement(window,OxOe4f9[0xa], true);var tb_width=Window_GetElement(window,OxOe4f9[0xb], true);var sel_width_unit=Window_GetElement(window,OxOe4f9[0xc], true);var tb_cliptop=Window_GetElement(window,OxOe4f9[0xd], true);var sel_cliptop_unit=Window_GetElement(window,OxOe4f9[0xe], true);var tb_clipbottom=Window_GetElement(window,OxOe4f9[0xf], true);var sel_clipbottom_unit=Window_GetElement(window,OxOe4f9[0x10], true);var tb_clipleft=Window_GetElement(window,OxOe4f9[0x11], true);var sel_clipleft_unit=Window_GetElement(window,OxOe4f9[0x12], true);var tb_clipright=Window_GetElement(window,OxOe4f9[0x13], true);var sel_clipright_unit=Window_GetElement(window,OxOe4f9[0x14], true);var sel_overflow=Window_GetElement(window,OxOe4f9[0x15], true);var tb_zindex=Window_GetElement(window,OxOe4f9[0x16], true);var sel_pagebreakbefore=Window_GetElement(window,OxOe4f9[0x17], true);var sel_pagebreakafter=Window_GetElement(window,OxOe4f9[0x18], true);var outer=Window_GetElement(window,OxOe4f9[0x19], true);var div_demo=Window_GetElement(window,OxOe4f9[0x1a], true); UpdateState=function UpdateState_Layout(){ div_demo[OxOe4f9[0x1c]][OxOe4f9[0x1b]]=element[OxOe4f9[0x1c]][OxOe4f9[0x1b]] ;}  ; SyncToView=function SyncToView_Layout(){ sel_position[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x1d]] ; sel_display[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x1f]] ;if(Browser_IsWinIE()){ sel_float[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x20]] ;} else { sel_float[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x21]] ;} ; sel_clear[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x22]] ;var arr=[OxOe4f9[0x23],OxOe4f9[0x24],OxOe4f9[0x25],OxOe4f9[0x26]];for(var Ox171=0x0;Ox171<arr[OxOe4f9[0x27]];Ox171++){var n=arr[Ox171];var Ox42=document.getElementById(OxOe4f9[0x28]+n);var Ox109=document.getElementById(OxOe4f9[0x29]+n+OxOe4f9[0x2a]); Ox109[OxOe4f9[0x2b]]=0x0 ;if(ParseFloatToString(element[OxOe4f9[0x1c]][n])){ Ox42[OxOe4f9[0x1e]]=ParseFloatToString(element[OxOe4f9[0x1c]][n]) ;for(var i=0x0;i<Ox109[OxOe4f9[0x2c]][OxOe4f9[0x27]];i++){var Ox134=Ox109[OxOe4f9[0x2c]][i][OxOe4f9[0x1e]];if(Ox134&&element[OxOe4f9[0x1c]][n].indexOf(Ox134)!=-0x1){ Ox109[OxOe4f9[0x2b]]=i ;break ;} ;} ;} ;} ;var arr=[OxOe4f9[0x23],OxOe4f9[0x24],OxOe4f9[0x2d],OxOe4f9[0x2e]];for(var Ox171=0x0;Ox171<arr[OxOe4f9[0x27]];Ox171++){var n=arr[Ox171];var Ox57b=OxOe4f9[0x2f]+n.charAt(0x0).toUpperCase()+n.substring(0x1);var Ox42=document.getElementById(OxOe4f9[0x30]+n);var Ox109=document.getElementById(OxOe4f9[0x31]+n+OxOe4f9[0x2a]); Ox109[OxOe4f9[0x2b]]=0x0 ;var Ox57c;if(Browser_IsWinIE()){ Ox57c=element[OxOe4f9[0x32]][Ox57b] ;} else { Ox57c=element[OxOe4f9[0x1c]][Ox57b] ;} ;if(ParseFloatToString(Ox57c)){ Ox42[OxOe4f9[0x1e]]=ParseFloatToString(Ox57c) ;for(var i=0x0;i<Ox109[OxOe4f9[0x2c]][OxOe4f9[0x27]];i++){var Ox134=Ox109[OxOe4f9[0x2c]][i][OxOe4f9[0x1e]];if(Ox134&&Ox57c.indexOf(Ox134)!=-0x1){ Ox109[OxOe4f9[0x2b]]=i ;break ;} ;} ;} ;} ; sel_overflow[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x33]] ; tb_zindex[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x34]] ; sel_pagebreakbefore[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x35]] ; sel_pagebreakafter[OxOe4f9[0x1e]]=element[OxOe4f9[0x1c]][OxOe4f9[0x36]] ;}  ; SyncTo=function SyncTo_Layout(element){ element[OxOe4f9[0x1c]][OxOe4f9[0x1d]]=sel_position[OxOe4f9[0x1e]] ; element[OxOe4f9[0x1c]][OxOe4f9[0x1f]]=sel_display[OxOe4f9[0x1e]] ;if(Browser_IsWinIE()){ element[OxOe4f9[0x1c]][OxOe4f9[0x20]]=sel_float[OxOe4f9[0x1e]] ;} else { element[OxOe4f9[0x1c]][OxOe4f9[0x21]]=sel_float[OxOe4f9[0x1e]] ;} ; element[OxOe4f9[0x1c]][OxOe4f9[0x22]]=sel_clear[OxOe4f9[0x1e]] ;var arr=[OxOe4f9[0x23],OxOe4f9[0x24],OxOe4f9[0x25],OxOe4f9[0x26]];for(var Ox171=0x0;Ox171<arr[OxOe4f9[0x27]];Ox171++){var n=arr[Ox171];var Ox42=document.getElementById(OxOe4f9[0x28]+n);if(ParseFloatToString(Ox42.value)){ element[OxOe4f9[0x1c]][n]=ParseFloatToString(Ox42.value)+document.all(OxOe4f9[0x29]+n+OxOe4f9[0x2a])[OxOe4f9[0x1e]] ;} else { element[OxOe4f9[0x1c]][n]=OxOe4f9[0x0] ;} ;} ;var arr=[OxOe4f9[0x23],OxOe4f9[0x24],OxOe4f9[0x2d],OxOe4f9[0x2e]];for(var Ox171=0x0;Ox171<arr[OxOe4f9[0x27]];Ox171++){var n=arr[Ox171];var Ox57b=OxOe4f9[0x2f]+n.charAt(0x0).toUpperCase()+n.substring(0x1);var Ox42=document.getElementById(OxOe4f9[0x30]+n);if(ParseFloatToString(Ox42.value)){ element[OxOe4f9[0x1c]][Ox57b]=ParseFloatToString(Ox42.value)+document.all(OxOe4f9[0x31]+n+OxOe4f9[0x2a])[OxOe4f9[0x1e]] ;} else { element[OxOe4f9[0x1c]][Ox57b]=OxOe4f9[0x0] ;} ;} ; element[OxOe4f9[0x1c]][OxOe4f9[0x33]]=sel_overflow[OxOe4f9[0x1e]] ; element[OxOe4f9[0x1c]][OxOe4f9[0x34]]=ParseFloatToString(tb_zindex.value) ; element[OxOe4f9[0x1c]][OxOe4f9[0x35]]=sel_pagebreakbefore[OxOe4f9[0x1e]] ; element[OxOe4f9[0x1c]][OxOe4f9[0x36]]=sel_pagebreakafter[OxOe4f9[0x1e]] ;}  ;