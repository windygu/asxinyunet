var OxOfa4c=["undefined","Microsoft.XMLHTTP","readyState","onreadystatechange","","document","length","element \x27","\x27 not found","returnValue","preventDefault","cancelBubble","stopPropagation","onchange","oninitialized","command","commandui","commandvalue","oncommand","string","event","_fireEventFunction","parentNode","_IsCuteEditor","True","readOnly","_IsRichDropDown","null","value","selectedIndex","nodeName","TR","cells","display","style","nextSibling","innerHTML","\x3Cimg src=\x22","/Load.ashx?type=image\x26file=t-minus.gif\x22\x3E","CuteEditor_CollapseTreeDropDownItem(this,\x22","\x22)","onclick","none","/Load.ashx?type=image\x26file=t-plus.gif\x22\x3E","CuteEditor_ExpandTreeDropDownItem(this,\x22","//TODO: event not found? throw error ?","all","UNSELECTABLE","on","tabIndex","-1","contentWindow","contentDocument","parentWindow","id","frames","frameElement","//TODO:frame contentWindow not found?","head","script","language","javascript","type","text/javascript","src","caller","arguments","parent","top","opener","srcElement","target","//TODO: srcElement not found? throw error ?","fromElement","relatedTarget","toElement","keyCode","clientX","clientY","offsetX","offsetY","button","ctrlKey","altKey","shiftKey","CuteEditor_GetEditor(this).ExecImageCommand(this.getAttribute(\x27Command\x27),this.getAttribute(\x27CommandUI\x27),this.getAttribute(\x27CommandArgument\x27),this)","CuteEditor_GetEditor(this).PostBack(this.getAttribute(\x27Command\x27))","this.onmouseout();CuteEditor_GetEditor(this).DropMenu(this.getAttribute(\x27Group\x27),this)","ResourceDir","Theme","/Load.ashx?type=theme\x26theme=","\x26file=all.png","/Images/blank2020.gif","IMG","Command","Group","ThemeIndex","width","20px","height","backgroundImage","url(",")","backgroundPosition","0 -","px","className","separator","CuteEditorButton","CuteEditor_ButtonCommandOver(this)","onmouseover","CuteEditor_ButtonCommandOut(this)","onmouseout","CuteEditor_ButtonCommandDown(this)","onmousedown","CuteEditor_ButtonCommandUp(this)","onmouseup","oncontextmenu","ondragstart","PostBack","ondblclick","_ToolBarID","_CodeViewToolBarID","_FrameID"," CuteEditorFrame"," CuteEditorToolbar","buttonInitialized","isover","CuteEditorButtonOver","CuteEditorButtonDown","CuteEditorDown","border","solid 1px #0A246A","backgroundColor","#b6bdd2","padding","1px","solid 1px #f5f5f4","inset 1px","IsCommandDisabled","CuteEditorButtonDisabled","IsCommandActive","CuteEditorButtonActive","(","href","location",",DanaInfo=",",","+","scriptProperties","GetScriptProperty","/Load.ashx?type=scripts\x26file=IE_Implementation","/Load.ashx?type=scripts\x26file=EditorExtension","CuteEditorImplementation","function","POST","\x26getModified=1","loadScript","status","Failed to load impl time!","GET","\x26modified=","Failed to load impl code!","cursor","body","InitializeCode","block","contentEditable","no-drop","CuteEditorInitialize"]; function CreateXMLHttpRequest(){try{if( typeof (XMLHttpRequest)!=OxOfa4c[0x0]){return  new XMLHttpRequest();} ;if( typeof (ActiveXObject)!=OxOfa4c[0x0]){return  new ActiveXObject(OxOfa4c[0x1]);} ;} catch(x){return null;} ;}  ; function LoadXMLAsync(Ox942,Ox1fe,Ox1a7,Ox943){var Oxd0=CreateXMLHttpRequest(); function Ox944(){if(Oxd0[OxOfa4c[0x2]]!=0x4){return ;} ; Oxd0[OxOfa4c[0x3]]= new Function() ;var Ox206=Oxd0; Oxd0=null ; Ox1a7(Ox206) ;}  ; Oxd0[OxOfa4c[0x3]]=Ox944 ; Oxd0.open(Ox942,Ox1fe,true) ; Oxd0.send(Ox943||OxOfa4c[0x4]) ;}  ; function Window_GetElement(Ox1ae,Ox83,Ox1b3){var Ox27=Ox1ae[OxOfa4c[0x5]].getElementById(Ox83);if(Ox27){return Ox27;} ;var Ox2f=Ox1ae[OxOfa4c[0x5]].getElementsByName(Ox83);if(Ox2f[OxOfa4c[0x6]]>0x0){return Ox2f.item(0x0);} ;if(Ox1b3){throw ( new Error(OxOfa4c[0x7]+Ox83+OxOfa4c[0x8]));} ;return null;}  ; function Event_PreventDefault(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ; Ox1b9[OxOfa4c[0x9]]=false ;if(Ox1b9[OxOfa4c[0xa]]){ Ox1b9.preventDefault() ;} ;}  ; function Event_CancelBubble(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ; Ox1b9[OxOfa4c[0xb]]=true ;if(Ox1b9[OxOfa4c[0xc]]){ Ox1b9.stopPropagation() ;} ;return false;}  ; function Event_CancelEvent(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ; Event_PreventDefault(Ox1b9) ;return Event_CancelBubble(Ox1b9);}  ; function CuteEditor_AddMainMenuItems(Ox5e5){}  ; function CuteEditor_AddDropMenuItems(Ox5e5,Ox5ec){}  ; function CuteEditor_AddTagMenuItems(Ox5e5,Ox5ee){}  ; function CuteEditor_AddVerbMenuItems(Ox5e5,Ox5ee){}  ; function CuteEditor_OnInitialized(editor){}  ; function CuteEditor_OnCommand(editor,Ox5f2,Ox5f3,Ox115){}  ; function CuteEditor_OnChange(editor){}  ; function CuteEditor_FilterCode(editor,Ox1e0){return Ox1e0;}  ; function CuteEditor_FilterHTML(editor,Ox1f8){return Ox1f8;}  ; function CuteEditor_FireChange(editor){ window.CuteEditor_OnChange(editor) ; CuteEditor_FireEvent(editor,OxOfa4c[0xd],null) ;}  ; function CuteEditor_FireInitialized(editor){ window.CuteEditor_OnInitialized(editor) ; CuteEditor_FireEvent(editor,OxOfa4c[0xe],null) ;}  ; function CuteEditor_FireCommand(editor,Ox5f2,Ox5f3,Ox115){var Ox130=window.CuteEditor_OnCommand(editor,Ox5f2,Ox5f3,Ox115);if(Ox130==true){return true;} ;var Ox5fa={}; Ox5fa[OxOfa4c[0xf]]=Ox5f2 ; Ox5fa[OxOfa4c[0x10]]=Ox5f3 ; Ox5fa[OxOfa4c[0x11]]=Ox115 ; Ox5fa[OxOfa4c[0x9]]=true ; CuteEditor_FireEvent(editor,OxOfa4c[0x12],Ox5fa) ;if(Ox5fa[OxOfa4c[0x9]]==false){return true;} ;}  ; function CuteEditor_FireEvent(editor,Ox5fc,Ox5fd){if(Ox5fd==null){ Ox5fd={} ;} ;var Ox5fe=editor.getAttribute(Ox5fc);if(Ox5fe){if( typeof (Ox5fe)==OxOfa4c[0x13]){ editor[OxOfa4c[0x15]]= new Function(OxOfa4c[0x14],Ox5fe) ;} else { editor[OxOfa4c[0x15]]=Ox5fe ;} ; editor._fireEventFunction(Ox5fd) ;} ;}  ; function CuteEditor_GetEditor(element){for(var Ox42=element;Ox42!=null;Ox42=Ox42[OxOfa4c[0x16]]){if(Ox42.getAttribute(OxOfa4c[0x17])==OxOfa4c[0x18]){return Ox42;} ;} ;return null;}  ; function CuteEditor_DropDownCommand(element,Ox946){var editor=CuteEditor_GetEditor(element);if(editor[OxOfa4c[0x19]]){return ;} ;if(element.getAttribute(OxOfa4c[0x1a])==OxOfa4c[0x18]){var Ox134=element.GetValue();if(Ox134==OxOfa4c[0x1b]){ Ox134=OxOfa4c[0x4] ;} ;var Ox176=element.GetText();if(Ox176==OxOfa4c[0x1b]){ Ox176=OxOfa4c[0x4] ;} ; element.SetSelectedIndex(0x0) ; editor.ExecCommand(Ox946,false,Ox134,Ox176) ;} else {if(!editor[OxOfa4c[0x19]]&&element[OxOfa4c[0x1c]]){var Ox134=element[OxOfa4c[0x1c]];if(Ox134==OxOfa4c[0x1b]){ Ox134=OxOfa4c[0x4] ;} ; element[OxOfa4c[0x1d]]=0x0 ; editor.ExecCommand(Ox946,false,Ox134,Ox176) ;} else { element[OxOfa4c[0x1d]]=0x0 ;} ;} ; editor.FocusDocument() ;}  ; function CuteEditor_ExpandTreeDropDownItem(src,Ox6ba){var Oxa3=null;while(src!=null){if(src[OxOfa4c[0x1e]]==OxOfa4c[0x1f]){ Oxa3=src ;break ;} ; src=src[OxOfa4c[0x16]] ;} ;var Ox313=Oxa3[OxOfa4c[0x20]].item(0x0); Oxa3[OxOfa4c[0x23]][OxOfa4c[0x22]][OxOfa4c[0x21]]=OxOfa4c[0x4] ; Ox313[OxOfa4c[0x24]]=OxOfa4c[0x25]+Ox6ba+OxOfa4c[0x26] ; Oxa3[OxOfa4c[0x29]]= new Function(OxOfa4c[0x27]+Ox6ba+OxOfa4c[0x28]) ;}  ; function CuteEditor_CollapseTreeDropDownItem(src,Ox6ba){var Oxa3=null;while(src!=null){if(src[OxOfa4c[0x1e]]==OxOfa4c[0x1f]){ Oxa3=src ;break ;} ; src=src[OxOfa4c[0x16]] ;} ;var Ox313=Oxa3[OxOfa4c[0x20]].item(0x0); Oxa3[OxOfa4c[0x23]][OxOfa4c[0x22]][OxOfa4c[0x21]]=OxOfa4c[0x2a] ; Ox313[OxOfa4c[0x24]]=OxOfa4c[0x25]+Ox6ba+OxOfa4c[0x2b] ; Oxa3[OxOfa4c[0x29]]= new Function(OxOfa4c[0x2c]+Ox6ba+OxOfa4c[0x28]) ;}  ; function Event_GetEvent(Ox1b9){ Ox1b9=Event_FindEvent(Ox1b9) ;if(Ox1b9==null){ Debug_Todo(OxOfa4c[0x2d]) ;} ;return Ox1b9;}  ; function Element_GetAllElements(p){var arr=[];for(var i=0x0;i<p[OxOfa4c[0x2e]][OxOfa4c[0x6]];i++){ arr.push(p[OxOfa4c[0x2e]].item(i)) ;} ;return arr;}  ; function Element_SetUnselectable(element){ element.setAttribute(OxOfa4c[0x2f],OxOfa4c[0x30]) ; element.setAttribute(OxOfa4c[0x31],OxOfa4c[0x32]) ;var arr=Element_GetAllElements(element);var len=arr[OxOfa4c[0x6]];if(!len){return ;} ;for(var i=0x0;i<len;i++){ arr[i].setAttribute(OxOfa4c[0x2f],OxOfa4c[0x30]) ; arr[i].setAttribute(OxOfa4c[0x31],OxOfa4c[0x32]) ;} ;}  ; function Frame_GetContentWindow(Ox2bf){if(Ox2bf[OxOfa4c[0x33]]){return Ox2bf[OxOfa4c[0x33]];} ;if(Ox2bf[OxOfa4c[0x34]]){if(Ox2bf[OxOfa4c[0x34]][OxOfa4c[0x35]]){return Ox2bf[OxOfa4c[0x34]][OxOfa4c[0x35]];} ;} ;var Ox1ae;if(Ox2bf[OxOfa4c[0x36]]){ Ox1ae=window[OxOfa4c[0x37]][Ox2bf[OxOfa4c[0x36]]] ;if(Ox1ae){return Ox1ae;} ;} ;var len=window[OxOfa4c[0x37]][OxOfa4c[0x6]];for(var i=0x0;i<len;i++){ Ox1ae=window[OxOfa4c[0x37]][i] ;if(Ox1ae[OxOfa4c[0x38]]==Ox2bf){return Ox1ae;} ;if(Ox1ae[OxOfa4c[0x5]]==Ox2bf[OxOfa4c[0x34]]){return Ox1ae;} ;} ; Debug_Todo(OxOfa4c[0x39]) ;}  ; function Array_IndexOf(arr,Ox1bb){for(var i=0x0;i<arr[OxOfa4c[0x6]];i++){if(arr[i]==Ox1bb){return i;} ;} ;return -0x1;}  ; function Array_Contains(arr,Ox1bb){return Array_IndexOf(arr,Ox1bb)!=-0x1;}  ; function clearArray(Ox1be){for(var i=0x0;i<Ox1be[OxOfa4c[0x6]];i++){ Ox1be[i]=null ;} ;}  ; function Event_FindEvent(Ox1b9){if(Ox1b9&&Ox1b9[OxOfa4c[0xa]]){return Ox1b9;} ;if(window[OxOfa4c[0x14]]){return window[OxOfa4c[0x14]];} ;return Event_FindEvent_FindEventFromWindows();}  ; function include(Oxb2,Ox1fe){var Ox1ff=document.getElementsByTagName(OxOfa4c[0x3a]).item(0x0);var Ox200=document.getElementById(Oxb2);if(Ox200){ Ox1ff.removeChild(Ox200) ;} ;var Ox201=document.createElement(OxOfa4c[0x3b]); Ox201.setAttribute(OxOfa4c[0x3c],OxOfa4c[0x3d]) ; Ox201.setAttribute(OxOfa4c[0x3e],OxOfa4c[0x3f]) ; Ox201.setAttribute(OxOfa4c[0x40],Ox1fe) ; Ox201.setAttribute(OxOfa4c[0x36],Oxb2) ; Ox1ff.appendChild(Ox201) ;}  ; function Event_FindEvent_FindEventFromCallers(){var Ox1c1=Event_GetEvent[OxOfa4c[0x41]];for(var i=0x0;i<0x64;i++){if(!Ox1c1){break ;} ;var Ox1b9=Ox1c1[OxOfa4c[0x42]][0x0];if(Ox1b9&&Ox1b9[OxOfa4c[0xa]]){return Ox1b9;} ; Ox1c1=Ox1c1[OxOfa4c[0x41]] ;} ;}  ; function Event_FindEvent_FindEventFromWindows(){var arr=[];return Ox1c3(window); function Ox1c3(Ox1ae){if(Ox1ae==null){return null;} ;if(Ox1ae[OxOfa4c[0x14]]){return Ox1ae[OxOfa4c[0x14]];} ;if(Array_Contains(arr,Ox1ae)){return null;} ; arr.push(Ox1ae) ;var Ox1c4=[];if(Ox1ae[OxOfa4c[0x43]]!=Ox1ae){ Ox1c4.push(Ox1ae.parent) ;} ;if(Ox1ae[OxOfa4c[0x44]]!=Ox1ae[OxOfa4c[0x43]]){ Ox1c4.push(Ox1ae.top) ;} ;if(Ox1ae[OxOfa4c[0x45]]){ Ox1c4.push(Ox1ae.opener) ;} ;for(var i=0x0;i<Ox1ae[OxOfa4c[0x37]][OxOfa4c[0x6]];i++){ Ox1c4.push(Ox1ae[OxOfa4c[0x37]][i]) ;} ;for(var i=0x0;i<Ox1c4[OxOfa4c[0x6]];i++){try{var Ox1b9=Ox1c3(Ox1c4[i]);if(Ox1b9){return Ox1b9;} ;} catch(x){} ;} ;return null;}  ;}  ; function Event_GetSrcElement(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Ox1b9[OxOfa4c[0x46]]){return Ox1b9[OxOfa4c[0x46]];} ;if(Ox1b9[OxOfa4c[0x47]]){return Ox1b9[OxOfa4c[0x47]];} ; Debug_Todo(OxOfa4c[0x48]) ;return null;}  ; function Event_GetFromElement(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Ox1b9[OxOfa4c[0x49]]){return Ox1b9[OxOfa4c[0x49]];} ;if(Ox1b9[OxOfa4c[0x4a]]){return Ox1b9[OxOfa4c[0x4a]];} ;return null;}  ; function Event_GetToElement(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Ox1b9[OxOfa4c[0x4b]]){return Ox1b9[OxOfa4c[0x4b]];} ;if(Ox1b9[OxOfa4c[0x4a]]){return Ox1b9[OxOfa4c[0x4a]];} ;return null;}  ; function Event_GetKeyCode(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x4c]];}  ; function Event_GetClientX(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x4d]];}  ; function Event_GetClientY(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x4e]];}  ; function Event_GetOffsetX(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x4f]];}  ; function Event_GetOffsetY(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x50]];}  ; function Event_IsLeftButton(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x51]]==0x1;}  ; function Event_IsCtrlKey(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x52]];}  ; function Event_IsAltKey(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x53]];}  ; function Event_IsShiftKey(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxOfa4c[0x54]];}  ; function CuteEditor_BasicInitialize(editor){var Ox684= new Function(OxOfa4c[0x55]);var Ox94b= new Function(OxOfa4c[0x56]);var Ox94c= new Function(OxOfa4c[0x57]);var Ox94d=editor.GetScriptProperty(OxOfa4c[0x58]);var Ox94e=editor.GetScriptProperty(OxOfa4c[0x59]);var Ox94f=Ox94d+OxOfa4c[0x5a]+Ox94e+OxOfa4c[0x5b];var Ox950=Ox94d+OxOfa4c[0x5c];var images=editor.getElementsByTagName(OxOfa4c[0x5d]);var len=images[OxOfa4c[0x6]];for(var i=0x0;i<len;i++){var img=images[i];var Ox127=img.getAttribute(OxOfa4c[0x5e]);var Ox5ec=img.getAttribute(OxOfa4c[0x5f]);if(!(Ox127||Ox5ec)){continue ;} ;var Ox951=img.getAttribute(OxOfa4c[0x60]);if(parseInt(Ox951)>=0x0){ img[OxOfa4c[0x22]][OxOfa4c[0x61]]=OxOfa4c[0x62] ; img[OxOfa4c[0x22]][OxOfa4c[0x63]]=OxOfa4c[0x62] ; img[OxOfa4c[0x40]]=Ox950 ; img[OxOfa4c[0x22]][OxOfa4c[0x64]]=OxOfa4c[0x65]+Ox94f+OxOfa4c[0x66] ; img[OxOfa4c[0x22]][OxOfa4c[0x67]]=OxOfa4c[0x68]+(Ox951*0x14)+OxOfa4c[0x69] ; img[OxOfa4c[0x22]][OxOfa4c[0x21]]=OxOfa4c[0x4] ;} ;if(img[OxOfa4c[0x6a]]!=OxOfa4c[0x6b]){ img[OxOfa4c[0x6a]]=OxOfa4c[0x6c] ; img[OxOfa4c[0x6e]]= new Function(OxOfa4c[0x6d]) ; img[OxOfa4c[0x70]]= new Function(OxOfa4c[0x6f]) ; img[OxOfa4c[0x72]]= new Function(OxOfa4c[0x71]) ; img[OxOfa4c[0x74]]= new Function(OxOfa4c[0x73]) ;} ;if(!img[OxOfa4c[0x75]]){ img[OxOfa4c[0x75]]=Event_CancelEvent ;} ;if(!img[OxOfa4c[0x76]]){ img[OxOfa4c[0x76]]=Event_CancelEvent ;} ;if(Ox127){var Ox1c1=img.getAttribute(OxOfa4c[0x77])==OxOfa4c[0x18]?Ox94b:Ox684;if(img[OxOfa4c[0x29]]==null){ img[OxOfa4c[0x29]]=Ox1c1 ;} ;if(img[OxOfa4c[0x78]]==null){ img[OxOfa4c[0x78]]=Ox1c1 ;} ;} else {if(Ox5ec){if(img[OxOfa4c[0x29]]==null){ img[OxOfa4c[0x29]]=Ox94c ;} ;} ;} ;} ;var Ox6ef=Window_GetElement(window,editor.GetScriptProperty(OxOfa4c[0x79]),true);var Ox6f0=Window_GetElement(window,editor.GetScriptProperty(OxOfa4c[0x7a]),true);var Ox6eb=Window_GetElement(window,editor.GetScriptProperty(OxOfa4c[0x7b]),true); Ox6eb[OxOfa4c[0x6a]]+=OxOfa4c[0x7c] ; Ox6ef[OxOfa4c[0x6a]]+=OxOfa4c[0x7d] ; Ox6f0[OxOfa4c[0x6a]]+=OxOfa4c[0x7d] ; Element_SetUnselectable(Ox6ef) ; Element_SetUnselectable(Ox6f0) ;}  ; function CuteEditor_ButtonOver(element){if(!element[OxOfa4c[0x7e]]){ element[OxOfa4c[0x75]]=Event_CancelEvent ; element[OxOfa4c[0x70]]=CuteEditor_ButtonOut ; element[OxOfa4c[0x72]]=CuteEditor_ButtonDown ; element[OxOfa4c[0x74]]=CuteEditor_ButtonUp ; Element_SetUnselectable(element) ; element[OxOfa4c[0x7e]]=true ;} ; element[OxOfa4c[0x7f]]=true ; element[OxOfa4c[0x6a]]=OxOfa4c[0x80] ;}  ; function CuteEditor_ButtonOut(){var element=this; element[OxOfa4c[0x6a]]=OxOfa4c[0x6c] ; element[OxOfa4c[0x7f]]=false ;}  ; function CuteEditor_ButtonDown(){if(!Event_IsLeftButton()){return ;} ;var element=this; element[OxOfa4c[0x6a]]=OxOfa4c[0x81] ;}  ; function CuteEditor_ButtonUp(){if(!Event_IsLeftButton()){return ;} ;var element=this;if(element[OxOfa4c[0x7f]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x80] ;} else { element[OxOfa4c[0x6a]]=OxOfa4c[0x82] ;} ;}  ; function CuteEditor_ColorPicker_ButtonOver(element){if(!element[OxOfa4c[0x7e]]){ element[OxOfa4c[0x75]]=Event_CancelEvent ; element[OxOfa4c[0x70]]=CuteEditor_ColorPicker_ButtonOut ; element[OxOfa4c[0x72]]=CuteEditor_ColorPicker_ButtonDown ; Element_SetUnselectable(element) ; element[OxOfa4c[0x7e]]=true ;} ; element[OxOfa4c[0x7f]]=true ; element[OxOfa4c[0x22]][OxOfa4c[0x83]]=OxOfa4c[0x84] ; element[OxOfa4c[0x22]][OxOfa4c[0x85]]=OxOfa4c[0x86] ; element[OxOfa4c[0x22]][OxOfa4c[0x87]]=OxOfa4c[0x88] ;}  ; function CuteEditor_ColorPicker_ButtonOut(){var element=this; element[OxOfa4c[0x7f]]=false ; element[OxOfa4c[0x22]][OxOfa4c[0x83]]=OxOfa4c[0x89] ; element[OxOfa4c[0x22]][OxOfa4c[0x85]]=OxOfa4c[0x4] ; element[OxOfa4c[0x22]][OxOfa4c[0x87]]=OxOfa4c[0x88] ;}  ; function CuteEditor_ColorPicker_ButtonDown(){var element=this; element[OxOfa4c[0x22]][OxOfa4c[0x83]]=OxOfa4c[0x8a] ; element[OxOfa4c[0x22]][OxOfa4c[0x85]]=OxOfa4c[0x4] ; element[OxOfa4c[0x22]][OxOfa4c[0x87]]=OxOfa4c[0x88] ;}  ; function CuteEditor_ButtonCommandOver(element){ element[OxOfa4c[0x7f]]=true ;if(element[OxOfa4c[0x8b]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x8c] ;} else { element[OxOfa4c[0x6a]]=OxOfa4c[0x80] ;} ;}  ; function CuteEditor_ButtonCommandOut(element){ element[OxOfa4c[0x7f]]=false ;if(element[OxOfa4c[0x8d]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x8e] ;} else {if(element[OxOfa4c[0x8b]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x8c] ;} else { element[OxOfa4c[0x6a]]=OxOfa4c[0x6c] ;} ;} ;}  ; function CuteEditor_ButtonCommandDown(element){if(!Event_IsLeftButton()){return ;} ; element[OxOfa4c[0x6a]]=OxOfa4c[0x81] ;}  ; function CuteEditor_ButtonCommandUp(element){if(!Event_IsLeftButton()){return ;} ;if(element[OxOfa4c[0x8b]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x8c] ;return ;} ;if(element[OxOfa4c[0x7f]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x80] ;} else {if(element[OxOfa4c[0x8d]]){ element[OxOfa4c[0x6a]]=OxOfa4c[0x8e] ;} else { element[OxOfa4c[0x6a]]=OxOfa4c[0x6c] ;} ;} ;}  ;var CuteEditorGlobalFunctions=[CuteEditor_GetEditor,CuteEditor_ButtonOver,CuteEditor_ButtonOut,CuteEditor_ButtonDown,CuteEditor_ButtonUp,CuteEditor_ColorPicker_ButtonOver,CuteEditor_ColorPicker_ButtonOut,CuteEditor_ColorPicker_ButtonDown,CuteEditor_ButtonCommandOver,CuteEditor_ButtonCommandOut,CuteEditor_ButtonCommandDown,CuteEditor_ButtonCommandUp,CuteEditor_DropDownCommand,CuteEditor_ExpandTreeDropDownItem,CuteEditor_CollapseTreeDropDownItem,CuteEditor_OnInitialized,CuteEditor_OnCommand,CuteEditor_OnChange,CuteEditor_AddVerbMenuItems,CuteEditor_AddTagMenuItems,CuteEditor_AddMainMenuItems,CuteEditor_AddDropMenuItems,CuteEditor_FilterCode,CuteEditor_FilterHTML]; function SetupCuteEditorGlobalFunctions(){for(var i=0x0;i<CuteEditorGlobalFunctions[OxOfa4c[0x6]];i++){var Ox1c1=CuteEditorGlobalFunctions[i];var name=Ox1c1+OxOfa4c[0x4]; name=name.substr(0x8,name.indexOf(OxOfa4c[0x8f])-0x8).replace(/\s/g,OxOfa4c[0x4]) ;if(!window[name]){ window[name]=Ox1c1 ;} ;} ;}  ; SetupCuteEditorGlobalFunctions() ;var __danainfo=null;var danaurl=window[OxOfa4c[0x91]][OxOfa4c[0x90]];var danapos=danaurl.indexOf(OxOfa4c[0x92]);if(danapos!=-0x1){var pluspos1=danaurl.indexOf(OxOfa4c[0x93],danapos+0xa);var pluspos2=danaurl.indexOf(OxOfa4c[0x94],danapos+0xa);if(pluspos1!=-0x1&&pluspos1<pluspos2){ pluspos2=pluspos1 ;} ; __danainfo=danaurl.substring(danapos,pluspos2)+OxOfa4c[0x94] ;} ; function CuteEditor_GetScriptProperty(name){var Ox134=this[OxOfa4c[0x95]][name];if(Ox134&&__danainfo){if(name==OxOfa4c[0x58]){return Ox134+__danainfo;} ;var Ox2f8=this[OxOfa4c[0x95]][OxOfa4c[0x58]];if(Ox134.substr(0x0,Ox2f8.length)==Ox2f8){return Ox2f8+__danainfo+Ox134.substring(Ox2f8.length);} ;} ;return Ox134;}  ; function CuteEditor_SetScriptProperty(name,Ox134){if(Ox134==null){ this[OxOfa4c[0x95]][name]=null ;} else { this[OxOfa4c[0x95]][name]=String(Ox134) ;} ;}  ; function CuteEditorInitialize(Ox95e,Ox95f){var editor=Window_GetElement(window,Ox95e,true); editor[OxOfa4c[0x95]]=Ox95f ; editor[OxOfa4c[0x96]]=CuteEditor_GetScriptProperty ;var Ox6eb=Window_GetElement(window,editor.GetScriptProperty(OxOfa4c[0x7b]),true);var editwin=Frame_GetContentWindow(Ox6eb);var editdoc=editwin[OxOfa4c[0x5]];var Ox960=false;var Ox961;var Ox962=false;var Ox963=editor.GetScriptProperty(OxOfa4c[0x58])+OxOfa4c[0x97];var Ox9c4=editor.GetScriptProperty(OxOfa4c[0x58])+OxOfa4c[0x98]; function Ox964(){if( typeof (window[OxOfa4c[0x99]])==OxOfa4c[0x9a]){return ;} ;try{ LoadXMLAsync(OxOfa4c[0x9b],Ox963+OxOfa4c[0x9c],Ox965) ;} catch(x){ include(OxOfa4c[0x9d],Ox963) ;var Ox9c5=setInterval(function (){if(window[OxOfa4c[0x99]]){ clearInterval(Ox9c5) ;if(Ox960){ Ox967() ;} ;} ;} ,0x64);} ;}  ; function Ox965(Ox206){if(Ox206[OxOfa4c[0x9e]]!=0xc8){ alert(OxOfa4c[0x9f]+Ox963) ;return ;} ; LoadXMLAsync(OxOfa4c[0xa0],Ox963+OxOfa4c[0xa1]+Ox206.responseText,Ox966) ;}  ; function Ox966(Ox206){if(Ox206[OxOfa4c[0x9e]]!=0xc8){ alert(OxOfa4c[0xa2]) ;return ;} ; CuteEditorInstallScriptCode(Ox206.responseText,OxOfa4c[0x99]) ;if(Ox960){ Ox967() ;} ;}  ; function Ox967(){if(Ox962){return ;} ; Ox962=true ; window.CuteEditorImplementation(editor) ;try{ editor[OxOfa4c[0x22]][OxOfa4c[0xa3]]=OxOfa4c[0x4] ;} catch(x){} ;try{ editdoc[OxOfa4c[0xa4]][OxOfa4c[0x22]][OxOfa4c[0xa3]]=OxOfa4c[0x4] ;} catch(x){} ;var Ox968=editor.GetScriptProperty(OxOfa4c[0xa5]);if(Ox968){ editor.Eval(Ox968) ;} ;}  ; function Ox969(){if(!window[OxOfa4c[0x5]][OxOfa4c[0xa4]].contains(editor)){return ;} ;try{ Ox6eb=Window_GetElement(window,editor.GetScriptProperty(OxOfa4c[0x7b]),true) ; editwin=Frame_GetContentWindow(Ox6eb) ; editdoc=editwin[OxOfa4c[0x5]] ; x=editdoc[OxOfa4c[0xa4]] ;} catch(x){ setTimeout(Ox969,0x64) ;return ;} ;if(!editdoc[OxOfa4c[0xa4]]){ setTimeout(Ox969,0x64) ;return ;} ;if(!Ox960){ Ox6eb[OxOfa4c[0x22]][OxOfa4c[0x21]]=OxOfa4c[0xa6] ; editdoc[OxOfa4c[0xa4]][OxOfa4c[0xa7]]=true ; Ox960=true ; setTimeout(Ox969,0x64) ;return ;} ;if( typeof (window[OxOfa4c[0x99]])==OxOfa4c[0x9a]){ Ox967() ;} else {try{ editdoc[OxOfa4c[0xa4]][OxOfa4c[0x22]][OxOfa4c[0xa3]]=OxOfa4c[0xa8] ;} catch(x){} ;} ;}  ; CuteEditor_BasicInitialize(editor) ; Ox964() ; Ox969() ;}  ; function CuteEditorInstallScriptCode(Ox906,Ox907){ eval(Ox906) ; window[Ox907]=eval(Ox907) ;}  ; window[OxOfa4c[0xa9]]=CuteEditorInitialize ;