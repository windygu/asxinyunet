var OxO58cf=["isWinIE","isGecko","isSafari","isOpera","userAgent","ua","opera","safari","gecko","msie","compatMode","document","CSS1Compat","undefined","Microsoft.XMLHTTP","readyState","onreadystatechange","","length","all","childNodes","nodeType","\x0D\x0A","onchange","oninitialized","command","commandui","commandvalue","returnValue","oncommand","string","event","_fireEventFunction","parentNode","_IsCuteEditor","True","readOnly","_IsRichDropDown","null","value","selectedIndex","nodeName","TR","cells","display","style","nextSibling","innerHTML","\x3Cimg src=\x22","/Load.ashx?type=image\x26file=t-minus.gif\x22\x3E","CuteEditor_CollapseTreeDropDownItem(this,\x22","\x22)","onclick","onmousedown","none","/Load.ashx?type=image\x26file=t-plus.gif\x22\x3E","CuteEditor_ExpandTreeDropDownItem(this,\x22","contains","UNSELECTABLE","on","tabIndex","-1","//TODO: event not found? throw error ?","contentWindow","contentDocument","parentWindow","id","frames","frameElement","//TODO:frame contentWindow not found?","preventDefault","caller","arguments","parent","top","opener","srcElement","target","//TODO: srcElement not found? throw error ?","fromElement","relatedTarget","toElement","keyCode","clientX","clientY","offsetX","offsetY","button","ctrlKey","altKey","shiftKey","cancelBubble","stopPropagation","CuteEditor_GetEditor(this).ExecImageCommand(this.getAttribute(\x27Command\x27),this.getAttribute(\x27CommandUI\x27),this.getAttribute(\x27CommandArgument\x27),this)","CuteEditor_GetEditor(this).PostBack(this.getAttribute(\x27Command\x27))","this.onmouseout();CuteEditor_GetEditor(this).DropMenu(this.getAttribute(\x27Group\x27),this)","ResourceDir","Theme","/Load.ashx?type=theme\x26theme=","\x26file=all.png","/Images/blank2020.gif","IMG","Command","Group","ThemeIndex","width","20px","height","src","backgroundImage","url(",")","backgroundPosition","0 -","px","onload","className","separator","CuteEditorButton","CuteEditor_ButtonCommandOver(this)","onmouseover","CuteEditor_ButtonCommandOut(this)","onmouseout","CuteEditor_ButtonCommandDown(this)","CuteEditor_ButtonCommandUp(this)","onmouseup","oncontextmenu","ondragstart","PostBack","ondblclick","_ToolBarID","_CodeViewToolBarID","_FrameID"," CuteEditorFrame"," CuteEditorToolbar","ActiveTab","View","Code","Edit","buttonInitialized","isover","CuteEditorButtonOver","CuteEditorButtonDown","CuteEditorDown","border","solid 1px #0A246A","backgroundColor","#b6bdd2","padding","1px","solid 1px #f5f5f4","inset 1px","IsCommandDisabled","CuteEditorButtonDisabled","IsCommandActive","CuteEditorButtonActive","cmd_fromfullpage","(","href","location",",DanaInfo=",",","+","scriptProperties","GetScriptProperty","/Load.ashx?type=scripts\x26file=Opera_Implementation","CuteEditorImplementation","function","POST","\x26getModified=1","status","Failed to load impl time!","GET","\x26modified=","Failed to load impl code!","cursor","body","InitializeCode","block","contentEditable"," \x3Cbr /\x3E ","designMode","CuteEditorInitialize"];var _Browser_TypeInfo=null; function Browser__InitType(){if(_Browser_TypeInfo!=null){return ;} ;var Ox4={}; Ox4[OxO58cf[0x5]]=navigator[OxO58cf[0x4]].toLowerCase(),Ox4[OxO58cf[0x3]]=(Ox4[OxO58cf[0x5]].indexOf(OxO58cf[0x6])>-0x1),Ox4[OxO58cf[0x2]]=(Ox4[OxO58cf[0x5]].indexOf(OxO58cf[0x7])>-0x1),Ox4[OxO58cf[0x1]]=(!Ox4[OxO58cf[0x3]]&&!Ox4[OxO58cf[0x2]]&&Ox4[OxO58cf[0x5]].indexOf(OxO58cf[0x8])>-0x1),Ox4[OxO58cf[0x0]]=(!Ox4[OxO58cf[0x3]]&&Ox4[OxO58cf[0x5]].indexOf(OxO58cf[0x9])>-0x1) ; _Browser_TypeInfo=Ox4 ;}  ; Browser__InitType() ; function Browser_IsWinIE(){return _Browser_TypeInfo[OxO58cf[0x0]];}  ; function Browser_IsGecko(){return _Browser_TypeInfo[OxO58cf[0x1]];}  ; function Browser_IsOpera(){return _Browser_TypeInfo[OxO58cf[0x3]];}  ; function Browser_IsSafari(){return _Browser_TypeInfo[OxO58cf[0x2]];}  ; function Browser_UseIESelection(){return _Browser_TypeInfo[OxO58cf[0x0]];}  ; function Browser_IsCSS1Compat(){return window[OxO58cf[0xb]][OxO58cf[0xa]]==OxO58cf[0xc];}  ; function CreateXMLHttpRequest(){try{if( typeof (XMLHttpRequest)!=OxO58cf[0xd]){return  new XMLHttpRequest();} ;if( typeof (ActiveXObject)!=OxO58cf[0xd]){return  new ActiveXObject(OxO58cf[0xe]);} ;} catch(x){return null;} ;}  ; function LoadXMLAsync(Ox944,Ox1fe,Ox1a7,Ox945){var Oxd0=CreateXMLHttpRequest(); function Ox946(){if(Oxd0[OxO58cf[0xf]]!=0x4){return ;} ; Oxd0[OxO58cf[0x10]]= new Function() ;var Ox206=Oxd0; Oxd0=null ; Ox1a7(Ox206) ;}  ; Oxd0[OxO58cf[0x10]]=Ox946 ; Oxd0.open(Ox944,Ox1fe, true) ; Oxd0.send(Ox945||OxO58cf[0x11]) ;}  ; function Element_GetAllElements(p){var arr=[];if(Browser_IsWinIE()){for(var i=0x0;i<p[OxO58cf[0x13]][OxO58cf[0x12]];i++){ arr.push(p[OxO58cf[0x13]].item(i)) ;} ;return arr;} ; Ox1b5(p) ; function Ox1b5(Ox27){var Ox1b6=Ox27[OxO58cf[0x14]];var Ox11=Ox1b6[OxO58cf[0x12]];for(var i=0x0;i<Ox11;i++){var n=Ox1b6.item(i);if(n[OxO58cf[0x15]]!=0x1){continue ;} ; arr.push(n) ; Ox1b5(n) ;} ;}  ;return arr;}  ;var __ISDEBUG=false; function Debug_Todo(msg){if(!__ISDEBUG){return ;} ;throw ( new Error(msg+OxO58cf[0x16]+Debug_Todo.caller));}  ; function Window_GetElement(Ox1ae,Ox83,Ox1b3){var Ox27=Ox1ae[OxO58cf[0xb]].getElementById(Ox83);if(Ox27){return Ox27;} ;var Ox2f=Ox1ae[OxO58cf[0xb]].getElementsByName(Ox83);if(Ox2f[OxO58cf[0x12]]>0x0){return Ox2f.item(0x0);} ;return null;}  ; function CuteEditor_AddMainMenuItems(Ox5e6){}  ; function CuteEditor_AddDropMenuItems(Ox5e6,Ox5ed){}  ; function CuteEditor_AddTagMenuItems(Ox5e6,Ox5ef){}  ; function CuteEditor_AddVerbMenuItems(Ox5e6,Ox5ef){}  ; function CuteEditor_OnInitialized(editor){}  ; function CuteEditor_OnCommand(editor,Ox5f3,Ox5f4,Ox115){}  ; function CuteEditor_OnChange(editor){}  ; function CuteEditor_FilterCode(editor,Ox1e0){return Ox1e0;}  ; function CuteEditor_FilterHTML(editor,Ox1f8){return Ox1f8;}  ; function CuteEditor_FireChange(editor){ window.CuteEditor_OnChange(editor) ; CuteEditor_FireEvent(editor,OxO58cf[0x17],null) ;}  ; function CuteEditor_FireInitialized(editor){ window.CuteEditor_OnInitialized(editor) ; CuteEditor_FireEvent(editor,OxO58cf[0x18],null) ;}  ; function CuteEditor_FireCommand(editor,Ox5f3,Ox5f4,Ox115){var Ox130=window.CuteEditor_OnCommand(editor,Ox5f3,Ox5f4,Ox115);if(Ox130==true){return true;} ;var Ox5fb={}; Ox5fb[OxO58cf[0x19]]=Ox5f3 ; Ox5fb[OxO58cf[0x1a]]=Ox5f4 ; Ox5fb[OxO58cf[0x1b]]=Ox115 ; Ox5fb[OxO58cf[0x1c]]=true ; CuteEditor_FireEvent(editor,OxO58cf[0x1d],Ox5fb) ;if(Ox5fb[OxO58cf[0x1c]]==false){return true;} ;}  ; function CuteEditor_FireEvent(editor,Ox5fd,Ox5fe){if(Ox5fe==null){ Ox5fe={} ;} ;var Ox5ff=editor.getAttribute(Ox5fd);if(Ox5ff){if( typeof (Ox5ff)==OxO58cf[0x1e]){ editor[OxO58cf[0x20]]= new Function(OxO58cf[0x1f],Ox5ff) ;} else { editor[OxO58cf[0x20]]=Ox5ff ;} ; editor._fireEventFunction(Ox5fe) ;} ;}  ; function CuteEditor_GetEditor(element){for(var Ox42=element;Ox42!=null;Ox42=Ox42[OxO58cf[0x21]]){if(Ox42.getAttribute(OxO58cf[0x22])==OxO58cf[0x23]){return Ox42;} ;} ;return null;}  ; function CuteEditor_DropDownCommand(element,Ox948){var editor=CuteEditor_GetEditor(element);if(editor[OxO58cf[0x24]]){return ;} ;if(element.getAttribute(OxO58cf[0x25])==OxO58cf[0x23]){var Ox134=element.GetValue();if(Ox134==OxO58cf[0x26]){ Ox134=OxO58cf[0x11] ;} ;var Ox176=element.GetText();if(Ox176==OxO58cf[0x26]){ Ox176=OxO58cf[0x11] ;} ; element.SetSelectedIndex(0x0) ; editor.ExecCommand(Ox948, false,Ox134,Ox176) ;} else {if(element[OxO58cf[0x27]]){var Ox134=element[OxO58cf[0x27]];if(Ox134==OxO58cf[0x26]){ Ox134=OxO58cf[0x11] ;} ; element[OxO58cf[0x28]]=0x0 ; editor.ExecCommand(Ox948, false,Ox134,Ox176) ;} else { element[OxO58cf[0x28]]=0x0 ;} ;} ; editor.FocusDocument() ;}  ; function CuteEditor_ExpandTreeDropDownItem(src,Ox6bb){var Oxa3=null;while(src!=null){if(src[OxO58cf[0x29]]==OxO58cf[0x2a]){ Oxa3=src ;break ;} ; src=src[OxO58cf[0x21]] ;} ;var Ox314=Oxa3[OxO58cf[0x2b]].item(0x0); Oxa3[OxO58cf[0x2e]][OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x11] ; Ox314[OxO58cf[0x2f]]=OxO58cf[0x30]+Ox6bb+OxO58cf[0x31] ; Oxa3[OxO58cf[0x34]]= new Function(OxO58cf[0x32]+Ox6bb+OxO58cf[0x33]) ; Oxa3[OxO58cf[0x35]]= new Function(OxO58cf[0x32]+Ox6bb+OxO58cf[0x33]) ;}  ; function CuteEditor_CollapseTreeDropDownItem(src,Ox6bb){var Oxa3=null;while(src!=null){if(src[OxO58cf[0x29]]==OxO58cf[0x2a]){ Oxa3=src ;break ;} ; src=src[OxO58cf[0x21]] ;} ;var Ox314=Oxa3[OxO58cf[0x2b]].item(0x0); Oxa3[OxO58cf[0x2e]][OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x36] ; Ox314[OxO58cf[0x2f]]=OxO58cf[0x30]+Ox6bb+OxO58cf[0x37] ; Oxa3[OxO58cf[0x34]]= new Function(OxO58cf[0x38]+Ox6bb+OxO58cf[0x33]) ; Oxa3[OxO58cf[0x35]]= new Function(OxO58cf[0x38]+Ox6bb+OxO58cf[0x33]) ;}  ; function Element_Contains(element,Ox165){if(!Browser_IsOpera()){if(element[OxO58cf[0x39]]){return element.contains(Ox165);} ;} ;for(;Ox165!=null;Ox165=Ox165[OxO58cf[0x21]]){if(element==Ox165){return true;} ;} ;return false;}  ; function Element_SetUnselectable(element){ element.setAttribute(OxO58cf[0x3a],OxO58cf[0x3b]) ; element.setAttribute(OxO58cf[0x3c],OxO58cf[0x3d]) ;var arr=Element_GetAllElements(element);var len=arr[OxO58cf[0x12]];if(!len){return ;} ;for(var i=0x0;i<len;i++){ arr[i].setAttribute(OxO58cf[0x3a],OxO58cf[0x3b]) ; arr[i].setAttribute(OxO58cf[0x3c],OxO58cf[0x3d]) ;} ;}  ; function Event_GetEvent(Ox1b9){ Ox1b9=Event_FindEvent(Ox1b9) ;if(Ox1b9==null){ Debug_Todo(OxO58cf[0x3e]) ;} ;return Ox1b9;}  ; function Frame_GetContentWindow(Ox2c0){if(Ox2c0[OxO58cf[0x3f]]){return Ox2c0[OxO58cf[0x3f]];} ;if(Ox2c0[OxO58cf[0x40]]){if(Ox2c0[OxO58cf[0x40]][OxO58cf[0x41]]){return Ox2c0[OxO58cf[0x40]][OxO58cf[0x41]];} ;} ;var Ox1ae;if(Ox2c0[OxO58cf[0x42]]){ Ox1ae=window[OxO58cf[0x43]][Ox2c0[OxO58cf[0x42]]] ;if(Ox1ae){return Ox1ae;} ;} ;var len=window[OxO58cf[0x43]][OxO58cf[0x12]];for(var i=0x0;i<len;i++){ Ox1ae=window[OxO58cf[0x43]][i] ;if(Ox1ae[OxO58cf[0x44]]==Ox2c0){return Ox1ae;} ;if(Ox1ae[OxO58cf[0xb]]==Ox2c0[OxO58cf[0x40]]){return Ox1ae;} ;} ; Debug_Todo(OxO58cf[0x45]) ;}  ; function Array_IndexOf(arr,Ox1bb){for(var i=0x0;i<arr[OxO58cf[0x12]];i++){if(arr[i]==Ox1bb){return i;} ;} ;return -0x1;}  ; function Array_Contains(arr,Ox1bb){return Array_IndexOf(arr,Ox1bb)!=-0x1;}  ; function Event_FindEvent(Ox1b9){if(Ox1b9&&Ox1b9[OxO58cf[0x46]]){return Ox1b9;} ;if(Browser_IsGecko()){return Event_FindEvent_FindEventFromCallers();} else {if(window[OxO58cf[0x1f]]){return window[OxO58cf[0x1f]];} ;return Event_FindEvent_FindEventFromWindows();} ;return null;}  ; function Event_FindEvent_FindEventFromCallers(){var Ox1c1=Event_GetEvent[OxO58cf[0x47]];for(var i=0x0;i<0x64;i++){if(!Ox1c1){break ;} ;var Ox1b9=Ox1c1[OxO58cf[0x48]][0x0];if(Ox1b9&&Ox1b9[OxO58cf[0x46]]){return Ox1b9;} ; Ox1c1=Ox1c1[OxO58cf[0x47]] ;} ;}  ; function Event_FindEvent_FindEventFromWindows(){var arr=[];return Ox1c3(window); function Ox1c3(Ox1ae){if(Ox1ae==null){return null;} ;if(Ox1ae[OxO58cf[0x1f]]){return Ox1ae[OxO58cf[0x1f]];} ;if(Array_Contains(arr,Ox1ae)){return null;} ; arr.push(Ox1ae) ;var Ox1c4=[];if(Ox1ae[OxO58cf[0x49]]!=Ox1ae){ Ox1c4.push(Ox1ae.parent) ;} ;if(Ox1ae[OxO58cf[0x4a]]!=Ox1ae[OxO58cf[0x49]]){ Ox1c4.push(Ox1ae.top) ;} ;if(Ox1ae[OxO58cf[0x4b]]){ Ox1c4.push(Ox1ae.opener) ;} ;for(var i=0x0;i<Ox1ae[OxO58cf[0x43]][OxO58cf[0x12]];i++){ Ox1c4.push(Ox1ae[OxO58cf[0x43]][i]) ;} ;for(var i=0x0;i<Ox1c4[OxO58cf[0x12]];i++){try{var Ox1b9=Ox1c3(Ox1c4[i]);if(Ox1b9){return Ox1b9;} ;} catch(x){} ;} ;return null;}  ;}  ; function Event_GetSrcElement(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Ox1b9[OxO58cf[0x4c]]){return Ox1b9[OxO58cf[0x4c]];} ;if(Ox1b9[OxO58cf[0x4d]]){return Ox1b9[OxO58cf[0x4d]];} ; Debug_Todo(OxO58cf[0x4e]) ;return null;}  ; function Event_GetFromElement(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Ox1b9[OxO58cf[0x4f]]){return Ox1b9[OxO58cf[0x4f]];} ;if(Ox1b9[OxO58cf[0x50]]){return Ox1b9[OxO58cf[0x50]];} ;return null;}  ; function Event_GetToElement(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Ox1b9[OxO58cf[0x51]]){return Ox1b9[OxO58cf[0x51]];} ;if(Ox1b9[OxO58cf[0x50]]){return Ox1b9[OxO58cf[0x50]];} ;return null;}  ; function Event_GetKeyCode(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x52]];}  ; function Event_GetClientX(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x53]];}  ; function Event_GetClientY(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x54]];}  ; function Event_GetOffsetX(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x55]];}  ; function Event_GetOffsetY(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x56]];}  ; function Event_IsLeftButton(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;if(Browser_IsWinIE()){return Ox1b9[OxO58cf[0x57]]==0x1;} ;if(Browser_IsGecko()){return Ox1b9[OxO58cf[0x57]]==0x0;} ;return Ox1b9[OxO58cf[0x57]]==0x0;}  ; function Event_IsCtrlKey(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x58]];}  ; function Event_IsAltKey(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x59]];}  ; function Event_IsShiftKey(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ;return Ox1b9[OxO58cf[0x5a]];}  ; function Event_PreventDefault(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ; Ox1b9[OxO58cf[0x1c]]=false ;if(Ox1b9[OxO58cf[0x46]]){ Ox1b9.preventDefault() ;} ;}  ; function Event_CancelBubble(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ; Ox1b9[OxO58cf[0x5b]]=true ;if(Ox1b9[OxO58cf[0x5c]]){ Ox1b9.stopPropagation() ;} ;return false;}  ; function Event_CancelEvent(Ox1b9){ Ox1b9=Event_GetEvent(Ox1b9) ; Event_PreventDefault(Ox1b9) ;return Event_CancelBubble(Ox1b9);}  ; function CuteEditor_BasicInitialize(editor){var Ox94c=Browser_IsOpera();var Ox685= new Function(OxO58cf[0x5d]);var Ox94d= new Function(OxO58cf[0x5e]);var Ox94e= new Function(OxO58cf[0x5f]);var Ox94f=editor.GetScriptProperty(OxO58cf[0x60]);var Ox950=editor.GetScriptProperty(OxO58cf[0x61]);var Ox951=Ox94f+OxO58cf[0x62]+Ox950+OxO58cf[0x63];var Ox952=Ox94f+OxO58cf[0x64];var images=editor.getElementsByTagName(OxO58cf[0x65]);var len=images[OxO58cf[0x12]];for(var i=0x0;i<len;i++){var img=images[i];var Ox127=img.getAttribute(OxO58cf[0x66]);var Ox5ed=img.getAttribute(OxO58cf[0x67]);var Ox953=img.getAttribute(OxO58cf[0x68]);if(parseInt(Ox953)>=0x0){ img[OxO58cf[0x2d]][OxO58cf[0x69]]=OxO58cf[0x6a] ; img[OxO58cf[0x2d]][OxO58cf[0x6b]]=OxO58cf[0x6a] ; img[OxO58cf[0x6c]]=Ox952 ; img[OxO58cf[0x2d]][OxO58cf[0x6d]]=OxO58cf[0x6e]+Ox951+OxO58cf[0x6f] ; img[OxO58cf[0x2d]][OxO58cf[0x70]]=OxO58cf[0x71]+(Ox953*0x14)+OxO58cf[0x72] ; img[OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x11] ;} ;if(!Ox127&&!Ox5ed){if(Ox94c){ img[OxO58cf[0x73]]=CuteEditor_OperaHandleImageLoaded ;} ;continue ;} ;if(img[OxO58cf[0x74]]!=OxO58cf[0x75]){ img[OxO58cf[0x74]]=OxO58cf[0x76] ; img[OxO58cf[0x78]]= new Function(OxO58cf[0x77]) ; img[OxO58cf[0x7a]]= new Function(OxO58cf[0x79]) ; img[OxO58cf[0x35]]= new Function(OxO58cf[0x7b]) ; img[OxO58cf[0x7d]]= new Function(OxO58cf[0x7c]) ;} ;if(!img[OxO58cf[0x7e]]){ img[OxO58cf[0x7e]]=Event_CancelEvent ;} ;if(!img[OxO58cf[0x7f]]){ img[OxO58cf[0x7f]]=Event_CancelEvent ;} ;if(Ox127){var Ox1c1=img.getAttribute(OxO58cf[0x80])==OxO58cf[0x23]?Ox94d:Ox685;if(img[OxO58cf[0x34]]==null){ img[OxO58cf[0x34]]=Ox1c1 ;} ;if(img[OxO58cf[0x81]]==null){ img[OxO58cf[0x81]]=Ox1c1 ;} ;} else {if(Ox5ed){if(img[OxO58cf[0x34]]==null){ img[OxO58cf[0x34]]=Ox94e ;} ;} ;} ;} ;var Ox6f0=Window_GetElement(window,editor.GetScriptProperty(OxO58cf[0x82]), true);var Ox6f1=Window_GetElement(window,editor.GetScriptProperty(OxO58cf[0x83]), true);var Ox6ec=Window_GetElement(window,editor.GetScriptProperty(OxO58cf[0x84]), true); Ox6ec[OxO58cf[0x74]]+=OxO58cf[0x85] ; Ox6f0[OxO58cf[0x74]]+=OxO58cf[0x86] ; Ox6f1[OxO58cf[0x74]]+=OxO58cf[0x86] ; Element_SetUnselectable(Ox6f0) ; Element_SetUnselectable(Ox6f1) ;var Ox76f=editor.GetScriptProperty(OxO58cf[0x87]);switch(Ox76f){case OxO58cf[0x8a]: Ox6f0[OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x11] ;break ;case OxO58cf[0x89]: Ox6f1[OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x11] ;break ;case OxO58cf[0x88]:break ;;;;} ;}  ; function CuteEditor_OperaHandleImageLoaded(){var img=this;if(img[OxO58cf[0x2d]][OxO58cf[0x2c]]){ img[OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x36] ; setTimeout(function Ox955(){ img[OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0x11] ;} ,0x1) ;} ;}  ; function CuteEditor_ButtonOver(element){if(!element[OxO58cf[0x8b]]){ element[OxO58cf[0x7e]]=Event_CancelEvent ; element[OxO58cf[0x7a]]=CuteEditor_ButtonOut ; element[OxO58cf[0x35]]=CuteEditor_ButtonDown ; element[OxO58cf[0x7d]]=CuteEditor_ButtonUp ; Element_SetUnselectable(element) ; element[OxO58cf[0x8b]]=true ;} ; element[OxO58cf[0x8c]]=true ; element[OxO58cf[0x74]]=OxO58cf[0x8d] ;}  ; function CuteEditor_ButtonOut(){var element=this; element[OxO58cf[0x74]]=OxO58cf[0x76] ; element[OxO58cf[0x8c]]=false ;}  ; function CuteEditor_ButtonDown(){if(!Event_IsLeftButton()){return ;} ;var element=this; element[OxO58cf[0x74]]=OxO58cf[0x8e] ;}  ; function CuteEditor_ButtonUp(){if(!Event_IsLeftButton()){return ;} ;var element=this;if(element[OxO58cf[0x8c]]){ element[OxO58cf[0x74]]=OxO58cf[0x8d] ;} else { element[OxO58cf[0x74]]=OxO58cf[0x8f] ;} ;}  ; function CuteEditor_ColorPicker_ButtonOver(element){if(!element[OxO58cf[0x8b]]){ element[OxO58cf[0x7e]]=Event_CancelEvent ; element[OxO58cf[0x7a]]=CuteEditor_ColorPicker_ButtonOut ; element[OxO58cf[0x35]]=CuteEditor_ColorPicker_ButtonDown ; Element_SetUnselectable(element) ; element[OxO58cf[0x8b]]=true ;} ; element[OxO58cf[0x8c]]=true ; element[OxO58cf[0x2d]][OxO58cf[0x90]]=OxO58cf[0x91] ; element[OxO58cf[0x2d]][OxO58cf[0x92]]=OxO58cf[0x93] ; element[OxO58cf[0x2d]][OxO58cf[0x94]]=OxO58cf[0x95] ;}  ; function CuteEditor_ColorPicker_ButtonOut(){var element=this; element[OxO58cf[0x8c]]=false ; element[OxO58cf[0x2d]][OxO58cf[0x90]]=OxO58cf[0x96] ; element[OxO58cf[0x2d]][OxO58cf[0x92]]=OxO58cf[0x11] ; element[OxO58cf[0x2d]][OxO58cf[0x94]]=OxO58cf[0x95] ;}  ; function CuteEditor_ColorPicker_ButtonDown(){var element=this; element[OxO58cf[0x2d]][OxO58cf[0x90]]=OxO58cf[0x97] ; element[OxO58cf[0x2d]][OxO58cf[0x92]]=OxO58cf[0x11] ; element[OxO58cf[0x2d]][OxO58cf[0x94]]=OxO58cf[0x95] ;}  ; function CuteEditor_ButtonCommandOver(element){ element[OxO58cf[0x8c]]=true ;if(element[OxO58cf[0x98]]){ element[OxO58cf[0x74]]=OxO58cf[0x99] ;} else { element[OxO58cf[0x74]]=OxO58cf[0x8d] ;} ;}  ; function CuteEditor_ButtonCommandOut(element){ element[OxO58cf[0x8c]]=false ;if(element[OxO58cf[0x9a]]){ element[OxO58cf[0x74]]=OxO58cf[0x9b] ;} else {if(element[OxO58cf[0x98]]){ element[OxO58cf[0x74]]=OxO58cf[0x99] ;} else {if(element[OxO58cf[0x42]]!=OxO58cf[0x9c]){ element[OxO58cf[0x74]]=OxO58cf[0x76] ;} ;} ;} ;}  ; function CuteEditor_ButtonCommandDown(element){if(!Event_IsLeftButton()){return ;} ; element[OxO58cf[0x74]]=OxO58cf[0x8e] ;}  ; function CuteEditor_ButtonCommandUp(element){if(!Event_IsLeftButton()){return ;} ;if(element[OxO58cf[0x98]]){ element[OxO58cf[0x74]]=OxO58cf[0x99] ;return ;} ;if(element[OxO58cf[0x8c]]){ element[OxO58cf[0x74]]=OxO58cf[0x8d] ;} else {if(element[OxO58cf[0x9a]]){ element[OxO58cf[0x74]]=OxO58cf[0x9b] ;} else { element[OxO58cf[0x74]]=OxO58cf[0x76] ;} ;} ;}  ;var CuteEditorGlobalFunctions=[CuteEditor_GetEditor,CuteEditor_ButtonOver,CuteEditor_ButtonOut,CuteEditor_ButtonDown,CuteEditor_ButtonUp,CuteEditor_ColorPicker_ButtonOver,CuteEditor_ColorPicker_ButtonOut,CuteEditor_ColorPicker_ButtonDown,CuteEditor_ButtonCommandOver,CuteEditor_ButtonCommandOut,CuteEditor_ButtonCommandDown,CuteEditor_ButtonCommandUp,CuteEditor_DropDownCommand,CuteEditor_ExpandTreeDropDownItem,CuteEditor_CollapseTreeDropDownItem,CuteEditor_OnInitialized,CuteEditor_OnCommand,CuteEditor_OnChange,CuteEditor_AddVerbMenuItems,CuteEditor_AddTagMenuItems,CuteEditor_AddMainMenuItems,CuteEditor_AddDropMenuItems,CuteEditor_FilterCode,CuteEditor_FilterHTML]; function SetupCuteEditorGlobalFunctions(){for(var i=0x0;i<CuteEditorGlobalFunctions[OxO58cf[0x12]];i++){var Ox1c1=CuteEditorGlobalFunctions[i];var name=Ox1c1+OxO58cf[0x11]; name=name.substr(0x8,name.indexOf(OxO58cf[0x9d])-0x8).replace(/\s/g,OxO58cf[0x11]) ;if(!window[name]){ window[name]=Ox1c1 ;} ;} ;}  ; SetupCuteEditorGlobalFunctions() ;var __danainfo=null;var danaurl=window[OxO58cf[0x9f]][OxO58cf[0x9e]];var danapos=danaurl.indexOf(OxO58cf[0xa0]);if(danapos!=-0x1){var pluspos1=danaurl.indexOf(OxO58cf[0xa1],danapos+0xa);var pluspos2=danaurl.indexOf(OxO58cf[0xa2],danapos+0xa);if(pluspos1!=-0x1&&pluspos1<pluspos2){ pluspos2=pluspos1 ;} ; __danainfo=danaurl.substring(danapos,pluspos2)+OxO58cf[0xa2] ;} ; function CuteEditor_GetScriptProperty(name){var Ox134=this[OxO58cf[0xa3]][name];if(Ox134&&__danainfo){if(name==OxO58cf[0x60]){return Ox134+__danainfo;} ;var Ox2f9=this[OxO58cf[0xa3]][OxO58cf[0x60]];if(Ox134.substr(0x0,Ox2f9.length)==Ox2f9){return Ox2f9+__danainfo+Ox134.substring(Ox2f9.length);} ;} ;return Ox134;}  ; function CuteEditor_SetScriptProperty(name,Ox134){if(Ox134==null){ this[OxO58cf[0xa3]][name]=null ;} else { this[OxO58cf[0xa3]][name]=String(Ox134) ;} ;}  ; function CuteEditorInitialize(Ox960,Ox961){var editor=Window_GetElement(window,Ox960, true); editor[OxO58cf[0xa3]]=Ox961 ; editor[OxO58cf[0xa4]]=CuteEditor_GetScriptProperty ;var Ox6ec=Window_GetElement(window,editor.GetScriptProperty(OxO58cf[0x84]), true);var editwin=Frame_GetContentWindow(Ox6ec);var editdoc=editwin[OxO58cf[0xb]];var Ox962=false;var Ox963;var Ox964=false;var Ox965=editor.GetScriptProperty(OxO58cf[0x60])+OxO58cf[0xa5]; function Ox966(){if( typeof (window[OxO58cf[0xa6]])==OxO58cf[0xa7]){return ;} ; LoadXMLAsync(OxO58cf[0xa8],Ox965+OxO58cf[0xa9],Ox967) ;}  ; function Ox967(Ox206){if(Ox206[OxO58cf[0xaa]]!=0xc8){ alert(OxO58cf[0xab]) ;return ;} ; LoadXMLAsync(OxO58cf[0xac],Ox965+OxO58cf[0xad]+Ox206.responseText,Ox968) ;}  ; function Ox968(Ox206){if(Ox206[OxO58cf[0xaa]]!=0xc8){ alert(OxO58cf[0xae]) ;return ;} ; CuteEditorInstallScriptCode(Ox206.responseText,OxO58cf[0xa6]) ;if(Ox962){ Ox969() ;} ;}  ; function Ox969(){if(Ox964){return ;} ; Ox964=true ; window.CuteEditorImplementation(editor) ;try{ editor[OxO58cf[0x2d]][OxO58cf[0xaf]]=OxO58cf[0x11] ;} catch(x){} ;try{ editdoc[OxO58cf[0xb0]][OxO58cf[0x2d]][OxO58cf[0xaf]]=OxO58cf[0x11] ;} catch(x){} ;var Ox96a=editor.GetScriptProperty(OxO58cf[0xb1]);if(Ox96a){ editor.Eval(Ox96a) ;} ;}  ; function Ox96b(){if(!Element_Contains(window[OxO58cf[0xb]].body,editor)){return ;} ;try{ Ox6ec=Window_GetElement(window,editor.GetScriptProperty(OxO58cf[0x84]), true) ; editwin=Frame_GetContentWindow(Ox6ec) ; editdoc=editwin[OxO58cf[0xb]] ;var y=editdoc[OxO58cf[0xb0]];} catch(x){ setTimeout(Ox96b,0x64) ;return ;} ;if(!editdoc[OxO58cf[0xb0]]){ setTimeout(Ox96b,0x64) ;return ;} ;if(!Ox962){ Ox6ec[OxO58cf[0x2d]][OxO58cf[0x2c]]=OxO58cf[0xb2] ;if(Browser_IsOpera()){ editdoc[OxO58cf[0xb0]][OxO58cf[0xb3]]=true ;} else {if(Browser_IsGecko()){ editdoc[OxO58cf[0xb0]][OxO58cf[0x2f]]=OxO58cf[0xb4] ;} ; editdoc[OxO58cf[0xb5]]=OxO58cf[0x3b] ;} ; Ox962=true ; setTimeout(Ox96b,0x32) ;return ;} ;if( typeof (window[OxO58cf[0xa6]])==OxO58cf[0xa7]){ Ox969() ;} else {} ;}  ; CuteEditor_BasicInitialize(editor) ; Ox966() ; Ox96b() ;}  ; function CuteEditorInstallScriptCode(Ox908,Ox909){ eval(Ox908) ; window[Ox909]=eval(Ox909) ;}  ; window[OxO58cf[0xb6]]=CuteEditorInitialize ;