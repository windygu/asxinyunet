var OxO2b61=["inp_src","inp_title","inp_target","sel_protocol","btnbrowse","editor","","href","value","title","target","onclick","length","options","://",":","others","selectedIndex"];var inp_src=Window_GetElement(window,OxO2b61[0x0],true);var inp_title=Window_GetElement(window,OxO2b61[0x1],true);var inp_target=Window_GetElement(window,OxO2b61[0x2],true);var sel_protocol=Window_GetElement(window,OxO2b61[0x3],true);var btnbrowse=Window_GetElement(window,OxO2b61[0x4],true);var obj=Window_GetDialogArguments(window);var editor=obj[OxO2b61[0x5]]; SyncToView() ; function SyncToView(){var src=obj[OxO2b61[0x7]].replace(/$\s*/,OxO2b61[0x6]); Update_sel_protocol(src) ; inp_src[OxO2b61[0x8]]=src ;if(obj[OxO2b61[0x9]]){ inp_title[OxO2b61[0x8]]=obj[OxO2b61[0x9]] ;} ;if(obj[OxO2b61[0xa]]){ inp_target[OxO2b61[0x8]]=obj[OxO2b61[0xa]] ;} ;}  ; btnbrowse[OxO2b61[0xb]]=function btnbrowse_onclick(){ function Ox2d3(Ox130){if(Ox130){ inp_src[OxO2b61[0x8]]=Ox130 ;} ;}  ; editor.SetNextDialogWindow(window) ;if(Browser_IsSafari()){ editor.ShowSelectFileDialog(Ox2d3,inp_src.value,inp_src) ;} else { editor.ShowSelectFileDialog(Ox2d3,inp_src.value) ;} ;}  ; function sel_protocol_change(){var src=inp_src[OxO2b61[0x8]].replace(/$\s*/,OxO2b61[0x6]);for(var i=0x0;i<sel_protocol[OxO2b61[0xd]][OxO2b61[0xc]];i++){var Ox134=sel_protocol[OxO2b61[0xd]][i][OxO2b61[0x8]];if(src.substr(0x0,Ox134.length).toLowerCase()==Ox134){ src=src.substr(Ox134[OxO2b61[0xc]],src[OxO2b61[0xc]]-Ox134.length) ;break ;} ;} ;var Ox3b7=src.indexOf(OxO2b61[0xe]);if(Ox3b7!=-0x1){ src=src.substr(Ox3b7+0x3,src[OxO2b61[0xc]]-0x3-Ox3b7) ;} ;var Ox3b7=src.indexOf(OxO2b61[0xf]);if(Ox3b7!=-0x1){ src=src.substr(Ox3b7+0x1,src[OxO2b61[0xc]]-0x1-Ox3b7) ;} ;var Ox3b8=sel_protocol[OxO2b61[0x8]];if(Ox3b8==OxO2b61[0x10]){ Ox3b8=OxO2b61[0x6] ;} ; inp_src[OxO2b61[0x8]]=Ox3b8+src ;}  ; function Update_sel_protocol(src){var Ox3ba=false;for(var i=0x0;i<sel_protocol[OxO2b61[0xd]][OxO2b61[0xc]];i++){var Ox134=sel_protocol[OxO2b61[0xd]][i][OxO2b61[0x8]];if(src.substr(0x0,Ox134.length).toLowerCase()==Ox134){if(sel_protocol[OxO2b61[0x11]]!=i){ sel_protocol[OxO2b61[0x11]]=i ;} ; Ox3ba=true ;break ;} ;} ;if(!Ox3ba){ sel_protocol[OxO2b61[0x11]]=sel_protocol[OxO2b61[0xd]][OxO2b61[0xc]]-0x1 ;} ;}  ; function insert_link(){var arr= new Array(); arr[0x0]=inp_src[OxO2b61[0x8]] ;if(inp_target[OxO2b61[0x8]]){ arr[0x1]=inp_target[OxO2b61[0x8]] ;} ;if(inp_title[OxO2b61[0x8]]){ arr[0x2]=inp_title[OxO2b61[0x8]] ;} ; Window_SetDialogReturnValue(window,arr) ; Window_CloseDialog(window) ;}  ;