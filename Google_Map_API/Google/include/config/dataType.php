<?php
$dataType = array(
"ANYTHING"		=> "(.*)", // all chars
//"CHAR"			=> "^[^<>]*$", // not allow to use "<>"  prevent from broke web page .  like "<html>" or any tags.
"CHAR"			=> "(.*)", // not allow to use "<>"  prevent from broke web page .  like "<html>" or any tags.
"EMAIL"			=> "^[a-z0-9]+([-_.]{0,1}[a-z0-9]+)*@[a-z0-9]+([-.]{0,1}[a-z0-9]+)*(\.)([a-z]{2,7})$", //Email :  abd_dkkd.dkfd-dkd@hotmail.adk-dkdk.gc.ca
"DATE"			=> "^([0-9]{4}-[0-9]{1,2}-[0-9]{1,2})$",  //2007-10-31  or 97-12-31
"TIME"			=> "^([0-9]{1,2}(:[0-5]{1}[0-9]{1}(:[0-5]{1}[0-9]{1})?)?[ ]*(am|pm)?)$", // 2pm , 13:01:56AM , 13:25pm 
"DATETIME"		=> "^([0-9]{4}-[0-9]{1,2}-[0-9]{1,2}[ ]+[0-9]{1,2}(:[0-5]{1}[0-9]{1}(:[0-5]{1}[0-9]{1})?)?[ ]*(am|pm)?)$", //1997-04-25 13pm    2007-4-25 10:00am
"NUMBER"		=> "^[-0-9.]*$",  // 3.1414, -34,  -3.143
"LETTER"			=> "^[a-z0-9]+$", //Email :  abd_dkkd.dkfd-dkd@hotmail.adk-dkdk.gc.ca
);

$default_length = array(	
"ANYTHING"		=> 16, 
"CHAR"			=> 16, 
"EMAIL"			=> 255, 
"DATE"			=> 10, 
"TIME"			=> 11, 
"DATETIME"		=> 22, 
"NUMBER"		=> 11,
"LETTER"		=> 6,
);

$err_char = array(
"ANYTHING"		=> "All charater was allowed.", // all chars
"CHAR"			=> "Not allow these characters : '<' , '>' ", // not allow to use "<>"  prevent from broke web page .  like "<html>" or any tags.
"EMAIL"			=> "Email format must be like xxxx@xxx.xxx , xxxx@xxx.xxx.xxx ", //Email :  abd_dkkd.dkfd-dkd@hotmail.adk-dkdk.gc.ca0-9]{4}-[0-9]{1,2}-[0-9]{1,2})$",  //2007-10-31  or 97-12-31
"TIME"			=> "Format as 2:00, 2pm, 9:01:56am, 13:25pm", // 2pm , 9:01:56AM , 13:25pm 
"DATE"			=> "Format as 1997-04-25, yyyy-mm-dd", //1997-04-25 13pm    2007-4-25 10:00am
"DATETIME"		=> "Format as 1997-04-25 13pm, 2007-4-25 10:00am", //1997-04-25 13pm    2007-4-25 10:00am
"NUMBER"		=> "Just number charater allowed.",  // 3.1414, -34,  -3.143
"LETTER"		=> "Letters and numbers only.",  // 3.1414, -34,  -3.143
);

function verify_fields($fields) {
	global $default_length, $dataType, $err_char;	
	if(0) {echo "<br>Array from Posted<pre>"; print_r($_REQUEST); echo "</pre>";}
	$return_info[0] = 0;
	$return_info[1] = "";
	$return_info[2] = "";
	
	foreach($fields as $key=>$val) {
		$field_name = $key;
		$tmp = explode("|", $val);
		$field_type = strpos($tmp[0],"(")?substr($tmp[0], 0 , strpos($tmp[0],"(")):$tmp[0];
		$field_size = strpos($tmp[0],"(")?substr($tmp[0], strpos($tmp[0],"(") + 1, strpos($tmp[0],")") - strpos($tmp[0],"(") -1):$default_length[$field_type];
		$field_element = $tmp[1];
		$field_name_ui = $tmp[2];
		$field_null = $tmp[3];
		
		$value = trim($_REQUEST[$field_name]);
		 
		if(strtoupper($field_null) == "NOT NULL") {
			if(strlen($value) == 0) {
				$return_info[0] = 1;
				$return_info[1] .= "The '" . $field_name_ui . "' field is required.\n";
				$return_info[2] = $return_info[2]==""?$field_element:$return_info[2];
			}
		}

		if( $field_size != 0 ) {
			if(strlen($value) > $field_size) {
					$return_info[0] = 1;
					$return_info[1] .= "Your input for the '" . $field_name_ui . "' field exceeds the maximum allowed length (" . $field_size . " chars).\n";
					$return_info[2] = $return_info[2]==""?$field_element:$return_info[2];
			}
		}

		if(!eregi($dataType[$field_type], $value) && $value != "") {
				$return_info[0] = 1;
				$return_info[1] .= "Your input for the '" . $field_name_ui . "' field contains invalid characters or an invalid format.\n";
				$return_info[1] .= "   ( Reference: " . $err_char[$field_type] . " )\n";
				$return_info[2] = $return_info[2]==""?$field_element:$return_info[2];
		}
		//echo "field_name:" . $field_name . "   field_type:" . $field_type . "   field_size:" . $field_size . "   element:" . $field_element .  "   null:" . $field_null . "  ";
	}
	if($return_info[1] != "") $return_info[1] = "Sorry, we are unable to process your input for the following reasons:\n\n" . $return_info[1];
	return $return_info;
}

