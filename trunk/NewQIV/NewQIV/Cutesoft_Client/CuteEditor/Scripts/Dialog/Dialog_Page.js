var OxO9ea5=["Table1","Table2","inp_title","inp_doctype","inp_description","inp_keywords","PageLanguage","HTMLEncoding","bgcolor","bgcolor_Preview","fontcolor","fontcolor_Preview","Backgroundimage","btnbrowse","TopMargin","BottomMargin","LeftMargin","RightMargin","MarginWidth","MarginHeight","btnok","btncc","editor","window","document","body","head","title","innerHTML","value","DOCTYPE","meta","length","name","keywords","content","description","httpEquiv","content-type","content-language","background","color","style","backgroundColor","bgColor","topMargin","bottomMargin","leftMargin","rightMargin","marginWidth","marginHeight","","[[ValidNumber]]","Please enter a valid color number.","text","childNodes","parentNode","http-equiv","Content-Type","Content-Language","\x3CMETA ","=\x22","\x22 CONTENT=\x22","\x22\x3E","META","onclick"];var Table1=Window_GetElement(window,OxO9ea5[0x0],true);var Table2=Window_GetElement(window,OxO9ea5[0x1],true);var inp_title=Window_GetElement(window,OxO9ea5[0x2],true);var inp_doctype=Window_GetElement(window,OxO9ea5[0x3],true);var inp_description=Window_GetElement(window,OxO9ea5[0x4],true);var inp_keywords=Window_GetElement(window,OxO9ea5[0x5],true);var PageLanguage=Window_GetElement(window,OxO9ea5[0x6],true);var HTMLEncoding=Window_GetElement(window,OxO9ea5[0x7],true);var bgcolor=Window_GetElement(window,OxO9ea5[0x8],true);var bgcolor_Preview=Window_GetElement(window,OxO9ea5[0x9],true);var fontcolor=Window_GetElement(window,OxO9ea5[0xa],true);var fontcolor_Preview=Window_GetElement(window,OxO9ea5[0xb],true);var Backgroundimage=Window_GetElement(window,OxO9ea5[0xc],true);var btnbrowse=Window_GetElement(window,OxO9ea5[0xd],true);var TopMargin=Window_GetElement(window,OxO9ea5[0xe],true);var BottomMargin=Window_GetElement(window,OxO9ea5[0xf],true);var LeftMargin=Window_GetElement(window,OxO9ea5[0x10],true);var RightMargin=Window_GetElement(window,OxO9ea5[0x11],true);var MarginWidth=Window_GetElement(window,OxO9ea5[0x12],true);var MarginHeight=Window_GetElement(window,OxO9ea5[0x13],true);var btnok=Window_GetElement(window,OxO9ea5[0x14],true);var btncc=Window_GetElement(window,OxO9ea5[0x15],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxO9ea5[0x16]];var editwin=obj[OxO9ea5[0x17]];var editdoc=obj[OxO9ea5[0x18]];var body=editdoc[OxO9ea5[0x19]];var head=obj[OxO9ea5[0x1a]];var title=head.getElementsByTagName(OxO9ea5[0x1b])[0x0];if(title){ inp_title[OxO9ea5[0x1d]]=title[OxO9ea5[0x1c]] ;} ; inp_doctype[OxO9ea5[0x1d]]=obj[OxO9ea5[0x1e]] ;var metas=head.getElementsByTagName(OxO9ea5[0x1f]);for(var m=0x0;m<metas[OxO9ea5[0x20]];m++){if(metas[m][OxO9ea5[0x21]].toLowerCase()==OxO9ea5[0x22]){ inp_keywords[OxO9ea5[0x1d]]=metas[m][OxO9ea5[0x23]] ;} ;if(metas[m][OxO9ea5[0x21]].toLowerCase()==OxO9ea5[0x24]){ inp_description[OxO9ea5[0x1d]]=metas[m][OxO9ea5[0x23]] ;} ;if(metas[m][OxO9ea5[0x25]].toLowerCase()==OxO9ea5[0x26]){ HTMLEncoding[OxO9ea5[0x1d]]=metas[m][OxO9ea5[0x23]] ;} ;if(metas[m][OxO9ea5[0x25]].toLowerCase()==OxO9ea5[0x27]){ PageLanguage[OxO9ea5[0x1d]]=metas[m][OxO9ea5[0x23]] ;} ;} ;if(editdoc[OxO9ea5[0x19]][OxO9ea5[0x28]]){ Backgroundimage[OxO9ea5[0x1d]]=editdoc[OxO9ea5[0x19]][OxO9ea5[0x28]] ;} ;if(editdoc[OxO9ea5[0x19]][OxO9ea5[0x2a]][OxO9ea5[0x29]]){ fontcolor[OxO9ea5[0x1d]]=editdoc[OxO9ea5[0x19]][OxO9ea5[0x2a]][OxO9ea5[0x29]] ; fontcolor[OxO9ea5[0x2a]][OxO9ea5[0x2b]]=fontcolor[OxO9ea5[0x1d]] ; fontcolor_Preview[OxO9ea5[0x2a]][OxO9ea5[0x2b]]=fontcolor[OxO9ea5[0x1d]] ;} ;var body_bgcolor=editdoc[OxO9ea5[0x19]][OxO9ea5[0x2a]][OxO9ea5[0x2b]]||editdoc[OxO9ea5[0x19]][OxO9ea5[0x2c]];if(body_bgcolor){ bgcolor[OxO9ea5[0x1d]]=body_bgcolor ; bgcolor[OxO9ea5[0x2a]][OxO9ea5[0x2b]]=body_bgcolor ; bgcolor_Preview[OxO9ea5[0x2a]][OxO9ea5[0x2b]]=body_bgcolor ;} ;if(Browser_IsWinIE()){if(body[OxO9ea5[0x2d]]){ TopMargin[OxO9ea5[0x1d]]=body[OxO9ea5[0x2d]] ;} ;if(body[OxO9ea5[0x2e]]){ BottomMargin[OxO9ea5[0x1d]]=body[OxO9ea5[0x2e]] ;} ;if(body[OxO9ea5[0x2f]]){ LeftMargin[OxO9ea5[0x1d]]=body[OxO9ea5[0x2f]] ;} ;if(body[OxO9ea5[0x30]]){ RightMargin[OxO9ea5[0x1d]]=body[OxO9ea5[0x30]] ;} ;if(body[OxO9ea5[0x31]]){ MarginWidth[OxO9ea5[0x1d]]=body[OxO9ea5[0x31]] ;} ;if(body[OxO9ea5[0x32]]){ MarginHeight[OxO9ea5[0x1d]]=body[OxO9ea5[0x32]] ;} ;} else {if(body.getAttribute(OxO9ea5[0x2d])){ TopMargin[OxO9ea5[0x1d]]=body.getAttribute(OxO9ea5[0x2d]) ;} ;if(body.getAttribute(OxO9ea5[0x2e])){ BottomMargin[OxO9ea5[0x1d]]=body.getAttribute(OxO9ea5[0x2e]) ;} ;if(body.getAttribute(OxO9ea5[0x2f])){ LeftMargin[OxO9ea5[0x1d]]=body.getAttribute(OxO9ea5[0x2f]) ;} ;if(body.getAttribute(OxO9ea5[0x30])){ RightMargin[OxO9ea5[0x1d]]=body.getAttribute(OxO9ea5[0x30]) ;} ;if(body.getAttribute(OxO9ea5[0x12])){ MarginWidth[OxO9ea5[0x1d]]=body.getAttribute(OxO9ea5[0x31]) ;} ;if(body.getAttribute(OxO9ea5[0x32])){ MarginHeight[OxO9ea5[0x1d]]=body.getAttribute(OxO9ea5[0x32]) ;} ;} ; function do_insert(){try{if(Browser_IsWinIE()){ body[OxO9ea5[0x2d]]=TopMargin[OxO9ea5[0x1d]] ; body[OxO9ea5[0x2e]]=BottomMargin[OxO9ea5[0x1d]] ; body[OxO9ea5[0x2f]]=LeftMargin[OxO9ea5[0x1d]] ; body[OxO9ea5[0x30]]=RightMargin[OxO9ea5[0x1d]] ;if(MarginWidth[OxO9ea5[0x1d]]){ body[OxO9ea5[0x31]]=MarginWidth[OxO9ea5[0x1d]] ;} ;if(MarginHeight[OxO9ea5[0x1d]]){ body[OxO9ea5[0x32]]=MarginHeight[OxO9ea5[0x1d]] ;} ;} else { body.setAttribute(OxO9ea5[0x2d],TopMargin.value) ; body.setAttribute(OxO9ea5[0x2e],BottomMargin.value) ; body.setAttribute(OxO9ea5[0x2f],LeftMargin.value) ; body.setAttribute(OxO9ea5[0x30],RightMargin.value) ; body.setAttribute(OxO9ea5[0x31],MarginWidth.value) ; body.setAttribute(OxO9ea5[0x32],MarginHeight.value) ;if(body.getAttribute(OxO9ea5[0x2d])==OxO9ea5[0x33]){ body.removeAttribute(OxO9ea5[0x2d]) ;} ;if(body.getAttribute(OxO9ea5[0x2e])==OxO9ea5[0x33]){ body.removeAttribute(OxO9ea5[0x2e]) ;} ;if(body.getAttribute(OxO9ea5[0x2f])==OxO9ea5[0x33]){ body.removeAttribute(OxO9ea5[0x2f]) ;} ;if(body.getAttribute(OxO9ea5[0x30])==OxO9ea5[0x33]){ body.removeAttribute(OxO9ea5[0x30]) ;} ;if(body.getAttribute(OxO9ea5[0x31])==OxO9ea5[0x33]){ body.removeAttribute(OxO9ea5[0x31]) ;} ;if(body.getAttribute(OxO9ea5[0x32])==OxO9ea5[0x33]){ body.removeAttribute(OxO9ea5[0x32]) ;} ;} ;} catch(er){ alert(OxO9ea5[0x34]) ;return ;} ;try{ editdoc[OxO9ea5[0x19]][OxO9ea5[0x2a]][OxO9ea5[0x2b]]=bgcolor[OxO9ea5[0x1d]] ; editdoc[OxO9ea5[0x19]][OxO9ea5[0x2a]][OxO9ea5[0x29]]=fontcolor[OxO9ea5[0x1d]] ;if(Backgroundimage[OxO9ea5[0x1d]]){ editdoc[OxO9ea5[0x19]][OxO9ea5[0x28]]=Backgroundimage[OxO9ea5[0x1d]] ;} else { body.removeAttribute(OxO9ea5[0x28]) ;} ;} catch(er){ alert(OxO9ea5[0x35]) ;return ;} ;if(!title){ title=document.createElement(OxO9ea5[0x1b]) ; head.appendChild(title) ;} ;if(Browser_IsWinIE()){ title[OxO9ea5[0x36]]=inp_title[OxO9ea5[0x1d]] ;} else {var Ox3d4=document.createTextNode(inp_title.value);try{ title.removeChild(title[OxO9ea5[0x37]].item(0x0)) ;} catch(x){} ; title.appendChild(Ox3d4) ;} ;for(var m=0x0;m<metas[OxO9ea5[0x20]];m++){var Oxa0=metas[m];if(Oxa0){if(Oxa0[OxO9ea5[0x21]].toLowerCase()==OxO9ea5[0x22]||Oxa0[OxO9ea5[0x21]].toLowerCase()==OxO9ea5[0x24]||Oxa0[OxO9ea5[0x21]].toLowerCase()==OxO9ea5[0x26]||Oxa0[OxO9ea5[0x21]].toLowerCase()==OxO9ea5[0x27]){ Oxa0[OxO9ea5[0x38]].removeChild(Oxa0) ; Oxa0=null ;} ;} ;} ;try{if(inp_keywords[OxO9ea5[0x1d]]){ Ox3d5(OxO9ea5[0x21],OxO9ea5[0x22],inp_keywords.value) ;} ;if(inp_description[OxO9ea5[0x1d]]){ Ox3d5(OxO9ea5[0x21],OxO9ea5[0x24],inp_description.value) ;} ;if(HTMLEncoding[OxO9ea5[0x1d]]){ Ox3d5(OxO9ea5[0x39],OxO9ea5[0x3a],HTMLEncoding.value) ;} ;if(PageLanguage[OxO9ea5[0x1d]]){ Ox3d5(OxO9ea5[0x39],OxO9ea5[0x3b],PageLanguage.value) ;} ;} catch(x){} ; function Ox3d5(Ox3d6,name,Oxb7){var Ox3d7;if(Browser_IsWinIE()){ Ox3d7=editdoc.createElement(OxO9ea5[0x3c]+Ox3d6+OxO9ea5[0x3d]+name+OxO9ea5[0x3e]+Oxb7+OxO9ea5[0x3f]) ;} else {var metas=head.getElementsByTagName(OxO9ea5[0x1f]);for(var m=0x0;m<metas[OxO9ea5[0x20]];m++){if(metas[m][OxO9ea5[0x21]].toLowerCase()==name.toLowerCase()){ metas[m][OxO9ea5[0x38]].removeChild(metas[m]) ;} ;} ;var Ox3d7=editdoc.createElement(OxO9ea5[0x40]); Ox3d7.setAttribute(Ox3d6,name) ; Ox3d7.setAttribute(OxO9ea5[0x23],Oxb7) ;} ; head.appendChild(Ox3d7) ;}  ; Window_SetDialogReturnValue(window,inp_doctype[OxO9ea5[0x1d]]+OxO9ea5[0x33]) ; Window_CloseDialog(window) ;}  ; btnbrowse[OxO9ea5[0x41]]=function btnbrowse_onclick(){ function Ox2d3(Ox130){if(Ox130){ Backgroundimage[OxO9ea5[0x1d]]=Ox130 ;} ;}  ; editor.SetNextDialogWindow(window) ;if(Browser_IsSafari()){ editor.ShowSelectImageDialog(Ox2d3,Backgroundimage.value,Backgroundimage) ;} else { editor.ShowSelectImageDialog(Ox2d3,Backgroundimage.value) ;} ;}  ; function do_Close(){ Window_CloseDialog(window) ;}  ; fontcolor[OxO9ea5[0x41]]=fontcolor_Preview[OxO9ea5[0x41]]=function fontcolor_onclick(){ SelectColor(fontcolor,fontcolor_Preview) ;}  ; bgcolor[OxO9ea5[0x41]]=bgcolor_Preview[OxO9ea5[0x41]]=function bgcolor_onclick(){ SelectColor(bgcolor,bgcolor_Preview) ;}  ;