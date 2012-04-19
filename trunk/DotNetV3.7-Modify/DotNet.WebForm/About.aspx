<%@ Page Language="C#" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>
<%@ Import Namespace="DotNet.Utilities" %>

<!-- Put IE into quirks mode -->
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" />
<title><%= BaseSystemInfo.SoftFullName%> - 关于我们</title>
<meta name="DESCRIPTION" content="电子商务平台 - 安全、快捷、稳定、易用、免费、专业的网络硬盘">
<meta name="KEYWORDS" content="网盘, 网络硬盘，网络u盘,免费网盘,免费网络硬盘,免费网络u盘,免费网盘申请,免费网络硬盘申请,免费网络u盘申请">
<link href="Themes/Default/layout.css" type="text/css" rel="stylesheet" />
<script type="text/javascript">
<!--

function setTab(name,cursel,n){
 for(i=1;i<=n;i++){
  var menu=document.getElementById(name+i);  
  var con=document.getElementById("con_"+name+"_"+i);
  menu.className=i==cursel?"check":"";
  if(cursel==1 && i==cursel){
	  document.getElementById('none').style.display="none";
  }else if(cursel==2 && i==cursel){
	  document.getElementById('none').style.display="block";
	  menu.className = 'checks';
  }
  con.style.display=i==cursel?"block":"none";
 }
}
//-->d
</script>
</head>

<body class="wrap">
<div class="helpheader">
  <div class="helplogo" onClick="window.open('logOn.aspx',target='_top');"><a name="a" id="a"></a></div>
