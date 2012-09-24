﻿<%@ Page Language="C#" AutoEventWireup="false" CodeFile="Category.aspx.cs" Inherits="SubHQ_Category" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
	<title>DesignHQ</title>
	<meta name="Robots" content="index,follow" />
	<meta name="author" content="Borut Jegrišnik (www.solucija.com)" />
	<link rel="stylesheet" type="text/css" href="../css/main.css" media="screen" />
	<link rel="stylesheet" type="text/css" href="../prettyphoto/css/prettyPhoto.css" media="screen" />
	<script type="text/javascript" src="../js/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" src="../js/core.js"></script>
	<script type="text/javascript" src="../js/jquery.pngFix.js"></script>
	<script type="text/javascript" src="../prettyphoto/js/jquery.prettyPhoto.js"></script>
	<!--[if IE 6]>
	<style>
		#pitch .infoline {margin-top:-74px;}
		.post-options {margin:-55px 0 40px 138px;}
	</style>
	<![endif]-->
	<!--[if IE 7]>
	<style>
		.post-options {margin-left:138px;}
	</style>
	<![endif]-->

</head>
<body>
	<div id="wrapper">
		<div id="logo">
			<h1><a href="../Default.aspx">DESIGN<span>HQ</span></a></h1>
		</div>
		
		<div id="content">
			<ul class="menu" id="jMenu">
				<li class="current"><a href="../Default.aspx">Home</a></li>
				<li><a href="category.aspx">Blog</a>
					<ul>
						<li><a href="#">Jim Carrey</a></li>
						<li><a href="#">Alan Morrison</a></li>
						<li><a href="#">Doing it right</a></li>
					</ul>
				</li>
				<li><a href="category.aspx">Portfolio</a>
					<ul>
						<li><a href="#">Designs</a></li>
						<li><a href="#">Code</a></li>
						<li><a href="#">Consulting</a></li>
						<li><a href="#">Help &amp; Support</a></li>
					</ul>
				</li>
				<li><a href="inner.aspx">About</a></li>
				<li><a href="contact.aspx">Contact</a></li>
			</ul>
			
			<div id="search">
				<form method="post" action="../Default.aspx">
					<input type="text" class="text" name="query" value="Search..." onfocus="this.value='';" onblur="this.value='Search...'" />
					<input type="submit" class="submit" name="search" value="" />
				</form>
			</div>
			
			<div class="x"></div>
			
			<div id="pitch">
				<div class="pitch-gallery">
					<div class="pitch-gallery-holder" id="gallery-pitch-holder">
						<div class="pitch-gallery-div">
							<img src="../images/pitch-1.jpg" alt="Pitch 1" />
							<div class="infoline">Hello! We are professional team of designers and we would like to share our passion with you!</div>
						</div>
						<div class="pitch-gallery-div">
							<img src="../images/pitch-2.jpg" alt="Pitch 2" />
							<div class="infoline">This is <strong>DesignHQ</strong> theme suited for business site or portfolio.</div>
						</div>
						<div class="pitch-gallery-div">
							<img src="../images/pitch-3.jpg" alt="Pitch 3" />
							<div class="infoline">Just works everywhere! This theme works fine under all major browsers.</div>
						</div>
						<div class="pitch-gallery-div">
							<img src="../images/pitch-4.jpg" alt="Pitch 4" />
							<div class="infoline">This is jQuery improved theme with custom drop down menu and ajax powered contact form.</div>
						</div>
					</div>
				</div>
			</div>
			
			<div id="left">
				<div class="post">
					<a href="inner.aspx"><img src="../images/small-image.jpg" alt="Small image" /></a>
					<h4><a href="inner.aspx">So who are we?</a></h4>
					<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</p>
				</div>
				<div class="post-options">
					<a href="inner.aspx" class="read-more">Read more</a> | Posted on 12.12.2012. by Author | It has 12 comments
				</div>
				<div class="x"></div>

				<div class="post">
					<a href="inner.aspx"><img src="../images/small-image.jpg" alt="Small image" /></a>
					<h4><a href="inner.aspx">So who are we?</a></h4>
					<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</p>
				</div>
				<div class="post-options">
					<a href="inner.aspx" class="read-more">Read more</a> | Posted on 12.12.2012. by Author | It has 12 comments
				</div>
				<div class="x"></div>

				<div class="post">
					<a href="inner.aspx"><img src="../images/small-image.jpg" alt="Small image" /></a>
					<h4><a href="inner.aspx">So who are we?</a></h4>
					<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.</p>
				</div>
				<div class="post-options">
					<a href="inner.aspx" class="read-more">Read more</a> | Posted on 12.12.2012. by Author | It has 12 comments
				</div>
				<div class="x"></div>
				
				<a href="#" class="read-more">Previous Posts</a>
			</div>
			
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
				
				<div class="small-post last">
					<img src="../images/contact.jpg" alt="Contact us" />
					<h1><a href="contact.aspx">Contact Us</a></h1>
					<p>It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.</p>
				</div>				
			</div>
						
			<div class="x space"></div>
			
		</div>
		
		<!-- footer -->
		<div id="footer">
			<p>Copyright &copy; 2009 DesignHQ &middot; Design: Borut Jegrišnik, <a href="http://www.solucija.com/" title="Free CSS Templates">Solucija</a></p>
		</div>
	</div>
	<script type="text/javascript">
	    jGallery('pitch');
	    $(document).pngFix();
	    $(document).ready(function () {
	        $("a[rel^='prettyPhoto']").prettyPhoto();
	    });
	</script>
</body>
</html>
