var OxO6055=["onerror","onload","onclick","btnCancel","btnOK","onkeyup","txtHSB_Hue","onkeypress","txtHSB_Saturation","txtHSB_Brightness","txtRGB_Red","txtRGB_Green","txtRGB_Blue","txtHex","btnWebSafeColor","rdoHSB_Hue","rdoHSB_Saturation","rdoHSB_Brightness","rdoRGB_Red","rdoRGB_Green","rdoRGB_Blue","onmousemove","onmousedown","onmouseup","{format}","length","\x5C{","\x5C}","BadNumber","A number between {0} and {1} is required. Closest value inserted.","Title","Color Picker","SelectAColor","Select a color:","OKButton","OK","CancelButton","Cancel","AboutButton","About","Recent","WebSafeWarning","Warning: not a web safe color","WebSafeClick","Click to select web safe color","HsbHue","H:","HsbHueTooltip","Hue","HsbHueUnit","%","HsbSaturation","S:","HsbSaturationTooltip","Saturation","HsbSaturationUnit","HsbBrightness","B:","HsbBrightnessTooltip","Brightness","HsbBrightnessUnit","RgbRed","R:","RgbRedTooltip","Red","RgbGreen","G:","RgbGreenTooltip","Green","RgbBlue","RgbBlueTooltip","Blue","Hex","#","RecentTooltip","Recent:","\x0D\x0ALewies Color Pickerversion 1.1\x0D\x0A\x0D\x0AThis form was created by Lewis Moten in May of 2004.\x0D\x0AIt simulates the color picker in a popular graphics application.\x0D\x0AIt gives users a visual way to choose colors from a large and dynamic palette.\x0D\x0A\x0D\x0AVisit the authors web page?\x0D\x0Awww.lewismoten.com\x0D\x0A","UNDEFINED","FFFFFF","value","checked","ColorMode","ColorType","RecentColors","","pnlRecent","all","border","style","0px","backgroundColor","srcElement","display","none","title","innerHTML","backgroundPosition","px ","px","000000","zIndex","01234567879","keyCode","abcdef","01234567879ABCDEF","returnValue","0123456789ABCDEFabcdef","0","id","pnlGradient_Top","pnlVertical_Top","top","opacity","filters","backgroundImage","url(Load.ashx?type=image\x26file=cpie_GradientPositionDark.gif)","url(Load.ashx?type=image\x26file=cpie_GradientPositionLight.gif)","cancelBubble","clientY","clientX","className","GradientNormal","button","GradientFullScreen","=","; path=/;"," expires=",";","cookie","00336699CCFF","0x","frm","do_select","__cphex"];var POSITIONADJUSTX=0x15;var POSITIONADJUSTY=0x2e;var POSITIONADJUSTZ=0x2b;var msg= new Object(); window[OxO6055[0x0]]=alert ;var ColorMode=0x1;var GradientPositionDark= new Boolean(false);var frm= new Object(); window[OxO6055[0x1]]=window_load ; function initialize(){ frm[OxO6055[0x3]][OxO6055[0x2]]=btnCancel_Click ; frm[OxO6055[0x4]][OxO6055[0x2]]=btnOK_Click ; frm[OxO6055[0x6]][OxO6055[0x5]]=Hsb_Changed ; frm[OxO6055[0x6]][OxO6055[0x7]]=validateNumber ; frm[OxO6055[0x8]][OxO6055[0x5]]=Hsb_Changed ; frm[OxO6055[0x8]][OxO6055[0x7]]=validateNumber ; frm[OxO6055[0x9]][OxO6055[0x5]]=Hsb_Changed ; frm[OxO6055[0x9]][OxO6055[0x7]]=validateNumber ; frm[OxO6055[0xa]][OxO6055[0x5]]=Rgb_Changed ; frm[OxO6055[0xa]][OxO6055[0x7]]=validateNumber ; frm[OxO6055[0xb]][OxO6055[0x5]]=Rgb_Changed ; frm[OxO6055[0xb]][OxO6055[0x7]]=validateNumber ; frm[OxO6055[0xc]][OxO6055[0x5]]=Rgb_Changed ; frm[OxO6055[0xc]][OxO6055[0x7]]=validateNumber ; frm[OxO6055[0xd]][OxO6055[0x5]]=Hex_Changed ; frm[OxO6055[0xd]][OxO6055[0x7]]=validateHex ; frm[OxO6055[0xe]][OxO6055[0x2]]=btnWebSafeColor_Click ; frm[OxO6055[0xf]][OxO6055[0x2]]=rdoHsb_Hue_Click ; frm[OxO6055[0x10]][OxO6055[0x2]]=rdoHsb_Saturation_Click ; frm[OxO6055[0x11]][OxO6055[0x2]]=rdoHsb_Brightness_Click ; frm[OxO6055[0x12]][OxO6055[0x2]]=rdoRgb_Red_Click ; frm[OxO6055[0x13]][OxO6055[0x2]]=rdoRgb_Green_Click ; frm[OxO6055[0x14]][OxO6055[0x2]]=rdoRgb_Blue_Click ; pnlGradient_Top[OxO6055[0x2]]=pnlGradient_Top_Click ; pnlGradient_Top[OxO6055[0x15]]=pnlGradient_Top_MouseMove ; pnlGradient_Top[OxO6055[0x16]]=pnlGradient_Top_MouseDown ; pnlGradient_Top[OxO6055[0x17]]=pnlGradient_Top_MouseUp ; pnlVertical_Top[OxO6055[0x2]]=pnlVertical_Top_Click ; pnlVertical_Top[OxO6055[0x15]]=pnlVertical_Top_MouseMove ; pnlVertical_Top[OxO6055[0x16]]=pnlVertical_Top_MouseDown ; pnlVertical_Top[OxO6055[0x17]]=pnlVertical_Top_MouseUp ; pnlWebSafeColor[OxO6055[0x2]]=btnWebSafeColor_Click ; pnlWebSafeColorBorder[OxO6055[0x2]]=btnWebSafeColor_Click ; pnlOldColor[OxO6055[0x2]]=pnlOldClick_Click ; lblHSB_Hue[OxO6055[0x2]]=rdoHsb_Hue_Click ; lblHSB_Saturation[OxO6055[0x2]]=rdoHsb_Saturation_Click ; lblHSB_Brightness[OxO6055[0x2]]=rdoHsb_Brightness_Click ; lblRGB_Red[OxO6055[0x2]]=rdoRgb_Red_Click ; lblRGB_Green[OxO6055[0x2]]=rdoRgb_Green_Click ; lblRGB_Blue[OxO6055[0x2]]=rdoRgb_Blue_Click ; pnlGradient_Top.focus() ;}  ; function formatString(Ox229){if(!Ox229){return OxO6055[0x18];} ;for(var i=0x1;i<arguments[OxO6055[0x19]];i++){ Ox229=Ox229.replace( new RegExp(OxO6055[0x1a]+(i-0x1)+OxO6055[0x1b]),arguments[i]) ;} ;return Ox229;}  ; function AddValue(Ox103,Ox115){ Ox115=Ox115.toLowerCase() ;for(var i=0x0;i<Ox103[OxO6055[0x19]];i++){if(Ox103[i]==Ox115){return ;} ;} ; Ox103[Ox103[OxO6055[0x19]]]=Ox115 ;}  ; function SniffLanguage(Ox11){}  ; function LoadLanguage(){ msg[OxO6055[0x1c]]=OxO6055[0x1d] ; msg[OxO6055[0x1e]]=OxO6055[0x1f] ; msg[OxO6055[0x20]]=OxO6055[0x21] ; msg[OxO6055[0x22]]=OxO6055[0x23] ; msg[OxO6055[0x24]]=OxO6055[0x25] ; msg[OxO6055[0x26]]=OxO6055[0x27] ; msg[OxO6055[0x28]]=OxO6055[0x28] ; msg[OxO6055[0x29]]=OxO6055[0x2a] ; msg[OxO6055[0x2b]]=OxO6055[0x2c] ; msg[OxO6055[0x2d]]=OxO6055[0x2e] ; msg[OxO6055[0x2f]]=OxO6055[0x30] ; msg[OxO6055[0x31]]=OxO6055[0x32] ; msg[OxO6055[0x33]]=OxO6055[0x34] ; msg[OxO6055[0x35]]=OxO6055[0x36] ; msg[OxO6055[0x37]]=OxO6055[0x32] ; msg[OxO6055[0x38]]=OxO6055[0x39] ; msg[OxO6055[0x3a]]=OxO6055[0x3b] ; msg[OxO6055[0x3c]]=OxO6055[0x32] ; msg[OxO6055[0x3d]]=OxO6055[0x3e] ; msg[OxO6055[0x3f]]=OxO6055[0x40] ; msg[OxO6055[0x41]]=OxO6055[0x42] ; msg[OxO6055[0x43]]=OxO6055[0x44] ; msg[OxO6055[0x45]]=OxO6055[0x39] ; msg[OxO6055[0x46]]=OxO6055[0x47] ; msg[OxO6055[0x48]]=OxO6055[0x49] ; msg[OxO6055[0x4a]]=OxO6055[0x4b] ; msg[OxO6055[0x27]]=OxO6055[0x4c] ;}  ; function localize(){}  ; function window_load(){ frm=frmColorPicker ; LoadLanguage() ; localize() ; initialize() ;var hex=OxO6055[0x4d];if(hex==OxO6055[0x4d]){ hex=OxO6055[0x4e] ;} ;if(hex[OxO6055[0x19]]==0x7){ hex=hex.substr(0x1,0x6) ;} ; frm[OxO6055[0xd]][OxO6055[0x4f]]=hex ; Hex_Changed() ; hex=Form_Get_Hex() ; SetBg(pnlOldColor,hex) ; frm[OxO6055[0x52]][ new Number(GetCookie(OxO6055[0x51])||0x0)][OxO6055[0x50]]=true ; ColorMode_Changed() ;var Ox21f=GetCookie(OxO6055[0x53])||OxO6055[0x54];var Ox22f=msg[OxO6055[0x4a]];for(var i=0x1;i<0x21;i++){if(Ox21f[OxO6055[0x19]]/0x6>=i){ hex=Ox21f.substr((i-0x1)*0x6,0x6) ;var Ox230=HexToRgb(hex);var title=formatString(msg[OxO6055[0x4a]],hex,Ox230[0x0],Ox230[0x1],Ox230[0x2]); SetBg(document[OxO6055[0x56]][OxO6055[0x55]+i],hex) ; SetTitle(document[OxO6055[0x56]][OxO6055[0x55]+i],title) ; document[OxO6055[0x56]][OxO6055[0x55]+i][OxO6055[0x2]]=pnlRecent_Click ;} else { document[OxO6055[0x56]][OxO6055[0x55]+i][OxO6055[0x58]][OxO6055[0x57]]=OxO6055[0x59] ;} ;} ;}  ; function pnlRecent_Click(){ frm[OxO6055[0xd]][OxO6055[0x4f]]=event[OxO6055[0x5b]][OxO6055[0x58]][OxO6055[0x5a]].substr(0x1,0x6).toUpperCase() ; Hex_Changed() ;}  ; function pnlOldClick_Click(){ frm[OxO6055[0xd]][OxO6055[0x4f]]=pnlOldColor[OxO6055[0x58]][OxO6055[0x5a]].substr(0x1,0x6).toUpperCase() ; Hex_Changed() ;}  ; function rdoHsb_Hue_Click(){ frm[OxO6055[0xf]][OxO6055[0x50]]=true ; ColorMode_Changed() ;}  ; function rdoHsb_Saturation_Click(){ frm[OxO6055[0x10]][OxO6055[0x50]]=true ; ColorMode_Changed() ;}  ; function rdoHsb_Brightness_Click(){ frm[OxO6055[0x11]][OxO6055[0x50]]=true ; ColorMode_Changed() ;}  ; function rdoRgb_Red_Click(){ frm[OxO6055[0x12]][OxO6055[0x50]]=true ; ColorMode_Changed() ;}  ; function rdoRgb_Green_Click(){ frm[OxO6055[0x13]][OxO6055[0x50]]=true ; ColorMode_Changed() ;}  ; function rdoRgb_Blue_Click(){ frm[OxO6055[0x14]][OxO6055[0x50]]=true ; ColorMode_Changed() ;}  ; function Hide(){for(var i=0x0;i<arguments[OxO6055[0x19]];i++){ arguments[i][OxO6055[0x58]][OxO6055[0x5c]]=OxO6055[0x5d] ;} ;}  ; function Show(){for(var i=0x0;i<arguments[OxO6055[0x19]];i++){ arguments[i][OxO6055[0x58]][OxO6055[0x5c]]=OxO6055[0x54] ;} ;}  ; function SetValue(){for(var i=0x0;i<arguments[OxO6055[0x19]];i+=0x2){ arguments[i][OxO6055[0x4f]]=arguments[i+0x1] ;} ;}  ; function SetTitle(){for(var i=0x0;i<arguments[OxO6055[0x19]];i+=0x2){ arguments[i][OxO6055[0x5e]]=arguments[i+0x1] ;} ;}  ; function SetHTML(){for(var i=0x0;i<arguments[OxO6055[0x19]];i+=0x2){ arguments[i][OxO6055[0x5f]]=arguments[i+0x1] ;} ;}  ; function SetBg(){for(var i=0x0;i<arguments[OxO6055[0x19]];i+=0x2){ arguments[i][OxO6055[0x58]][OxO6055[0x5a]]=OxO6055[0x49]+arguments[i+0x1] ;} ;}  ; function SetBgPosition(){for(var i=0x0;i<arguments[OxO6055[0x19]];i+=0x3){ arguments[i][OxO6055[0x58]][OxO6055[0x60]]=arguments[i+0x1]+OxO6055[0x61]+arguments[i+0x2]+OxO6055[0x62] ;} ;}  ; function ColorMode_Changed(){for(var i=0x0;i<0x6;i++){if(frm[OxO6055[0x52]][i][OxO6055[0x50]]){ ColorMode=i ;} ;} ; SetCookie(OxO6055[0x51],ColorMode,0x3c*0x3c*0x18*0x16d) ; Hide(pnlGradientHsbHue_Hue,pnlGradientHsbHue_Black,pnlGradientHsbHue_White,pnlVerticalHsbHue_Background,pnlVerticalHsbSaturation_Hue,pnlVerticalHsbSaturation_White,pnlVerticalHsbBrightness_Hue,pnlVerticalHsbBrightness_Black,pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert,pnlGradientRgb_Overlay1,pnlGradientRgb_Overlay2) ;switch(ColorMode){case 0x0: Show(pnlGradientHsbHue_Hue,pnlGradientHsbHue_Black,pnlGradientHsbHue_White,pnlVerticalHsbHue_Background) ; Hsb_Changed() ;break ;case 0x1: Show(pnlVerticalHsbSaturation_Hue,pnlVerticalHsbSaturation_White,pnlGradientRgb_Base,pnlGradientRgb_Overlay1,pnlGradientRgb_Overlay2) ; SetBgPosition(pnlGradientRgb_Base,0x0,0x0) ; SetBg(pnlGradientRgb_Overlay1,OxO6055[0x4e],pnlGradientRgb_Overlay2,OxO6055[0x63]) ; pnlGradientRgb_Overlay1[OxO6055[0x58]][OxO6055[0x64]]=0x5 ; pnlGradientRgb_Overlay2[OxO6055[0x58]][OxO6055[0x64]]=0x6 ; Hsb_Changed() ;break ;case 0x2: Show(pnlVerticalHsbBrightness_Hue,pnlVerticalHsbBrightness_Black,pnlGradientRgb_Base,pnlGradientRgb_Overlay1,pnlGradientRgb_Overlay2) ; SetBgPosition(pnlGradientRgb_Base,0x0,0x0) ; SetBg(pnlGradientRgb_Overlay1,OxO6055[0x63],pnlGradientRgb_Overlay2,OxO6055[0x4e]) ; pnlGradientRgb_Overlay1[OxO6055[0x58]][OxO6055[0x64]]=0x6 ; pnlGradientRgb_Overlay2[OxO6055[0x58]][OxO6055[0x64]]=0x5 ; Hsb_Changed() ;break ;case 0x3: Show(pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert) ; SetBgPosition(pnlGradientRgb_Base,0x100,0x0,pnlGradientRgb_Invert,0x100,0x0) ; Rgb_Changed() ;break ;case 0x4: Show(pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert) ; SetBgPosition(pnlGradientRgb_Base,0x0,0x100,pnlGradientRgb_Invert,0x0,0x100) ; Rgb_Changed() ;break ;case 0x5: Show(pnlVerticalRgb_Start,pnlVerticalRgb_End,pnlGradientRgb_Base,pnlGradientRgb_Invert) ; SetBgPosition(pnlGradientRgb_Base,0x100,0x100,pnlGradientRgb_Invert,0x100,0x100) ; Rgb_Changed() ;break ;default:break ;;;;;;;;} ;}  ; function btnWebSafeColor_Click(){var Ox230=HexToRgb(frm[OxO6055[0xd]].value); Ox230=RgbToWebSafeRgb(Ox230) ; frm[OxO6055[0xd]][OxO6055[0x4f]]=RgbToHex(Ox230) ; Hex_Changed() ;}  ; function checkWebSafe(){var Ox230=Form_Get_Rgb();if(RgbIsWebSafe(Ox230)){ Hide(frm.btnWebSafeColor,pnlWebSafeColor,pnlWebSafeColorBorder) ;} else { Ox230=RgbToWebSafeRgb(Ox230) ; SetBg(pnlWebSafeColor,RgbToHex(Ox230)) ; Show(frm.btnWebSafeColor,pnlWebSafeColor,pnlWebSafeColorBorder) ;} ;}  ; function validateNumber(){var Ox245=String.fromCharCode(event.keyCode);if(IgnoreKey()){return ;} ;if(OxO6055[0x65].indexOf(Ox245)!=-0x1){return ;} ; event[OxO6055[0x66]]=0x0 ;}  ; function validateHex(){if(IgnoreKey()){return ;} ;var Ox245=String.fromCharCode(event.keyCode);if(OxO6055[0x67].indexOf(Ox245)!=-0x1){ event[OxO6055[0x66]]=Ox245.toUpperCase().charCodeAt(0x0) ;return ;} ;if(OxO6055[0x68].indexOf(Ox245)!=-0x1){return ;} ; event[OxO6055[0x66]]=0x0 ;}  ; function IgnoreKey(){var Ox245=String.fromCharCode(event.keyCode);var Ox248= new Array(0x0,0x8,0x9,0xd,0x1b);if(Ox245==null){return true;} ;for(var i=0x0;i<0x5;i++){if(event[OxO6055[0x66]]==Ox248[i]){return true;} ;} ;return false;}  ; function btnCancel_Click(){ top.close() ;}  ; function btnOK_Click(){var hex= new String(frm[OxO6055[0xd]].value);try{ window[OxO6055[0x69]]=hex ;} catch(e){} ; recent=GetCookie(OxO6055[0x53])||OxO6055[0x54] ;for(var i=0x0;i<recent[OxO6055[0x19]];i+=0x6){if(recent.substr(i,0x6)==hex){ recent=recent.substr(0x0,i)+recent.substr(i+0x6) ; i-=0x6 ;} ;} ;if(recent[OxO6055[0x19]]>0x1f*0x6){ recent=recent.substr(0x0,0x1f*0x6) ;} ; recent=frm[OxO6055[0xd]][OxO6055[0x4f]]+recent ; SetCookie(OxO6055[0x53],recent,0x3c*0x3c*0x18*0x16d) ; top.close() ;}  ; function SetGradientPosition(x,y){ x=x-POSITIONADJUSTX+0x5 ; y=y-POSITIONADJUSTY+0x5 ; x-=0x7 ; y-=0x1b ; x=x<0x0?0x0:x>0xff?0xff:x ; y=y<0x0?0x0:y>0xff?0xff:y ; SetBgPosition(pnlGradientPosition,x-0x5,y-0x5) ;switch(ColorMode){case 0x0:var Ox24c= new Array(0x0,0x0,0x0); Ox24c[0x1]=x/0xff ; Ox24c[0x2]=0x1-(y/0xff) ; frm[OxO6055[0x8]][OxO6055[0x4f]]=Math.round(Ox24c[0x1]*0x64) ; frm[OxO6055[0x9]][OxO6055[0x4f]]=Math.round(Ox24c[0x2]*0x64) ; Hsb_Changed() ;break ;case 0x1:var Ox24c= new Array(0x0,0x0,0x0); Ox24c[0x0]=x/0xff ; Ox24c[0x2]=0x1-(y/0xff) ; frm[OxO6055[0x6]][OxO6055[0x4f]]=Ox24c[0x0]==0x1?0x0:Math.round(Ox24c[0x0]*0x168) ; frm[OxO6055[0x9]][OxO6055[0x4f]]=Math.round(Ox24c[0x2]*0x64) ; Hsb_Changed() ;break ;case 0x2:var Ox24c= new Array(0x0,0x0,0x0); Ox24c[0x0]=x/0xff ; Ox24c[0x1]=0x1-(y/0xff) ; frm[OxO6055[0x6]][OxO6055[0x4f]]=Ox24c[0x0]==0x1?0x0:Math.round(Ox24c[0x0]*0x168) ; frm[OxO6055[0x8]][OxO6055[0x4f]]=Math.round(Ox24c[0x1]*0x64) ; Hsb_Changed() ;break ;case 0x3:var Ox230= new Array(0x0,0x0,0x0); Ox230[0x1]=0xff-y ; Ox230[0x2]=x ; frm[OxO6055[0xb]][OxO6055[0x4f]]=Ox230[0x1] ; frm[OxO6055[0xc]][OxO6055[0x4f]]=Ox230[0x2] ; Rgb_Changed() ;break ;case 0x4:var Ox230= new Array(0x0,0x0,0x0); Ox230[0x0]=0xff-y ; Ox230[0x2]=x ; frm[OxO6055[0xa]][OxO6055[0x4f]]=Ox230[0x0] ; frm[OxO6055[0xc]][OxO6055[0x4f]]=Ox230[0x2] ; Rgb_Changed() ;break ;case 0x5:var Ox230= new Array(0x0,0x0,0x0); Ox230[0x0]=x ; Ox230[0x1]=0xff-y ; frm[OxO6055[0xa]][OxO6055[0x4f]]=Ox230[0x0] ; frm[OxO6055[0xb]][OxO6055[0x4f]]=Ox230[0x1] ; Rgb_Changed() ;break ;;;;;;;} ;}  ; function Hex_Changed(){var hex=Form_Get_Hex();var Ox230=HexToRgb(hex);var Ox24c=RgbToHsb(Ox230); Form_Set_Rgb(Ox230) ; Form_Set_Hsb(Ox24c) ; SetBg(pnlNewColor,hex) ; SetupCursors() ; SetupGradients() ; checkWebSafe() ;}  ; function Rgb_Changed(){var Ox230=Form_Get_Rgb();var Ox24c=RgbToHsb(Ox230);var hex=RgbToHex(Ox230); Form_Set_Hsb(Ox24c) ; Form_Set_Hex(hex) ; SetBg(pnlNewColor,hex) ; SetupCursors() ; SetupGradients() ; checkWebSafe() ;}  ; function Hsb_Changed(){var Ox24c=Form_Get_Hsb();var Ox230=HsbToRgb(Ox24c);var hex=RgbToHex(Ox230); Form_Set_Rgb(Ox230) ; Form_Set_Hex(hex) ; SetBg(pnlNewColor,hex) ; SetupCursors() ; SetupGradients() ; checkWebSafe() ;}  ; function Form_Set_Hex(hex){ frm[OxO6055[0xd]][OxO6055[0x4f]]=hex ;}  ; function Form_Get_Hex(){var hex= new String(frm[OxO6055[0xd]].value);for(var i=0x0;i<hex[OxO6055[0x19]];i++){if(OxO6055[0x6a].indexOf(hex.substr(i,0x1))==-0x1){ hex=OxO6055[0x63] ; frm[OxO6055[0xd]][OxO6055[0x4f]]=hex ; alert(formatString(msg.BadNumber,OxO6055[0x63],OxO6055[0x4e])) ;break ;} ;} ;while(hex[OxO6055[0x19]]<0x6){ hex=OxO6055[0x6b]+hex ;} ;return hex;}  ; function Form_Get_Hsb(){var Ox24c= new Array(0x0,0x0,0x0); Ox24c[0x0]= new Number(frm[OxO6055[0x6]].value)/0x168 ; Ox24c[0x1]= new Number(frm[OxO6055[0x8]].value)/0x64 ; Ox24c[0x2]= new Number(frm[OxO6055[0x9]].value)/0x64 ;if(Ox24c[0x0]>0x1||isNaN(Ox24c[0x0])){ Ox24c[0x0]=0x1 ; frm[OxO6055[0x6]][OxO6055[0x4f]]=0x168 ; alert(formatString(msg.BadNumber,0x0,0x168)) ;} ;if(Ox24c[0x1]>0x1||isNaN(Ox24c[0x1])){ Ox24c[0x1]=0x1 ; frm[OxO6055[0x8]][OxO6055[0x4f]]=0x64 ; alert(formatString(msg.BadNumber,0x0,0x64)) ;} ;if(Ox24c[0x2]>0x1||isNaN(Ox24c[0x2])){ Ox24c[0x2]=0x1 ; frm[OxO6055[0x9]][OxO6055[0x4f]]=0x64 ; alert(formatString(msg.BadNumber,0x0,0x64)) ;} ;return Ox24c;}  ; function Form_Set_Hsb(Ox24c){ SetValue(frm[OxO6055[0x6]],Math.round(Ox24c[0x0]*0x168),frm[OxO6055[0x8]],Math.round(Ox24c[0x1]*0x64),frm[OxO6055[0x9]],Math.round(Ox24c[0x2]*0x64)) ;}  ; function Form_Get_Rgb(){var Ox230= new Array(0x0,0x0,0x0); Ox230[0x0]= new Number(frm[OxO6055[0xa]].value) ; Ox230[0x1]= new Number(frm[OxO6055[0xb]].value) ; Ox230[0x2]= new Number(frm[OxO6055[0xc]].value) ;if(Ox230[0x0]>0xff||isNaN(Ox230[0x0])||Ox230[0x0]!=Math.round(Ox230[0x0])){ Ox230[0x0]=0xff ; frm[OxO6055[0xa]][OxO6055[0x4f]]=0xff ; alert(formatString(msg.BadNumber,0x0,0xff)) ;} ;if(Ox230[0x1]>0xff||isNaN(Ox230[0x1])||Ox230[0x1]!=Math.round(Ox230[0x1])){ Ox230[0x1]=0xff ; frm[OxO6055[0xb]][OxO6055[0x4f]]=0xff ; alert(formatString(msg.BadNumber,0x0,0xff)) ;} ;if(Ox230[0x2]>0xff||isNaN(Ox230[0x2])||Ox230[0x2]!=Math.round(Ox230[0x2])){ Ox230[0x2]=0xff ; frm[OxO6055[0xc]][OxO6055[0x4f]]=0xff ; alert(formatString(msg.BadNumber,0x0,0xff)) ;} ;return Ox230;}  ; function Form_Set_Rgb(Ox230){ frm[OxO6055[0xa]][OxO6055[0x4f]]=Ox230[0x0] ; frm[OxO6055[0xb]][OxO6055[0x4f]]=Ox230[0x1] ; frm[OxO6055[0xc]][OxO6055[0x4f]]=Ox230[0x2] ;}  ; function SetupCursors(){var Ox24c=Form_Get_Hsb();var Ox230=Form_Get_Rgb();if(RgbToYuv(Ox230)[0x0]>=0.5){ SetGradientPositionDark() ;} else { SetGradientPositionLight() ;} ;if(event[OxO6055[0x5b]]!=null){if(event[OxO6055[0x5b]][OxO6055[0x6c]]==OxO6055[0x6d]){return ;} ;if(event[OxO6055[0x5b]][OxO6055[0x6c]]==OxO6055[0x6e]){return ;} ;} ;var x;var y;var z;if(ColorMode>=0x0&&ColorMode<=0x2){for(var i=0x0;i<0x3;i++){ Ox24c[i]*=0xff ;} ;} ;switch(ColorMode){case 0x0: x=Ox24c[0x1] ; y=Ox24c[0x2] ; z=Ox24c[0x0]==0x0?0x1:Ox24c[0x0] ;break ;case 0x1: x=Ox24c[0x0]==0x0?0x1:Ox24c[0x0] ; y=Ox24c[0x2] ; z=Ox24c[0x1] ;break ;case 0x2: x=Ox24c[0x0]==0x0?0x1:Ox24c[0x0] ; y=Ox24c[0x1] ; z=Ox24c[0x2] ;break ;case 0x3: x=Ox230[0x2] ; y=Ox230[0x1] ; z=Ox230[0x0] ;break ;case 0x4: x=Ox230[0x2] ; y=Ox230[0x0] ; z=Ox230[0x1] ;break ;case 0x5: x=Ox230[0x0] ; y=Ox230[0x1] ; z=Ox230[0x2] ;break ;;;;;;;} ; y=0xff-y ; z=0xff-z ; SetBgPosition(pnlGradientPosition,x-0x5,y-0x5) ; pnlVerticalPosition[OxO6055[0x58]][OxO6055[0x6f]]=(z+0x1b)+OxO6055[0x62] ;}  ; function SetupGradients(){var Ox24c=Form_Get_Hsb();var Ox230=Form_Get_Rgb();switch(ColorMode){case 0x0: SetBg(pnlGradientHsbHue_Hue,RgbToHex(HueToRgb(Ox24c[0x0]))) ;break ;case 0x1:var Oxc= new Array();for(var i=0x0;i<0x3;i++){ Oxc[i]=Math.round(Ox24c[0x2]*0xff) ;} ; SetBg(pnlGradientHsbHue_Hue,RgbToHex(HueToRgb(Ox24c[0x0])),pnlVerticalHsbSaturation_Hue,RgbToHex(HsbToRgb( new Array(Ox24c[0x0],0x1,Ox24c[0x2]))),pnlVerticalHsbSaturation_White,RgbToHex(Oxc)) ; pnlGradientRgb_Overlay1[OxO6055[0x71]][0x0][OxO6055[0x70]]=(0x64-Math.round(Ox24c[0x1]*0x64)) ;break ;case 0x2: SetBg(pnlVerticalHsbBrightness_Hue,RgbToHex(HsbToRgb( new Array(Ox24c[0x0],Ox24c[0x1],0x1)))) ; pnlGradientRgb_Overlay1[OxO6055[0x71]][0x0][OxO6055[0x70]]=(0x64-Math.round(Ox24c[0x2]*0x64)) ;break ;case 0x3: pnlGradientRgb_Invert[OxO6055[0x71]][0x3][OxO6055[0x70]]=0x64-Math.round((Ox230[0x0]/0xff)*0x64) ; SetBg(pnlVerticalRgb_Start,RgbToHex( new Array(0xff,Ox230[0x1],Ox230[0x2])),pnlVerticalRgb_End,RgbToHex( new Array(0x0,Ox230[0x1],Ox230[0x2]))) ;break ;case 0x4: pnlGradientRgb_Invert[OxO6055[0x71]][0x3][OxO6055[0x70]]=0x64-Math.round((Ox230[0x1]/0xff)*0x64) ; SetBg(pnlVerticalRgb_Start,RgbToHex( new Array(Ox230[0x0],0xff,Ox230[0x2])),pnlVerticalRgb_End,RgbToHex( new Array(Ox230[0x0],0x0,Ox230[0x2]))) ;break ;case 0x5: pnlGradientRgb_Invert[OxO6055[0x71]][0x3][OxO6055[0x70]]=0x64-Math.round((Ox230[0x2]/0xff)*0x64) ; SetBg(pnlVerticalRgb_Start,RgbToHex( new Array(Ox230[0x0],Ox230[0x1],0xff)),pnlVerticalRgb_End,RgbToHex( new Array(Ox230[0x0],Ox230[0x1],0x0))) ;break ;default:;;;;;;;} ;}  ; function SetGradientPositionDark(){if(GradientPositionDark){return ;} ; GradientPositionDark=true ; pnlGradientPosition[OxO6055[0x58]][OxO6055[0x72]]=OxO6055[0x73] ;}  ; function SetGradientPositionLight(){if(!GradientPositionDark){return ;} ; GradientPositionDark=false ; pnlGradientPosition[OxO6055[0x58]][OxO6055[0x72]]=OxO6055[0x74] ;}  ; function pnlGradient_Top_Click(){ event[OxO6055[0x75]]=true ; SetGradientPosition(event[OxO6055[0x77]]-0x5,event[OxO6055[0x76]]-0x5) ; pnlGradient_Top[OxO6055[0x78]]=OxO6055[0x79] ;}  ; function pnlGradient_Top_MouseMove(){ event[OxO6055[0x75]]=true ;if(event[OxO6055[0x7a]]!=0x1){return ;} ; SetGradientPosition(event[OxO6055[0x77]]-0x5,event[OxO6055[0x76]]-0x5) ;}  ; function pnlGradient_Top_MouseDown(){ event[OxO6055[0x75]]=true ; SetGradientPosition(event[OxO6055[0x77]]-0x5,event[OxO6055[0x76]]-0x5) ; pnlGradient_Top[OxO6055[0x78]]=OxO6055[0x7b] ;}  ; function pnlGradient_Top_MouseUp(){ event[OxO6055[0x75]]=true ; SetGradientPosition(event[OxO6055[0x77]]-0x5,event[OxO6055[0x76]]-0x5) ; pnlGradient_Top[OxO6055[0x78]]=OxO6055[0x79] ;}  ; function Document_MouseUp(){ event[OxO6055[0x75]]=true ; pnlGradient_Top[OxO6055[0x78]]=OxO6055[0x79] ;}  ; function SetVerticalPosition(z){var z=z-POSITIONADJUSTZ;if(z<0x1b){ z=0x1b ;} ;if(z>0x11a){ z=0x11a ;} ; pnlVerticalPosition[OxO6055[0x58]][OxO6055[0x6f]]=z+OxO6055[0x62] ; z=0x1-((z-0x1b)/0xff) ;switch(ColorMode){case 0x0:if(z==0x1){ z=0x0 ;} ; frm[OxO6055[0x6]][OxO6055[0x4f]]=Math.round(z*0x168) ; Hsb_Changed() ;break ;case 0x1: frm[OxO6055[0x8]][OxO6055[0x4f]]=Math.round(z*0x64) ; Hsb_Changed() ;break ;case 0x2: frm[OxO6055[0x9]][OxO6055[0x4f]]=Math.round(z*0x64) ; Hsb_Changed() ;break ;case 0x3: frm[OxO6055[0xa]][OxO6055[0x4f]]=Math.round(z*0xff) ; Rgb_Changed() ;break ;case 0x4: frm[OxO6055[0xb]][OxO6055[0x4f]]=Math.round(z*0xff) ; Rgb_Changed() ;break ;case 0x5: frm[OxO6055[0xc]][OxO6055[0x4f]]=Math.round(z*0xff) ; Rgb_Changed() ;break ;;;;;;;} ;}  ; function pnlVertical_Top_Click(){ SetVerticalPosition(event[OxO6055[0x76]]-0x5) ; event[OxO6055[0x75]]=true ;}  ; function pnlVertical_Top_MouseMove(){if(event[OxO6055[0x7a]]!=0x1){return ;} ; SetVerticalPosition(event[OxO6055[0x76]]-0x5) ; event[OxO6055[0x75]]=true ;}  ; function pnlVertical_Top_MouseDown(){ SetVerticalPosition(event[OxO6055[0x76]]-0x5) ; event[OxO6055[0x75]]=true ;}  ; function pnlVertical_Top_MouseUp(){ SetVerticalPosition(event[OxO6055[0x76]]-0x5) ; event[OxO6055[0x75]]=true ;}  ; function SetCookie(name,Ox115,Ox116){var Ox117=name+OxO6055[0x7c]+escape(Ox115)+OxO6055[0x7d];if(Ox116){var Ox118= new Date(); Ox118.setSeconds(Ox118.getSeconds()+Ox116) ; Ox117+=OxO6055[0x7e]+Ox118.toUTCString()+OxO6055[0x7f] ;} ; document[OxO6055[0x80]]=Ox117 ;}  ; function GetCookie(name){var Ox11a=document[OxO6055[0x80]].split(OxO6055[0x7f]);for(var i=0x0;i<Ox11a[OxO6055[0x19]];i++){var Ox11b=Ox11a[i].split(OxO6055[0x7c]);if(name==Ox11b[0x0].replace(/\s/g,OxO6055[0x54])){return unescape(Ox11b[0x1]);} ;} ;}  ; function GetCookieDictionary(){var Ox11d={};var Ox11a=document[OxO6055[0x80]].split(OxO6055[0x7f]);for(var i=0x0;i<Ox11a[OxO6055[0x19]];i++){var Ox11b=Ox11a[i].split(OxO6055[0x7c]); Ox11d[Ox11b[0x0].replace(/\s/g,OxO6055[0x54])]=unescape(Ox11b[0x1]) ;} ;return Ox11d;}  ; function RgbIsWebSafe(Ox230){var hex=RgbToHex(Ox230);for(var i=0x0;i<0x3;i++){if(OxO6055[0x81].indexOf(hex.substr(i*0x2,0x2))==-0x1){return false;} ;} ;return true;}  ; function RgbToWebSafeRgb(Ox230){var Ox266= new Array(Ox230[0x0],Ox230[0x1],Ox230[0x2]);if(RgbIsWebSafe(Ox230)){return Ox266;} ;var Ox267= new Array(0x0,0x33,0x66,0x99,0xcc,0xff);for(var i=0x0;i<0x3;i++){for(var j=0x1;j<0x6;j++){if(Ox266[i]>Ox267[j-0x1]&&Ox266[i]<Ox267[j]){if(Ox266[i]-Ox267[j-0x1]>Ox267[j]-Ox266[i]){ Ox266[i]=Ox267[j] ;} else { Ox266[i]=Ox267[j-0x1] ;} ;break ;} ;} ;} ;return Ox266;}  ; function RgbToYuv(Ox230){var Ox269= new Array(); Ox269[0x0]=(Ox230[0x0]*0.299+Ox230[0x1]*0.587+Ox230[0x2]*0.114)/0xff ; Ox269[0x1]=(Ox230[0x0]*-0.169+Ox230[0x1]*-0.332+Ox230[0x2]*0.5+0x80)/0xff ; Ox269[0x2]=(Ox230[0x0]*0.5+Ox230[0x1]*-0.419+Ox230[0x2]*-0.0813+0x80)/0xff ;return Ox269;}  ; function RgbToHsb(Ox230){var Ox26b= new Array(Ox230[0x0],Ox230[0x1],Ox230[0x2]);var Ox26c= new Number(0x1);var Ox26d= new Number(0x0);var Ox26e= new Number(0x1);var Ox24c= new Array(0x0,0x0,0x0);var Ox26f= new Array();for(var i=0x0;i<0x3;i++){ Ox26b[i]=Ox230[i]/0xff ;if(Ox26b[i]<Ox26c){ Ox26c=Ox26b[i] ;} ;if(Ox26b[i]>Ox26d){ Ox26d=Ox26b[i] ;} ;} ; Ox26e=Ox26d-Ox26c ; Ox24c[0x2]=Ox26d ;if(Ox26e==0x0){return Ox24c;} ; Ox24c[0x1]=Ox26e/Ox26d ;for(var i=0x0;i<0x3;i++){ Ox26f[i]=(((Ox26d-Ox26b[i])/0x6)+(Ox26e/0x2))/Ox26e ;} ;if(Ox26b[0x0]==Ox26d){ Ox24c[0x0]=Ox26f[0x2]-Ox26f[0x1] ;} else {if(Ox26b[0x1]==Ox26d){ Ox24c[0x0]=(0x1/0x3)+Ox26f[0x0]-Ox26f[0x2] ;} else {if(Ox26b[0x2]==Ox26d){ Ox24c[0x0]=(0x2/0x3)+Ox26f[0x1]-Ox26f[0x0] ;} ;} ;} ;if(Ox24c[0x0]<0x0){ Ox24c[0x0]+=0x1 ;} else {if(Ox24c[0x0]>0x1){ Ox24c[0x0]-=0x1 ;} ;} ;return Ox24c;}  ; function HsbToRgb(Ox24c){var Ox230=HueToRgb(Ox24c[0x0]);var Ox109=Ox24c[0x2]*0xff;for(var i=0x0;i<0x3;i++){ Ox230[i]=Ox230[i]*Ox24c[0x2] ; Ox230[i]=((Ox230[i]-Ox109)*Ox24c[0x1])+Ox109 ; Ox230[i]=Math.round(Ox230[i]) ;} ;return Ox230;}  ; function RgbToHex(Ox230){var hex= new String();for(var i=0x0;i<0x3;i++){ Ox230[0x2-i]=Math.round(Ox230[0x2-i]) ; hex=Ox230[0x2-i].toString(0x10)+hex ;if(hex[OxO6055[0x19]]%0x2==0x1){ hex=OxO6055[0x6b]+hex ;} ;} ;return hex.toUpperCase();}  ; function HexToRgb(hex){var Ox230= new Array();for(var i=0x0;i<0x3;i++){ Ox230[i]= new Number(OxO6055[0x82]+hex.substr(i*0x2,0x2)) ;} ;return Ox230;}  ; function HueToRgb(Ox274){var Ox275=Ox274*0x168;var Ox230= new Array(0x0,0x0,0x0);var Ox276=(Ox275%0x3c)/0x3c;if(Ox275<0x3c){ Ox230[0x0]=0xff ; Ox230[0x1]=Ox276*0xff ;} else {if(Ox275<0x78){ Ox230[0x1]=0xff ; Ox230[0x0]=(0x1-Ox276)*0xff ;} else {if(Ox275<0xb4){ Ox230[0x1]=0xff ; Ox230[0x2]=Ox276*0xff ;} else {if(Ox275<0xf0){ Ox230[0x2]=0xff ; Ox230[0x1]=(0x1-Ox276)*0xff ;} else {if(Ox275<0x12c){ Ox230[0x2]=0xff ; Ox230[0x0]=Ox276*0xff ;} else {if(Ox275<0x168){ Ox230[0x0]=0xff ; Ox230[0x2]=(0x1-Ox276)*0xff ;} ;} ;} ;} ;} ;} ;return Ox230;}  ; function CheckHexSelect(){if(window[OxO6055[0x84]]&&window[OxO6055[0x83]]&&frm[OxO6055[0xd]]){var Oxc5=OxO6055[0x49]+frm[OxO6055[0xd]][OxO6055[0x4f]];if(Oxc5[OxO6055[0x19]]==0x7){if(window[OxO6055[0x85]]!=Oxc5){ window[OxO6055[0x85]]=Oxc5 ; window.do_select(Oxc5) ;} ;} ;} ;}  ; setInterval(CheckHexSelect,0xa) ;