</div>
<div class="helpmain">
  <ul class="helpmenu">
  
    <li id="one1" onClick="setTab('one',1,2)" class="check">关于我们</li>
    <li id="one2" onClick="setTab('one',2,2)" >常见问题
      <ul id="none" class="none">
        <li><a href="#ab">账户注册与管理</a></li>
        <li><a href="#ac">关于上传与下载</a></li>
        <li><a href="#ad">关于文件快递</a></li>
        <li><a href="#ae">关于共享与联系人</a></li>
        <li><a href="#af">关于积分</a></li>
        <li><a href="#ag">其它</a></li>
      </ul>
    </li>
  </ul>
  <div class="helpmaincenter">
    <div class="helpabout " id="con_one_1">
      <div class="ad"></div>
      <h2>关于电子商务平台</h2>
      <p class="pre">电子商务平台是面向所有注册用户，提供多种文件类型的存储、传递、共享的网络服务，“安全”、“快捷”、“稳定”、“易用”是电子商务平台的服务宗旨。</p>
      <p><span class="icon"></span>3G的免费存储空间，可存储大容量文件，并随时随地访问您的文件</p>
      <p><span class="icons"></span>与亲朋好友分享自己的照片、资料等</p>
    </div>
    
    <div class="helpcontent none" id="con_one_2">
      <ul class="helpnav">
        <li>
          <h2>账户注册与管理</h2>
          <ul>
            <li><em class="square"></em><a href="#b">什么是网络硬盘？</a></li>
            <li><em class="square"></em><a href="#b1">注册邮箱可以修改吗？</a></li>
            <li><em class="square"></em><a href="#b2">登录密码忘记了怎么办？</a></li>
            <li><em class="square"></em><a href="#b3">为什么要填写准确的邮箱地址？</a></li>
            <li><em class="square"></em><a href="#b4">如何邀请好友注册？</a></li>
          </ul>
        </li>
        <li>
          <h2>关于上传与下载</h2>
          <ul>
            <li><em class="square"></em><a href="#c">上传的文件有什么限制？</a></li>
            <li><em class="square"></em><a href="#c1">文件为何下载失败？</a></li>
          </ul>
        </li>
        <li>
          <h2>关于文件快递</h2>
          <ul>
            <li><em class="square"></em><a href="#d">什么是文件快递？</a></li>
            <li><em class="square"></em><a href="#d1">通过文件快递如何发送文件？</a></li>
            <li><em class="square"></em><a href="#d2">文件快递当中的容量达到上限怎么办？</a></li>
          </ul>
        </li>
        <li>
          <h2>关于共享与联系人</h2>
          <ul>
            <li><em class="square"></em><a href="#e">如何添加联系人？</a></li>
            <li><em class="square"></em><a href="#e1">如何导入联系人？</a></li>
            <li><em class="square"></em><a href="#e2">如何共享文件给我的好友？</a></li>
            <li><em class="square"></em><a href="#e3">如何设置共享中的上传权限？</a></li>
          </ul>
        </li>
        <li>
          <h2>关于积分</h2>
          <ul>
            <li><em class="square"></em><a href="#f">什么是积分？</a></li>
            <li><em class="square"></em><a href="#f1">积分有什么用处？</a></li>
            <li><em class="square"></em><a href="#f2">积分获取与扣除规则？</a></li>
          </ul>
        </li>
        <li>
          <h2>其它</h2>
          <ul>
            <li><em class="square"></em><a href="#f1">电子商务平台使用小技巧？</a></li>
          </ul>
        </li>
      </ul>
      <div class="helpblock"><a name="ab" id="ab"></a>
        <h1><a name="b" id="b"></a>什么是网络硬盘？<a href="#a">返回顶部&uarr;</a></h1>
        <p>网络硬盘是应用于网络中的一种存储服务，可用于重要资料的备份和存储。电子商务平台为您提供3G的大容量网络存储服务。</p>
      </div>
      
      <div class="helpblock">
        <h1><a name="b1" id="b1"></a>注册邮箱可以修改吗？<a href="#a">返回顶部&uarr;</a></h1>
        <p>注册邮箱不可更改，若您想更改您的邮箱名称，请重新注册一个账户。</p>
      </div>
      
      
        <div class="helpblock">
        <h1><a name="b2" id="b2"></a>登录密码忘记了怎么办？<a href="#a">返回顶部&uarr;</a></h1>
        <p class="nomargin">登录密码忘记后可以进行重置密码，重新设置新的登录密码。步骤如下：</p>
        <ul>
        	<li>1、进入登陆页面，点击“忘记密码了”；</li>
            <li>2、在跳转的页面输入注册时的电子邮箱，点击“重置密码”；</li>
            <li>3、登陆邮箱，根据邮箱中的提示信息进行操作；</li>
            <li>4、重新输入您的新密码并进行确认，完成密码重置。</li>
        </ul>
      </div>
      
        <div class="helpblock">
        <h1><a name="b3" id="b3"></a>为什么要填写准确的邮箱地址？<a href="#a">返回顶部&uarr;</a></h1>
        <p>用来登录账户，当您因忘记密码需要重置时，系统将发送验证邮件给您重置密码。同时，为了保证您的信息安全，也请您填写准确的邮箱地址。</p>
      </div>
      
      <div class="helpblock">
        <h1><a name="b4" id="b4"></a>如何邀请好友注册电子商务平台？<a href="#a">返回顶部&uarr;</a></h1>
        <p>登录电子商务平台后在页面的右上方，点击“<a href="http://www.Jirisoft.com" target="_blank">邀请</a>”链接，您可以复制邀请链接发给您QQ/MSN上的好友，好友通过您的邀请链接进行注册，每邀请一个好友成功注册，电子商务平台都会有积分奖励给您。</p>
        <p class="nomargin">同时您还可以选择批量邀请QQ上的好友，常用邮箱的通讯录联系人，批量的邮箱联系人及联系人的方式邀请他们。</p>
        <ul>
        	<li><strong>1、邀请QQ好友加入</strong>可批量输入您所需要邀请的好友的QQ号码，发送邀请链接</li>
            <li><strong>2、邀请邮箱通讯录中的联系人加入</strong>可以批量邀请您的邮箱通讯录中的联系人加入，目前电子商务平台支持Sohu、Sina、163、126、Tom、Yahoo等常用邮箱，进行此方式的邀请时，需要您暂时输入您的邮箱密码，<span class="reds">但此密码仅用于您邀请邮箱中的联系人，电子商务平台不会存储您的密码，请您放心使用。</span></li>
        	<li><strong>3、向指定邮箱发送邀请</strong>您可以填写一个或多个邮箱地址至邀请名单向指定的邮箱发送邀请链接。</li>
        	<li><strong>4、邀请联系人加入</strong>若您的联系人中有未注册的电子商务平台的，则可通过此功能发送邀请链接到相应的联系人。</li>
        </ul>
        <p class="reds">注：一个用户每次最多邀请10人，每天最多邀请100人</p>
      </div>
      
      <div class="helpblock"><a name="ac" id="ac"></a>
        <h1><a name="c" id="c"></a>上传的文件有什么限制？<a href="#a">返回顶部&uarr;</a></h1>
        <p class="nomargins">关于上传文件大小：上传单个文件不超过100M。<br />
