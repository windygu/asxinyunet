var OxOf11f=["inp_src","btnbrowse","AlternateText","inp_id","longDesc","Align","optNotSet","optLeft","optRight","optTexttop","optAbsMiddle","optBaseline","optAbsBottom","optBottom","optMiddle","optTop","Border","bordercolor","bordercolor_Preview","inp_width","imgLock","inp_height","constrain_prop","HSpace","VSpace","outer","img_demo","onclick","src","height","width","value","cssText","style","","src_cetemp","id","vspace","hspace","border","borderColor"," ","backgroundColor","align","alt","[[ValidNumber]]","[[ValidID]]","longdesc","checked","Load.ashx?type=image\x26file=locked.gif","Load.ashx?type=image\x26file=1x1.gif","length"];var inp_src=Window_GetElement(window,OxOf11f[0x0], true);var btnbrowse=Window_GetElement(window,OxOf11f[0x1], true);var AlternateText=Window_GetElement(window,OxOf11f[0x2], true);var inp_id=Window_GetElement(window,OxOf11f[0x3], true);var longDesc=Window_GetElement(window,OxOf11f[0x4], true);var Align=Window_GetElement(window,OxOf11f[0x5], true);var optNotSet=Window_GetElement(window,OxOf11f[0x6], true);var optLeft=Window_GetElement(window,OxOf11f[0x7], true);var optRight=Window_GetElement(window,OxOf11f[0x8], true);var optTexttop=Window_GetElement(window,OxOf11f[0x9], true);var optAbsMiddle=Window_GetElement(window,OxOf11f[0xa], true);var optBaseline=Window_GetElement(window,OxOf11f[0xb], true);var optAbsBottom=Window_GetElement(window,OxOf11f[0xc], true);var optBottom=Window_GetElement(window,OxOf11f[0xd], true);var optMiddle=Window_GetElement(window,OxOf11f[0xe], true);var optTop=Window_GetElement(window,OxOf11f[0xf], true);var Border=Window_GetElement(window,OxOf11f[0x10], true);var bordercolor=Window_GetElement(window,OxOf11f[0x11], true);var bordercolor_Preview=Window_GetElement(window,OxOf11f[0x12], true);var inp_width=Window_GetElement(window,OxOf11f[0x13], true);var imgLock=Window_GetElement(window,OxOf11f[0x14], true);var inp_height=Window_GetElement(window,OxOf11f[0x15], true);var constrain_prop=Window_GetElement(window,OxOf11f[0x16], true);var HSpace=Window_GetElement(window,OxOf11f[0x17], true);var VSpace=Window_GetElement(window,OxOf11f[0x18], true);var outer=Window_GetElement(window,OxOf11f[0x19], true);var img_demo=Window_GetElement(window,OxOf11f[0x1a], true); btnbrowse[OxOf11f[0x1b]]=function btnbrowse_onclick(){ function Ox2d4(Ox130){if(Ox130){ function Actualsize(){var Ox66= new Image(); Ox66[OxOf11f[0x1c]]=Ox130 ;if(Ox66[OxOf11f[0x1e]]>0x0&&Ox66[OxOf11f[0x1d]]>0x0){ inp_width[OxOf11f[0x1f]]=Ox66[OxOf11f[0x1e]] ; inp_height[OxOf11f[0x1f]]=Ox66[OxOf11f[0x1d]] ; FireUIChanged() ;} else { setTimeout(Actualsize,0x190) ;} ;}  ; inp_src[OxOf11f[0x1f]]=Ox130 ; setTimeout(Actualsize,0x190) ;} ;}  ; editor.SetNextDialogWindow(window) ;if(Browser_IsSafari()){ editor.ShowSelectImageDialog(Ox2d4,inp_src.value,inp_src) ;} else { editor.ShowSelectImageDialog(Ox2d4,inp_src.value) ;} ;}  ; UpdateState=function UpdateState_Image(){ img_demo[OxOf11f[0x21]][OxOf11f[0x20]]=element[OxOf11f[0x21]][OxOf11f[0x20]] ;if(Browser_IsWinIE()){ img_demo.mergeAttributes(element) ;} ;if(element[OxOf11f[0x1c]]){ img_demo[OxOf11f[0x1c]]=element[OxOf11f[0x1c]] ;} else { img_demo.removeAttribute(OxOf11f[0x1c]) ;} ;}  ; SyncToView=function SyncToView_Image(){var src; src=element.getAttribute(OxOf11f[0x1c])+OxOf11f[0x22] ;if(element.getAttribute(OxOf11f[0x23])){ src=element.getAttribute(OxOf11f[0x23])+OxOf11f[0x22] ;} ; inp_src[OxOf11f[0x1f]]=src ; inp_width[OxOf11f[0x1f]]=element[OxOf11f[0x1e]] ; inp_height[OxOf11f[0x1f]]=element[OxOf11f[0x1d]] ; inp_id[OxOf11f[0x1f]]=element[OxOf11f[0x24]] ;if(element[OxOf11f[0x25]]<=0x0){ VSpace[OxOf11f[0x1f]]=OxOf11f[0x22] ;} else { VSpace[OxOf11f[0x1f]]=element[OxOf11f[0x25]] ;} ;if(element[OxOf11f[0x26]]<=0x0){ HSpace[OxOf11f[0x1f]]=OxOf11f[0x22] ;} else { HSpace[OxOf11f[0x1f]]=element[OxOf11f[0x26]] ;} ; Border[OxOf11f[0x1f]]=element[OxOf11f[0x27]] ;if(Browser_IsWinIE()){ bordercolor[OxOf11f[0x1f]]=element[OxOf11f[0x21]][OxOf11f[0x28]] ;} else {var arr=revertColor(element[OxOf11f[0x21]].borderColor).split(OxOf11f[0x29]); bordercolor[OxOf11f[0x1f]]=arr[0x0] ;} ; bordercolor[OxOf11f[0x21]][OxOf11f[0x2a]]=bordercolor[OxOf11f[0x1f]]||OxOf11f[0x22] ; bordercolor[OxOf11f[0x21]][OxOf11f[0x2a]]=bordercolor[OxOf11f[0x1f]] ; bordercolor_Preview[OxOf11f[0x21]][OxOf11f[0x2a]]=bordercolor[OxOf11f[0x1f]] ; Align[OxOf11f[0x1f]]=element[OxOf11f[0x2b]] ; AlternateText[OxOf11f[0x1f]]=element[OxOf11f[0x2c]] ; longDesc[OxOf11f[0x1f]]=element[OxOf11f[0x4]] ;}  ; SyncTo=function SyncTo_Image(element){ element[OxOf11f[0x1c]]=inp_src[OxOf11f[0x1f]] ; element.setAttribute(OxOf11f[0x23],inp_src.value) ; element[OxOf11f[0x27]]=Border[OxOf11f[0x1f]] ; element[OxOf11f[0x26]]=HSpace[OxOf11f[0x1f]] ; element[OxOf11f[0x25]]=VSpace[OxOf11f[0x1f]] ;try{ element[OxOf11f[0x1e]]=inp_width[OxOf11f[0x1f]] ; element[OxOf11f[0x1d]]=inp_height[OxOf11f[0x1f]] ;} catch(er){ alert(OxOf11f[0x2d]) ;return false;} ;if(element[OxOf11f[0x21]][OxOf11f[0x1e]]||element[OxOf11f[0x21]][OxOf11f[0x1d]]){try{ element[OxOf11f[0x21]][OxOf11f[0x1e]]=inp_width[OxOf11f[0x1f]] ; element[OxOf11f[0x21]][OxOf11f[0x1d]]=inp_height[OxOf11f[0x1f]] ;} catch(er){ alert(OxOf11f[0x2d]) ;return false;} ;} ;var Ox2ed=/[^a-z\d]/i;if(Ox2ed.test(inp_id.value)){ alert(OxOf11f[0x2e]) ;return ;} ; element[OxOf11f[0x24]]=inp_id[OxOf11f[0x1f]] ; element[OxOf11f[0x2b]]=Align[OxOf11f[0x1f]] ; element[OxOf11f[0x2c]]=AlternateText[OxOf11f[0x1f]] ; element[OxOf11f[0x4]]=longDesc[OxOf11f[0x1f]] ; element[OxOf11f[0x21]][OxOf11f[0x28]]=bordercolor[OxOf11f[0x1f]] ;if(element[OxOf11f[0x2f]]==OxOf11f[0x22]||element[OxOf11f[0x2f]]==null){ element.removeAttribute(OxOf11f[0x2f]) ;} ;if(element[OxOf11f[0x4]]==OxOf11f[0x22]||element[OxOf11f[0x4]]==null){ element.removeAttribute(OxOf11f[0x4]) ;} ;if(element[OxOf11f[0x1e]]==0x0){ element.removeAttribute(OxOf11f[0x1e]) ;} ;if(element[OxOf11f[0x1d]]==0x0){ element.removeAttribute(OxOf11f[0x1d]) ;} ;if(element[OxOf11f[0x26]]==OxOf11f[0x22]){ element.removeAttribute(OxOf11f[0x26]) ;} ;if(element[OxOf11f[0x25]]==OxOf11f[0x22]){ element.removeAttribute(OxOf11f[0x25]) ;} ;if(element[OxOf11f[0x24]]==OxOf11f[0x22]){ element.removeAttribute(OxOf11f[0x24]) ;} ;if(element[OxOf11f[0x2b]]==OxOf11f[0x22]){ element.removeAttribute(OxOf11f[0x2b]) ;} ;if(element[OxOf11f[0x27]]==OxOf11f[0x22]){ element.removeAttribute(OxOf11f[0x27]) ;} ;}  ; function toggleConstrains(){if(constrain_prop[OxOf11f[0x30]]){ imgLock[OxOf11f[0x1c]]=OxOf11f[0x31] ; checkConstrains(OxOf11f[0x1e]) ;} else { imgLock[OxOf11f[0x1c]]=OxOf11f[0x32] ;} ;}  ;var checkingConstrains=false; function checkConstrains(Ox63){if(checkingConstrains){return ;} ; checkingConstrains=true ;try{var Ox8,Ox2b;if(constrain_prop[OxOf11f[0x30]]){var Ox66= new Image(); Ox66[OxOf11f[0x1c]]=inp_src[OxOf11f[0x1f]] ;var Ox399=Ox66[OxOf11f[0x1e]];var Ox39a=Ox66[OxOf11f[0x1d]];if((Ox399>0x0)&&(Ox39a>0x0)){var Ox5d=inp_width[OxOf11f[0x1f]];var Ox5c=inp_height[OxOf11f[0x1f]];if(Ox63==OxOf11f[0x1e]){if(Ox5d[OxOf11f[0x33]]==0x0||isNaN(Ox5d)){ inp_width[OxOf11f[0x1f]]=OxOf11f[0x22] ; inp_height[OxOf11f[0x1f]]=OxOf11f[0x22] ;} else { Ox5c=parseInt(Ox5d*Ox39a/Ox399) ; inp_height[OxOf11f[0x1f]]=Ox5c ;} ;} ;if(Ox63==OxOf11f[0x1d]){if(Ox5c[OxOf11f[0x33]]==0x0||isNaN(Ox5c)){ inp_width[OxOf11f[0x1f]]=OxOf11f[0x22] ; inp_height[OxOf11f[0x1f]]=OxOf11f[0x22] ;} else { Ox5d=parseInt(Ox5c*Ox399/Ox39a) ; inp_width[OxOf11f[0x1f]]=Ox5d ;} ;} ;} ;} ;} finally{ checkingConstrains=false ;} ;}  ; bordercolor[OxOf11f[0x1b]]=bordercolor_Preview[OxOf11f[0x1b]]=function bordercolor_onclick(){ SelectColor(bordercolor,bordercolor_Preview) ;}  ;