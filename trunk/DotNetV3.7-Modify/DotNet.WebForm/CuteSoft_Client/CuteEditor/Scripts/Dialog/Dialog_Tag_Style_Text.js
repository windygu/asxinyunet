var OxO11c9=["","sel_align","sel_valign","sel_justify","sel_letter","tb_letter","sel_letter_unit","sel_line","tb_line","sel_line_unit","tb_indent","sel_indent_unit","sel_direction","sel_writingmode","outer","div_demo","disabled","selectedIndex","cssText","style","textAlign","value","verticalAlign","textJustify","letterSpacing","length","options","lineHeight","textIndent","direction","writingMode"]; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO11c9[0x0];} ;return Ox8+OxO11c9[0x0];}  ;var sel_align=Window_GetElement(window,OxO11c9[0x1], true);var sel_valign=Window_GetElement(window,OxO11c9[0x2], true);var sel_justify=Window_GetElement(window,OxO11c9[0x3], true);var sel_letter=Window_GetElement(window,OxO11c9[0x4], true);var tb_letter=Window_GetElement(window,OxO11c9[0x5], true);var sel_letter_unit=Window_GetElement(window,OxO11c9[0x6], true);var sel_line=Window_GetElement(window,OxO11c9[0x7], true);var tb_line=Window_GetElement(window,OxO11c9[0x8], true);var sel_line_unit=Window_GetElement(window,OxO11c9[0x9], true);var tb_indent=Window_GetElement(window,OxO11c9[0xa], true);var sel_indent_unit=Window_GetElement(window,OxO11c9[0xb], true);var sel_direction=Window_GetElement(window,OxO11c9[0xc], true);var sel_writingmode=Window_GetElement(window,OxO11c9[0xd], true);var outer=Window_GetElement(window,OxO11c9[0xe], true);var div_demo=Window_GetElement(window,OxO11c9[0xf], true); UpdateState=function UpdateState_Text(){ tb_letter[OxO11c9[0x10]]=sel_letter_unit[OxO11c9[0x10]]=(sel_letter[OxO11c9[0x11]]>0x0) ; tb_line[OxO11c9[0x10]]=sel_line_unit[OxO11c9[0x10]]=(sel_line[OxO11c9[0x11]]>0x0) ; div_demo[OxO11c9[0x13]][OxO11c9[0x12]]=element[OxO11c9[0x13]][OxO11c9[0x12]] ;}  ; SyncToView=function SyncToView_Text(){ sel_align[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x14]] ; sel_valign[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x16]] ; sel_justify[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x17]] ; sel_letter[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x18]] ; sel_letter_unit[OxO11c9[0x11]]=0x0 ;if(sel_letter[OxO11c9[0x11]]==-0x1){if(ParseFloatToString(element[OxO11c9[0x13]].letterSpacing)){ tb_letter[OxO11c9[0x15]]=ParseFloatToString(element[OxO11c9[0x13]].letterSpacing) ;for(var i=0x0;i<sel_letter_unit[OxO11c9[0x1a]][OxO11c9[0x19]];i++){var Ox134=sel_letter_unit[OxO11c9[0x1a]][i][OxO11c9[0x15]];if(Ox134&&element[OxO11c9[0x13]][OxO11c9[0x18]].indexOf(Ox134)!=-0x1){ sel_letter_unit[OxO11c9[0x11]]=i ;break ;} ;} ;} ;} ; sel_line[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x1b]] ; sel_line_unit[OxO11c9[0x11]]=0x0 ;if(sel_line[OxO11c9[0x11]]==-0x1){if(ParseFloatToString(element[OxO11c9[0x13]].lineHeight)){ tb_line[OxO11c9[0x15]]=ParseFloatToString(element[OxO11c9[0x13]].lineHeight) ;for(var i=0x0;i<sel_line_unit[OxO11c9[0x1a]][OxO11c9[0x19]];i++){var Ox134=sel_line_unit[OxO11c9[0x1a]][i][OxO11c9[0x15]];if(Ox134&&element[OxO11c9[0x13]][OxO11c9[0x1b]].indexOf(Ox134)!=-0x1){ sel_line_unit[OxO11c9[0x11]]=i ;break ;} ;} ;} ;} ; sel_indent_unit[OxO11c9[0x11]]=0x0 ;if(!isNaN(ParseFloatToString(element[OxO11c9[0x13]].textIndent))){ tb_indent[OxO11c9[0x15]]=ParseFloatToString(element[OxO11c9[0x13]].textIndent) ;for(var i=0x0;i<sel_indent_unit[OxO11c9[0x1a]][OxO11c9[0x19]];i++){var Ox134=sel_indent_unit[OxO11c9[0x1a]][i][OxO11c9[0x15]];if(Ox134&&element[OxO11c9[0x13]][OxO11c9[0x1c]].indexOf(Ox134)!=-0x1){ sel_indent_unit[OxO11c9[0x11]]=i ;break ;} ;} ;} ; sel_direction[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x1d]] ; sel_writingmode[OxO11c9[0x15]]=element[OxO11c9[0x13]][OxO11c9[0x1e]] ;}  ; SyncTo=function SyncTo_Text(element){ element[OxO11c9[0x13]][OxO11c9[0x14]]=sel_align[OxO11c9[0x15]] ; element[OxO11c9[0x13]][OxO11c9[0x16]]=sel_valign[OxO11c9[0x15]] ; element[OxO11c9[0x13]][OxO11c9[0x17]]=sel_justify[OxO11c9[0x15]] ;if(sel_letter[OxO11c9[0x11]]>0x0){ element[OxO11c9[0x13]][OxO11c9[0x18]]=sel_letter[OxO11c9[0x15]] ;} else {if(ParseFloatToString(tb_letter.value)){ element[OxO11c9[0x13]][OxO11c9[0x18]]=ParseFloatToString(tb_letter.value)+sel_letter_unit[OxO11c9[0x15]] ;} else { element[OxO11c9[0x13]][OxO11c9[0x18]]=OxO11c9[0x0] ;} ;} ;if(sel_line[OxO11c9[0x11]]>0x0){ element[OxO11c9[0x13]][OxO11c9[0x1b]]=sel_line[OxO11c9[0x15]] ;} else {if(ParseFloatToString(tb_line.value)){ element[OxO11c9[0x13]][OxO11c9[0x1b]]=ParseFloatToString(tb_line.value)+sel_line_unit[OxO11c9[0x15]] ;} else { element[OxO11c9[0x13]][OxO11c9[0x1b]]=OxO11c9[0x0] ;} ;} ;if(ParseFloatToString(tb_indent.value)){ element[OxO11c9[0x13]][OxO11c9[0x1c]]=ParseFloatToString(tb_indent.value)+sel_indent_unit[OxO11c9[0x15]] ;} else { element[OxO11c9[0x13]][OxO11c9[0x1c]]=OxO11c9[0x0] ;} ; element[OxO11c9[0x13]][OxO11c9[0x1d]]=sel_direction[OxO11c9[0x15]]||OxO11c9[0x0] ; element[OxO11c9[0x13]][OxO11c9[0x1e]]=sel_writingmode[OxO11c9[0x15]]||OxO11c9[0x0] ;}  ;