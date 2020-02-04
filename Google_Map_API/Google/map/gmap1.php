<?php
ini_set("display_errors", "0");
include("../include/config/config.php");
?>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<title>Google Maps Group Marker</title>
		<meta name="viewport" content="initial-scale=1.0, user-scalable=no" />
		<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?sensor=true"></script>

		<link href="jquery/themes/base/jquery.ui.all.css" rel="stylesheet" type="text/css" />
		<script type="text/javascript" src="jquery/code/jquery-1.4.2.js"></script>
		<script type="text/javascript" src="jquery/min/jquery-ui-1.8.5.custom.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.curvycorners.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.mousewheel.min.js"></script>
		<script type="text/javascript" src="jquery/min/jquery.curvycorners.min.js"></script>
	
		<script type="text/javascript" src="jquery/code/myplugin/jquery.lwh.loading.js"></script>
		<link href="jquery/code/myplugin/css/jquery.lwh.loading.css" rel="stylesheet" type="text/css" />

		<script type="text/javascript" src="jquery/code/myplugin/jquery.lwh.dialog.js"></script>
		<link href="jquery/code/myplugin/css/jquery.lwh.dialog.css" rel="stylesheet" type="text/css" />
	
		<script type="text/javascript" src="js/lwh_common.js"></script>
		<script type="text/javascript" src="js/lwh_gmap_class.js"></script>
		<script type="text/javascript" src="js/lwh_gmap.js"></script>
		<script language="javascript" type="text/javascript">
			$(function() {
				//$("#wait").lwhLoading({container:"#div_gmap"});
				//$("#wait").LShow();

				$("#div_marker").lwhDialog({
					container:"#div_gmap",
					maskclick: true,
					btn_close: "#btn_close"
				});
			
			
			
			});
		</script>
	</head>
	<body>
		<div id="div_gmap" style="width:800px; height:600px;"></div><br />
        <input id="db_clear" type="button" onclick="gmarkers_delete_all()" value="Clear All Markers" />
		<div id="msg"></div>
		
		
		
		
		
		<div id="div_marker">
			<span class="lwhDialog-head">Marker Information</span><BR />
			<div class="lwhDialog-content">ID:</div>
			<input type="button" id="btn_close" value="Close" />
		</div>

		<div id="marker_info" style="display:none;">
        	<a class="mk_delete" style="cursor:pointer; color:blue; text-decoration:underline;">Delete this Marker</a>
        </div>
		
		<div id="wait"></div>
	</body>
</html>
