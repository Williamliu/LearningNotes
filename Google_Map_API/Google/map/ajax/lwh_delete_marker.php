<?php
ini_set("display_errors", "0");
include("../../include/config/config.php");
include($CFG["include_path"] . "/config/dataType.php");
include($CFG["include_path"] . "/lib/database/mysql_db.php");
include($CFG["include_path"] . "/lib/json/lwh_json.php");

if($err_msg[0]==0) {
} 

if($err_msg[0] == "") {
	$marker = $_REQUEST["marker"];
	sql_exec("DELETE FROM gmap_markers WHERE id = '" . $marker["id"] . "'");
	$response["errorCode"] = 0;
} else {
	$response["errorCode"] = $err_msg[0];
	$response["errorMessage"] = $err_msg[1];
	$response["errorField"] = $err_msg[2];
}
echo jEncode( $response );
exit();
?>