var OxOe445=["string","-1","ok","on","yes","true","1","nodeName","INPUT","TEXTAREA","BUTTON","IMG","SELECT","TABLE","position","style","absolute","relative","|H1|H2|H3|H4|H5|H6|P|PRE|LI|TD|DIV|BLOCKQUOTE|DT|DD|TABLE|HR|IMG|","|","body","document","inp_src","btnbrowse","sel_protocol","inp_target","inp_id","inp_class","inp_access","inp_index","inp_color","inp_color_Preview","inp_title","inp_checked","allanchors","Nofollow","","visibility","hidden","onclick","value","visible","options","length","anchors","OPTION","name","text","#","images","className","cetempAnchor","id","anchorname","://",":","others","selectedIndex","href","href_cetemp","\x26#","EnableAntiSpamEmailEncoder","color","backgroundColor","title","target","tabIndex","accessKey","rel","nofollow","checked","innerHTML","class","[[ValidID]]","\x3Cp\x3E\x26nbsp;\x3C/p\x3E","\x3Cp\x3E\x26#160;\x3C/p\x3E","\x3Cp\x3E\x3C/p\x3E","\x3Cdiv\x3E\x26#160;\x3C/div\x3E","\x3Cdiv\x3E\x26nbsp;\x3C/div\x3E","\x3Cdiv\x3E\x3C/div\x3E",";"]; function ToBoolean(Ox115){if( typeof (Ox115)==OxOe445[0x0]){switch(Ox115.toLowerCase()){case OxOe445[0x6]:case OxOe445[0x5]:case OxOe445[0x4]:case OxOe445[0x3]:case OxOe445[0x2]:case OxOe445[0x1]:return true;default:return false;;;;;;;;} ;} ;return !!Ox115;}  ; function Element_IsBlockControl(element){var name=element[OxOe445[0x7]];if(name==OxOe445[0x8]){return true;} ;if(name==OxOe445[0x9]){return true;} ;if(name==OxOe445[0xa]){return true;} ;if(name==OxOe445[0xb]){return true;} ;if(name==OxOe445[0xc]){return true;} ;if(name==OxOe445[0xd]){return true;} ;var Ox10f=element[OxOe445[0xf]][OxOe445[0xe]];if(Ox10f==OxOe445[0x10]||Ox10f==OxOe445[0x11]){return true;} ;return false;}  ; function Element_CUtil_IsBlock(Ox2e6){var Ox2e7=OxOe445[0x12];return (Ox2e6!=null)&&(Ox2e7.indexOf(OxOe445[0x13]+Ox2e6[OxOe445[0x7]]+OxOe445[0x13])!=-0x1);}  ; function Window_SelectElement(Ox1ae,element){if(Browser_UseIESelection()){if(Element_IsBlockControl(element)){var Ox2f=Ox1ae[OxOe445[0x15]][OxOe445[0x14]].createControlRange(); Ox2f.add(element) ; Ox2f.select() ;} else {var Ox19b=Ox1ae[OxOe445[0x15]][OxOe445[0x14]].createTextRange(); Ox19b.moveToElementText(element) ; Ox19b.select() ;} ;} else {var Ox19b=Ox1ae[OxOe445[0x15]].createRange();try{ Ox19b.selectNode(element) ;} catch(x){ Ox19b.selectNodeContents(element) ;} ;var Ox128=Ox1ae.getSelection(); Ox128.removeAllRanges() ; Ox128.addRange(Ox19b) ;} ;}  ;var inp_src=Window_GetElement(window,OxOe445[0x16], true);var btnbrowse=Window_GetElement(window,OxOe445[0x17], true);var sel_protocol=Window_GetElement(window,OxOe445[0x18], true);var inp_target=Window_GetElement(window,OxOe445[0x19], true);var inp_id=Window_GetElement(window,OxOe445[0x1a], true);var inp_class=Window_GetElement(window,OxOe445[0x1b], true);var inp_access=Window_GetElement(window,OxOe445[0x1c], true);var inp_index=Window_GetElement(window,OxOe445[0x1d], true);var inp_color=Window_GetElement(window,OxOe445[0x1e], true);var inp_color_Preview=Window_GetElement(window,OxOe445[0x1f], true);var inp_title=Window_GetElement(window,OxOe445[0x20], true);var inp_checked=Window_GetElement(window,OxOe445[0x21], true);var allanchors=Window_GetElement(window,OxOe445[0x22], true);var Nofollow=Window_GetElement(window,OxOe445[0x23], true);var originalInnerHTML=OxOe445[0x24];var BaseHref=editor.GetBaseHref(); allanchors[OxOe445[0xf]][OxOe445[0x25]]=OxOe445[0x26] ; btnbrowse[OxOe445[0x27]]=function btnbrowse_onclick(){ function Ox2d4(Ox130){if(Ox130){ inp_src[OxOe445[0x28]]=Ox130 ; SyncTo(element) ;} ;}  ; editor.SetNextDialogWindow(window) ;if(Browser_IsSafari()){ editor.ShowSelectFileDialog(Ox2d4,inp_src.value,inp_src) ;} else { editor.ShowSelectFileDialog(Ox2d4,inp_src.value) ;} ;}  ; function ToggleAnchors(){if(allanchors[OxOe445[0xf]][OxOe445[0x25]]==OxOe445[0x26]){ allanchors[OxOe445[0xf]][OxOe445[0x25]]=OxOe445[0x29] ;} else { allanchors[OxOe445[0xf]][OxOe445[0x25]]=OxOe445[0x26] ;} ;}  ; function updateList(){while(allanchors[OxOe445[0x2a]][OxOe445[0x2b]]!=0x0){ allanchors[OxOe445[0x2a]].remove(allanchors.options(0x0)) ;} ;if(Browser_IsWinIE()){for(var i=0x0;i<editdoc[OxOe445[0x2c]][OxOe445[0x2b]];i++){var Ox2ef=document.createElement(OxOe445[0x2d]); Ox2ef[OxOe445[0x2f]]=OxOe445[0x30]+editdoc[OxOe445[0x2c]][i][OxOe445[0x2e]] ; Ox2ef[OxOe445[0x28]]=editdoc[OxOe445[0x2c]][i][OxOe445[0x2e]] ; allanchors[OxOe445[0x2a]].add(Ox2ef) ;} ;} else {var Ox2f0=editdoc[OxOe445[0x31]];if(Ox2f0){for(var j=0x0;j<Ox2f0[OxOe445[0x2b]];j++){var img=Ox2f0[j];if(img[OxOe445[0x32]]==OxOe445[0x33]){var Ox2ef=document.createElement(OxOe445[0x2d]); Ox2ef[OxOe445[0x28]]=img.getAttribute(OxOe445[0x35])||img[OxOe445[0x2e]]||img[OxOe445[0x34]] ; Ox2ef[OxOe445[0x2f]]=OxOe445[0x30]+Ox2ef[OxOe445[0x28]] ; allanchors[OxOe445[0x2a]].add(Ox2ef) ;} ;} ;} ;} ;}  ; function selectAnchor(Ox2f2){ editor.FocusDocument() ;if(Browser_IsWinIE()){for(var i=0x0;i<editdoc[OxOe445[0x2c]][OxOe445[0x2b]];i++){if(editdoc[OxOe445[0x2c]][i][OxOe445[0x2e]]==Ox2f2){ inp_src[OxOe445[0x28]]=OxOe445[0x30]+Ox2f2 ; Window_SelectElement(editwin,editdoc[OxOe445[0x2c]][i]) ;} ;} ;} else { inp_src[OxOe445[0x28]]=OxOe445[0x30]+Ox2f2 ;} ;}  ; function sel_protocol_change(){var src=inp_src[OxOe445[0x28]].replace(/$\s*/,OxOe445[0x24]);for(var i=0x0;i<sel_protocol[OxOe445[0x2a]][OxOe445[0x2b]];i++){var Ox134=sel_protocol[OxOe445[0x2a]][i][OxOe445[0x28]];if(src.substr(0x0,Ox134.length).toLowerCase()==Ox134){ src=src.substr(Ox134[OxOe445[0x2b]],src[OxOe445[0x2b]]-Ox134.length) ;break ;} ;} ;var Ox3b8=src.indexOf(OxOe445[0x36]);if(Ox3b8!=-0x1){ src=src.substr(Ox3b8+0x3,src[OxOe445[0x2b]]-0x3-Ox3b8) ;} ;var Ox3b8=src.indexOf(OxOe445[0x37]);if(Ox3b8!=-0x1){ src=src.substr(Ox3b8+0x1,src[OxOe445[0x2b]]-0x1-Ox3b8) ;} ;var Ox3b9=sel_protocol[OxOe445[0x28]];if(Ox3b9==OxOe445[0x38]){ Ox3b9=OxOe445[0x24] ;} ; inp_src[OxOe445[0x28]]=Ox3b9+src ;}  ; function Update_sel_protocol(src){var Ox3bb=false;for(var i=0x0;i<sel_protocol[OxOe445[0x2a]][OxOe445[0x2b]];i++){var Ox134=sel_protocol[OxOe445[0x2a]][i][OxOe445[0x28]];if(src.substr(0x0,Ox134.length).toLowerCase()==Ox134){if(sel_protocol[OxOe445[0x39]]!=i){ sel_protocol[OxOe445[0x39]]=i ;} ; Ox3bb=true ;break ;} ;} ;if(!Ox3bb){ sel_protocol[OxOe445[0x39]]=sel_protocol[OxOe445[0x2a]][OxOe445[0x2b]]-0x1 ;} ;}  ; UpdateState=function UpdateState_A(){}  ; SyncToView=function SyncToView_A(){var src=OxOe445[0x24];if(element.getAttribute(OxOe445[0x3a])){ src=element.getAttribute(OxOe445[0x3a]) ;} ;if(element.getAttribute(OxOe445[0x3b])){ src=element.getAttribute(OxOe445[0x3b]) ;} ;if(src){if(ToBoolean(editor.GetScriptProperty(OxOe445[0x3d]))&&(element[OxOe445[0x3a]]).indexOf(OxOe445[0x3c])!=-0x1){ src=decode(src) ;} else {if(BaseHref!=null&&BaseHref!=OxOe445[0x24]){if(src.toLowerCase().substr(0x0,BaseHref[OxOe445[0x2b]]+0x1)==BaseHref+OxOe445[0x30]){ src=src.substring(BaseHref.length) ;} ;} ;} ;} ;try{ Update_sel_protocol(src) ;} catch(x){} ;if(element[OxOe445[0x34]]){ inp_id[OxOe445[0x28]]=element[OxOe445[0x34]] ;} ;if(src){ inp_src[OxOe445[0x28]]=src ;} ;if(element[OxOe445[0xf]][OxOe445[0x3e]]){ inp_color[OxOe445[0x28]]=revertColor(element[OxOe445[0xf]].color) ; inp_color[OxOe445[0xf]][OxOe445[0x3f]]=inp_color[OxOe445[0x28]] ;} ;if(element[OxOe445[0x40]]){ inp_title[OxOe445[0x28]]=element[OxOe445[0x40]] ;} ;if(element[OxOe445[0x41]]){ inp_target[OxOe445[0x28]]=element[OxOe445[0x41]] ;} ;if(element[OxOe445[0x42]]){ inp_index[OxOe445[0x28]]=element[OxOe445[0x42]] ;} ;if(element[OxOe445[0x43]]){ inp_access[OxOe445[0x28]]=element[OxOe445[0x43]] ;} ;if(element.getAttribute(OxOe445[0x44])==OxOe445[0x45]){ Nofollow[OxOe445[0x46]]=true ;} ; inp_class[OxOe445[0x28]]=element[OxOe445[0x32]] ; originalInnerHTML=element[OxOe445[0x47]] ;}  ; SyncTo=function SyncTo_A(element){if(inp_src[OxOe445[0x28]]){ element[OxOe445[0x3a]]=inp_src[OxOe445[0x28]] ; element.setAttribute(OxOe445[0x3b],inp_src.value) ;try{ Update_sel_protocol(element[OxOe445[0x3a]].replace(/$\s*/,OxOe445[0x24])) ;} catch(x){} ;} ;try{ element[OxOe445[0xf]][OxOe445[0x3e]]=inp_color[OxOe445[0x28]]||OxOe445[0x24] ;} catch(x){ element[OxOe445[0xf]][OxOe445[0x3e]]=OxOe445[0x24] ;} ; element[OxOe445[0x32]]=inp_class[OxOe445[0x28]] ; element[OxOe445[0x41]]=inp_target[OxOe445[0x28]] ; element[OxOe445[0x40]]=inp_title[OxOe445[0x28]] ; element[OxOe445[0x42]]=inp_index[OxOe445[0x28]] ; element[OxOe445[0x43]]=inp_access[OxOe445[0x28]] ; element[OxOe445[0x34]]=inp_id[OxOe445[0x28]] ;if(element[OxOe445[0x34]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x34]) ;} ;if(element[OxOe445[0x40]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x40]) ;} ;if(element[OxOe445[0x41]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x41]) ;} ;if(element[OxOe445[0x32]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x32]) ;} ;if(element[OxOe445[0x32]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x48]) ;} ;if(element[OxOe445[0x42]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x42]) ;} ;if(element[OxOe445[0x43]]==OxOe445[0x24]){ element.removeAttribute(OxOe445[0x43]) ;} ;if(Nofollow[OxOe445[0x46]]){ element.setAttribute(OxOe445[0x44],OxOe445[0x45]) ;} else {try{ element.removeAttribute(OxOe445[0x44]) ;} catch(x){} ;} ;var Ox2ed=/[^a-z\d]/i;if(Ox2ed.test(inp_id.value)){ alert(OxOe445[0x49]) ;return ;} ;var Ox1f8=element[OxOe445[0x47]];switch(Ox1f8.toLowerCase()){case OxOe445[0x4f]:case OxOe445[0x4e]:case OxOe445[0x4d]:case OxOe445[0x4c]:case OxOe445[0x4b]:case OxOe445[0x4a]: element[OxOe445[0x47]]=OxOe445[0x24] ;break ;default:break ;;;;;;;;} ;if(originalInnerHTML==OxOe445[0x24]){ element[OxOe445[0x47]]=element[OxOe445[0x40]]||inp_src[OxOe445[0x28]]||element[OxOe445[0x2e]] ;} ;}  ; function obfuscate(Ox408){var Ox409=OxOe445[0x24];if(Ox408[OxOe445[0x2b]]>0x0){for(var i=0x0;i<Ox408[OxOe445[0x2b]];i++){ Ox409+=OxOe445[0x3c]+Ox408.charCodeAt(i)+OxOe445[0x50] ;} ;} ;return (Ox409);}  ; function decode(Ox40b){var Ox40c=OxOe445[0x24];var arr=Ox40b.split(OxOe445[0x50]);for(var i=0x0;i<arr[OxOe445[0x2b]];i++){var Ox12=arr[i].substr(0x2,arr[i][OxOe445[0x2b]]-0x2); Ox12=String.fromCharCode(Ox12) ; Ox40c+=Ox12 ;} ;return (Ox40c);}  ; updateList() ; inp_color[OxOe445[0x27]]=inp_color_Preview[OxOe445[0x27]]=function inp_color_onclick(){ SelectColor(inp_color,inp_color_Preview) ;}  ;