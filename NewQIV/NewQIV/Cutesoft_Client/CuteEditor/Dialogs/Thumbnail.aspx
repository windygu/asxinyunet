<%@ Page Language="C#" Inherits="CuteEditor.Dialogs.ThumbnailPage" %>

<script runat="server">
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{
		if(Context.Request.QueryString["IsFrame"]==null)
		{
			string FrameSrc="Thumbnail.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
			CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[AutoThumbnail]]",FrameSrc);
			Context.Response.End();
		}
	}
		base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<title>[[AutoThumbnail]] </title>		
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css" rel="stylesheet" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
	</head>
	<body style="margin:0px;border-width:0px;padding:4px;">
		<form runat="server" id="Form1">
			<input type="hidden" runat="server" id="hiddenDirectory" name="hiddenDirectory" /> 
			<input type="hidden" runat="server" id="hiddenFile" name="hiddenFile" />
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAlert" name="hiddenAlert" /> 
			<input type="hidden" runat="server" enableviewstate="false" id="hiddenAction" name="hiddenAction" />
		<table border="0" cellpadding="4" cellspacing="0" width="100%">
			<tr>
				<td>
					<table border="0" cellpadding="1" cellspacing="4" class="normal">
					<tr>
						<td style="white-space:nowrap"  valign="top">
							<fieldset style="height:80px;">
								<table border="0" cellpadding="1" cellspacing="0" class="normal">
									<tr>
										<td style="white-space:nowrap; width:60" >[[Width]]:</td>
										<td>
											<input runat="server" id="inp_width" value="80" maxlength="3" onkeyup="checkConstrains('width');"  onkeypress="return CancelEventIfNotDigit()" style="WIDTH : 70px" name="inp_width" />
										</td>
										<td rowspan="2" align="right" valign="middle"><img src="Load.ashx?type=image&file=locked.gif" id="imgLock" width="25" height="32" title="[[ConstrainProportions]]" /></td>
									</tr>
									<tr>
										<td>[[Height]]:</td>
										<td>
											<input runat="server" id="inp_height" value="80" maxlength="3" onkeyup="checkConstrains('height');"  onkeypress="return CancelEventIfNotDigit()" style="WIDTH : 70px" name="inp_height" />
										</td>
									</tr>
									<tr>
										<td colspan="2">
											<input type="checkbox" id="constrain_prop" checked="checked" onclick="javascript:toggleConstrains();" />
											 [[ConstrainProportions]]
										</td>
									</tr>
								</table>
							</fieldset>		
						</td>
						<td valign="top" style="white-space:nowrap" >
							<div style="width:100px; height:80px; vertical-align:top;overflow:hidden;BACKGROUND-COLOR: #ffffff;BORDER-RIGHT: buttonhighlight 1px solid;BORDER-TOP: buttonshadow 1px solid;BORDER-LEFT: buttonshadow 1px solid;BORDER-BOTTOM: buttonhighlight 1px solid;">
								<img alt="" id="img_demo" src="Load.ashx?type=image&file=1x1.gif" />
							</div>
						</td>
					</tr>	
					<tr>
						<td>
							<div style="margin-top:8px;text-align:center">
								<asp:Button id="okButton" Text="  [[OK]]  " CssClass="formbutton" Runat="server" OnClick="thumbnailButton_Click" />
								&nbsp;&nbsp;
								<input type="button" value="[[Cancel]]" class="formbutton" onclick="top.returnValue=false;top.close()" />
							</div>
						</td>
					</tr>				
				</table>
			</td>
		</tr>
		</table>
	</form>			
	</body>
