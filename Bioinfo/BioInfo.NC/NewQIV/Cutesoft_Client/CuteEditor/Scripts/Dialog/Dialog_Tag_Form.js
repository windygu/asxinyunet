var OxO26b0=["inp_action","sel_Method","inp_name","inp_id","inp_encode","sel_target","Name","value","name","id","action","method","encoding","application/x-www-form-urlencoded","","target"];var inp_action=Window_GetElement(window,OxO26b0[0x0],true);var sel_Method=Window_GetElement(window,OxO26b0[0x1],true);var inp_name=Window_GetElement(window,OxO26b0[0x2],true);var inp_id=Window_GetElement(window,OxO26b0[0x3],true);var inp_encode=Window_GetElement(window,OxO26b0[0x4],true);var sel_target=Window_GetElement(window,OxO26b0[0x5],true); UpdateState=function UpdateState_Form(){}  ; SyncToView=function SyncToView_Form(){if(element[OxO26b0[0x6]]){ inp_name[OxO26b0[0x7]]=element[OxO26b0[0x6]] ;} ;if(element[OxO26b0[0x8]]){ inp_name[OxO26b0[0x7]]=element[OxO26b0[0x8]] ;} ; inp_id[OxO26b0[0x7]]=element[OxO26b0[0x9]] ; inp_action[OxO26b0[0x7]]=element[OxO26b0[0xa]] ; sel_Method[OxO26b0[0x7]]=element[OxO26b0[0xb]] ;if(element[OxO26b0[0xc]]==OxO26b0[0xd]){ inp_encode[OxO26b0[0x7]]=OxO26b0[0xe] ;} else { inp_encode[OxO26b0[0x7]]=element[OxO26b0[0xc]] ;} ; sel_target[OxO26b0[0x7]]=element[OxO26b0[0xf]] ;}  ; SyncTo=function SyncTo_Form(element){ element[OxO26b0[0x8]]=inp_name[OxO26b0[0x7]] ;if(element[OxO26b0[0x6]]){ element[OxO26b0[0x6]]=inp_name[OxO26b0[0x7]] ;} else {if(element[OxO26b0[0x8]]){ element.removeAttribute(OxO26b0[0x8],0x0) ; element[OxO26b0[0x6]]=inp_name[OxO26b0[0x7]] ;} else { element[OxO26b0[0x6]]=inp_name[OxO26b0[0x7]] ;} ;} ; element[OxO26b0[0x9]]=inp_id[OxO26b0[0x7]] ; element[OxO26b0[0xa]]=inp_action[OxO26b0[0x7]] ; element[OxO26b0[0xb]]=sel_Method[OxO26b0[0x7]] ;try{ element[OxO26b0[0xc]]=inp_encode[OxO26b0[0x7]] ;} catch(e){} ; element[OxO26b0[0xf]]=sel_target[OxO26b0[0x7]] ;if(element[OxO26b0[0xf]]==OxO26b0[0xe]){ element.removeAttribute(OxO26b0[0xf]) ;} ;if(element[OxO26b0[0x6]]==OxO26b0[0xe]){ element.removeAttribute(OxO26b0[0x6]) ;} ;if(element[OxO26b0[0xa]]==OxO26b0[0xe]){ element.removeAttribute(OxO26b0[0xa]) ;} ;}  ;