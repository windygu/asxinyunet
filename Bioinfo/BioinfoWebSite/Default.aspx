﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>测试网站</title>
	<meta name="Robots" content="index,follow" />
	<meta name="author" content="Borut Jegrišnik (www.solucija.com)" />
	<link rel="stylesheet" type="text/css" href="css/main.css" media="screen" />
	<link rel="stylesheet" type="text/css" href="prettyphoto/css/prettyPhoto.css" media="screen" />
	<script type="text/javascript" src="js/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" src="js/core.js"></script>
	<script type="text/javascript" src="js/jquery.pngFix.js"></script>
	<script type="text/javascript" src="prettyphoto/js/jquery.prettyPhoto.js"></script>
	<!--[if IE 6]>
	<style>
		#pitch .infoline {margin-top:-74px;}
		.post-options {margin:-55px 0 40px 138px;}
	</style>
	<![endif]-->
</head>
<body>
	<form id="form1" runat="server">
	<div id="wrapper">
		<div id="logo">
			<h1><a href="Default.aspx">Test WebSite</span></a></h1>
		</div>
		
		<div id="content">
		<!-- main menu -->
			<ul class="menu" id="jMenu">
				<li class="current"><a href="Default.aspx">Home</a></li>
				<li><a href="SubHQ/category.aspx">Blog</a>
					<ul>
						<li><a href="#">Jim Carrey</a></li>
						<li><a href="#">Alan Morrison</a></li>
						<li><a href="#">Doing it right</a></li>
					</ul>
				</li>
				<li><a href="SubHQ/category.aspx">Portfolio</a>
					<ul>
						<li><a href="#">Designs</a></li>
						<li><a href="#">Code</a></li>
						<li><a href="#">Consulting</a></li>
						<li><a href="#">Help &amp; Support</a></li>
					</ul>
				</li>
				<li><a href="SubHQ/inner.aspx">About</a></li>
				<li><a href="SubHQ/contact.aspx">Contact</a></li>
			</ul>
			
			<!-- search form -->
			<div id="search">
					<input type="text" class="text" name="query" value="Search..." onfocus="this.value='';" onblur="this.value='Search...'" />
					<input type="submit" class="submit" name="search" value="" />
				</div>
			
			<div class="x"></div>
			
			<!-- image slider -->
			<div id="pitch">
				<div class="pitch-gallery">
					<div class="pitch-gallery-holder" id="gallery-pitch-holder">
						<div class="pitch-gallery-div">
							<img src="images/pitch-1.jpg" alt="Pitch 1" />
							<div class="infoline">Hello! We are professional team of designers and we would like to share our passion with you!</div>
						</div>
						<div class="pitch-gallery-div">
							<img src="images/pitch-2.jpg" alt="Pitch 2" />
							<div class="infoline">This is <strong>DesignHQ</strong> theme suited for business site or portfolio.</div>
						</div>
						<div class="pitch-gallery-div">
							<img src="images/pitch-3.jpg" alt="Pitch 3" />
							<div class="infoline">Just works everywhere! This theme works fine under all major browsers.</div>
						</div>
						<div class="pitch-gallery-div">
							<img src="images/pitch-4.jpg" alt="Pitch 4" />
							<div class="infoline">This is jQuery improved theme with custom drop down menu and ajax powered contact form.</div>
						</div>
					</div>
				</div>
			</div>
			
			<!-- main content -->
			<div id="left">
				<h1><a href="SubHQ/inner.aspx">So who are we?</a></h1>
				<p>
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </p>
				<p>It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
				<a href="SubHQ/inner.aspx" class="read-more">Read more</a>
			</div>
			
			<!-- sidebar -->
			<div id="right">
				<h1>Latest news</h1>
				
				<h2><a href="#">Big picture</a></h2>
				<p class="post-info">Posted on 12.12.2009. in Category | 12 comments</p>

				<h2><a href="#">Earning more money</a></h2>
				<p class="post-info">Posted on 12.12.2009. in Category | 12 comments</p>

				<h2><a href="#">Global warming in your house</a></h2>
				<p class="post-info">Posted on 12.12.2009. in Category | 12 comments</p>

				<h2><a href="#">Do you believe?</a></h2>
				<p class="post-info">Posted on 12.12.2009. in Category | 12 comments</p>
			</div>
			
			<div class="x"></div>
			<div class="break"></div>
			
			<!-- small posts -->
			<div id="feature">
				<div class="small-post">
					<img src="images/clean.jpg" alt="Clean and Simple" />
					<h1><a href="#">Clean and Simple</a></h1>
					<p><strong>DesignHQ</strong> is a sleek modern theme best suited for business or portfolio site. It's ready out of the box and comes with all needed pages - home, category, inner and contact form with all css styled elements.</p>
				</div>
							
				<div class="small-post">
					<img src="images/newtech.jpg" alt="jQuery Powered" />
					<h1><a href="#">jQuery Powered</a></h1>
					<p>This template uses jQuery to enhance usability and visual performance:</p><ul><li>Custom drop down menu</li><li>Ajax powered contact form</li><li>preetyPhoto plugin</li></ul>
				</div>

				<div class="small-post last">
					<img src="images/contact.jpg" alt="Contuct Us" />
					<h1><a href="SubHQ/contact.aspx">Contact Us</a></h1>
					<p>Contact form is ready to use. It works with ajax and simple PHP script that sends user submited data directly to your email. Contact form is build with Javascript math captcha to protect you from spam.</p>
				</div>
				<div class="x"></div>
			</div>

		</div>
		
		<!-- footer -->
		<div id="footer">
			<p>Copyright &copy; 2009 DesignHQ &middot; Design: Borut Jegrišnik, <a href="http://www.solucija.com/" title="Free CSS Templates">Solucija</a></p>
		</div>
	</div>
	
	<!-- gallery starter and prettyPhoto starter -->
	<script type="text/javascript">
	    jGallery('pitch');
	    $(document).pngFix();
	    $(document).ready(function () {
	        $("a[rel^='prettyPhoto']").prettyPhoto();
	    });
	</script>
    </form>
</body>
</html>