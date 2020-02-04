<?php
ini_set("display_errors", "0");
include("../include/config/config.php");
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
		<title>My Custom Scrollbar</title>
		<link href="jquery/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" src="jquery/min/jquery-1.6.4.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery-ui-1.8.5.custom.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.other.resize.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.mousewheel.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.curvycorners.min.js"></script>
		<script type="text/javascript" src="jquery/code/myplugin/jquery.lwh.scrollbar.js"></script>
		<link href="jquery/code/myplugin/css/jquery.lwh.scrollbar.css" rel="stylesheet" type="text/css" />

		<script type="text/javascript" src="jquery/code/myplugin/jquery.lwh.loading.js"></script>
		<link href="jquery/code/myplugin/css/jquery.lwh.loading.css" rel="stylesheet" type="text/css" />


		<script type="text/javascript" src="jquery/code/myplugin/jquery.lwh.dialog.js"></script>
		<link href="jquery/code/myplugin/css/jquery.lwh.dialog.css" rel="stylesheet" type="text/css" />

		<script type="text/javascript" src="js/lwh_common.js"></script>
		<script language="javascript" type="text/javascript">
			$(function() {
				$("#msg1, #m2").lwhScrollbar({resizable:true});
				
				$("#msg2").lwhScrollbar();
				
				$("#msg3").lwhScrollbar({resizable:true, hscroll: false});
				$("#msg4").lwhScrollbar({resizable:false, vscroll: false});
				$("#msg5").lwhScrollbar({resizable:true, vscroll: false});
				$("#msg6").lwhScrollbar({resizable:false, vscroll: false, hscroll:false});
				
				//$("#wait").lwhLoading({container:"#msg1"});
				//$("#wait").LShow();
			});
		
			function input_data() {
				$("#m2").html("good Idea Good Solution<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day");
			}
			function input_data1() {
				$("#m2").html("good Idea Good good Idea Good Solution  good Idea Good Solution  good Idea Good Solution  good Idea Good Solution  good Idea Good Solution  good Idea Good Solution " +
								"<br><div style='width:400px;height:300px; border:1px solid yellow;'>DIV Square 400px * 300px</div> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day<br> day");
			}
		</script>
</head>
<body>
		This is customize scrollbar<br />
		<div id="msg1" style="width:200px; height:120px; border:1px solid black; display:inline-block; overflow:auto;">
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		</div>
		&nbsp;&nbsp;
		<div id="msg2" style="width:200px; height:120px; border:1px solid black; display:inline-block;">
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		</div>
		
		<br /><br />
				
		<div id="msg3" style="width:200px; height:120px; border:1px solid black; display:inline-block;">
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj		
		</div>
		&nbsp;&nbsp;
		<div id="msg4" style="width:200px; height:120px; border:1px solid black; display:inline-block; overflow:auto;">
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj		
		</div>
		&nbsp;&nbsp;
		<div id="msg5" style="width:200px; height:120px; border:1px solid black; display:inline-block;">
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj		
		</div>

		&nbsp;&nbsp;
		<div id="msg6" style="width:200px; height:120px; border:1px solid black; display:inline-block;">
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj
		 Ehllo Jame ... dskfjsadkljf sadkfjaskldjf sad kfadsjkflj kasdjflasj  kadsjflkasjd
		 kdfjkladsjfl asdjflasdjkjdsklfjsadkljlkasdjf kjdklfjaskldjflask dkadsjfklasjdlfjadslfjkasd
		 adskfjkladsjf;ladskjflksadjfklasjdklfjasldkfjadsklfjaklsdjflkasdjfkladsjf asjdfljasdlkfjals;df
		 asdkfjakdsljfk;lasdjf;asjdfklasjdkflj asdkljfklasdj		
		</div>
		

		<div id="m2" style="position:relative; width:200px; height:auto; border:1px solid red; padding:2px;margin:0px;">
						
						good idea, good solution
						<div style="width:500px; height:300px; border:1px solid green; left:20px; top:20px;"></div>
						<span style="position:relative; left:100px; top:30px;">hello</span>
						<div style="position:relative; width:100px; height:100px; border:1px solid yellow; left:20px; top:20px;"></div>
						<div style="clear:both"></div>
						hello world kdfjdskaj kdsfjkads fkdjf sadjfkdsjaklj asdfkjdsakljsa dfjsadkljkladsfj dsajldjfkldsjkl dfsadkjl<br />
						a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z<br />
						Lilian Liu<br />
						hello world1111<br />
						hello world2222<br />
						hello world3333<br />
						hello world4444<br />
						hello world5555<br />
						hello world6666<br />
						hello world7777<br />
						hello world8888<br />
						hello world9999
	</div>
	<input type="button" onclick="input_data()" value="Data" />
	<input type="button" onclick="input_data1()" value="Data1" />
	<div id="wait"></div>
</body>
</html>
