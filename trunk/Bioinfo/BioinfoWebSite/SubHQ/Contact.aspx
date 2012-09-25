﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="SubHQ_Contact" %>

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
	<script type="text/javascript" src="../pngFix/jquery.pngFix.js"></script>
	<script type="text/javascript" src="../prettyphoto/js/jquery.prettyPhoto.js"></script>
	<!--[if IE 6]>
	<style>
		#pitch .infoline {margin-top:-74px;}
		.post-options {margin:-55px 0 40px 138px;}
	</style>
	<![endif]-->

</head>
<body>
	<div id="wrapper">
		<div id="logo">
			<h1><a href="index.aspx">DESIGN<span>HQ</span></a></h1>
		</div>
		
		<div id="content">
			<ul class="menu" id="jMenu">
				<li class="current"><a href="index.aspx">Home</a></li>
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
				<form method="post" action="index.aspx">
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
				<div id="contact_form">
					<h1>Contact us</h1>
					<p>Please use the form below to send us a message.</p>
					<form method="post" onsubmit="return sendContact();" action="sendContact.php">
						<p>
							<label for="name" id="lname">Full name:</label>
							<input type="text" class="text" name="name" id="name" onfocus="input_focus('name');" onblur="input_blur('name');" />
						</p>
						
						<p>
							<label for="email" id="lemail">Email address:</label>
							<input type="text" class="text" name="email" id="email" onfocus="input_focus('email');" onblur="input_blur('email');" />
						</p>
						<div class="x"></div>
						<p class="error" id="email-error">You must enter your email address.</p>
						
						<p>
							<label for="category" id="lcategory">Category:</label>
							<select name="category" id="category" onfocus="input_focus('category');" onblur="input_blur('category');">
								<option value="software">Software</option>
								<option value="hardwae">Hardware</option>
								<option value="consulting">Consulting</option>
								<option value="resources">Resources</option>
							</select>
						</p>

						<p>
							<label for="message" id="lmessage">Message:</label>
							<textarea name="message" id="message" onfocus="input_focus('message');" onblur="input_blur('message');"></textarea>
						</p>
						<div class="x"></div>
						<p class="error" id="message-error">You must enter your message.</p>

						<p>
							<label for="captcha" id="lcaptcha"></label>
							<input type="text" class="text" name="captcha" id="captcha" onfocus="input_focus('captcha');" onblur="input_blur('captcha');" />
						</p>
						<div class="x"></div>
						<p class="error" id="captcha-error">Are you shure about your calculations?</p>
						<script type="text/javascript">
						    generate_captcha('lcaptcha');
						</script>
						
						<div class="x"></div>
						
						<input type="submit" class="submit" name="send_contact" value="Send" />
						
					</form>
					
					<span id="contact-back">or you can <a href="index.aspx" class="read-more">Go back</a></span>
				</div>
				
				<div id="message_sent" style="display:none;">
					<h1>Your message has been sent</h1>
					<p>We'll contact you in a shortest possible time.</p>
					<p>You can now <a href="Default.aspx" class="read-more">go back</a> to home page.</p>
				</div>				
			</div>
						
			<div id="right">
				<p>Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular.</p>
				<br />
				<h3>Other Contact informations:</h3>
				<p>
					email: <strong>some@email.com</strong><br />
					phone: <strong>+123.456.789</strong><br />
					address: <strong>Some Address 13</strong><br />
					zip: <strong>123450</strong><br />
					state: <strong>State</strong>
					country: <strong>Country</strong>
				</p>
				<br />
				<p>Li Europan lingues es membres del sam familie. Lor separat existentie es un myth. Por scientie, musica, sport etc, litot Europa usa li sam vocabular.</p>
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
				<br />
			</div>
			
			<div class="x"></div>
			<div class="break no-border"></div>
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
