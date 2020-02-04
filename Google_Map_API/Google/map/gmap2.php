<?php
ini_set("display_errors", "0");
include("../include/config/config.php");
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Google Maps Group Marker</title>
		<link href="jquery/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" src="jquery/min/jquery-1.6.3.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.other.resize.js"></script>
		<script type="text/javascript" src="jquery/min/jquery-ui-1.8.5.custom.min.js"></script>
		<script type="text/javascript" src="js/lwh_common.js"></script>
		<script language="javascript" type="text/javascript">
			$(function() {
				var str = "";
				$("#m1").resizable();
				$("#hs").draggable({
					axis: "y",
					containment:"parent"
				});
				$("#vs").draggable({
					axis: "x",
					containment:"parent"
				});
				
				$("#m2").resize(function(){
					str = "W:" + $(this).width() + " H:" + $(this).height() + "<br>";
					$("#msg").html(str);
				});
				
				/*
				document.getElementById('m2').addEventListener("resize", function(){
					str += "width:" + $(this).width();
					$("#msg").html(str);
				}, false);
				*/	
			});
			
			function showme(){
				$("#m2").width(150);
			}
		</script>
	</head>
	<body>
		This is customize scrollbar<br />
		<div id="msg" style="width:300px; height:120px; border:1px solid black; overflow:auto;"></div>		
		<div id="m1" style="position:relative; width:400px; height:400px; border:1px solid blue; overflow:hidden;">
				<div style="position:absolute; width:15px; height:100%; top:0px; left:100%; margin-left: -15px; border:1px solid orange; z-index:99;">
					<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
						<tr>
							<td height="20" width="100%" style="background-color:#666666;"></td>
						</tr>
						<tr>
							<td height="auto" width="100%" style="background:#333333;">
								<div id="hs" style="width:100%; height:50px; background-color:#33CC99;"></div>
							</td>
						</tr>
						<tr>
							<td height="20" width="100%" style="background-color:#666666;"></td>
						</tr>
						<tr>
							<td height="15" width="100%" style="background-color:#cccccc;"></td>
						</tr>
					</table>
				</div>
				<div style="position:absolute; width:100%; height:15px; top:100%;left:0px;  margin-top: -15px; border:1px solid orange; z-index:98;">
					<table border="0"  cellpadding="0" cellspacing="0" width="100%" height="100%">
						<tr>
							<td width="20" height="100%"  style="background-color:#666666;"></td>
							<td width="auto" height="100%" style="background-color:#333333;">
								<div id="vs" style="width:50px; height:100%; background-color:#33CC99;"></div>
							</td>
							<td width="20" height="100%"  style="background-color:#666666;"></td>
							<td width="15" height="100%"  style="background-color:red;"></td>
						</tr>
					</table>
				</div>

				<div id="m2" style="position:relative; width:auto; height:auto; border:1px solid red; padding:0px; padding-right:20px; margin:0px;">
								
								good day
								<div style="width:100px; height:100px; border:1px solid green; left:20px; top:20px;"></div>
								<span style="position:relative; left:100px; top:30px;">hello</span>
								<div style="position:absolute; width:100px; height:100px; border:1px solid yellow; left:20px; top:20px;"></div>
								
								hello world kdfjdskaj kdsfjkads fkdjf sadjfkdsjaklj asdfkjdsakljsa dfjsadkljkladsfj dsajldjfkldsjkl dfsadkjl<br />
								a b c d e f g h i j k l m n o p q r s t u v w x y z a b c d e f g h i j k l m n o p q r s t u v w x y z<br />
								Lilian Liu<br />
								hello world<br />
								hello world<br />
								hello world<br />
								hello world<br />
								hello world<br />
								hello world<br />
								hello world<br />
								hello world<br />
								hello world<br />
			</div>
		</div>
		<input type="button" onclick="showme()" value="show" />
	</body>
</html>
