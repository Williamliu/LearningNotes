<?php
ini_set("display_errors", "0");
include("../../include/config/config.php");
include($CFG["include_path"] . "/config/dataType.php");
include($CFG["include_path"] . "/lib/database/mysql_db.php");
include($CFG["include_path"] . "/lib/json/lwh_json.php");

if($err_msg[0]==0) {
} 

if($err_msg[0] == "") {
	$zones 	= $_REQUEST["zones"];
	$marker = $_REQUEST["marker"];
	$fields = array();
	$fields["lat"] = $marker["lat"];
	$fields["lng"] = $marker["lng"];
	$fields["created_date"] = time();
	$marker_id = table_insert("gmap_markers", $fields);
	
	$response["data"] = array();
	$response["data"]["id"] 	= $marker_id;
	$response["data"]["ref_id"] = 102;
	$response["data"]["zidx"] 	= $marker["zidx"];
	$response["data"]["midx"] 	= $marker["midx"];

	$response["errorCode"] = 0;
} else {
	$response["errorCode"] = $err_msg[0];
	$response["errorMessage"] = $err_msg[1];
	$response["errorField"] = $err_msg[2];
}
echo jEncode( $response );
exit();
?>