</html>
	
		<script type="text/javascript">
			var OxOc4e9=["src","img_demo","inp_width","inp_height","hiddenFile","hiddenAlert","hiddenDirectory","hiddenAction","onload","value","","width","height","[[ImagetooSmall]]","dir","imgLock","constrain_prop","checked","Load.ashx?type=image\x26file=locked.gif","Load.ashx?type=image\x26file=1x1.gif","preview_image","DIV","cssText","style","position:absolute","body","offsetWidth","offsetHeight","length"];var obj=Window_GetDialogArguments(window);var src=obj[OxOc4e9[0x0]];var img_demo=document.getElementById(OxOc4e9[0x1]);var inp_width=document.getElementById(OxOc4e9[0x2]);var inp_height=document.getElementById(OxOc4e9[0x3]);var hiddenFile=Window_GetElement(window,OxOc4e9[0x4],true);var hiddenAlert=Window_GetElement(window,OxOc4e9[0x5],true);var hiddenDirectory=Window_GetElement(window,OxOc4e9[0x6],true);var hiddenAction=Window_GetElement(window,OxOc4e9[0x7],true);var defaultwidth=<%= secset.ThumbnailWidth %>;var defaultheight=<%= secset.ThumbnailHeight %>; window[OxOc4e9[0x8]]=reset_hiddens ; function reset_hiddens(){if(hiddenAction[OxOc4e9[0x9]]!=OxOc4e9[0xa]){if(hiddenAlert[OxOc4e9[0x9]]){ alert(hiddenAlert.value) ;} ; Window_SetDialogReturnValue(window,hiddenAction.value) ; Window_CloseDialog(window) ;} else { hiddenAlert[OxOc4e9[0x9]]=OxOc4e9[0xa] ; hiddenAction[OxOc4e9[0x9]]=OxOc4e9[0xa] ;} ;}  ; SyncToView() ; function SyncToView(){if(src){var img= new Image(); img[OxOc4e9[0x0]]=src ; img_demo[OxOc4e9[0x0]]=src ;var p1=parseInt(img[OxOc4e9[0xb]]/defaultwidth);var Ox5b=parseInt(img[OxOc4e9[0xc]]/defaultheight);if(p1>Ox5b){if(img[OxOc4e9[0xb]]<defaultwidth){ alert(OxOc4e9[0xd]) ; inp_width[OxOc4e9[0x9]]=img[OxOc4e9[0xb]] ; inp_height[OxOc4e9[0x9]]=img[OxOc4e9[0xc]] ;} else { inp_width[OxOc4e9[0x9]]=defaultwidth ;var Ox5c=parseInt(defaultwidth*img[OxOc4e9[0xc]]/img.width); inp_height[OxOc4e9[0x9]]=Ox5c ;} ;} else {if(img[OxOc4e9[0xc]]<defaultheight){ alert(OxOc4e9[0xd]) ; inp_width[OxOc4e9[0x9]]=img[OxOc4e9[0xb]] ; inp_height[OxOc4e9[0x9]]=img[OxOc4e9[0xc]] ;} else { inp_height[OxOc4e9[0x9]]=defaultheight ;var Ox5d=parseInt(defaultwidth*img[OxOc4e9[0xb]]/img.height); inp_width[OxOc4e9[0x9]]=Ox5d ;} ;} ; hiddenFile[OxOc4e9[0x9]]=src ; hiddenDirectory[OxOc4e9[0x9]]=obj[OxOc4e9[0xe]] ; do_preview() ;} ;}  ; function toggleConstrains(){var Ox5f=document.getElementById(OxOc4e9[0xf]);var Ox60=document.getElementById(OxOc4e9[0x10]);if(Ox60[OxOc4e9[0x11]]){ Ox5f[OxOc4e9[0x0]]=OxOc4e9[0x12] ; checkConstrains(OxOc4e9[0xb]) ;} else { Ox5f[OxOc4e9[0x0]]=OxOc4e9[0x13] ;} ;}  ;var checkingConstrains=false; function checkConstrains(Ox63){if(checkingConstrains){return ;} ; checkingConstrains=true ;try{var Ox60=document.getElementById(OxOc4e9[0x10]);if(Ox60[OxOc4e9[0x11]]){var Ox64=document.getElementById(OxOc4e9[0x14]);if(Ox64){var Ox65=document.createElement(OxOc4e9[0x15]); Ox65[OxOc4e9[0x17]][OxOc4e9[0x16]]=OxOc4e9[0x18] ; document[OxOc4e9[0x19]].appendChild(Ox65) ; Ox65.appendChild(Ox64) ; Ox64.removeAttribute(OxOc4e9[0xb]) ; Ox64.removeAttribute(OxOc4e9[0xc]) ; Ox64[OxOc4e9[0x17]][OxOc4e9[0xb]]=OxOc4e9[0xa] ; Ox64[OxOc4e9[0x17]][OxOc4e9[0xc]]=OxOc4e9[0xa] ; original_width=Ox64[OxOc4e9[0x1a]] ; original_height=Ox64[OxOc4e9[0x1b]] ; Ox65.removeNode(true) ;} else {var Ox66= new Image(); Ox66[OxOc4e9[0x0]]=src ; original_width=Ox66[OxOc4e9[0xb]] ; original_height=Ox66[OxOc4e9[0xc]] ;} ;if((original_width>0x0)&&(original_height>0x0)){ width=inp_width[OxOc4e9[0x9]] ; height=inp_height[OxOc4e9[0x9]] ;if(Ox63==OxOc4e9[0xb]){if(width[OxOc4e9[0x1c]]==0x0||isNaN(width)){ inp_width[OxOc4e9[0x9]]=OxOc4e9[0xa] ; inp_height[OxOc4e9[0x9]]=OxOc4e9[0xa] ;} else { height=parseInt(width*original_height/original_width) ; inp_height[OxOc4e9[0x9]]=height ;} ;} ;if(Ox63==OxOc4e9[0xc]){if(height[OxOc4e9[0x1c]]==0x0||isNaN(height)){ inp_width[OxOc4e9[0x9]]=OxOc4e9[0xa] ; inp_height[OxOc4e9[0x9]]=OxOc4e9[0xa] ;} else { width=parseInt(height*original_width/original_height) ; inp_width[OxOc4e9[0x9]]=width ;} ;} ;} ;} ; do_preview() ;} finally{ checkingConstrains=false ;} ;}  ; function do_preview(){ img_demo[OxOc4e9[0xb]]=inp_width[OxOc4e9[0x9]] ; img_demo[OxOc4e9[0xc]]=inp_height[OxOc4e9[0x9]] ;}  ;	
			
		</script>

