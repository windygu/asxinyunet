var OxO4d41=["SetStyle","length","","GetStyle","GetText",":",";","cssText","div_selector_event","div_selector","sel_part","tb_margin","sel_margin_unit","tb_padding","sel_padding_unit","tb_border","sel_border_unit","sel_border","sel_style","inp_color","inp_color_Preview","outer","div_demo","offsetWidth","offsetHeight","Top","Left","Bottom","Right","onmousemove","runtimeStyle","border","4px solid red","style","onmouseout","onclick","value","onchange","disabled","selectedIndex","4px solid blue","-","Color"," ","#7f7c75","backgroundColor","Style","Width","options","margin","padding"]; function pause(Ox41d){var Ox91= new Date();var Ox41e=Ox91.getTime()+Ox41d;while(true){ Ox91= new Date() ;if(Ox91.getTime()>Ox41e){return ;} ;} ;}  ; function StyleClass(Ox176){var Ox420=[];var Ox421={};if(Ox176){ Ox426() ;} ; this[OxO4d41[0x0]]=function SetStyle(name,Ox115,Ox423){ name=name.toLowerCase() ;for(var i=0x0;i<Ox420[OxO4d41[0x1]];i++){if(Ox420[i]==name){break ;} ;} ; Ox420[i]=name ; Ox421[name]=Ox115?(Ox115+(Ox423||OxO4d41[0x2])):OxO4d41[0x2] ;}  ; this[OxO4d41[0x3]]=function GetStyle(name){ name=name.toLowerCase() ;return Ox421[name]||OxO4d41[0x2];}  ; this[OxO4d41[0x4]]=function Ox425(){var Ox176=OxO4d41[0x2];for(var i=0x0;i<Ox420[OxO4d41[0x1]];i++){var n=Ox420[i];var p=Ox421[n];if(p){ Ox176+=n+OxO4d41[0x5]+p+OxO4d41[0x6] ;} ;} ;return Ox176;}  ; function Ox426(){var arr=Ox176.split(OxO4d41[0x6]);for(var i=0x0;i<arr[OxO4d41[0x1]];i++){var p=arr[i].split(OxO4d41[0x5]);var n=p[0x0].replace(/^\s+/g,OxO4d41[0x2]).replace(/\s+$/g,OxO4d41[0x2]).toLowerCase(); Ox420[Ox420[OxO4d41[0x1]]]=n ; Ox421[n]=p[0x1] ;} ;}  ;}  ; function GetStyle(Ox129,name){return  new StyleClass(Ox129.cssText).GetStyle(name);}  ; function SetStyle(Ox129,name,Ox115,Ox427){var Ox428= new StyleClass(Ox129.cssText); Ox428.SetStyle(name,Ox115,Ox427) ; Ox129[OxO4d41[0x7]]=Ox428.GetText() ;}  ; function ParseFloatToString(Ox24){var Ox8=parseFloat(Ox24);if(isNaN(Ox8)){return OxO4d41[0x2];} ;return Ox8+OxO4d41[0x2];}  ;var div_selector_event=Window_GetElement(window,OxO4d41[0x8], true);var div_selector=Window_GetElement(window,OxO4d41[0x9], true);var sel_part=Window_GetElement(window,OxO4d41[0xa], true);var tb_margin=Window_GetElement(window,OxO4d41[0xb], true);var sel_margin_unit=Window_GetElement(window,OxO4d41[0xc], true);var tb_padding=Window_GetElement(window,OxO4d41[0xd], true);var sel_padding_unit=Window_GetElement(window,OxO4d41[0xe], true);var tb_border=Window_GetElement(window,OxO4d41[0xf], true);var sel_border_unit=Window_GetElement(window,OxO4d41[0x10], true);var sel_border=Window_GetElement(window,OxO4d41[0x11], true);var sel_style=Window_GetElement(window,OxO4d41[0x12], true);var inp_color=Window_GetElement(window,OxO4d41[0x13], true);var inp_color_Preview=Window_GetElement(window,OxO4d41[0x14], true);var outer=Window_GetElement(window,OxO4d41[0x15], true);var div_demo=Window_GetElement(window,OxO4d41[0x16], true); function GetPartFromEvent(){var src=Event_GetSrcElement();var x=Event_GetOffsetX();var y=Event_GetOffsetY();if(src==div_selector){ x+=0xa ; y+=0xa ;} ;var Ox11=0xf-x;var Oxa=x-(div_selector_event[OxO4d41[0x17]]-0xf);var Ox12=0xf-y;var Oxc=y-(div_selector_event[OxO4d41[0x18]]-0xf);if(Ox11>0x0){if(Ox12>0x0){return Ox11>Ox12?OxO4d41[0x19]:OxO4d41[0x1a];} ;if(Oxc>0x0){return Ox11>Oxc?OxO4d41[0x1b]:OxO4d41[0x1a];} ;return OxO4d41[0x1a];} ;if(Oxa>0x0){if(Ox12>0x0){return Oxa>Ox12?OxO4d41[0x19]:OxO4d41[0x1c];} ;if(Oxc>0x0){return Oxa>Oxc?OxO4d41[0x1b]:OxO4d41[0x1c];} ;return OxO4d41[0x1c];} ;if(Ox12>0x0){return OxO4d41[0x19];} ;if(Oxc>0x0){return OxO4d41[0x1b];} ;return OxO4d41[0x2];}  ; div_selector_event[OxO4d41[0x1d]]=function div_selector_event_onmousemove(){var Ox440=GetPartFromEvent();if(Browser_IsWinIE()){ div_selector[OxO4d41[0x1e]][OxO4d41[0x7]]=OxO4d41[0x2] ; div_selector[OxO4d41[0x1e]][OxO4d41[0x1f]+Ox440]=OxO4d41[0x20] ;} else { div_selector[OxO4d41[0x21]][OxO4d41[0x7]]=OxO4d41[0x2] ; div_selector[OxO4d41[0x21]][OxO4d41[0x1f]+Ox440]=OxO4d41[0x20] ;} ;}  ; div_selector_event[OxO4d41[0x22]]=function div_selector_event_onmouseout(){if(Browser_IsWinIE()){ div_selector[OxO4d41[0x1e]][OxO4d41[0x7]]=OxO4d41[0x2] ;} else { div_selector[OxO4d41[0x21]][OxO4d41[0x7]]=OxO4d41[0x2] ;} ;}  ; div_selector_event[OxO4d41[0x23]]=function div_selector_event_onclick(){ sel_part[OxO4d41[0x24]]=GetPartFromEvent() ; SyncToViewInternal() ; UpdateState() ;}  ; sel_part[OxO4d41[0x25]]=function sel_part_onchange(){ SyncToViewInternal() ; UpdateState() ;}  ; UpdateState=function UpdateState_Border(){ tb_border[OxO4d41[0x26]]=sel_border_unit[OxO4d41[0x26]]=(sel_border[OxO4d41[0x27]]>0x0) ; div_demo[OxO4d41[0x21]][OxO4d41[0x7]]=element[OxO4d41[0x21]][OxO4d41[0x7]] ; div_selector[OxO4d41[0x21]][OxO4d41[0x7]]=OxO4d41[0x2] ; div_selector[OxO4d41[0x21]][OxO4d41[0x1f]+(sel_part[OxO4d41[0x24]]||OxO4d41[0x2])]=OxO4d41[0x28] ;}  ; SyncToView=function SyncToView_Border(){var Ox440=sel_part[OxO4d41[0x24]];var Ox441=Ox440?OxO4d41[0x29]+Ox440:Ox440;if(Browser_IsWinIE()){ inp_color[OxO4d41[0x24]]=element[OxO4d41[0x21]][OxO4d41[0x1f]+Ox440+OxO4d41[0x2a]] ;} else {var arr=revertColor(element[OxO4d41[0x21]][OxO4d41[0x1f]+Ox440+OxO4d41[0x2a]]).split(OxO4d41[0x2b]);if(arr[0x0]!=OxO4d41[0x2c]){ inp_color[OxO4d41[0x24]]=arr[0x0] ;} ;} ; inp_color[OxO4d41[0x21]][OxO4d41[0x2d]]=inp_color[OxO4d41[0x24]] ; sel_style[OxO4d41[0x24]]=element[OxO4d41[0x21]][OxO4d41[0x1f]+Ox440+OxO4d41[0x2e]] ; sel_border[OxO4d41[0x24]]=element[OxO4d41[0x21]][OxO4d41[0x1f]+Ox440+OxO4d41[0x2f]] ;var Ox54b=element[OxO4d41[0x21]][OxO4d41[0x1f]+Ox440+OxO4d41[0x2f]]; tb_border[OxO4d41[0x24]]=ParseFloatToString(Ox54b) ;if(tb_border[OxO4d41[0x24]]){for(var i=0x0;i<sel_border_unit[OxO4d41[0x30]][OxO4d41[0x1]];i++){var Ox134=sel_border_unit[OxO4d41[0x30]][i][OxO4d41[0x24]];if(Ox134&&Ox54b.indexOf(Ox134)!=-0x1){ sel_border_unit[OxO4d41[0x27]]=i ;break ;} ;} ;} ;var Ox54c=element[OxO4d41[0x21]][OxO4d41[0x31]+Ox440]; tb_margin[OxO4d41[0x24]]=ParseFloatToString(Ox54c) ;if(tb_margin[OxO4d41[0x24]]){for(var i=0x0;i<sel_margin_unit[OxO4d41[0x30]][OxO4d41[0x1]];i++){var Ox134=sel_margin_unit[OxO4d41[0x30]][i][OxO4d41[0x24]];if(Ox134&&Ox54c.indexOf(Ox134)!=-0x1){ sel_margin_unit[OxO4d41[0x27]]=i ;break ;} ;} ;} ;var Ox54d=element[OxO4d41[0x21]][OxO4d41[0x32]+Ox440]; tb_padding[OxO4d41[0x24]]=ParseFloatToString(Ox54d) ;if(tb_padding[OxO4d41[0x24]]){for(var i=0x0;i<sel_padding_unit[OxO4d41[0x30]][OxO4d41[0x1]];i++){var Ox134=sel_padding_unit[OxO4d41[0x30]][i][OxO4d41[0x24]];if(Ox134&&Ox54d.indexOf(Ox134)!=-0x1){ sel_padding_unit[OxO4d41[0x27]]=i ;break ;} ;} ;} ;}  ; SyncTo=function SyncTo_Border(element){var Ox440=sel_part[OxO4d41[0x24]];var Ox441=Ox440?OxO4d41[0x29]+Ox440:Ox440;var Ox442=OxO4d41[0x2];if(sel_border[OxO4d41[0x27]]>0x0){ Ox442=sel_border[OxO4d41[0x24]] ;} else {if(ParseFloatToString(tb_border.value)){ Ox442=ParseFloatToString(tb_border.value)+sel_border_unit[OxO4d41[0x24]] ;} else { Ox442=OxO4d41[0x2] ;} ;} ;var Oxc5=inp_color[OxO4d41[0x24]]||OxO4d41[0x2];var Ox129=sel_style[OxO4d41[0x24]]||OxO4d41[0x2];if(Ox442||Ox129){ SetStyle(element[OxO4d41[0x21]],OxO4d41[0x1f]+Ox441,Ox442+OxO4d41[0x2b]+Ox129+OxO4d41[0x2b]+Oxc5) ;} else { SetStyle(element[OxO4d41[0x21]],OxO4d41[0x1f]+Ox441,OxO4d41[0x2]) ;} ; SetStyle(element[OxO4d41[0x21]],OxO4d41[0x31]+Ox441,ParseFloatToString(tb_margin.value),sel_margin_unit.value) ; SetStyle(element[OxO4d41[0x21]],OxO4d41[0x32]+Ox441,ParseFloatToString(tb_padding.value),sel_padding_unit.value) ;}  ; inp_color[OxO4d41[0x23]]=inp_color_Preview[OxO4d41[0x23]]=function inp_color_onclick(){ SelectColor(inp_color,inp_color_Preview) ;}  ;