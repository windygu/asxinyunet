var OxOad89=["nodeName","INPUT","TEXTAREA","BUTTON","IMG","SELECT","TABLE","position","style","absolute","relative","|H1|H2|H3|H4|H5|H6|P|PRE|LI|TD|DIV|BLOCKQUOTE|DT|DD|TABLE|HR|IMG|","|","body","document","allanchors","anchor_name","editor","window","name","value","[[ValidName]]","options","length","anchors","OPTION","text","#","images","className","cetempAnchor","anchorname"]; function Element_IsBlockControl(element){var name=element[OxOad89[0x0]];if(name==OxOad89[0x1]){return true;} ;if(name==OxOad89[0x2]){return true;} ;if(name==OxOad89[0x3]){return true;} ;if(name==OxOad89[0x4]){return true;} ;if(name==OxOad89[0x5]){return true;} ;if(name==OxOad89[0x6]){return true;} ;var Ox10f=element[OxOad89[0x8]][OxOad89[0x7]];if(Ox10f==OxOad89[0x9]||Ox10f==OxOad89[0xa]){return true;} ;return false;}  ; function Element_CUtil_IsBlock(Ox2e5){var Ox2e6=OxOad89[0xb];return (Ox2e5!=null)&&(Ox2e6.indexOf(OxOad89[0xc]+Ox2e5[OxOad89[0x0]]+OxOad89[0xc])!=-0x1);}  ; function Window_SelectElement(Ox1ae,element){if(Browser_UseIESelection()){if(Element_IsBlockControl(element)){var Ox2f=Ox1ae[OxOad89[0xe]][OxOad89[0xd]].createControlRange(); Ox2f.add(element) ; Ox2f.select() ;} else {var Ox19b=Ox1ae[OxOad89[0xe]][OxOad89[0xd]].createTextRange(); Ox19b.moveToElementText(element) ; Ox19b.select() ;} ;} else {var Ox19b=Ox1ae[OxOad89[0xe]].createRange();try{ Ox19b.selectNode(element) ;} catch(x){ Ox19b.selectNodeContents(element) ;} ;var Ox128=Ox1ae.getSelection(); Ox128.removeAllRanges() ; Ox128.addRange(Ox19b) ;} ;}  ;var allanchors=Window_GetElement(window,OxOad89[0xf],true);var anchor_name=Window_GetElement(window,OxOad89[0x10],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxOad89[0x11]];var editwin=obj[OxOad89[0x12]];var editdoc=obj[OxOad89[0xe]];var name=obj[OxOad89[0x13]]; function insert_link(){var Ox2eb=anchor_name[OxOad89[0x14]];var Ox2ec=/[^a-z\d]/i;if(Ox2ec.test(Ox2eb)){ alert(OxOad89[0x15]) ;} else { Window_SetDialogReturnValue(window,Ox2eb) ; Window_CloseDialog(window) ;} ;}  ; function updateList(){while(allanchors[OxOad89[0x16]][OxOad89[0x17]]!=0x0){ allanchors[OxOad89[0x16]].remove(allanchors.options(0x0)) ;} ;if(Browser_IsWinIE()){for(var i=0x0;i<editdoc[OxOad89[0x18]][OxOad89[0x17]];i++){var Ox2ee=document.createElement(OxOad89[0x19]); Ox2ee[OxOad89[0x1a]]=OxOad89[0x1b]+editdoc[OxOad89[0x18]][i][OxOad89[0x13]] ; Ox2ee[OxOad89[0x14]]=editdoc[OxOad89[0x18]][i][OxOad89[0x13]] ; allanchors[OxOad89[0x16]].add(Ox2ee) ;} ;} else {var Ox2ef=editdoc[OxOad89[0x1c]];if(Ox2ef){for(var j=0x0;j<Ox2ef[OxOad89[0x17]];j++){var img=Ox2ef[j];if(img[OxOad89[0x1d]]==OxOad89[0x1e]){var Ox2ee=document.createElement(OxOad89[0x19]); Ox2ee[OxOad89[0x1a]]=OxOad89[0x1b]+img.getAttribute(OxOad89[0x1f]) ; Ox2ee[OxOad89[0x14]]=img.getAttribute(OxOad89[0x1f]) ; allanchors[OxOad89[0x16]].add(Ox2ee) ;} ;} ;} ;} ;}  ; function selectAnchor(Ox2f1){ editor.FocusDocument() ;for(var i=0x0;i<editdoc[OxOad89[0x18]][OxOad89[0x17]];i++){if(editdoc[OxOad89[0x18]][i][OxOad89[0x13]]==Ox2f1){ anchor_name[OxOad89[0x14]]=Ox2f1 ; Window_SelectElement(editwin,editdoc[OxOad89[0x18]][i]) ;} ;} ;}  ;if(name){ anchor_name[OxOad89[0x14]]=name ;} ; updateList() ;