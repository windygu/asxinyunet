var OxOb49a=["inp_name","inp_cols","inp_rows","inp_value","sel_Wrap","inp_id","inp_access","inp_index","inp_Disabled","inp_Readonly","Name","value","name","id","cols","","rows","disabled","checked","readOnly","wrap","tabIndex","accessKey","textContent"];var inp_name=Window_GetElement(window,OxOb49a[0x0], true);var inp_cols=Window_GetElement(window,OxOb49a[0x1], true);var inp_rows=Window_GetElement(window,OxOb49a[0x2], true);var inp_value=Window_GetElement(window,OxOb49a[0x3], true);var sel_Wrap=Window_GetElement(window,OxOb49a[0x4], true);var inp_id=Window_GetElement(window,OxOb49a[0x5], true);var inp_access=Window_GetElement(window,OxOb49a[0x6], true);var inp_index=Window_GetElement(window,OxOb49a[0x7], true);var inp_Disabled=Window_GetElement(window,OxOb49a[0x8], true);var inp_Readonly=Window_GetElement(window,OxOb49a[0x9], true); UpdateState=function UpdateState_Textarea(){}  ; SyncToView=function SyncToView_Textarea(){if(element[OxOb49a[0xa]]){ inp_name[OxOb49a[0xb]]=element[OxOb49a[0xa]] ;} ;if(element[OxOb49a[0xc]]){ inp_name[OxOb49a[0xb]]=element[OxOb49a[0xc]] ;} ; inp_id[OxOb49a[0xb]]=element[OxOb49a[0xd]] ; inp_value[OxOb49a[0xb]]=element[OxOb49a[0xb]] ;if(element[OxOb49a[0xe]]){if(element[OxOb49a[0xe]]==0x14){ inp_cols[OxOb49a[0xb]]=OxOb49a[0xf] ;} else { inp_cols[OxOb49a[0xb]]=element[OxOb49a[0xe]] ;} ;} ;if(element[OxOb49a[0x10]]){if(element[OxOb49a[0x10]]==0x2){ inp_rows[OxOb49a[0xb]]=OxOb49a[0xf] ;} else { inp_rows[OxOb49a[0xb]]=element[OxOb49a[0x10]] ;} ;} ; inp_Disabled[OxOb49a[0x12]]=element[OxOb49a[0x11]] ; inp_Readonly[OxOb49a[0x12]]=element[OxOb49a[0x13]] ; sel_Wrap[OxOb49a[0xb]]=element[OxOb49a[0x14]] ;if(element[OxOb49a[0x15]]==0x0){ inp_index[OxOb49a[0xb]]=OxOb49a[0xf] ;} else { inp_index[OxOb49a[0xb]]=element[OxOb49a[0x15]] ;} ;if(element[OxOb49a[0x16]]){ inp_access[OxOb49a[0xb]]=element[OxOb49a[0x16]] ;} ;}  ; SyncTo=function SyncTo_Textarea(element){ element[OxOb49a[0xc]]=inp_name[OxOb49a[0xb]] ;if(element[OxOb49a[0xa]]){ element[OxOb49a[0xa]]=inp_name[OxOb49a[0xb]] ;} else {if(element[OxOb49a[0xc]]){ element.removeAttribute(OxOb49a[0xc],0x0) ; element[OxOb49a[0xa]]=inp_name[OxOb49a[0xb]] ;} else { element[OxOb49a[0xa]]=inp_name[OxOb49a[0xb]] ;} ;} ; element[OxOb49a[0xd]]=inp_id[OxOb49a[0xb]] ; element[OxOb49a[0xb]]=inp_value[OxOb49a[0xb]] ;if(!Browser_IsWinIE()){try{ element[OxOb49a[0x17]]=inp_value[OxOb49a[0xb]] ;} catch(x){} ;} ; element[OxOb49a[0x15]]=inp_index[OxOb49a[0xb]] ; element[OxOb49a[0x11]]=inp_Disabled[OxOb49a[0x12]] ; element[OxOb49a[0x13]]=inp_Readonly[OxOb49a[0x12]] ; element[OxOb49a[0x16]]=inp_access[OxOb49a[0xb]] ;if(inp_cols[OxOb49a[0xb]]==OxOb49a[0xf]){ element[OxOb49a[0xe]]=0x14 ;} else { element[OxOb49a[0xe]]=inp_cols[OxOb49a[0xb]] ;} ;if(inp_rows[OxOb49a[0xb]]==OxOb49a[0xf]){ element[OxOb49a[0x10]]=0x2 ;} else { element[OxOb49a[0x10]]=inp_rows[OxOb49a[0xb]] ;} ;try{ element[OxOb49a[0x14]]=sel_Wrap[OxOb49a[0xb]] ;} catch(e){ element.removeAttribute(OxOb49a[0x14]) ;} ; element[OxOb49a[0x15]]=inp_index[OxOb49a[0xb]] ;if(element[OxOb49a[0x15]]==OxOb49a[0xf]){ element.removeAttribute(OxOb49a[0x15]) ;} ;if(element[OxOb49a[0x16]]==OxOb49a[0xf]){ element.removeAttribute(OxOb49a[0x16]) ;} ;}  ;