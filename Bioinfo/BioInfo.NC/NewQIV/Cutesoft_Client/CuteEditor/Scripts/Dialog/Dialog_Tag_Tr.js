var OxOaf81=["inp_width","inp_height","sel_align","sel_valign","inp_bgColor","inp_borderColor","inp_borderColorLight","inp_borderColorDark","inp_class","inp_id","inp_tooltip","backgroundColor","style","bgColor","value","id","borderColor","borderColorLight","borderColorDark","className","width","height","align","vAlign","title","[[ValidNumber]]","[[ValidID]]","","class","valign","onclick"];var inp_width=Window_GetElement(window,OxOaf81[0x0],true);var inp_height=Window_GetElement(window,OxOaf81[0x1],true);var sel_align=Window_GetElement(window,OxOaf81[0x2],true);var sel_valign=Window_GetElement(window,OxOaf81[0x3],true);var inp_bgColor=Window_GetElement(window,OxOaf81[0x4],true);var inp_borderColor=Window_GetElement(window,OxOaf81[0x5],true);var inp_borderColorLight=Window_GetElement(window,OxOaf81[0x6],true);var inp_borderColorDark=Window_GetElement(window,OxOaf81[0x7],true);var inp_class=Window_GetElement(window,OxOaf81[0x8],true);var inp_id=Window_GetElement(window,OxOaf81[0x9],true);var inp_tooltip=Window_GetElement(window,OxOaf81[0xa],true); SyncToView=function SyncToView_Tr(){ inp_bgColor[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0xd])||element[OxOaf81[0xc]][OxOaf81[0xb]] ; inp_id[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0xf]) ; inp_bgColor[OxOaf81[0xc]][OxOaf81[0xb]]=inp_bgColor[OxOaf81[0xe]] ; inp_borderColor[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x10]) ; inp_borderColor[OxOaf81[0xc]][OxOaf81[0xb]]=inp_borderColor[OxOaf81[0xe]] ; inp_borderColorLight[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x11]) ; inp_borderColorLight[OxOaf81[0xc]][OxOaf81[0xb]]=inp_borderColorLight[OxOaf81[0xe]] ; inp_borderColorDark[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x12]) ; inp_borderColorDark[OxOaf81[0xc]][OxOaf81[0xb]]=inp_borderColorDark[OxOaf81[0xe]] ; inp_class[OxOaf81[0xe]]=element[OxOaf81[0x13]] ; inp_width[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x14])||element[OxOaf81[0xc]][OxOaf81[0x14]] ; inp_height[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x15])||element[OxOaf81[0xc]][OxOaf81[0x15]] ; sel_align[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x16]) ; sel_valign[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x17]) ; inp_tooltip[OxOaf81[0xe]]=element.getAttribute(OxOaf81[0x18]) ;}  ; SyncTo=function SyncTo_Tr(element){if(inp_bgColor[OxOaf81[0xe]]){if(element[OxOaf81[0xc]][OxOaf81[0xb]]){ element[OxOaf81[0xc]][OxOaf81[0xb]]=inp_bgColor[OxOaf81[0xe]] ;} else { element[OxOaf81[0xd]]=inp_bgColor[OxOaf81[0xe]] ;} ;} else { element.removeAttribute(OxOaf81[0xd]) ;} ; element[OxOaf81[0x10]]=inp_borderColor[OxOaf81[0xe]] ; element[OxOaf81[0x11]]=inp_borderColorLight[OxOaf81[0xe]] ; element[OxOaf81[0x12]]=inp_borderColorDark[OxOaf81[0xe]] ; element[OxOaf81[0x13]]=inp_class[OxOaf81[0xe]] ;if(element[OxOaf81[0xc]][OxOaf81[0x14]]||element[OxOaf81[0xc]][OxOaf81[0x15]]){try{ element[OxOaf81[0xc]][OxOaf81[0x14]]=inp_width[OxOaf81[0xe]] ; element[OxOaf81[0xc]][OxOaf81[0x15]]=inp_height[OxOaf81[0xe]] ;} catch(er){ alert(OxOaf81[0x19]) ;} ;} else {try{ element[OxOaf81[0x14]]=inp_width[OxOaf81[0xe]] ; element[OxOaf81[0x15]]=inp_height[OxOaf81[0xe]] ;} catch(er){ alert(OxOaf81[0x19]) ;} ;} ;var Ox2ec=/[^a-z\d]/i;if(Ox2ec.test(inp_id.value)){ alert(OxOaf81[0x1a]) ;return ;} ; element[OxOaf81[0x16]]=sel_align[OxOaf81[0xe]] ; element[OxOaf81[0xf]]=inp_id[OxOaf81[0xe]] ; element[OxOaf81[0x17]]=sel_valign[OxOaf81[0xe]] ; element[OxOaf81[0x18]]=inp_tooltip[OxOaf81[0xe]] ;if(element[OxOaf81[0xf]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0xf]) ;} ;if(element[OxOaf81[0xd]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0xd]) ;} ;if(element[OxOaf81[0x10]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x10]) ;} ;if(element[OxOaf81[0x11]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x11]) ;} ;if(element[OxOaf81[0x7]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x7]) ;} ;if(element[OxOaf81[0x13]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x13]) ;} ;if(element[OxOaf81[0x13]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x1c]) ;} ;if(element[OxOaf81[0x16]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x16]) ;} ;if(element[OxOaf81[0x17]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x1d]) ;} ;if(element[OxOaf81[0x18]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x18]) ;} ;if(element[OxOaf81[0x14]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x14]) ;} ;if(element[OxOaf81[0x15]]==OxOaf81[0x1b]){ element.removeAttribute(OxOaf81[0x15]) ;} ;}  ; inp_borderColor[OxOaf81[0x1e]]=function inp_borderColor_onclick(){ SelectColor(inp_borderColor) ;}  ; inp_bgColor[OxOaf81[0x1e]]=function inp_bgColor_onclick(){ SelectColor(inp_bgColor) ;}  ; inp_borderColorLight[OxOaf81[0x1e]]=function inp_borderColorLight_onclick(){ SelectColor(inp_borderColorLight) ;}  ; inp_borderColorDark[OxOaf81[0x1e]]=function inp_borderColorDark_onclick(){ SelectColor(inp_borderColorDark) ;}  ;