function datetoint($date) {
	if(strpos($date, ":") != false) {
		$d_t = explode(" ", $date);
		$date = $d_t[0];
		$time = $d_t[1];
		$APM = $d_t[2];
	} else {
		$time = "";
	}
	if(strpos($date, "/") != false) {
		$sp = "/";
		$count = substr_count($date,"/");
	} elseif(strpos($date, "-") != false) {
		$sp = "-";
		$count = substr_count($date, "-");
	} else {
		return "";
	}
	$a = explode($sp, $date);
	$b = explode(":", $time);
	if(strtoupper($APM) == "PM") $b[0] += 12;
	//return  "Year:" . $a[0] . "  month:" . $a[1] . " day:" . $a[2] . " hour:" . $b[0] . " minutes:" . $b[1] ;
	switch (count($a)){
		case 0:
			return "";
			break;
		case 1:
			if(count($b) == 1) {return mktime($b[0],$b[1],0,0,0,$a[0]);}
			else {return mktime(0,0,0,0,0,$a[0]);}
			break;
		case 2:
			if(count($b) == 2) {return mktime($b[0],$b[1],0,$a[1],0,$a[0]);}
			else {return mktime(0,0,0,$a[1],0,$a[0]);}
			break;
		case 3:
			if(count($b) == 3) {return mktime($b[0],$b[1],0,$a[1],$a[2],$a[0]);}
			else {return mktime(0,0,0,$a[1],$a[2],$a[0]);}
			break;
		default:
			return "";
	}
}

function dateinrange($start_time, $end_time) {
	$ok = true;
	if($start_time != "" && $start_time !=0) {
		if( $start_time <= time() ) {
			$ok = true;
		} else {
			$ok = false;
		}
	}
	
	if($ok) {
		if($end_time != "" && $end_time !=0) {
			if( $end_time >= time() ) {
				$ok = true;
			} else {
				$ok = false;
			}
		}
	}
	return $ok;
}

function datediff($end_time, $start_time) {
	$time_dd = floor(($end_time - $start_time )/(3600 * 24));
	$time_hh = floor( fmod( $end_time - $start_time , 3600 * 24 ) / 3600 );
	$time_mm = ceil(fmod($end_time - $start_time, 3600) / 60);
	
    $left_dd =  $time_dd > 0? $time_dd	. ' days ':'';
	$left_hh =  $left_dd==""?( $time_hh > 0?$time_hh . ' hrs ':''):$left_dd . $time_hh . ' hrs ';
	$left_mm =  $left_hh==""?( $time_mm > 0?$time_mm  . ' mins':''):$left_hh . $time_mm  . ' mins';
	
	return $left_mm;
}

function inttodate($dint, $format="Y-m-d G:i:s T") {
	if($dint > 0) return date($format, $dint); else return "";
}

function inttodate1($dint, $format="Y-m-d") {
	if($dint > 0) return date($format, $dint); else return "";
}

function inttodate2($dint, $format="F j, Y") {
	if($dint > 0) return date($format, $dint); else return "";
}

function inttodate3($dint, $format="M jS, Y") {
	if($dint > 0) return date($format, $dint); else return "";
}

function inttodate4($dint, $format="Y-m-d H:i:s") {
	if($dint > 0) return date($format, $dint); else return "";
}
?>
