var OxOac7a=["zoomcount","wheelDelta","zoom","style","0%","top","hiddenDirectory","hiddenFile","hiddenAlert","hiddenAction","hiddenActionData","This function is disabled in the demo mode.","disabled","[[Disabled]]","[[SpecifyNewFolderName]]","","value","createdir","[[CopyMoveto]]","/","move","copy","[[AreyouSureDelete]]","parentNode","text","isdir","true",".","[[SpecifyNewFileName]]","rename","path","True","False",":","FoldersAndFiles","TR","length","this.bgColor=\x27#eeeeee\x27;","onmouseover","this.bgColor=\x27\x27;","onmouseout","nodeName","INPUT","changedir","url","TargetUrl","htmlcode","onload","getElementsByTagName","table","sortable","className"," ","id","rows","cells","innerHTML","\x3Ca href=\x22#\x22 onclick=\x22ts_resortTable(this);return false;\x22\x3E","\x3Cspan class=\x22sortarrow\x22\x3E\x26nbsp;\x3C/span\x3E\x3C/a\x3E","string","undefined","innerText","childNodes","nodeValue","nodeType","span","cellIndex","TABLE","sortdir","down","\x26uarr;","up","\x26darr;","sortbottom","tBodies","sortarrow","\x26nbsp;","20","19","Form1","Image1","FolderDescription","CreateDir","Copy","Move","img_AutoThumbnail","img_ImageEditor","Delete","DoRefresh","name_Cell","size_Cell","op_Cell","op_space","divpreview","img_demo","Align","Border","bordercolor","bordercolor_Preview","inp_width","imgLock","inp_height","constrain_prop","HSpace","VSpace","AlternateText","inp_id","longDesc","fieldsetUpload","Button1","Button2","btn_zoom_in","btn_zoom_out","btn_Actualsize","btn_bestfit","img","editor","src","src_cetemp","width","height","vspace","hspace","border","borderColor","backgroundColor","align","alt","file","complete","../images/1x1.gif","?","\x26time=","?time=","0","onmousewheel",".aspx","display","none","Edit","[[ValidID]]","[[ValidColor]]","[[SelectImagetoInsert]]","longdesc","=\x22","\x22","checked","../Load.ashx?type=image\x26file=locked.gif","../Load.ashx?type=image\x26file=1x1.gif","[[SelectImagetoThumbnail]]","dir","refresh","Thumbnail.aspx?","dialogWidth:310px;dialogHeight:150px;help:no;scroll:no;status:no;resizable:1;","UseStandardDialog","1","\x26Dialog=Standard","Theme","EditorSetting","setting=","\x26Theme=","[[SelectImagetoEdit]]","[[_CuteEditorResource_]]","../ImageEditor/ImageEditor.aspx?f=","\x26p=","dialogWidth:676px;dialogHeight:500px;help:no;scroll:no;status:no;resizable:0;","onclick","wrapupPrompt","iepromptfield","body","div","IEPromptBox","promptBlackout","1px solid #b0bec7","#f0f0f0","position","absolute","330px","zIndex","100","\x3Cdiv style=\x22width: 100%; padding-top:3px;background-color: #DCE7EB; font-family: verdana; font-size: 10pt; font-weight: bold; height: 22px; text-align:center; background:url(Load.ashx?type=image\x26file=formbg2.gif) repeat-x left top;\x22\x3E[[InputRequired]]\x3C/div\x3E","\x3Cdiv style=\x22padding: 10px\x22\x3E","\x3CBR\x3E\x3CBR\x3E","\x3Cform action=\x22\x22 onsubmit=\x22return wrapupPrompt()\x22\x3E","\x3Cinput id=\x22iepromptfield\x22 name=\x22iepromptdata\x22 type=text size=46 value=\x22","\x22\x3E","\x3Cbr\x3E\x3Cbr\x3E\x3Ccenter\x3E","\x3Cinput type=\x22submit\x22 value=\x22\x26nbsp;\x26nbsp;\x26nbsp;[[OK]]\x26nbsp;\x26nbsp;\x26nbsp;\x22\x3E","\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;\x26nbsp;","\x3Cinput type=\x22button\x22 onclick=\x22wrapupPrompt(true)\x22 value=\x22\x26nbsp;[[Cancel]]\x26nbsp;\x22\x3E","\x3C/form\x3E\x3C/div\x3E","100px","offsetWidth","left","px","block","CuteEditor_ColorPicker_ButtonOver(this)"]; function OnImageMouseWheel(){var Ox2a8=Event_GetEvent();var img=Event_GetSrcElement(Ox2a8);var Ox386=img[OxOac7a[0x0]]||0x3;if(Ox2a8[OxOac7a[0x1]]>=0x6a){ Ox386++ ;} else {if(Ox2a8[OxOac7a[0x1]]<=-0x6a){ Ox386-- ;} ;} ; img[OxOac7a[0x0]]=Ox386 ; img[OxOac7a[0x3]][OxOac7a[0x2]]=Ox386+OxOac7a[0x4] ;return false;}  ; function Window_GetDialogTop(Ox1ae){return Ox1ae[OxOac7a[0x5]];}  ;var hiddenDirectory=Window_GetElement(window,OxOac7a[0x6],true);var hiddenFile=Window_GetElement(window,OxOac7a[0x7],true);var hiddenAlert=Window_GetElement(window,OxOac7a[0x8],true);var hiddenAction=Window_GetElement(window,OxOac7a[0x9],true);var hiddenActionData=Window_GetElement(window,OxOac7a[0xa],true); function CreateDir_click(){if(isDemoMode){ alert(OxOac7a[0xb]) ;return false;} ;if(Event_GetSrcElement()[OxOac7a[0xc]]){ alert(OxOac7a[0xd]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox194,OxOac7a[0xe],OxOac7a[0xf]) ; function Ox194(Ox2f8){if(Ox2f8){ hiddenActionData[OxOac7a[0x10]]=Ox2f8 ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0x11] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox2f8=prompt(OxOac7a[0xe],OxOac7a[0xf]);if(Ox2f8){ hiddenActionData[OxOac7a[0x10]]=Ox2f8 ;return true;} else {return false;} ;return false;} ;}  ; function Move_click(){if(isDemoMode){ alert(OxOac7a[0xb]) ;return false;} ;if(Event_GetSrcElement()[OxOac7a[0xc]]){ alert(OxOac7a[0xd]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox194,OxOac7a[0x12],OxOac7a[0x13]) ; function Ox194(Ox2f8){if(Ox2f8){ hiddenActionData[OxOac7a[0x10]]=Ox2f8 ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0x14] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox2f8=prompt(OxOac7a[0x12],OxOac7a[0x13]);if(Ox2f8){ hiddenActionData[OxOac7a[0x10]]=Ox2f8 ;return true;} else {return false;} ;return false;} ;}  ; function Copy_click(){if(isDemoMode){ alert(OxOac7a[0xb]) ;return false;} ;if(Event_GetSrcElement()[OxOac7a[0xc]]){ alert(OxOac7a[0xd]) ;return false;} ;if(Browser_IsIE7()){ IEprompt(Ox194,OxOac7a[0x12],OxOac7a[0x13]) ; function Ox194(Ox2f8){if(Ox2f8){ hiddenActionData[OxOac7a[0x10]]=Ox2f8 ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0x15] ; window.PostBackAction() ;return true;} else {return false;} ;}  ;return Event_CancelEvent();} else {var Ox2f8=prompt(OxOac7a[0x12],OxOac7a[0x13]);if(Ox2f8){ hiddenActionData[OxOac7a[0x10]]=Ox2f8 ;return true;} else {return false;} ;return false;} ;}  ; function Delete_click(){if(isDemoMode){ alert(OxOac7a[0xb]) ;return false;} ;if(Event_GetSrcElement()[OxOac7a[0xc]]){ alert(OxOac7a[0xd]) ;return false;} ;return confirm(OxOac7a[0x16]);}  ; function EditImg_click(img){if(isDemoMode){ alert(OxOac7a[0xb]) ;return false;} ;if(img[OxOac7a[0xc]]){ alert(OxOac7a[0xd]) ;return false;} ;var Ox2fd=img[OxOac7a[0x17]][OxOac7a[0x17]];var Ox2fe=Ox2fd[OxOac7a[0x18]];var name;var Ox2ff;if(Browser_IsOpera()){ Ox2ff=Ox2fd.getAttribute(OxOac7a[0x19])==OxOac7a[0x1a] ;} else { Ox2ff=Ox2fd[OxOac7a[0x19]] ;} ;if(Browser_IsIE7()){var Oxb3;if(Ox2ff){ IEprompt(Ox194,OxOac7a[0xe],Ox2fe) ;} else {var i=Ox2fe.lastIndexOf(OxOac7a[0x1b]); Oxb3=Ox2fe.substr(i) ;var Ox12=Ox2fe.substr(0x0,Ox2fe.lastIndexOf(OxOac7a[0x1b])); IEprompt(Ox194,OxOac7a[0x1c],Ox12) ;} ; function Ox194(Ox2f8){if(Ox2f8&&Ox2f8!=Ox2fd[OxOac7a[0x18]]){if(!Ox2ff){ Ox2f8=Ox2f8+Oxb3 ;} ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0x1d] ; hiddenActionData[OxOac7a[0x10]]=(Ox2ff?OxOac7a[0x1f]:OxOac7a[0x20])+OxOac7a[0x21]+Ox2fd[OxOac7a[0x1e]]+OxOac7a[0x21]+Ox2f8 ; window.PostBackAction() ;} ;}  ;} else {if(Ox2ff){ name=prompt(OxOac7a[0xe],Ox2fe) ;} else {var i=Ox2fe.lastIndexOf(OxOac7a[0x1b]);var Oxb3=Ox2fe.substr(i);var Ox12=Ox2fe.substr(0x0,Ox2fe.lastIndexOf(OxOac7a[0x1b])); name=prompt(OxOac7a[0x1c],Ox12) ;if(name){ name=name+Oxb3 ;} ;} ;if(name&&name!=Ox2fd[OxOac7a[0x18]]){ hiddenAction[OxOac7a[0x10]]=OxOac7a[0x1d] ; hiddenActionData[OxOac7a[0x10]]=(Ox2ff?OxOac7a[0x1f]:OxOac7a[0x20])+OxOac7a[0x21]+Ox2fd[OxOac7a[0x1e]]+OxOac7a[0x21]+name ; window.PostBackAction() ;} ;} ;return Event_CancelEvent();}  ; setMouseOver() ; function setMouseOver(){var FoldersAndFiles=Window_GetElement(window,OxOac7a[0x22],true);var Ox302=FoldersAndFiles.getElementsByTagName(OxOac7a[0x23]);for(var i=0x0;i<Ox302[OxOac7a[0x24]];i++){var Ox2fd=Ox302[i]; Ox2fd[OxOac7a[0x26]]= new Function(OxOac7a[0xf],OxOac7a[0x25]) ; Ox2fd[OxOac7a[0x28]]= new Function(OxOac7a[0xf],OxOac7a[0x27]) ;} ;}  ; function row_click(Ox2fd){var Ox2ff;if(Browser_IsOpera()){ Ox2ff=Ox2fd.getAttribute(OxOac7a[0x19])==OxOac7a[0x1a] ;} else { Ox2ff=Ox2fd[OxOac7a[0x19]] ;} ;if(Ox2ff){if(Event_GetSrcElement()[OxOac7a[0x29]]==OxOac7a[0x2a]){return ;} ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0x2b] ; hiddenActionData[OxOac7a[0x10]]=Ox2fd.getAttribute(OxOac7a[0x1e]) ; window.PostBackAction() ;} else {var Oxf2=Ox2fd.getAttribute(OxOac7a[0x1e]); hiddenFile[OxOac7a[0x10]]=Oxf2 ;var Ox1fe=Ox2fd.getAttribute(OxOac7a[0x2c]); Window_GetElement(window,OxOac7a[0x2d],true)[OxOac7a[0x10]]=Ox1fe ;var htmlcode=Ox2fd.getAttribute(OxOac7a[0x2e]);if(htmlcode!=OxOac7a[0xf]&&htmlcode!=null){ do_preview(htmlcode) ;} else {if(Ox1fe!=OxOac7a[0xf]&&Ox1fe!=null){try{ Actualsize() ;} catch(x){ do_preview() ;} ;} ;} ;} ;}  ; function do_preview(){}  ; function reset_hiddens(){if(hiddenAlert[OxOac7a[0x10]]){ alert(hiddenAlert.value) ;} ;if(TargetUrl[OxOac7a[0x10]]!=OxOac7a[0xf]&&TargetUrl[OxOac7a[0x10]]!=null){ do_preview() ;} ; hiddenAlert[OxOac7a[0x10]]=OxOac7a[0xf] ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0xf] ; hiddenActionData[OxOac7a[0x10]]=OxOac7a[0xf] ;}  ; Event_Attach(window,OxOac7a[0x2f],reset_hiddens) ; function RequireFileBrowseScript(){}  ; function Actualsize(){}  ; Event_Attach(window,OxOac7a[0x2f],sortables_init) ;var SORT_COLUMN_INDEX; function sortables_init(){if(!document[OxOac7a[0x30]]){return ;} ;var Ox307=document.getElementsByTagName(OxOac7a[0x31]);for(var Ox308=0x0;Ox308<Ox307[OxOac7a[0x24]];Ox308++){var Ox309=Ox307[Ox308];if(((OxOac7a[0x34]+Ox309[OxOac7a[0x33]]+OxOac7a[0x34]).indexOf(OxOac7a[0x32])!=-0x1)&&(Ox309[OxOac7a[0x35]])){ ts_makeSortable(Ox309) ;} ;} ;}  ; function ts_makeSortable(Ox30b){if(Ox30b[OxOac7a[0x36]]&&Ox30b[OxOac7a[0x36]][OxOac7a[0x24]]>0x0){var Ox30c=Ox30b[OxOac7a[0x36]][0x0];} ;if(!Ox30c){return ;} ;for(var i=0x2;i<0x4;i++){var Ox30d=Ox30c[OxOac7a[0x37]][i];var Ox1f9=ts_getInnerText(Ox30d); Ox30d[OxOac7a[0x38]]=OxOac7a[0x39]+Ox1f9+OxOac7a[0x3a] ;} ;}  ; function ts_getInnerText(Ox27){if( typeof Ox27==OxOac7a[0x3b]){return Ox27;} ;if( typeof Ox27==OxOac7a[0x3c]){return Ox27;} ;if(Ox27[OxOac7a[0x3d]]){return Ox27[OxOac7a[0x3d]];} ;var Ox24=OxOac7a[0xf];var Ox2b9=Ox27[OxOac7a[0x3e]];var Ox11=Ox2b9[OxOac7a[0x24]];for(var i=0x0;i<Ox11;i++){switch(Ox2b9[i][OxOac7a[0x40]]){case 0x1: Ox24+=ts_getInnerText(Ox2b9[i]) ;break ;case 0x3: Ox24+=Ox2b9[i][OxOac7a[0x3f]] ;break ;;;} ;} ;return Ox24;}  ; function ts_resortTable(Ox310){var Ox21d;for(var Ox311=0x0;Ox311<Ox310[OxOac7a[0x3e]][OxOac7a[0x24]];Ox311++){if(Ox310[OxOac7a[0x3e]][Ox311][OxOac7a[0x29]]&&Ox310[OxOac7a[0x3e]][Ox311][OxOac7a[0x29]].toLowerCase()==OxOac7a[0x41]){ Ox21d=Ox310[OxOac7a[0x3e]][Ox311] ;} ;} ;var Ox312=ts_getInnerText(Ox21d);var Ox313=Ox310[OxOac7a[0x17]];var Ox314=Ox313[OxOac7a[0x42]];var Ox30b=getParent(Ox313,OxOac7a[0x43]);if(Ox30b[OxOac7a[0x36]][OxOac7a[0x24]]<=0x1){return ;} ;var Ox315=ts_getInnerText(Ox30b[OxOac7a[0x36]][0x1][OxOac7a[0x37]][Ox314]);var Ox316=ts_sort_caseinsensitive;if(Ox315.match(/^\d\d[\/-]\d\d[\/-]\d\d\d\d$/)){ Ox316=ts_sort_date ;} ;if(Ox315.match(/^\d\d[\/-]\d\d[\/-]\d\d$/)){ Ox316=ts_sort_date ;} ;if(Ox315.match(/^[?]/)){ Ox316=ts_sort_currency ;} ;if(Ox315.match(/^[\d\.]+$/)){ Ox316=ts_sort_numeric ;} ; SORT_COLUMN_INDEX=Ox314 ;var Ox30c= new Array();var Ox317= new Array();for(var i=0x0;i<Ox30b[OxOac7a[0x36]][0x0][OxOac7a[0x24]];i++){ Ox30c[i]=Ox30b[OxOac7a[0x36]][0x0][i] ;} ;for(var j=0x1;j<Ox30b[OxOac7a[0x36]][OxOac7a[0x24]];j++){ Ox317[j-0x1]=Ox30b[OxOac7a[0x36]][j] ;} ; Ox317.sort(Ox316) ;if(Ox21d.getAttribute(OxOac7a[0x44])==OxOac7a[0x45]){var Ox318=OxOac7a[0x46]; Ox317.reverse() ; Ox21d.setAttribute(OxOac7a[0x44],OxOac7a[0x47]) ;} else { Ox318=OxOac7a[0x48] ; Ox21d.setAttribute(OxOac7a[0x44],OxOac7a[0x45]) ;} ;for( i=0x0 ;i<Ox317[OxOac7a[0x24]];i++){if(!Ox317[i][OxOac7a[0x33]]||(Ox317[i][OxOac7a[0x33]]&&(Ox317[i][OxOac7a[0x33]].indexOf(OxOac7a[0x49])==-0x1))){ Ox30b[OxOac7a[0x4a]][0x0].appendChild(Ox317[i]) ;} ;} ;for( i=0x0 ;i<Ox317[OxOac7a[0x24]];i++){if(Ox317[i][OxOac7a[0x33]]&&(Ox317[i][OxOac7a[0x33]].indexOf(OxOac7a[0x49])!=-0x1)){ Ox30b[OxOac7a[0x4a]][0x0].appendChild(Ox317[i]) ;} ;} ;var Ox319=document.getElementsByTagName(OxOac7a[0x41]);for(var Ox311=0x0;Ox311<Ox319[OxOac7a[0x24]];Ox311++){if(Ox319[Ox311][OxOac7a[0x33]]==OxOac7a[0x4b]){if(getParent(Ox319[Ox311],OxOac7a[0x31])==getParent(Ox310,OxOac7a[0x31])){ Ox319[Ox311][OxOac7a[0x38]]=OxOac7a[0x4c] ;} ;} ;} ; Ox21d[OxOac7a[0x38]]=Ox318 ;}  ; function getParent(Ox27,Ox31b){if(Ox27==null){return null;} else {if(Ox27[OxOac7a[0x40]]==0x1&&Ox27[OxOac7a[0x29]].toLowerCase()==Ox31b.toLowerCase()){return Ox27;} else {return getParent(Ox27.parentNode,Ox31b);} ;} ;}  ; function ts_sort_date(Oxd7,Oxc){var Ox31d=ts_getInnerText(Oxd7[OxOac7a[0x37]][SORT_COLUMN_INDEX]);var Ox31e=ts_getInnerText(Oxc[OxOac7a[0x37]][SORT_COLUMN_INDEX]);if(Ox31d[OxOac7a[0x24]]==0xa){var Ox31f=Ox31d.substr(0x6,0x4)+Ox31d.substr(0x3,0x2)+Ox31d.substr(0x0,0x2);} else {var Ox320=Ox31d.substr(0x6,0x2);if(parseInt(Ox320)<0x32){ Ox320=OxOac7a[0x4d]+Ox320 ;} else { Ox320=OxOac7a[0x4e]+Ox320 ;} ;var Ox31f=Ox320+Ox31d.substr(0x3,0x2)+Ox31d.substr(0x0,0x2);} ;if(Ox31e[OxOac7a[0x24]]==0xa){var Ox321=Ox31e.substr(0x6,0x4)+Ox31e.substr(0x3,0x2)+Ox31e.substr(0x0,0x2);} else { Ox320=Ox31e.substr(0x6,0x2) ;if(parseInt(Ox320)<0x32){ Ox320=OxOac7a[0x4d]+Ox320 ;} else { Ox320=OxOac7a[0x4e]+Ox320 ;} ;var Ox321=Ox320+Ox31e.substr(0x3,0x2)+Ox31e.substr(0x0,0x2);} ;if(Ox31f==Ox321){return 0x0;} ;if(Ox31f<Ox321){return -0x1;} ;return 0x1;}  ; function ts_sort_currency(Oxd7,Oxc){var Ox31d=ts_getInnerText(Oxd7[OxOac7a[0x37]][SORT_COLUMN_INDEX]).replace(/[^0-9.]/g,OxOac7a[0xf]);var Ox31e=ts_getInnerText(Oxc[OxOac7a[0x37]][SORT_COLUMN_INDEX]).replace(/[^0-9.]/g,OxOac7a[0xf]);return parseFloat(Ox31d)-parseFloat(Ox31e);}  ; function ts_sort_numeric(Oxd7,Oxc){var Ox31d=parseFloat(ts_getInnerText(Oxd7[OxOac7a[0x37]][SORT_COLUMN_INDEX]));if(isNaN(Ox31d)){ Ox31d=0x0 ;} ;var Ox31e=parseFloat(ts_getInnerText(Oxc[OxOac7a[0x37]][SORT_COLUMN_INDEX]));if(isNaN(Ox31e)){ Ox31e=0x0 ;} ;return Ox31d-Ox31e;}  ; function ts_sort_caseinsensitive(Oxd7,Oxc){var Ox31d=ts_getInnerText(Oxd7[OxOac7a[0x37]][SORT_COLUMN_INDEX]).toLowerCase();var Ox31e=ts_getInnerText(Oxc[OxOac7a[0x37]][SORT_COLUMN_INDEX]).toLowerCase();if(Ox31d==Ox31e){return 0x0;} ;if(Ox31d<Ox31e){return -0x1;} ;return 0x1;}  ; function ts_sort_default(Oxd7,Oxc){var Ox31d=ts_getInnerText(Oxd7[OxOac7a[0x37]][SORT_COLUMN_INDEX]);var Ox31e=ts_getInnerText(Oxc[OxOac7a[0x37]][SORT_COLUMN_INDEX]);if(Ox31d==Ox31e){return 0x0;} ;if(Ox31d<Ox31e){return -0x1;} ;return 0x1;} [sortables_init] ; RequireFileBrowseScript() ;var Form1=Window_GetElement(window,OxOac7a[0x4f],true);var hiddenDirectory=Window_GetElement(window,OxOac7a[0x6],true);var hiddenFile=Window_GetElement(window,OxOac7a[0x7],true);var hiddenAlert=Window_GetElement(window,OxOac7a[0x8],true);var hiddenAction=Window_GetElement(window,OxOac7a[0x9],true);var hiddenActionData=Window_GetElement(window,OxOac7a[0xa],true);var Image1=Window_GetElement(window,OxOac7a[0x50],true);var FolderDescription=Window_GetElement(window,OxOac7a[0x51],true);var CreateDir=Window_GetElement(window,OxOac7a[0x52],true);var Copy=Window_GetElement(window,OxOac7a[0x53],true);var Move=Window_GetElement(window,OxOac7a[0x54],true);var img_AutoThumbnail=Window_GetElement(window,OxOac7a[0x55],true);var img_ImageEditor=Window_GetElement(window,OxOac7a[0x56],false);var FoldersAndFiles=Window_GetElement(window,OxOac7a[0x22],true);var Delete=Window_GetElement(window,OxOac7a[0x57],true);var DoRefresh=Window_GetElement(window,OxOac7a[0x58],true);var name_Cell=Window_GetElement(window,OxOac7a[0x59],true);var size_Cell=Window_GetElement(window,OxOac7a[0x5a],true);var op_Cell=Window_GetElement(window,OxOac7a[0x5b],true);var op_space=Window_GetElement(window,OxOac7a[0x5c],true);var divpreview=Window_GetElement(window,OxOac7a[0x5d],true);var img_demo=Window_GetElement(window,OxOac7a[0x5e],true);var Align=Window_GetElement(window,OxOac7a[0x5f],true);var Border=Window_GetElement(window,OxOac7a[0x60],true);var bordercolor=Window_GetElement(window,OxOac7a[0x61],true);var bordercolor_Preview=Window_GetElement(window,OxOac7a[0x62],true);var inp_width=Window_GetElement(window,OxOac7a[0x63],true);var imgLock=Window_GetElement(window,OxOac7a[0x64],true);var inp_height=Window_GetElement(window,OxOac7a[0x65],true);var constrain_prop=Window_GetElement(window,OxOac7a[0x66],true);var HSpace=Window_GetElement(window,OxOac7a[0x67],true);var VSpace=Window_GetElement(window,OxOac7a[0x68],true);var TargetUrl=Window_GetElement(window,OxOac7a[0x2d],true);var AlternateText=Window_GetElement(window,OxOac7a[0x69],true);var inp_id=Window_GetElement(window,OxOac7a[0x6a],true);var longDesc=Window_GetElement(window,OxOac7a[0x6b],true);var fieldsetUpload=Window_GetElement(window,OxOac7a[0x6c],true);var Button1=Window_GetElement(window,OxOac7a[0x6d],true);var Button2=Window_GetElement(window,OxOac7a[0x6e],true);var btn_zoom_in=Window_GetElement(window,OxOac7a[0x6f],true);var btn_zoom_out=Window_GetElement(window,OxOac7a[0x70],true);var btn_Actualsize=Window_GetElement(window,OxOac7a[0x71],true);var btn_bestfit=Window_GetElement(window,OxOac7a[0x72],true);var obj=Window_GetDialogArguments(window);var element=obj[OxOac7a[0x73]];var editor=obj[OxOac7a[0x74]];var src=OxOac7a[0xf];if(element.getAttribute(OxOac7a[0x75])){ src=element.getAttribute(OxOac7a[0x75]) ;} ;if(element.getAttribute(OxOac7a[0x76])){ src=element.getAttribute(OxOac7a[0x76]) ;} ;if(element&&src){ TargetUrl[OxOac7a[0x10]]=src ;} ; inp_width[OxOac7a[0x10]]=element[OxOac7a[0x77]]||OxOac7a[0xf] ; inp_height[OxOac7a[0x10]]=element[OxOac7a[0x78]]||OxOac7a[0xf] ; inp_id[OxOac7a[0x10]]=element[OxOac7a[0x35]]||OxOac7a[0xf] ;if(element[OxOac7a[0x79]]<=0x0){ VSpace[OxOac7a[0x10]]=OxOac7a[0xf] ;} else { VSpace[OxOac7a[0x10]]=element[OxOac7a[0x79]] ;} ;if(element[OxOac7a[0x7a]]<=0x0){ HSpace[OxOac7a[0x10]]=OxOac7a[0xf] ;} else { HSpace[OxOac7a[0x10]]=element[OxOac7a[0x7a]] ;} ; Border[OxOac7a[0x10]]=element[OxOac7a[0x7b]]||OxOac7a[0xf] ;if(Browser_IsWinIE()){ bordercolor[OxOac7a[0x10]]=element[OxOac7a[0x3]][OxOac7a[0x7c]] ;} else {var arr=revertColor(element[OxOac7a[0x3]].borderColor).split(OxOac7a[0x34]); bordercolor[OxOac7a[0x10]]=arr[0x0] ;} ; bordercolor[OxOac7a[0x3]][OxOac7a[0x7d]]=bordercolor[OxOac7a[0x10]]||OxOac7a[0xf] ; bordercolor_Preview[OxOac7a[0x3]][OxOac7a[0x7d]]=bordercolor[OxOac7a[0x10]]||OxOac7a[0xf] ; Align[OxOac7a[0x10]]=element[OxOac7a[0x7e]]||OxOac7a[0xf] ; AlternateText[OxOac7a[0x10]]=element[OxOac7a[0x7f]]||OxOac7a[0xf] ; longDesc[OxOac7a[0x10]]=element[OxOac7a[0x6b]]||OxOac7a[0xf] ;var sCheckFlag=OxOac7a[0x80]; function ResetFields(){ TargetUrl[OxOac7a[0x10]]=OxOac7a[0xf] ; inp_width[OxOac7a[0x10]]=OxOac7a[0xf] ; inp_height[OxOac7a[0x10]]=OxOac7a[0xf] ; inp_id[OxOac7a[0x10]]=OxOac7a[0xf] ; VSpace[OxOac7a[0x10]]=OxOac7a[0xf] ; HSpace[OxOac7a[0x10]]=OxOac7a[0xf] ; Border[OxOac7a[0x10]]=OxOac7a[0xf] ; bordercolor[OxOac7a[0x10]]=OxOac7a[0xf] ; bordercolor[OxOac7a[0x3]][OxOac7a[0x7d]]=OxOac7a[0xf] ; Align[OxOac7a[0x10]]=OxOac7a[0xf] ; AlternateText[OxOac7a[0x10]]=OxOac7a[0xf] ; longDesc[OxOac7a[0x10]]=OxOac7a[0xf] ;}  ; function do_preview(){var Ox1a4=TargetUrl[OxOac7a[0x10]];if(Ox1a4==null){ TargetUrl[OxOac7a[0x10]]=OxOac7a[0xf] ; Ox1a4==OxOac7a[0xf] ;} ;if(Ox1a4!=null&&Ox1a4!=OxOac7a[0xf]){var Ox395;var Ox396;var Ox395= new Image(); Ox395[OxOac7a[0x75]]=Ox1a4 ; function Ox397(){if(Ox395[OxOac7a[0x81]]){ window.clearInterval(Ox396) ;var Ox90= new Date();var Ox91=Ox90.getTime();if(Ox1a4==OxOac7a[0xf]){ Ox1a4=OxOac7a[0x82] ;} ;if(Ox1a4.indexOf(OxOac7a[0x83])!=-0x1){ Ox1a4=Ox1a4+OxOac7a[0x84]+Ox91 ;} else { Ox1a4=Ox1a4+OxOac7a[0x85]+Ox91 ;} ;if(inp_width[OxOac7a[0x10]]==OxOac7a[0x86]||inp_width[OxOac7a[0x10]]==OxOac7a[0xf]){ inp_width[OxOac7a[0x10]]=Ox395[OxOac7a[0x77]] ; inp_height[OxOac7a[0x10]]=Ox395[OxOac7a[0x78]] ;} ; img_demo[OxOac7a[0x75]]=Ox1a4 ;if(Browser_IsWinIE()){ Event_Attach(img_demo,OxOac7a[0x87],OnImageMouseWheel) ;} ; img_demo[OxOac7a[0x7f]]=AlternateText[OxOac7a[0x10]] ; img_demo[OxOac7a[0x7e]]=Align[OxOac7a[0x10]] ; img_demo[OxOac7a[0x77]]=inp_width[OxOac7a[0x10]] ; img_demo[OxOac7a[0x78]]=inp_height[OxOac7a[0x10]] ; img_demo[OxOac7a[0x79]]=VSpace[OxOac7a[0x10]] ; img_demo[OxOac7a[0x7a]]=HSpace[OxOac7a[0x10]] ;if(parseInt(Border.value)>0x0){ img_demo[OxOac7a[0x7b]]=Border[OxOac7a[0x10]] ;} ;if(bordercolor[OxOac7a[0x10]]!=OxOac7a[0xf]){ img_demo[OxOac7a[0x3]][OxOac7a[0x7c]]=bordercolor[OxOac7a[0x10]] ;} ; Ox1a4=Ox1a4.toLowerCase() ;if(Ox1a4.indexOf(OxOac7a[0x88])!=-0x1){ img_AutoThumbnail[OxOac7a[0x3]][OxOac7a[0x89]]=OxOac7a[0x8a] ;if(img_ImageEditor){ img_ImageEditor[OxOac7a[0x3]][OxOac7a[0x89]]=OxOac7a[0x8a] ;} ;} ;} ;}  ; Ox396=window.setInterval(Ox397,0x64) ;} ;}  ; function do_insert(){var img=element; img[OxOac7a[0x75]]=TargetUrl[OxOac7a[0x10]] ;if(editor.GetActiveTab()==OxOac7a[0x8b]){ img.setAttribute(OxOac7a[0x76],TargetUrl.value) ;} ; img[OxOac7a[0x77]]=inp_width[OxOac7a[0x10]] ; img[OxOac7a[0x78]]=inp_height[OxOac7a[0x10]] ;if(img[OxOac7a[0x3]][OxOac7a[0x77]]||img[OxOac7a[0x3]][OxOac7a[0x78]]){ img[OxOac7a[0x3]][OxOac7a[0x77]]=inp_width[OxOac7a[0x10]] ; img[OxOac7a[0x3]][OxOac7a[0x78]]=inp_height[OxOac7a[0x10]] ;} ; img[OxOac7a[0x79]]=VSpace[OxOac7a[0x10]] ; img[OxOac7a[0x7a]]=HSpace[OxOac7a[0x10]] ; img[OxOac7a[0x7b]]=Border[OxOac7a[0x10]] ;var Ox2ec=/[^a-z\d]/i;if(Ox2ec.test(inp_id.value)){ alert(OxOac7a[0x8c]) ;return ;} ; img[OxOac7a[0x35]]=inp_id[OxOac7a[0x10]] ;try{ img[OxOac7a[0x3]][OxOac7a[0x7c]]=bordercolor[OxOac7a[0x10]] ;} catch(er){ alert(OxOac7a[0x8d]) ;return false;} ; img[OxOac7a[0x7e]]=Align[OxOac7a[0x10]] ; img[OxOac7a[0x7f]]=AlternateText[OxOac7a[0x10]]||OxOac7a[0xf] ; img[OxOac7a[0x6b]]=longDesc[OxOac7a[0x10]] ;if(TargetUrl[OxOac7a[0x10]]==OxOac7a[0xf]){ alert(OxOac7a[0x8e]) ;return false;} ;if(img[OxOac7a[0x77]]==0x0){ img.removeAttribute(OxOac7a[0x77]) ;} ;if(img[OxOac7a[0x78]]==0x0){ img.removeAttribute(OxOac7a[0x78]) ;} ;if(img[OxOac7a[0x8f]]==OxOac7a[0xf]||img[OxOac7a[0x8f]]==null){ img.removeAttribute(OxOac7a[0x8f]) ;} ;if(img[OxOac7a[0x6b]]==OxOac7a[0xf]||img[OxOac7a[0x6b]]==null){ img.removeAttribute(OxOac7a[0x6b]) ;} ;if(img[OxOac7a[0x7a]]==OxOac7a[0xf]){ img.removeAttribute(OxOac7a[0x7a]) ;} ;if(img[OxOac7a[0x79]]==OxOac7a[0xf]){ img.removeAttribute(OxOac7a[0x79]) ;} ;if(img[OxOac7a[0x35]]==OxOac7a[0xf]){ img.removeAttribute(OxOac7a[0x35]) ;} ;if(img[OxOac7a[0x7b]]==OxOac7a[0xf]){ img.removeAttribute(OxOac7a[0x7b]) ;} ;if(img[OxOac7a[0x7e]]==OxOac7a[0xf]){ img.removeAttribute(OxOac7a[0x7e]) ;} ; editor.InsertElement(img) ; Window_CloseDialog(window) ;}  ; function attr(name,Ox115){if(!Ox115||Ox115==OxOac7a[0xf]){return OxOac7a[0xf];} ;return OxOac7a[0x34]+name+OxOac7a[0x90]+Ox115+OxOac7a[0x91];}  ; function do_Close(){ Window_CloseDialog(window) ;}  ; function Zoom_In(){if(Browser_IsWinIE()){if(divpreview[OxOac7a[0x3]][OxOac7a[0x2]]!=0x0){ divpreview[OxOac7a[0x3]][OxOac7a[0x2]]*=1.2 ;} else { divpreview[OxOac7a[0x3]][OxOac7a[0x2]]=1.2 ;} ;} ;}  ; function Zoom_Out(){if(Browser_IsWinIE()){if(divpreview[OxOac7a[0x3]][OxOac7a[0x2]]!=0x0){ divpreview[OxOac7a[0x3]][OxOac7a[0x2]]*=0.8 ;} else { divpreview[OxOac7a[0x3]][OxOac7a[0x2]]=0.8 ;} ;} ;}  ; function BestFit(){var img=img_demo;if(!img){return ;} ;var Ox5c=0x118;var Ox5d=0x122;if(Browser_IsWinIE()){ divpreview[OxOac7a[0x3]][OxOac7a[0x2]]=0x1/Math.max(img[OxOac7a[0x77]]/Ox5d,img[OxOac7a[0x78]]/Ox5c) ;} ;}  ; function Actualsize(){ inp_width[OxOac7a[0x10]]=OxOac7a[0xf] ; inp_height[OxOac7a[0x10]]=OxOac7a[0xf] ; do_preview() ;if(Browser_IsWinIE()){ divpreview[OxOac7a[0x3]][OxOac7a[0x2]]=0x1 ;} ;}  ; function toggleConstrains(){if(constrain_prop[OxOac7a[0x92]]){ imgLock[OxOac7a[0x75]]=OxOac7a[0x93] ; checkConstrains(OxOac7a[0x77]) ;} else { imgLock[OxOac7a[0x75]]=OxOac7a[0x94] ;} ;}  ;var checkingConstrains=false; function checkConstrains(Ox63){if(checkingConstrains){return ;} ; checkingConstrains=true ;try{if(constrain_prop[OxOac7a[0x92]]){var Ox66= new Image(); Ox66[OxOac7a[0x75]]=TargetUrl[OxOac7a[0x10]] ;var Ox398=Ox66[OxOac7a[0x77]];var Ox399=Ox66[OxOac7a[0x78]];if((Ox398>0x0)&&(Ox399>0x0)){var Ox5d=inp_width[OxOac7a[0x10]];var Ox5c=inp_height[OxOac7a[0x10]];if(Ox63==OxOac7a[0x77]){if(Ox5d[OxOac7a[0x24]]==0x0||isNaN(Ox5d)){ inp_width[OxOac7a[0x10]]=OxOac7a[0xf] ; inp_height[OxOac7a[0x10]]=OxOac7a[0xf] ;} else { Ox5c=parseInt(Ox5d*Ox399/Ox398) ; inp_height[OxOac7a[0x10]]=Ox5c ;} ;} ;if(Ox63==OxOac7a[0x78]){if(Ox5c[OxOac7a[0x24]]==0x0||isNaN(Ox5c)){ inp_width[OxOac7a[0x10]]=OxOac7a[0xf] ; inp_height[OxOac7a[0x10]]=OxOac7a[0xf] ;} else { Ox5d=parseInt(Ox5c*Ox398/Ox399) ; inp_width[OxOac7a[0x10]]=Ox5d ;} ;} ;} ;} ; do_preview() ;} finally{ checkingConstrains=false ;} ;}  ; function AutoThumbnail(){if(TargetUrl[OxOac7a[0x10]]==OxOac7a[0xf]){ alert(OxOac7a[0x95]) ;return false;} ;var obj= new Object(); obj[OxOac7a[0x75]]=TargetUrl[OxOac7a[0x10]] ; obj[OxOac7a[0x96]]=FolderDescription[OxOac7a[0x38]]+OxOac7a[0xf] ; function Ox2d3(Ox17f){if(Ox17f){ TargetUrl[OxOac7a[0x10]]=Ox17f ; hiddenAction[OxOac7a[0x10]]=OxOac7a[0x97] ; window.PostBackAction() ;} ;}  ; editor.SetNextDialogWindow(window) ; editor.ShowDialog(Ox2d3,OxOac7a[0x98]+GetDialogQueryString(),obj,OxOac7a[0x99]) ;}  ; function GetDialogQueryString(){var Ox109=OxOac7a[0xf];if(editor.GetScriptProperty(OxOac7a[0x9a])==OxOac7a[0x9b]){ Ox109=OxOac7a[0x9c] ;} ;return OxOac7a[0x9f]+editor.GetScriptProperty(OxOac7a[0x9e])+OxOac7a[0xa0]+editor.GetScriptProperty(OxOac7a[0x9d])+Ox109;}  ; function ImageEditor(){if(TargetUrl[OxOac7a[0x10]]==OxOac7a[0xf]){ alert(OxOac7a[0xa1]) ;return false;} ;var img= new Image(); img[OxOac7a[0x75]]=TargetUrl[OxOac7a[0x10]] ;var src=TargetUrl[OxOac7a[0x10]];var p=OxOac7a[0xa2]; function Ox2d3(arr){ TargetUrl[OxOac7a[0x10]]=src ; do_preview() ;}  ; editor.SetNextDialogWindow(window) ; editor.ShowDialog(Ox2d3,OxOac7a[0xa3]+src+OxOac7a[0xa4]+p,img,OxOac7a[0xa5]) ;}  ; bordercolor[OxOac7a[0xa6]]=bordercolor_Preview[OxOac7a[0xa6]]=function bordercolor_onclick(){ SelectColor(bordercolor,bordercolor_Preview) ;}  ;if(!Browser_IsWinIE()){ img_ImageEditor[OxOac7a[0x3]][OxOac7a[0x89]]=btn_zoom_in[OxOac7a[0x3]][OxOac7a[0x89]]=btn_zoom_out[OxOac7a[0x3]][OxOac7a[0x89]]=btn_bestfit[OxOac7a[0x3]][OxOac7a[0x89]]=btn_Actualsize[OxOac7a[0x3]][OxOac7a[0x89]]=OxOac7a[0x8a] ;} ;if(Browser_IsIE7()){var _dialogPromptID=null; function IEprompt(Ox194,Ox195,Ox196){ that=this ; this[OxOac7a[0xa7]]=function (Ox197){ val=document.getElementById(OxOac7a[0xa8])[OxOac7a[0x10]] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0x89]]=OxOac7a[0x8a] ; document.getElementById(OxOac7a[0xa8])[OxOac7a[0x10]]=OxOac7a[0xf] ;if(Ox197){ val=OxOac7a[0xf] ;} ; Ox194(val) ;return false;}  ;if(Ox196==undefined){ Ox196=OxOac7a[0xf] ;} ;if(_dialogPromptID==null){var Ox198=document.getElementsByTagName(OxOac7a[0xa9])[0x0]; tnode=document.createElement(OxOac7a[0xaa]) ; tnode[OxOac7a[0x35]]=OxOac7a[0xab] ; Ox198.appendChild(tnode) ; _dialogPromptID=document.getElementById(OxOac7a[0xab]) ; tnode=document.createElement(OxOac7a[0xaa]) ; tnode[OxOac7a[0x35]]=OxOac7a[0xac] ; Ox198.appendChild(tnode) ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0x7b]]=OxOac7a[0xad] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0x7d]]=OxOac7a[0xae] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0xaf]]=OxOac7a[0xb0] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0x77]]=OxOac7a[0xb1] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0xb2]]=OxOac7a[0xb3] ;} ;var Ox199=OxOac7a[0xb4]; Ox199+=OxOac7a[0xb5]+Ox195+OxOac7a[0xb6] ; Ox199+=OxOac7a[0xb7] ; Ox199+=OxOac7a[0xb8]+Ox196+OxOac7a[0xb9] ; Ox199+=OxOac7a[0xba] ; Ox199+=OxOac7a[0xbb] ; Ox199+=OxOac7a[0xbc] ; Ox199+=OxOac7a[0xbd] ; Ox199+=OxOac7a[0xbe] ; _dialogPromptID[OxOac7a[0x38]]=Ox199 ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0x5]]=OxOac7a[0xbf] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0xc1]]=parseInt((document[OxOac7a[0xa9]][OxOac7a[0xc0]]-0x13b)/0x2)+OxOac7a[0xc2] ; _dialogPromptID[OxOac7a[0x3]][OxOac7a[0x89]]=OxOac7a[0xc3] ;var Ox19a=document.getElementById(OxOac7a[0xa8]);try{var Ox19b=Ox19a.createTextRange(); Ox19b.collapse(false) ; Ox19b.select() ;} catch(x){ Ox19a.focus() ;} ;}  ;} ;if(CreateDir){ CreateDir[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(Copy){ Copy[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(Move){ Move[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(Delete){ Delete[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(DoRefresh){ DoRefresh[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(btn_zoom_in){ btn_zoom_in[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(btn_zoom_out){ btn_zoom_out[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(btn_Actualsize){ btn_Actualsize[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(img_ImageEditor){ img_ImageEditor[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(btn_bestfit){ btn_bestfit[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;if(img_AutoThumbnail){ img_AutoThumbnail[OxOac7a[0x26]]= new Function(OxOac7a[0xc4]) ;} ;