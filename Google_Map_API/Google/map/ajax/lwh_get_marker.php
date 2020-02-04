<?php
ini_set("display_errors", "0");
include("../../include/config/config.php");
include($CFG["include_path"] . "/config/dataType.php");
include($CFG["include_path"] . "/lib/database/mysql_db.php");
include($CFG["include_path"] . "/lib/json/lwh_json.php");

if($err_msg[0]==0) {
} 

if($err_msg[0] == "") {
	$general	= $_REQUEST["general"];
	$zones 		= $_REQUEST["zones"];
	//print_r( $_REQUEST["zones"] );
	$select = "lat >= '" . $general["sw"]["lat"] . "' AND lat <= '" . $general["ne"]["lat"] . "'";
	if( $general["ne"]["lng"] < $general["sw"]["lng"] ) {
		$select .= " AND ( (lng >= '" . $general["sw"]["lng"] . "' AND lng <= '180') OR (lng >= '-180' AND lng <= '" . $general["ne"]["lng"] . "') )";
	} else {
		$select .= " AND lng >= '" . $general["sw"]["lng"] . "' AND lng <= '" . $general["ne"]["lng"] . "'";
	}
	
	//	$result = sql_exec("SELECT id, ref_id, lat, lng FROM gmap_markers WHERE $select");
	$lat_col = "FLOOR( (lat - " . $general["sw"]["lat"] . ") / " . $general["zx_step"] . ") as x";
	$lng_col = "IF( lng < ". $general["sw"]["lng"] . ", FLOOR((lng - " . $general["sw"]["lng"] . " + 360) / " . $general["zy_step"] . "), FLOOR((lng - " . $general["sw"]["lng"] . ") / " . $general["zy_step"] . ") ) as y"; "   FLOOR( (lat - " . $general["sw"]["lat"] . ") / " . $general["zx_step"] . ") as x";
	 
	$query = "SELECT id, ref_id, lat, lng, $lat_col, $lng_col FROM gmap_markers WHERE $select ORDER BY created_date DESC";
	//echo "query: " . $query;
	$result = sql_exec($query);
	
	$gmarkers = gmarkers_format();
	$cnt = cnt_format();
	while( $row = fetch_row($result)) {
		$idx = $row["x"] * $general["zy"] + $row["y"];
		
		//$gmarkers[$idx]["id_list"] 	.= ($gmarkers[$idx]["id_list"]==""?"":",") . $row["id"];
		$gmarkers[$idx]["total"]= $gmarkers[$idx]["total"] + 1;

		if($zones[$idx]["showAll"]=="true" || $gmarkers[$idx]["total"]==1) {
			//echo "midx:" . $cnt[$idx] . "  id:" . $row["id"]; 
			$gmarkers[$idx]["markers"][$cnt[$idx]]["id"] 		= $row["id"];
			$gmarkers[$idx]["markers"][$cnt[$idx]]["ref_id"] 	= $row["ref_id"];
			$gmarkers[$idx]["markers"][$cnt[$idx]]["zidx"] 		= $idx;
			$gmarkers[$idx]["markers"][$cnt[$idx]]["lat"] 		= $row["lat"];
			$gmarkers[$idx]["markers"][$cnt[$idx]]["lng"] 		= $row["lng"];
			$cnt[$idx]++;
		}
	}
	
	//echo jEncode($gmarkers);
	$response["data"]["markers"] = $gmarkers;
	$response["errorCode"] = 0;
	echo jEncode( $response );

} else {
	$response["errorCode"] 		= $err_msg[0];
	$response["errorMessage"] 	= $err_msg[1];
	$response["errorField"] 	= $err_msg[2];
	echo jEncode( $response );
}
exit();

function cnt_format() {
	$tmp_zones = $_REQUEST["zones"];
	$tmp_cnt = array();
	foreach($tmp_zones as $i=>$theZone) {
		$tmp_cnt[$i] =0;
	}
	return $tmp_cnt;
}
function gmarkers_format() {
	$tmp_zones = $_REQUEST["zones"];
	$tmp_gmarkers = array();
	foreach($tmp_zones as $i=>$theZone) {
		$tmp_gmarkers[$i] 						= array();
		$tmp_gmarkers[$i]["total"] 		= 0;
		$tmp_gmarkers[$i]["zidx"] 		= $i;
		$tmp_gmarkers[$i]["markers"]	= array();
	}
	return $tmp_gmarkers;
}

?>