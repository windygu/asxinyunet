var OxO6e33=["outer","btnbrowse","inp_src","onclick","value","cssText","style","src","FileName"];var outer=Window_GetElement(window,OxO6e33[0x0],true);var btnbrowse=Window_GetElement(window,OxO6e33[0x1],true);var inp_src=Window_GetElement(window,OxO6e33[0x2],true); btnbrowse[OxO6e33[0x3]]=function btnbrowse_onclick(){ function Ox2d3(Ox130){if(Ox130){ inp_src[OxO6e33[0x4]]=Ox130 ;} ;}  ; editor.SetNextDialogWindow(window) ; editor.ShowSelectFileDialog(Ox2d3,inp_src.value) ;}  ; UpdateState=function UpdateState_Media(){ outer[OxO6e33[0x6]][OxO6e33[0x5]]=element[OxO6e33[0x6]][OxO6e33[0x5]] ; outer.mergeAttributes(element) ;if(element[OxO6e33[0x7]]){ outer[OxO6e33[0x8]]=element[OxO6e33[0x8]] ;} else { outer.removeAttribute(OxO6e33[0x8]) ;} ;}  ; SyncToView=function SyncToView_Media(){ inp_src[OxO6e33[0x4]]=element[OxO6e33[0x8]] ;}  ; SyncTo=function SyncTo_Media(element){ element[OxO6e33[0x8]]=inp_src[OxO6e33[0x4]] ;}  ;