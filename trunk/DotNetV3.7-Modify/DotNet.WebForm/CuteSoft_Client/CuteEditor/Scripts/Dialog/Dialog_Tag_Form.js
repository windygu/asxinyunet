var OxOd60e=["inp_action","sel_Method","inp_name","inp_id","inp_encode","sel_target","Name","value","name","id","action","method","encoding","application/x-www-form-urlencoded","","target"];var inp_action=Window_GetElement(window,OxOd60e[0x0], true);var sel_Method=Window_GetElement(window,OxOd60e[0x1], true);var inp_name=Window_GetElement(window,OxOd60e[0x2], true);var inp_id=Window_GetElement(window,OxOd60e[0x3], true);var inp_encode=Window_GetElement(window,OxOd60e[0x4], true);var sel_target=Window_GetElement(window,OxOd60e[0x5], true); UpdateState=function UpdateState_Form(){}  ; SyncToView=function SyncToView_Form(){if(element[OxOd60e[0x6]]){ inp_name[OxOd60e[0x7]]=element[OxOd60e[0x6]] ;} ;if(element[OxOd60e[0x8]]){ inp_name[OxOd60e[0x7]]=element[OxOd60e[0x8]] ;} ; inp_id[OxOd60e[0x7]]=element[OxOd60e[0x9]] ;if(element[OxOd60e[0xa]]){ inp_action[OxOd60e[0x7]]=element[OxOd60e[0xa]] ;} ;if(element[OxOd60e[0xb]]){ sel_Method[OxOd60e[0x7]]=element[OxOd60e[0xb]] ;} ;if(element[OxOd60e[0xc]]==OxOd60e[0xd]){ inp_encode[OxOd60e[0x7]]=OxOd60e[0xe] ;} else { inp_encode[OxOd60e[0x7]]=element[OxOd60e[0xc]] ;} ;if(element[OxOd60e[0xf]]){ sel_target[OxOd60e[0x7]]=element[OxOd60e[0xf]] ;} ;}  ; SyncTo=function SyncTo_Form(element){ element[OxOd60e[0x8]]=inp_name[OxOd60e[0x7]] ;if(element[OxOd60e[0x6]]){ element[OxOd60e[0x6]]=inp_name[OxOd60e[0x7]] ;} else {if(element[OxOd60e[0x8]]){ element.removeAttribute(OxOd60e[0x8],0x0) ; element[OxOd60e[0x6]]=inp_name[OxOd60e[0x7]] ;} else { element[OxOd60e[0x6]]=inp_name[OxOd60e[0x7]] ;} ;} ; element[OxOd60e[0x9]]=inp_id[OxOd60e[0x7]] ; element[OxOd60e[0xa]]=inp_action[OxOd60e[0x7]] ; element[OxOd60e[0xb]]=sel_Method[OxOd60e[0x7]] ;try{ element[OxOd60e[0xc]]=inp_encode[OxOd60e[0x7]] ;} catch(e){} ; element[OxOd60e[0xf]]=sel_target[OxOd60e[0x7]] ;if(element[OxOd60e[0xf]]==OxOd60e[0xe]){ element.removeAttribute(OxOd60e[0xf]) ;} ;if(element[OxOd60e[0x6]]==OxOd60e[0xe]){ element.removeAttribute(OxOd60e[0x6]) ;} ;if(element[OxOd60e[0xa]]==OxOd60e[0xe]){ element.removeAttribute(OxOd60e[0xa]) ;} ;}  ;