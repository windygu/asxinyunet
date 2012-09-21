<%@ Page Language="C#" Inherits="CuteEditor.EditorUtilityPage" %>
<script runat="server">
string GetDialogQueryString;
override protected void OnInit(EventArgs args)
{
	if(Context.Request.QueryString["Dialog"]=="Standard")
	{	
	if(Context.Request.QueryString["IsFrame"]==null)
	{
		string FrameSrc="colorpicker_basic.aspx?IsFrame=1&"+Request.ServerVariables["QUERY_STRING"];
		CuteEditor.CEU.WriteDialogOuterFrame(Context,"[[MoreColors]]",FrameSrc);
		Context.Response.End();
	}
	}
	string s="";
	if(Context.Request.QueryString["Dialog"]=="Standard")	
		s="&Dialog=Standard";
	
	GetDialogQueryString="Theme="+Context.Request.QueryString["Theme"]+s;	
	base.OnInit(args);
}
</script>
<html xmlns="http://www.w3.org/1999/xhtml">
	<head runat="server">
		<meta http-equiv="Page-Enter" content="blendTrans(Duration=0.1)" />
		<meta http-equiv="Page-Exit" content="blendTrans(Duration=0.1)" />
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=DialogHead.js"></script>
		<script type="text/javascript" src="Load.ashx?type=dialogscript&file=Dialog_ColorPicker.js"></script>
		<link href='Load.ashx?type=themecss&file=dialog.css&theme=[[_Theme_]]' type="text/css"
			rel="stylesheet" />
		<style type="text/css">
			.colorcell
			{
				width:16px;
				height:17px;
				cursor:hand;
			}
			.colordiv,.customdiv
			{
				border:solid 1px #808080;
				width:16px;
				height:17px;
				font-size:1px;
			}
		</style>
		<title>[[NamedColors]]</title>
		<script>
								
		var OxO3762=["Green","#008000","Lime","#00FF00","Teal","#008080","Aqua","#00FFFF","Navy","#000080","Blue","#0000FF","Purple","#800080","Fuchsia","#FF00FF","Maroon","#800000","Red ","#FF0000","Olive","#808000","Yellow","#FFFF00","White","#FFFFFF","Silver","#C0C0C0","Gray","#808080","Black","#000000","DarkOliveGreen","#556B2F","DarkGreen","#006400","DarkSlateGray","#2F4F4F","SlateGray","#708090","DarkBlue","#00008B","MidnightBlue","#191970","Indigo","#4B0082","DarkMagenta","#8B008B","Brown","#A52A2A","DarkRed","#8B0000","Sienna","#A0522D","SaddleBrown","#8B4513","DarkGoldenrod","#B8860B","Beige","#F5F5DC","HoneyDew","#F0FFF0","DimGray","#696969","OliveDrab","#6B8E23","ForestGreen","#228B22","DarkCyan","#008B8B","LightSlateGray","#778899","MediumBlue","#0000CD","DarkSlateBlue","#483D8B","DarkViolet","#9400D3","MediumVioletRed","#C71585","IndianRed","#CD5C5C","Firebrick","#B22222","Chocolate","#D2691E","Peru","#CD853F","Goldenrod","#DAA520","LightGoldenrodYellow","#FAFAD2","MintCream","#F5FFFA","DarkGray","#A9A9A9","YellowGreen","#9ACD32","SeaGreen","#2E8B57","CadetBlue","#5F9EA0","SteelBlue","#4682B4","RoyalBlue","#4169E1","BlueViolet","#8A2BE2","DarkOrchid","#9932CC","DeepPink","#FF1493","RosyBrown","#BC8F8F","Crimson","#DC143C","DarkOrange","#FF8C00","BurlyWood","#DEB887","DarkKhaki","#BDB76B","LightYellow","#FFFFE0","Azure","#F0FFFF","LightGray","#D3D3D3","LawnGreen","#7CFC00","MediumSeaGreen","#3CB371","LightSeaGreen","#20B2AA","DeepSkyBlue","#00BFFF","DodgerBlue","#1E90FF","SlateBlue","#6A5ACD","MediumOrchid","#BA55D3","PaleVioletRed","#DB7093","Salmon","#FA8072","OrangeRed","#FF4500","SandyBrown","#F4A460","Tan","#D2B48C","Gold","#FFD700","Ivory","#FFFFF0","GhostWhite","#F8F8FF","Gainsboro","#DCDCDC","Chartreuse","#7FFF00","LimeGreen","#32CD32","MediumAquamarine","#66CDAA","DarkTurquoise","#00CED1","CornflowerBlue","#6495ED","MediumSlateBlue","#7B68EE","Orchid","#DA70D6","HotPink","#FF69B4","LightCoral","#F08080","Tomato","#FF6347","Orange","#FFA500","Bisque","#FFE4C4","Khaki","#F0E68C","Cornsilk","#FFF8DC","Linen","#FAF0E6","WhiteSmoke","#F5F5F5","GreenYellow","#ADFF2F","DarkSeaGreen","#8FBC8B","Turquoise","#40E0D0","MediumTurquoise","#48D1CC","SkyBlue","#87CEEB","MediumPurple","#9370DB","Violet","#EE82EE","LightPink","#FFB6C1","DarkSalmon","#E9967A","Coral","#FF7F50","NavajoWhite","#FFDEAD","BlanchedAlmond","#FFEBCD","PaleGoldenrod","#EEE8AA","Oldlace","#FDF5E6","Seashell","#FFF5EE","PaleGreen","#98FB98","SpringGreen","#00FF7F","Aquamarine","#7FFFD4","PowderBlue","#B0E0E6","LightSkyBlue","#87CEFA","LightSteelBlue","#B0C4DE","Plum","#DDA0DD","Pink","#FFC0CB","LightSalmon","#FFA07A","Wheat","#F5DEB3","Moccasin","#FFE4B5","AntiqueWhite","#FAEBD7","LemonChiffon","#FFFACD","FloralWhite","#FFFAF0","Snow","#FFFAFA","AliceBlue","#F0F8FF","LightGreen","#90EE90","MediumSpringGreen","#00FA9A","PaleTurquoise","#AFEEEE","LightCyan","#E0FFFF","LightBlue","#ADD8E6","Lavender","#E6E6FA","Thistle","#D8BFD8","MistyRose","#FFE4E1","Peachpuff","#FFDAB9","PapayaWhip","#FFEFD5"];var colorlist=[{n:OxO3762[0x0],h:OxO3762[0x1]},{n:OxO3762[0x2],h:OxO3762[0x3]},{n:OxO3762[0x4],h:OxO3762[0x5]},{n:OxO3762[0x6],h:OxO3762[0x7]},{n:OxO3762[0x8],h:OxO3762[0x9]},{n:OxO3762[0xa],h:OxO3762[0xb]},{n:OxO3762[0xc],h:OxO3762[0xd]},{n:OxO3762[0xe],h:OxO3762[0xf]},{n:OxO3762[0x10],h:OxO3762[0x11]},{n:OxO3762[0x12],h:OxO3762[0x13]},{n:OxO3762[0x14],h:OxO3762[0x15]},{n:OxO3762[0x16],h:OxO3762[0x17]},{n:OxO3762[0x18],h:OxO3762[0x19]},{n:OxO3762[0x1a],h:OxO3762[0x1b]},{n:OxO3762[0x1c],h:OxO3762[0x1d]},{n:OxO3762[0x1e],h:OxO3762[0x1f]}];var colormore=[{n:OxO3762[0x20],h:OxO3762[0x21]},{n:OxO3762[0x22],h:OxO3762[0x23]},{n:OxO3762[0x24],h:OxO3762[0x25]},{n:OxO3762[0x26],h:OxO3762[0x27]},{n:OxO3762[0x28],h:OxO3762[0x29]},{n:OxO3762[0x2a],h:OxO3762[0x2b]},{n:OxO3762[0x2c],h:OxO3762[0x2d]},{n:OxO3762[0x2e],h:OxO3762[0x2f]},{n:OxO3762[0x30],h:OxO3762[0x31]},{n:OxO3762[0x32],h:OxO3762[0x33]},{n:OxO3762[0x34],h:OxO3762[0x35]},{n:OxO3762[0x36],h:OxO3762[0x37]},{n:OxO3762[0x38],h:OxO3762[0x39]},{n:OxO3762[0x3a],h:OxO3762[0x3b]},{n:OxO3762[0x3c],h:OxO3762[0x3d]},{n:OxO3762[0x3e],h:OxO3762[0x3f]},{n:OxO3762[0x40],h:OxO3762[0x41]},{n:OxO3762[0x42],h:OxO3762[0x43]},{n:OxO3762[0x44],h:OxO3762[0x45]},{n:OxO3762[0x46],h:OxO3762[0x47]},{n:OxO3762[0x48],h:OxO3762[0x49]},{n:OxO3762[0x4a],h:OxO3762[0x4b]},{n:OxO3762[0x4c],h:OxO3762[0x4d]},{n:OxO3762[0x4e],h:OxO3762[0x4f]},{n:OxO3762[0x50],h:OxO3762[0x51]},{n:OxO3762[0x52],h:OxO3762[0x53]},{n:OxO3762[0x54],h:OxO3762[0x55]},{n:OxO3762[0x56],h:OxO3762[0x57]},{n:OxO3762[0x58],h:OxO3762[0x59]},{n:OxO3762[0x5a],h:OxO3762[0x5b]},{n:OxO3762[0x5c],h:OxO3762[0x5d]},{n:OxO3762[0x5e],h:OxO3762[0x5f]},{n:OxO3762[0x60],h:OxO3762[0x61]},{n:OxO3762[0x62],h:OxO3762[0x63]},{n:OxO3762[0x64],h:OxO3762[0x65]},{n:OxO3762[0x66],h:OxO3762[0x67]},{n:OxO3762[0x68],h:OxO3762[0x69]},{n:OxO3762[0x6a],h:OxO3762[0x6b]},{n:OxO3762[0x6c],h:OxO3762[0x6d]},{n:OxO3762[0x6e],h:OxO3762[0x6f]},{n:OxO3762[0x70],h:OxO3762[0x71]},{n:OxO3762[0x72],h:OxO3762[0x73]},{n:OxO3762[0x74],h:OxO3762[0x75]},{n:OxO3762[0x76],h:OxO3762[0x77]},{n:OxO3762[0x78],h:OxO3762[0x79]},{n:OxO3762[0x7a],h:OxO3762[0x7b]},{n:OxO3762[0x7c],h:OxO3762[0x7d]},{n:OxO3762[0x7e],h:OxO3762[0x7f]},{n:OxO3762[0x80],h:OxO3762[0x81]},{n:OxO3762[0x82],h:OxO3762[0x83]},{n:OxO3762[0x84],h:OxO3762[0x85]},{n:OxO3762[0x86],h:OxO3762[0x87]},{n:OxO3762[0x88],h:OxO3762[0x89]},{n:OxO3762[0x8a],h:OxO3762[0x8b]},{n:OxO3762[0x8c],h:OxO3762[0x8d]},{n:OxO3762[0x8e],h:OxO3762[0x8f]},{n:OxO3762[0x90],h:OxO3762[0x91]},{n:OxO3762[0x92],h:OxO3762[0x93]},{n:OxO3762[0x94],h:OxO3762[0x95]},{n:OxO3762[0x96],h:OxO3762[0x97]},{n:OxO3762[0x98],h:OxO3762[0x99]},{n:OxO3762[0x9a],h:OxO3762[0x9b]},{n:OxO3762[0x9c],h:OxO3762[0x9d]},{n:OxO3762[0x9e],h:OxO3762[0x9f]},{n:OxO3762[0xa0],h:OxO3762[0xa1]},{n:OxO3762[0xa2],h:OxO3762[0xa3]},{n:OxO3762[0xa4],h:OxO3762[0xa5]},{n:OxO3762[0xa6],h:OxO3762[0xa7]},{n:OxO3762[0xa8],h:OxO3762[0xa9]},{n:OxO3762[0xaa],h:OxO3762[0xab]},{n:OxO3762[0xac],h:OxO3762[0xad]},{n:OxO3762[0xae],h:OxO3762[0xaf]},{n:OxO3762[0xb0],h:OxO3762[0xb1]},{n:OxO3762[0xb2],h:OxO3762[0xb3]},{n:OxO3762[0xb4],h:OxO3762[0xb5]},{n:OxO3762[0xb6],h:OxO3762[0xb7]},{n:OxO3762[0xb8],h:OxO3762[0xb9]},{n:OxO3762[0xba],h:OxO3762[0xbb]},{n:OxO3762[0xbc],h:OxO3762[0xbd]},{n:OxO3762[0xbe],h:OxO3762[0xbf]},{n:OxO3762[0xc0],h:OxO3762[0xc1]},{n:OxO3762[0xc2],h:OxO3762[0xc3]},{n:OxO3762[0xc4],h:OxO3762[0xc5]},{n:OxO3762[0xc6],h:OxO3762[0xc7]},{n:OxO3762[0xc8],h:OxO3762[0xc9]},{n:OxO3762[0xca],h:OxO3762[0xcb]},{n:OxO3762[0xcc],h:OxO3762[0xcd]},{n:OxO3762[0xce],h:OxO3762[0xcf]},{n:OxO3762[0xd0],h:OxO3762[0xd1]},{n:OxO3762[0xd2],h:OxO3762[0xd3]},{n:OxO3762[0xd4],h:OxO3762[0xd5]},{n:OxO3762[0xd6],h:OxO3762[0xd7]},{n:OxO3762[0xd8],h:OxO3762[0xd9]},{n:OxO3762[0xda],h:OxO3762[0xdb]},{n:OxO3762[0xdc],h:OxO3762[0xdd]},{n:OxO3762[0x9c],h:OxO3762[0x9d]},{n:OxO3762[0xde],h:OxO3762[0xdf]},{n:OxO3762[0xe0],h:OxO3762[0xe1]},{n:OxO3762[0xe2],h:OxO3762[0xe3]},{n:OxO3762[0xe4],h:OxO3762[0xe5]},{n:OxO3762[0xe6],h:OxO3762[0xe7]},{n:OxO3762[0xe8],h:OxO3762[0xe9]},{n:OxO3762[0xea],h:OxO3762[0xeb]},{n:OxO3762[0xec],h:OxO3762[0xed]},{n:OxO3762[0xee],h:OxO3762[0xef]},{n:OxO3762[0xf0],h:OxO3762[0xf1]},{n:OxO3762[0xf2],h:OxO3762[0xf3]},{n:OxO3762[0xf4],h:OxO3762[0xf5]},{n:OxO3762[0xf6],h:OxO3762[0xf7]},{n:OxO3762[0xf8],h:OxO3762[0xf9]},{n:OxO3762[0xfa],h:OxO3762[0xfb]},{n:OxO3762[0xfc],h:OxO3762[0xfd]},{n:OxO3762[0xfe],h:OxO3762[0xff]},{n:OxO3762[0x100],h:OxO3762[0x101]},{n:OxO3762[0x102],h:OxO3762[0x103]},{n:OxO3762[0x104],h:OxO3762[0x105]},{n:OxO3762[0x106],h:OxO3762[0x107]},{n:OxO3762[0x108],h:OxO3762[0x109]},{n:OxO3762[0x10a],h:OxO3762[0x10b]},{n:OxO3762[0x10c],h:OxO3762[0x10d]},{n:OxO3762[0x10e],h:OxO3762[0x10f]},{n:OxO3762[0x110],h:OxO3762[0x111]}];
		
		</script>
	</head>
	<body>
		<div id="container">
			<div class="tab-pane-control tab-pane" id="tabPane1">
				<div class="tab-row">
					<h2 class="tab">
						<a tabindex="-1" href='colorpicker.aspx?<%=GetDialogQueryString%>'>
							<span style="white-space:nowrap;">
								[[WebPalette]]
							</span>
						</a>
					</h2>
					<h2 class="tab selected">
							<a tabindex="-1" href='colorpicker_basic.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[NamedColors]]
								</span>
							</a>
					</h2>
					<h2 class="tab">
							<a tabindex="-1" href='colorpicker_more.aspx?<%=GetDialogQueryString%>'>
								<span style="white-space:nowrap;">
									[[CustomColor]]
								</span>
							</a>
					</h2>
				</div>
				<div class="tab-page">			
					<table class="colortable" align="center">
						<tr>
							<td colspan="16" height="16"><p align="left">Basic:
								</p>
							</td>
						</tr>
						<tr>
							<script>
								var OxO38c1=["length","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E",""];var arr=[];for(var i=0x0;i<colorlist[OxO38c1[0x0]];i++){ arr.push(OxO38c1[0x1]) ; arr.push(colorlist[i].n) ; arr.push(OxO38c1[0x2]) ; arr.push(colorlist[i].n) ; arr.push(OxO38c1[0x3]) ; arr.push(colorlist[i].h) ; arr.push(OxO38c1[0x4]) ; arr.push(colorlist[i].n) ; arr.push(OxO38c1[0x5]) ; arr.push(colorlist[i].h) ; arr.push(OxO38c1[0x6]) ;} ; document.write(arr.join(OxO38c1[0x7])) ;
							</script>
						</tr>
						<tr>
							<td colspan="16" height="12"><p align="left"></p>
							</td>
						</tr>
						<tr>
							<td colspan="16"><p align="left">Additional:
								</p>
							</td>
						</tr>
						<script>
							var OxO8131=["length","\x3Ctr\x3E","\x3Ctd class=\x27colorcell\x27\x3E\x3Cdiv class=\x27colordiv\x27 style=\x27background-color:","\x27 title=\x27"," ","\x27 cname=\x27","\x27 cvalue=\x27","\x27\x3E\x3C/div\x3E\x3C/td\x3E","\x3C/tr\x3E",""];var arr=[];for(var i=0x0;i<colormore[OxO8131[0x0]];i++){if(i%0x10==0x0){ arr.push(OxO8131[0x1]) ;} ; arr.push(OxO8131[0x2]) ; arr.push(colormore[i].n) ; arr.push(OxO8131[0x3]) ; arr.push(colormore[i].n) ; arr.push(OxO8131[0x4]) ; arr.push(colormore[i].h) ; arr.push(OxO8131[0x5]) ; arr.push(colormore[i].n) ; arr.push(OxO8131[0x6]) ; arr.push(colormore[i].h) ; arr.push(OxO8131[0x7]) ;if(i%0x10==0xf){ arr.push(OxO8131[0x8]) ;} ;} ;if(colormore%0x10>0x0){ arr.push(OxO8131[0x8]) ;} ; document.write(arr.join(OxO8131[0x9])) ;
						</script>
						<tr>
							<td colspan="16" height="8">
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
								<input checked id="CheckboxColorNames" style="width: 16px; height: 20px" type="checkbox">
								<span style="width: 118px;">Use color names</span>
							</td>
						</tr>
						<tr>
							<td colspan="16" height="12">
							</td>
						</tr>
						<tr>
							<td colspan="16" valign="middle" height="24">
							<span style="height:24px;width:50px;vertical-align:middle;">Color : </span>&nbsp;
							<input type="text" id="divpreview" size="7" maxlength="7" style="width:180px;height:24px;border:#a0a0a0 1px solid; Padding:4;"/>
					
							</td>
						</tr>
				</table>
			</div>
		</div>
		<div id="container-bottom">
			<input type="button" id="buttonok" value="[[OK]]" class="formbutton" style="width:70px"	onclick="do_insert();" /> 
			&nbsp;&nbsp;&nbsp;&nbsp; 
			<input type="button" id="buttoncancel" value="[[Cancel]]" class="formbutton" style="width:70px"	onclick="do_Close();" />	
		</div>
	</div>
	</body>
</html>

