var OxOf7d0=["inp_name","inp_access","inp_id","inp_index","inp_size","inp_Multiple","inp_Disabled","inp_item_text","inp_item_value","btnInsertItem","btnUpdateItem","btnDeleteItem","btnMoveUpItem","btnMoveDownItem","list_options","list_options2","inp_item_forecolor","inp_item_forecolor_Preview","inp_item_backcolor_Preview","value","text","color","style","backgroundColor","selectedIndex","options","Please select an item first","length","ondblclick","onclick","OPTION","document","id","cssText","Name","name","size","disabled","checked","multiple","tabIndex","","accessKey"];var inp_name=Window_GetElement(window,OxOf7d0[0x0], true);var inp_access=Window_GetElement(window,OxOf7d0[0x1], true);var inp_id=Window_GetElement(window,OxOf7d0[0x2], true);var inp_index=Window_GetElement(window,OxOf7d0[0x3], true);var inp_size=Window_GetElement(window,OxOf7d0[0x4], true);var inp_Multiple=Window_GetElement(window,OxOf7d0[0x5], true);var inp_Disabled=Window_GetElement(window,OxOf7d0[0x6], true);var inp_item_text=Window_GetElement(window,OxOf7d0[0x7], true);var inp_item_value=Window_GetElement(window,OxOf7d0[0x8], true);var btnInsertItem=Window_GetElement(window,OxOf7d0[0x9], true);var btnUpdateItem=Window_GetElement(window,OxOf7d0[0xa], true);var btnDeleteItem=Window_GetElement(window,OxOf7d0[0xb], true);var btnMoveUpItem=Window_GetElement(window,OxOf7d0[0xc], true);var btnMoveDownItem=Window_GetElement(window,OxOf7d0[0xd], true);var list_options=Window_GetElement(window,OxOf7d0[0xe], true);var list_options2=Window_GetElement(window,OxOf7d0[0xf], true);var inp_item_forecolor=Window_GetElement(window,OxOf7d0[0x10], true);var inp_item_forecolor=Window_GetElement(window,OxOf7d0[0x10], true);var inp_item_forecolor_Preview=Window_GetElement(window,OxOf7d0[0x11], true);var inp_item_backcolor_Preview=Window_GetElement(window,OxOf7d0[0x12], true); function SetOption(Ox518){ Ox518[OxOf7d0[0x14]]=inp_item_text[OxOf7d0[0x13]] ; Ox518[OxOf7d0[0x13]]=inp_item_value[OxOf7d0[0x13]] ; Ox518[OxOf7d0[0x16]][OxOf7d0[0x15]]=inp_item_forecolor[OxOf7d0[0x13]] ; Ox518[OxOf7d0[0x16]][OxOf7d0[0x17]]=inp_item_backcolor[OxOf7d0[0x13]] ;}  ; function SetOption2(Ox518){ Ox518[OxOf7d0[0x14]]=inp_item_value[OxOf7d0[0x13]] ; Ox518[OxOf7d0[0x13]]=inp_item_text[OxOf7d0[0x13]] ; Ox518[OxOf7d0[0x16]][OxOf7d0[0x15]]=inp_item_forecolor[OxOf7d0[0x13]] ; Ox518[OxOf7d0[0x16]][OxOf7d0[0x17]]=inp_item_backcolor[OxOf7d0[0x13]] ;}  ; function Select(Ox518){var Ox51b=Ox518[OxOf7d0[0x18]]; list_options[OxOf7d0[0x18]]=Ox51b ; list_options2[OxOf7d0[0x18]]=Ox51b ; inp_item_text[OxOf7d0[0x13]]=list_options2[OxOf7d0[0x13]] ; inp_item_value[OxOf7d0[0x13]]=list_options[OxOf7d0[0x13]] ;}  ; function Insert(){var Ox518= new Option(); SetOption(Ox518) ; list_options[OxOf7d0[0x19]].add(Ox518) ;var Ox51d= new Option(); SetOption2(Ox51d) ; list_options2[OxOf7d0[0x19]].add(Ox51d) ; FireUIChanged() ;}  ; function Update(){if(list_options[OxOf7d0[0x18]]==-0x1){ alert(OxOf7d0[0x1a]) ;return ;} ;var Ox518=list_options.options(list_options.selectedIndex); SetOption(Ox518) ;var Ox51d=list_options2.options(list_options2.selectedIndex); SetOption2(Ox51d) ; FireUIChanged() ;}  ; function Move(Ox134){var Ox51b=list_options[OxOf7d0[0x18]];if(Ox51b<0x0){return ;} ;var Ox51f=Ox51b-Ox134;if(Ox51f<0x0){ Ox51f=0x0 ;} ;if(Ox51f>(list_options[OxOf7d0[0x19]][OxOf7d0[0x1b]]-0x1)){ Ox51f=list_options[OxOf7d0[0x19]][OxOf7d0[0x1b]]-0x1 ;} ;if(Ox51b==Ox51f){return ;} ;var Ox518=list_options.options(list_options.selectedIndex);var Ox12=list_options2[OxOf7d0[0x13]];var Ox8=list_options[OxOf7d0[0x13]]; Delete() ; inp_item_text[OxOf7d0[0x13]]=Ox12 ; inp_item_value[OxOf7d0[0x13]]=Ox8 ;var Ox518= new Option(); SetOption(Ox518) ; list_options[OxOf7d0[0x19]].add(Ox518,Ox51f) ;var Ox51d= new Option(); SetOption2(Ox51d) ; list_options2[OxOf7d0[0x19]].add(Ox51d,Ox51f) ; list_options[OxOf7d0[0x18]]=Ox51f ; list_options2[OxOf7d0[0x18]]=Ox51f ; FireUIChanged() ;}  ; function Delete(){if(list_options[OxOf7d0[0x18]]==-0x1||list_options[OxOf7d0[0x18]]==-0x1){ alert(OxOf7d0[0x1a]) ;return ;} ;var Ox520=list_options[OxOf7d0[0x18]];var Ox518=list_options.options(list_options.selectedIndex); Ox518.removeNode(true) ; Ox518=list_options2.options(list_options2.selectedIndex) ; Ox518.removeNode(true) ;if(list_options[OxOf7d0[0x19]][OxOf7d0[0x1b]]>Ox520){ list_options[OxOf7d0[0x18]]=Ox520 ;} else {if(list_options[OxOf7d0[0x19]][OxOf7d0[0x1b]]){ list_options[OxOf7d0[0x18]]=list_options[OxOf7d0[0x19]][OxOf7d0[0x1b]]-0x1 ;} ;} ; list_options.ondblclick() ;if(list_options2[OxOf7d0[0x19]][OxOf7d0[0x1b]]>Ox520){ list_options2[OxOf7d0[0x18]]=Ox520 ;} else {if(list_options2[OxOf7d0[0x19]][OxOf7d0[0x1b]]){ list_options2[OxOf7d0[0x18]]=list_options2[OxOf7d0[0x19]][OxOf7d0[0x1b]]-0x1 ;} ;} ; FireUIChanged() ;}  ; list_options[OxOf7d0[0x1c]]=function list_options_ondblclick(){if(list_options[OxOf7d0[0x18]]==-0x1){return ;} ;var Ox518=list_options.options(list_options.selectedIndex); inp_item_text[OxOf7d0[0x13]]=Ox518[OxOf7d0[0x14]] ; inp_item_value[OxOf7d0[0x13]]=Ox518[OxOf7d0[0x13]] ; inp_item_forecolor[OxOf7d0[0x13]]=inp_item_forecolor[OxOf7d0[0x16]][OxOf7d0[0x17]]=inp_item_forecolor_Preview[OxOf7d0[0x16]][OxOf7d0[0x17]]=Ox518[OxOf7d0[0x16]][OxOf7d0[0x15]] ; inp_item_backcolor[OxOf7d0[0x13]]=inp_item_backcolor[OxOf7d0[0x16]][OxOf7d0[0x17]]=inp_item_backcolor_Preview[OxOf7d0[0x16]][OxOf7d0[0x17]]=Ox518[OxOf7d0[0x16]][OxOf7d0[0x17]] ;}  ; inp_item_forecolor[OxOf7d0[0x1d]]=inp_item_forecolor_Preview[OxOf7d0[0x1d]]=function inp_item_forecolor_onclick(){ SelectColor(inp_item_forecolor,inp_item_forecolor_Preview) ;}  ; inp_item_backcolor[OxOf7d0[0x1d]]=inp_item_backcolor_Preview[OxOf7d0[0x1d]]=function inp_item_backcolor_onclick(){ SelectColor(inp_item_backcolor,inp_item_backcolor_Preview) ;}  ; function CopySelect(Ox525,Ox526){ Ox526[OxOf7d0[0x19]][OxOf7d0[0x1b]]=0x0 ;for(var i=0x0;i<Ox525[OxOf7d0[0x19]][OxOf7d0[0x1b]];i++){var Ox527=Ox525[OxOf7d0[0x19]][i];var Ox51d;if(Browser_IsWinIE()){ Ox51d=Ox526[OxOf7d0[0x1f]].createElement(OxOf7d0[0x1e]) ;} else { Ox51d=document.createElement(OxOf7d0[0x1e]) ;} ;if(Ox526[OxOf7d0[0x20]]!=OxOf7d0[0xf]){ Ox51d[OxOf7d0[0x13]]=Ox527[OxOf7d0[0x13]] ; Ox51d[OxOf7d0[0x14]]=Ox527[OxOf7d0[0x14]] ;} else { Ox51d[OxOf7d0[0x13]]=Ox527[OxOf7d0[0x14]] ; Ox51d[OxOf7d0[0x14]]=Ox527[OxOf7d0[0x13]] ;} ; Ox51d[OxOf7d0[0x16]][OxOf7d0[0x21]]=Ox527[OxOf7d0[0x16]][OxOf7d0[0x21]] ; Ox526[OxOf7d0[0x19]].add(Ox51d) ;} ; Ox526[OxOf7d0[0x18]]=Ox525[OxOf7d0[0x18]] ;}  ; UpdateState=function UpdateState_Select(){}  ; SyncToView=function SyncToView_Select(){if(element[OxOf7d0[0x22]]){ inp_name[OxOf7d0[0x13]]=element[OxOf7d0[0x22]] ;} ;if(element[OxOf7d0[0x23]]){ inp_name[OxOf7d0[0x13]]=element[OxOf7d0[0x23]] ;} ; inp_id[OxOf7d0[0x13]]=element[OxOf7d0[0x20]] ; inp_size[OxOf7d0[0x13]]=element[OxOf7d0[0x24]] ; CopySelect(element,list_options) ; CopySelect(element,list_options2) ; inp_Disabled[OxOf7d0[0x26]]=element[OxOf7d0[0x25]] ; inp_Multiple[OxOf7d0[0x26]]=element[OxOf7d0[0x27]] ;if(element[OxOf7d0[0x28]]==0x0){ inp_index[OxOf7d0[0x13]]=OxOf7d0[0x29] ;} else { inp_index[OxOf7d0[0x13]]=element[OxOf7d0[0x28]] ;} ;if(element[OxOf7d0[0x2a]]){ inp_access[OxOf7d0[0x13]]=element[OxOf7d0[0x2a]] ;} ;}  ; SyncTo=function SyncTo_Select(element){ element[OxOf7d0[0x23]]=inp_name[OxOf7d0[0x13]] ;if(element[OxOf7d0[0x22]]){ element[OxOf7d0[0x22]]=inp_name[OxOf7d0[0x13]] ;} else {if(element[OxOf7d0[0x23]]){ element.removeAttribute(OxOf7d0[0x23],0x0) ; element[OxOf7d0[0x22]]=inp_name[OxOf7d0[0x13]] ;} else { element[OxOf7d0[0x22]]=inp_name[OxOf7d0[0x13]] ;} ;} ; element[OxOf7d0[0x20]]=inp_id[OxOf7d0[0x13]] ; element[OxOf7d0[0x24]]=inp_size[OxOf7d0[0x13]] ; element[OxOf7d0[0x25]]=inp_Disabled[OxOf7d0[0x26]] ; element[OxOf7d0[0x27]]=inp_Multiple[OxOf7d0[0x26]] ; element[OxOf7d0[0x2a]]=inp_access[OxOf7d0[0x13]] ; element[OxOf7d0[0x28]]=inp_index[OxOf7d0[0x13]] ;if(element[OxOf7d0[0x28]]==OxOf7d0[0x29]){ element.removeAttribute(OxOf7d0[0x28]) ;} ;if(element[OxOf7d0[0x2a]]==OxOf7d0[0x29]){ element.removeAttribute(OxOf7d0[0x2a]) ;} ; CopySelect(list_options,element) ;}  ;