关于上传文件的格式：电子商务平台支持上传各种格式的文件(如：jpg;gif;doc;ppt;xls等)；<br />
关于上传的文件数量：电子商务平台没有上传文件数量限制。
</p>
      </div>
      
      <div class="helpblock">
        <h1><a name="c1" id="c1"></a>文件为何下载失败？<a href="#a">返回顶部&uarr;</a></h1>
        <p class="nomargin">文件下载失败有以下原因：</p>
         <ul>
        	<li>1、网络中断；</li>
            <li>2、发送者提前删除该文件；</li>
            <li class="reds">若由于原因1导致下载失败，可重新尝试下载</li>
            <li class="reds">若由于原因2导致下载失败，可请求发送者重新发送该文件。</li>
        </ul>
      </div>
      
      <div class="helpblock"><a name="ad" id="ad"></a>
        <h1><a name="d" id="d"></a>什么是文件快递？<a href="#a">返回顶部&uarr;</a></h1>
        <p>电子商务平台的文件快递是为您提供大文件的快递服务，解决传统邮件附件大小受限的问题。通过文件快递，我们可以将存储电子商务平台网络硬盘中的超大文件或本地电脑中的超大文件发送给好友。</p>
      </div>
      
      <div class="helpblock">
        <h1><a name="d1" id="d1"></a>通过文件快递如何发送文件？<a href="#a">返回顶部&uarr;</a></h1>
        <p class="nomargin">发送本地电脑中的大文件给好友：</p>
        <ul>
        	<li>1、登录电子商务平台，在左侧菜单中点击“文件快递”</li>
            <li>2、点击文件快递页面左上方“发送文件”</li>
            <li>3、填写收件人邮箱（如果您之前在联系人中已添加过此收件人，则点击相应的联系人即可将邮箱添加到收件人一栏中）及相关信息。</li>
            <li>4、选择本地电脑中的附件并添加，点击“发送”按钮即可。</li>
        </ul><br />
         <p class="nomargin">发送网盘中的大文件：</p>
        <ul>
        	<li>1、在电子商务平台网络硬盘中选择您需要发送的文件，并点击“发送”按钮；</li>
            <li>2、在跳转到的文件快递页面，输入收件人邮箱及相关信息；</li>
            <li>3、点击“发送”按钮即可。</li>
        </ul>
      </div>
      
      <div class="helpblock">
        <h1><a name="d2" id="d2"></a>文件快递当中的容量达到上限怎么办？<a href="#a">返回顶部&uarr;</a></h1>
        <p>电子商务平台的文件快递为您提供1G的免费容量（包括“收件箱”中文件及“已发送”中文件总共的容量），如果文件快递中的容量已达到上限，则您可以将文件转存（“收件箱”中文件）或移动（“已发送”栏中的文件）到电子商务平台网络硬盘当中，届时可以继续发送文件。</p>
      </div>
      
      <div class="helpblock"><a name="ae" id="ae"></a>
        <h1><a name="e" id="e"></a>如何添加联系人？<a href="#a">返回顶部&uarr;</a></h1>
        <ul>
        	<li>1、点击右边区域“添加联系人”按钮，在跳转的对话框中填写所需添加的联系人昵称、邮箱、手机号码，并可选择联系人分组</li>
            <li>2、填写完后点击“确定”即可添加成功</li>
        </ul>
      </div>
      
      <div class="helpblock">
        <h1><a name="e1" id="e1"></a>如何导入联系人？<a href="#a">返回顶部&uarr;</a></h1>
        <p class="nomargins">在联系人工具箱一栏，有导入邮箱联系人一项，您可以输入您的邮箱用户名和密码批量导入您的邮箱联系人。<br />
另有导入联系人一项，您可以将联系人邮箱制作成CSV文件后再导入电子商务平台。<br /><span class="reds">
注：*号为必填项，进行批量导入邮箱联系人时所输入的邮箱密码不会被电子商务平台记录，请您放心使用。</span>
</p>
      </div>
      <div class="helpblock">
        <h1><a name="e2" id="e2"></a>如何共享文件给我的好友？<a href="#a">返回顶部&uarr;</a></h1>
         <ul>
        	<li>1、选择需要与好友共享的目录，然后右击鼠标，选择“共享”一项</li>
            <li>2、在跳转的对话框中添加共享成员的邮箱，指定您要共享的好友特定邮箱</li>
            <li>3、设置共享人的权限，有允许上传和取消上传两个权限，您可以设置是否允许或取消共享成员在共享目录中上传文件</li>
            <li>4、点击“确定”按钮，在跳转的页面会出现“共享设置操作成功”的小提示，这时共享的目录就会多出一个小手的标志，在您的网络硬盘目录下会多出“共享目录”一栏</li>
        </ul>
      </div>
      
      <div class="helpblock">
        <h1><a name="e3" id="e3"></a>如何设置共享中的上传权限？<a href="#a">返回顶部&uarr;</a></h1>
       <ul>
        	<li>上传权限分为：“取消上传”与“允许上传”两个权限；</li>
            <li>系统默认的共享成员没有“允许上传”权限，共享成员只可下载共享目录中的文件；</li>
            <li>共享者设置共享成员“允许上传”权限时，共享成员可在共享目录中可以操作：上传文件，新建目录，下载文件；</li>
            <li>共享者设置共享成员“取消上传”权限时，共享成员只能下载共享目录中的文件，不能进行其它操作。</li>
        </ul>
      </div>
      
      <div class="helpblock"><a name="af" id="af"></a>
        <h1><a name="f" id="f"></a>什么是积分？<a href="#a">返回顶部&uarr;</a></h1>
        <p>积分是2009年7月电子商务平台为感谢广大用户长期以来的支持与厚爱，根据用户使用情况，通过累积积分的方式推出的一项长期回馈计划。
