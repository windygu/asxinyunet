var OxOd43d=["inp_type","inp_name","inp_value","row_txt1","inp_Size","row_txt2","inp_MaxLength","row_img","inp_src","btnbrowse","row_img2","sel_Align","optNotSet","optLeft","optRight","optTexttop","optAbsMiddle","optBaseline","optAbsBottom","optBottom","optMiddle","optTop","inp_Border","row_img3","inp_width","inp_height","row_img4","inp_HSpace","inp_VSpace","row_img5","AlternateText","inp_id","row_txt3","inp_access","row_txt4","inp_index","row_chk","inp_checked","row_txt5","inp_Disabled","row_txt6","inp_Readonly","onclick","value","Name","name","id","src","type","checked","disabled","readOnly","tabIndex","","accessKey","size","maxLength","width","height","vspace","hspace","border","align","alt","display","style","none","image","button","reset","submit","checkbox","radio","hidden","password","text","className","class"];var inp_type=Window_GetElement(window,OxOd43d[0x0],true);var inp_name=Window_GetElement(window,OxOd43d[0x1],true);var inp_value=Window_GetElement(window,OxOd43d[0x2],true);var row_txt1=Window_GetElement(window,OxOd43d[0x3],true);var inp_Size=Window_GetElement(window,OxOd43d[0x4],true);var row_txt2=Window_GetElement(window,OxOd43d[0x5],true);var inp_MaxLength=Window_GetElement(window,OxOd43d[0x6],true);var row_img=Window_GetElement(window,OxOd43d[0x7],true);var inp_src=Window_GetElement(window,OxOd43d[0x8],true);var btnbrowse=Window_GetElement(window,OxOd43d[0x9],true);var row_img2=Window_GetElement(window,OxOd43d[0xa],true);var sel_Align=Window_GetElement(window,OxOd43d[0xb],true);var optNotSet=Window_GetElement(window,OxOd43d[0xc],true);var optLeft=Window_GetElement(window,OxOd43d[0xd],true);var optRight=Window_GetElement(window,OxOd43d[0xe],true);var optTexttop=Window_GetElement(window,OxOd43d[0xf],true);var optAbsMiddle=Window_GetElement(window,OxOd43d[0x10],true);var optBaseline=Window_GetElement(window,OxOd43d[0x11],true);var optAbsBottom=Window_GetElement(window,OxOd43d[0x12],true);var optBottom=Window_GetElement(window,OxOd43d[0x13],true);var optMiddle=Window_GetElement(window,OxOd43d[0x14],true);var optTop=Window_GetElement(window,OxOd43d[0x15],true);var inp_Border=Window_GetElement(window,OxOd43d[0x16],true);var row_img3=Window_GetElement(window,OxOd43d[0x17],true);var inp_width=Window_GetElement(window,OxOd43d[0x18],true);var inp_height=Window_GetElement(window,OxOd43d[0x19],true);var row_img4=Window_GetElement(window,OxOd43d[0x1a],true);var inp_HSpace=Window_GetElement(window,OxOd43d[0x1b],true);var inp_VSpace=Window_GetElement(window,OxOd43d[0x1c],true);var row_img5=Window_GetElement(window,OxOd43d[0x1d],true);var AlternateText=Window_GetElement(window,OxOd43d[0x1e],true);var inp_id=Window_GetElement(window,OxOd43d[0x1f],true);var row_txt3=Window_GetElement(window,OxOd43d[0x20],true);var inp_access=Window_GetElement(window,OxOd43d[0x21],true);var row_txt4=Window_GetElement(window,OxOd43d[0x22],true);var inp_index=Window_GetElement(window,OxOd43d[0x23],true);var row_chk=Window_GetElement(window,OxOd43d[0x24],true);var inp_checked=Window_GetElement(window,OxOd43d[0x25],true);var row_txt5=Window_GetElement(window,OxOd43d[0x26],true);var inp_Disabled=Window_GetElement(window,OxOd43d[0x27],true);var row_txt6=Window_GetElement(window,OxOd43d[0x28],true);var inp_Readonly=Window_GetElement(window,OxOd43d[0x29],true); btnbrowse[OxOd43d[0x2a]]=function btnbrowse_onclick(){ function Ox2d3(Ox130){if(Ox130){ inp_src[OxOd43d[0x2b]]=Ox130 ; SyncTo(element) ;} ;}  ; editor.SetNextDialogWindow(window) ;if(Browser_IsSafari()){ editor.ShowSelectImageDialog(Ox2d3,inp_src.value,inp_src) ;} else { editor.ShowSelectImageDialog(Ox2d3,inp_src.value) ;} ;}  ; UpdateState=function UpdateState_Input(){}  ; SyncToView=function SyncToView_Input(){if(element[OxOd43d[0x2c]]){ inp_name[OxOd43d[0x2b]]=element[OxOd43d[0x2c]] ;} ;if(element[OxOd43d[0x2d]]){ inp_name[OxOd43d[0x2b]]=element[OxOd43d[0x2d]] ;} ; inp_id[OxOd43d[0x2b]]=element[OxOd43d[0x2e]] ; inp_value[OxOd43d[0x2b]]=(element[OxOd43d[0x2b]]).trim() ; inp_src[OxOd43d[0x2b]]=element[OxOd43d[0x2f]] ; inp_type[OxOd43d[0x2b]]=element[OxOd43d[0x30]] ; inp_checked[OxOd43d[0x31]]=element[OxOd43d[0x31]] ; inp_Disabled[OxOd43d[0x31]]=element[OxOd43d[0x32]] ; inp_Readonly[OxOd43d[0x31]]=element[OxOd43d[0x33]] ;if(element[OxOd43d[0x34]]==0x0){ inp_index[OxOd43d[0x2b]]=OxOd43d[0x35] ;} else { inp_index[OxOd43d[0x2b]]=element[OxOd43d[0x34]] ;} ;if(element[OxOd43d[0x36]]){ inp_access[OxOd43d[0x2b]]=element[OxOd43d[0x36]] ;} ;if(element[OxOd43d[0x37]]){if(element[OxOd43d[0x37]]==0x14){ inp_Size[OxOd43d[0x2b]]=OxOd43d[0x35] ;} else { inp_Size[OxOd43d[0x2b]]=element[OxOd43d[0x37]] ;} ;} ;if(element[OxOd43d[0x38]]){if(element[OxOd43d[0x38]]==0x7fffffff||element[OxOd43d[0x38]]<=0x0){ inp_MaxLength[OxOd43d[0x2b]]=OxOd43d[0x35] ;} else { inp_MaxLength[OxOd43d[0x2b]]=element[OxOd43d[0x38]] ;} ;} ;if(element[OxOd43d[0x39]]){ inp_width[OxOd43d[0x2b]]=element[OxOd43d[0x39]] ;} ;if(element[OxOd43d[0x3a]]){ inp_height[OxOd43d[0x2b]]=element[OxOd43d[0x3a]] ;} ;if(element[OxOd43d[0x3b]]){ inp_HSpace[OxOd43d[0x2b]]=element[OxOd43d[0x3b]] ;} ;if(element[OxOd43d[0x3c]]){ inp_VSpace[OxOd43d[0x2b]]=element[OxOd43d[0x3c]] ;} ;if(element[OxOd43d[0x3d]]){ inp_Border[OxOd43d[0x2b]]=element[OxOd43d[0x3d]] ;} ;if(element[OxOd43d[0x3e]]){ sel_Align[OxOd43d[0x2b]]=element[OxOd43d[0x3e]] ;} ;if(element[OxOd43d[0x3f]]){ alt[OxOd43d[0x2b]]=element[OxOd43d[0x3f]] ;} ;switch((element[OxOd43d[0x30]]).toLowerCase()){case OxOd43d[0x4b]:case OxOd43d[0x4a]: row_img[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img3[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img4[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img5[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_chk[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ;break ;case OxOd43d[0x49]: row_img[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img3[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img4[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img5[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_chk[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt1[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt3[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt4[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt5[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt6[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ;break ;case OxOd43d[0x48]:case OxOd43d[0x47]: row_img[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img3[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img4[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img5[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt1[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt6[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ;break ;case OxOd43d[0x46]:case OxOd43d[0x45]:case OxOd43d[0x44]: row_chk[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img3[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img4[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_img5[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt1[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt6[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ;break ;case OxOd43d[0x43]: row_chk[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt1[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt2[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ; row_txt6[OxOd43d[0x41]][OxOd43d[0x40]]=OxOd43d[0x42] ;break ;;;;;;;;;;} ;}  ; SyncTo=function SyncTo_Input(element){ element[OxOd43d[0x2d]]=inp_name[OxOd43d[0x2b]] ;if(element[OxOd43d[0x2c]]){ element[OxOd43d[0x2c]]=inp_name[OxOd43d[0x2b]] ;} else {if(element[OxOd43d[0x2d]]){ element.removeAttribute(OxOd43d[0x2d],0x0) ; element[OxOd43d[0x2c]]=inp_name[OxOd43d[0x2b]] ;} else { element[OxOd43d[0x2c]]=inp_name[OxOd43d[0x2b]] ;} ;} ; element[OxOd43d[0x2e]]=inp_id[OxOd43d[0x2b]] ;if(inp_src[OxOd43d[0x2b]]){ element[OxOd43d[0x2f]]=inp_src[OxOd43d[0x2b]] ;} ; element[OxOd43d[0x31]]=inp_checked[OxOd43d[0x31]] ; element[OxOd43d[0x2b]]=inp_value[OxOd43d[0x2b]] ; element[OxOd43d[0x32]]=inp_Disabled[OxOd43d[0x31]] ; element[OxOd43d[0x33]]=inp_Readonly[OxOd43d[0x31]] ; element[OxOd43d[0x36]]=inp_access[OxOd43d[0x2b]] ; element[OxOd43d[0x34]]=inp_index[OxOd43d[0x2b]] ; element[OxOd43d[0x38]]=inp_MaxLength[OxOd43d[0x2b]] ; element[OxOd43d[0x39]]=inp_width[OxOd43d[0x2b]] ; element[OxOd43d[0x3a]]=inp_height[OxOd43d[0x2b]] ; element[OxOd43d[0x3b]]=inp_HSpace[OxOd43d[0x2b]] ; element[OxOd43d[0x3c]]=inp_VSpace[OxOd43d[0x2b]] ; element[OxOd43d[0x3d]]=inp_Border[OxOd43d[0x2b]] ; element[OxOd43d[0x3e]]=sel_Align[OxOd43d[0x2b]] ; element[OxOd43d[0x3f]]=AlternateText[OxOd43d[0x2b]] ;try{ element[OxOd43d[0x37]]=inp_Size[OxOd43d[0x2b]] ;} catch(e){ element[OxOd43d[0x37]]=0x14 ;} ;if(element[OxOd43d[0x34]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x34]) ;} ;if(element[OxOd43d[0x36]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x36]) ;} ;if(element[OxOd43d[0x38]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x38]) ;} ;if(element[OxOd43d[0x37]]==0x0){ element.removeAttribute(OxOd43d[0x37]) ;} ;if(element[OxOd43d[0x39]]==0x0){ element.removeAttribute(OxOd43d[0x39]) ;} ;if(element[OxOd43d[0x3a]]==0x0){ element.removeAttribute(OxOd43d[0x3a]) ;} ;if(element[OxOd43d[0x3c]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x3c]) ;} ;if(element[OxOd43d[0x3b]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x3b]) ;} ;if(element[OxOd43d[0x2e]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x2e]) ;} ;if(element[OxOd43d[0x2c]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x2c]) ;} ;if(element[OxOd43d[0x3f]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x3f]) ;} ;if(element[OxOd43d[0x3e]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x3e]) ;} ;if(element[OxOd43d[0x4c]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x4d]) ;} ;if(element[OxOd43d[0x4c]]==OxOd43d[0x35]){ element.removeAttribute(OxOd43d[0x4c]) ;} ;switch((element[OxOd43d[0x30]]).toLowerCase()){case OxOd43d[0x4b]:case OxOd43d[0x4a]:case OxOd43d[0x49]:case OxOd43d[0x48]:case OxOd43d[0x47]:case OxOd43d[0x46]:case OxOd43d[0x45]:case OxOd43d[0x44]: element.removeAttribute(OxOd43d[0x3a]) ; element.removeAttribute(OxOd43d[0x3d]) ; element.removeAttribute(OxOd43d[0x2f]) ;break ;case OxOd43d[0x43]:break ;;;;;;;;;;} ;}  ;