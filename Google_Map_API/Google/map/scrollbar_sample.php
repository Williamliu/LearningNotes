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
		<script type="text/javascript" src="jquery/code/myplugin/jquery.lwh.scrollbar.js"></script>
		<link href="jquery/code/myplugin/css/jquery.lwh.scrollbar.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" src="js/lwh_common.js"></script>
		<script language="javascript" type="text/javascript">
			$(function() {
				$("#m1").resizable();

				$("#vs-top", "#m1").live("click", function() {
					$("#lwh-scrollbar-content").scrollTop($("#lwh-scrollbar-content").scrollTop()-20);
					$.scroll_vgoing("#m1", "#m2");
				});
				
				$("#vs-middle", "#m1").live("click", function(ev) {
					var hit_top = ev.clientY - $(this).offset().top;
					var new_top;
					if( hit_top > 	parseInt( $("#vs-middle-bar", this).css("top") ) ) {
					 	new_top = 	parseInt( $("#vs-middle-bar", this).css("top") ) + 40;
					} else {
					 	new_top = 	parseInt( $("#vs-middle-bar", this).css("top") ) - 40;
					}
					if( new_top < 0 ) new_top = 0;
					var vs_length 	= $(this).height() - $("#vs-middle-bar",this).outerHeight();
					if( new_top > vs_length ) new_top = vs_length; 
					
					$("#vs-middle-bar", this).css("top", new_top );
					$.drag_vgoing("#m1", "#m2", new_top);
					return false;
				});

				$("#vs-bottom", "#m1").live("click", function() {
					$("#lwh-scrollbar-content").scrollTop($("#lwh-scrollbar-content").scrollTop()+40);
					$.scroll_vgoing("#m1", "#m2");
				});


				$("#hs-left", "#m1").live("click", function() {
					$("#lwh-scrollbar-content").scrollLeft($("#lwh-scrollbar-content").scrollLeft()-40);
					$.scroll_hgoing("#m1", "#m2");
				});

				$("#hs-center", "#m1").live("click", function(ev) {
					var hit_left = ev.clientX - $(this).offset().left;
					var new_left;
					if( hit_left > 	parseInt( $("#hs-center-bar", 	this).css("left") ) ) {
					 	new_left = 	parseInt( $("#hs-center-bar",	this).css("left") ) + 20;
					} else {
					 	new_left = 	parseInt( $("#hs-center-bar", 	this).css("left") ) - 20;
					}
					if( new_left < 0 ) new_left = 0;
					var hs_length 	= $(this).width() - $("#hs-center-bar",this).outerWidth();
					if( new_left > hs_length ) new_left = hs_length; 
					
					$("#hs-center-bar", this).css("left", new_left );
					$.drag_hgoing("#m1", "#m2", new_left);
					return false;
				});

				$("#hs-right", "#m1").live("click", function() {
					$("#lwh-scrollbar-content").scrollLeft($("#lwh-scrollbar-content").scrollLeft()+20);
					$.scroll_hgoing("#m1", "#m2");
				});

				
				$("#vs-middle-bar", "#m1").draggable({
					axis: "y",
					containment:"parent",
					drag: function(ev, ui) {
						$.drag_vgoing("#m1", "#m2", ui.position.top);
					}
				});
				$("#hs-center-bar", "#m1").draggable({
					axis: "x",
					containment:"parent",
					drag: function(ev, ui) {
						$.drag_hgoing("#m1", "#m2", ui.position.left);
					} 
				});
				
				$.scroll_visible("#m1" , "#m2");
				
				$("#m1").resize(function(){
					$.scroll_visible("#m1" , "#m2");
				});

				$("#m2").resize(function(){
				});
				
				$("#m1").mousewheel( function(ev, pos) {
					if(pos > 0 ) {
						$("#lwh-scrollbar-content").scrollTop($("#lwh-scrollbar-content").scrollTop()-20);
					} else {
						$("#lwh-scrollbar-content").scrollTop($("#lwh-scrollbar-content").scrollTop()+20);
					}
					$.scroll_vgoing("#m1", "#m2");
					return false;
				});
				
			});
			
			$.extend({
				scroll_visible: function( el0, el1) {
					if( $(el0).width() < $(el1).outerWidth() ) {
						$(el1).css("padding-bottom", 20);
						$("#hs-bar", el0).show();
						$("#vs-corner", el0).height(15);
						var new_width = $(el0).width() / $(el1).outerWidth() * $("#hs-center-bar", el0).parent().width();
						new_width = new_width<20?20:new_width;
						new_width = $("#hs-center-bar", el0).parent().width()<=20?$("#hs-center-bar", el0).parent().width()-5:new_width;
						if( new_width > 5 ) {
							$("#hs-center-bar", el0).show();
							$("#hs-center-bar", el0).width( new_width );
							$.scroll_hgoing(el0, el1);
						} else {
							$("#hs-center-bar", el0).hide();
						}
					} else {
						$("#hs-bar", el0).hide();
						$("#vs-corner", el0).height(15);
						$(el1).css("padding-bottom", 2);
					}
					
					if( $(el0).height() < $(el1).outerHeight() ) {
						$(el1).css("padding-right", 20);
						$("#vs-bar", el0).show();
						$("#hs-corner", el0).width(15);
						var new_height = $(el0).height() / $(el1).outerHeight() * $("#vs-middle-bar", el0).parent().height();
						new_height = new_height < 20 ? 20: new_height;
						new_height = $("#vs-middle-bar",el0).parent().height()<=20?$("#vs-middle-bar", el0).parent().height()-5:new_height; 
						if( new_height > 5 ) {
							$("#vs-middle-bar", el0).show();
							$("#vs-middle-bar", el0).height( new_height );
							$.scroll_vgoing(el0, el1);
						} else {
							$("#vs-middle-bar", el0).hide();
						}
					} else {
						$("#vs-bar", el0).hide();
						$("#hs-corner", el0).width(15);
						$(el1).css("padding-left", 2);
						
					}
				},
				
				scroll_vgoing: function( el0, el1 ) {
					var vs_length 	= $(el1).outerHeight() - $(el0).height();
					var bar_length 	= $("#vs-middle-bar", el0).parent().height() - $("#vs-middle-bar", el0).outerHeight();
					var bar_top = bar_length *  $("#lwh-scrollbar-content", el0).scrollTop() / vs_length;
					$("#vs-middle-bar", el0).css("top", bar_top);
					return false;
				},

				scroll_hgoing: function( el0, el1 ) {
					var hs_length 	= $(el1).outerWidth() - $(el0).width();
					var bar_length 	= $("#hs-center-bar", el0).parent().width() - $("#hs-center-bar", el0).outerWidth();
					var bar_left = bar_length *  $("#lwh-scrollbar-content", el0).scrollLeft() / hs_length;
					$("#hs-center-bar", el0).css("left", bar_left);
					return false;
				},
				
				drag_vgoing: function( el0, el1, ytop ) {
					var vs_length 	= $(el1).outerHeight() - $(el0).height();
					var bar_length 	= $("#vs-middle-bar", el0).parent().height() - $("#vs-middle-bar", el0).outerHeight();
					var scroll_top = ytop  * vs_length / bar_length;
					$("#lwh-scrollbar-content", el0).scrollTop(scroll_top);
				},
	
				drag_hgoing: function( el0, el1, xleft ) {
					var hs_length 	= $(el1).outerWidth() - $(el0).width();
					var bar_length 	= $("#hs-center-bar", el0).parent().width() - $("#hs-center-bar", el0).outerWidth();
					var scroll_left = xleft  * hs_length / bar_length;
					$("#lwh-scrollbar-content", el0).scrollLeft(scroll_left);
				}
			
			});
		</script>
	</head>
	<body>
		This is customize scrollbar<br />
		<div id="msg1" style="width:200px; height:120px; border:1px solid black; display:inline-block; overflow:auto;"></div>
		<div id="msg2" style="width:200px; height:120px; border:1px solid black; display:inline-block; overflow:auto;"></div>
		<div id="msg3" style="width:200px; height:120px; border:1px solid black; display:inline-block; overflow:auto;"></div>
		
		<div id="m1" style="position:relative; margin:50px; width:400px; border:1px solid black; height:400px; overflow:hidden;">
				<div id="vs-bar" class="lwh-plugin-vscroll">
					<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
						<tr>
							<td id="vs-top"></td>
						</tr>
						<tr>
							<td id="vs-middle" align="center" valign="top">
								<div id="vs-middle-bar"></div>
							</td>
						</tr>
						<tr>
							<td id="vs-bottom"></td>
						</tr>
						<tr>
							<td id="vs-corner"></td>
						</tr>
					</table>
				</div>
				<div id="hs-bar" class="lwh-plugin-hscroll">
					<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">
						<tr>
							<td id="hs-left"></td>
							<td id="hs-center" valign="middle" align="left">
								<div id="hs-center-bar"></div>
							</td>
							<td id="hs-right"></td>
							<td id="hs-corner"></td>
						</tr>
					</table>
				</div>
				<div id="lwh-scrollbar-content" class="lwh-plugin-scrollbar-content">
					<div id="m2" style="position:relative; width:auto; height:auto; padding:2px;margin:0px; display:table;">
									
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
			</div>
		</div>
	</body>
</html>