在您登录后电子商务平台页面右上方显示的数目就是您现有的积分数目，点击即可查看到相应的积分记录明细
(您也可以在设置页面查看积分详情)。
</p>
      </div>
      
       <div class="helpblock">
        <h1><a name="f1" id="f1"></a>积分有什么用处？<a href="#a">返回顶部&uarr;</a></h1>
        <p>积分可以用来参与电子商务平台一系列用户回馈活动，您可以继续关注一下！</p>
      </div>
      <div class="helpblock">
        <h1><a name="f2" id="f2"></a>积分获取与扣除规则？<a href="#a">返回顶部&uarr;</a></h1>
		<table>
        <tr>
        	<th width="30%">积分获取</th>
            <th>具体获取规则</th>
        </tr>
        <tr>
        	<td>登录</td>
            <td>新注册用户首次登录可获得50积分；老用户登录每日可获得1积分，每日限一次</td>
        </tr>
         <tr class="colbg">
        	<td>邀请好友注册</td>
            <td>每邀请一位好友成功注册可获得50积分，每天封顶500积分</td>
        </tr>
         <tr>
        	<td>下载链接引导注册</td>
            <td>通过下载链接每引导一位用户成功注册可获得50积分，每日封顶500积分</td>
        </tr>
        <tr class="colbg">
        	<td>BBS主题帖引导注册</td>
            <td>通过发表BBS主题帖每引导一位用户成功注册可获得50积分，每日封顶500积分</td>
        </tr>
        <tr>
        	<td>文件快递引导注册</td>
            <td>通过发送文件快递每引导一位用户成功注册可获得50积分，每日封顶500积分</td>
        </tr>
        <tr class="colbg">
        	<td>共享文件夹引导注册</td>
            <td>通过共享文件夹每引导一位用户成功注册可获得50积分，每日封顶500积分</td>
        </tr>
        <tr>
        	<td class="colorb">举报不和谐内容</td>
            <td class="colorb">举报一次有效不和谐内容可获得20积分，每日封顶200积分</td>
        </tr>
         <tr>
        	<th>积分扣除</th>
            <th>具体扣除规则</th>
        </tr>
        <tr>
        	<td>虚假推荐注册</td>
            <td>每虚假推荐注册一位用户扣除100积分</td>
        </tr>
         <tr class="colbg">
        	<td>传播不和谐内容</td>
            <td>每传播一个不和谐文件内容扣除1000积分</td>
        </tr>
        <tr>
        	<td>发送垃圾文件快递有效投诉</td>
            <td>每发送一次垃圾文件快递并收到有效投诉扣除100积分</td>
        </tr>
        <tr class="colbg">
        	<td>BBS上删除垃圾贴</td>
            <td>在BBS上发布垃圾帖被管理员删除，每次扣除10积分</td>
        </tr>
         <tr>
        	<td colspan="2" class="reds">积分累计扣除1000分封帐号，终止服务</td>
        </tr>
        </table>
      </div>
      
      <div class="helpblock"><a name="ag" id="ag"></a>
        <h1><a name="g1" id="g1"></a>电子商务平台使用小技巧？<a href="#a">返回顶部&uarr;</a></h1>
         <ul>
        	<li>1、电子商务平台可以拖拽文件批量上传</li>
            <li>2、可以用键盘Delete键快速删除</li>
            <li>3、单个文件多选可以使用Ctrl键</li>
            <li>4、连续多选文件可以使用Shift键</li>
            <li>5、可以使用“上”“下”方向键选择单个文件</li>
            <li>6、网盘目录有右键操作</li>
        </ul>
      </div>
      
    </div>
  </div>
</div>



    

  
<script type="text/javascript">
	var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
	document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
</script>
<script type="text/javascript">
	try {
	var pageTracker = _gat._getTracker("UA-8272227-1");
	pageTracker._initData();
	pageTracker._trackPageview();
	} catch(err) {}
</script>

</body>
</html>
