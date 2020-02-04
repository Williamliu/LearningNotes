<?php
//  xml parser  to array
$level = 0;
$xml_tags = array();

$xml_array = array();
$xml_count = array();

function XMLparser($xml_text) {
		global $level;
		global $xml_tags;
		global $xml_tags_tmp;
		global $xml_array;
		global $xml_count;
		$level = 0;
		$xml_tags = array();
		$xml_tags_tmp = array();
		$xml_array = array();
		$xml_count = array();

//		$xml_text = str_replace(array(chr(10),chr(13),"\n","\r","\t", "&amp;"), array("","","","","","[[[amp]]]"), $xml_text);
//		$xml_text = eregi_replace(">"."[[:space:]]+"."<","><",$xml_text);
		$xml_text = preg_replace('/>\s+</i',"><",$xml_text);
		PreXMLparser( $xml_text);

		$xml_pr = xml_parser_create();
		xml_parser_set_option($xml_pr, XML_OPTION_TARGET_ENCODING, "UTF-8");		
		xml_set_element_handler($xml_pr,"tag_start","tag_end");
		xml_set_character_data_handler($xml_pr, "el_data");
		xml_parse($xml_pr,$xml_text);
		
		xml_parser_free($xml_pr);
		return $xml_array;
}

function tag_start($xml_parser, $name, $attr) {
	static $tmp_count = 0;
	global $level;
	global $xml_tags;
	global $xml_tags_tmp;
	global $xml_array;
	global $xml_count;
	global $xml_pre_array;
	$level++;
	if( count($attr) > 0 ) {
		$tmp_name = ""; 
		foreach($attr as $kk1 => $vv1) {
			$tmp_name .= ($tmp_name==""?"":"_") . $vv1; 
		}
		$xml_tags[$level] = strtolower('["' .  $name . '"]' . '["' .  $tmp_name . '"]');
	} else { 
		// to identify the XML tags have multiple children or not 		
		$xml_count[$level][$name]++;
		$xml_tags_tmp[$level] = strtolower('["' . $name . '"]');
		$key = '';
		for($k=1;$k<=$level;$k++) {
			$key .=  $xml_tags_tmp[$k];
		}
		$xml_tags_tmp[$level] = strtolower('["' . $name . '"]' . '["' . $xml_count[$level][$name] . '"]');

		eval('$flag_array =  $xml_pre_array' . $key . ';');
		if ( count($flag_array) > 1 )   //  if multiple children,  then add array to it .  otherwise  set value to it
			$xml_tags[$level] = strtolower('["' . $name . '"]' . '["' . ( $xml_count[$level][$name] - 1 ) . '"]');
		else 
			$xml_tags[$level] = strtolower('["' . $name . '"]["0"]');
	}
}

function tag_end($xml_parser, $name) {
	global $level;
	$level--;
}

function el_data($xml_parser, $val) {
	global $level;
	global $xml_tags;
	global $xml_array;
	

	$key = '';
	for($k=1;$k<=$level;$k++) {
		$key .=  $xml_tags[$k];
	}
	//$val = str_replace("[[[amp]]]", "&amp;", $val);
	$temp = '$xml_array' . $key . ' = $val;';
	eval($temp);
}

//  Pre Parse to get XML structure and  element's count
$xml_pre_tags = array();
$xml_pre_array = array();
$xml_pre_count = array();
function PreXMLparser($xml_text) {
		global $level;
		global $xml_pre_tags;
		global $xml_pre_array;
		global $xml_pre_count;
		$level = 0;
		$xml_pre_tags = array();
		$xml_pre_array = array();
		$xml_pre_count = array();

//		$xml_text = str_replace(array(chr(10),chr(13),"\n","\r","\t", "&amp;"), array("","","","","","[[[amp]]]"), $xml_text);
//		$xml_text = eregi_replace(">"."[[:space:]]+"."<","><",$xml_text);
        $xml_text = preg_replace('/>\s+</i',"><",$xml_text);
		$xml_pr = xml_parser_create();
		xml_parser_set_option($xml_pr, XML_OPTION_TARGET_ENCODING, "UTF-8");		
		xml_set_element_handler($xml_pr,"pre_tag_start","pre_tag_end");
		xml_set_character_data_handler($xml_pr, "pre_el_data");
		xml_parse($xml_pr,$xml_text);
		xml_parser_free($xml_pr);
		return $xml_pre_array;
}

function pre_tag_start($xml_parser, $name, $attr) {
	global $level;
	global $xml_pre_tags;
	global $xml_pre_count;

	$level++;
	if( count($attr) > 0 ) {
		$tmp_name = ""; 
		foreach($attr as $kk1 => $vv1) {
			$tmp_name .= ($tmp_name==""?"":"_") . $vv1; 
		}
		$xml_pre_tags[$level] = strtolower('["' .  $name . '"]' . '["' .  $tmp_name . '"]');
	} else { 
		$xml_pre_count[$level][$name]++;
		$xml_pre_tags[$level] = strtolower('["' . $name . '"]'. '["' . $xml_pre_count[$level][$name] . '"]');
	}
}

function pre_tag_end($xml_parser, $name) {
	global $level;
	$level--;
}

function pre_el_data($xml_parser, $val) {
	global $level;
	global $xml_pre_tags;
	global $xml_pre_array;
	$key = '';
	for($k=1;$k<=$level;$k++) {
		$key .=  $xml_pre_tags[$k];
	}
	$temp = '$xml_pre_array' . $key . '="1";';
	eval($temp);
}

// xml Object
class xmlObject {
	var $xml_array;
	public function __construct($xml_arr) {
	   $this->xml_array = $xml_arr;
	}
	public function show() {
		echo "<pre>";
		print_r($this->xml_array);
		echo "</pre>";
	}
	public function nodes( $node_path ) {
		$nodes = array();
		$path = explode("=>",$node_path);
		if( $path != "" ) {		
			$newArray = $this->xml_array;
			for($i  = 0 ; $i < count($path); $i++) {
				if( $i < (count($path) - 1) ) {
					$newArray = $newArray[$path[$i]]["0"];
				} else {
					$newArray = $newArray[$path[$i]];
				}
			}
			if( is_array( $newArray ) ) {
				foreach( $newArray as $key=>$val ) {
					$nodes[$key] = new xmlObject($val);			
				}
			}
		}
		return $nodes;
	}
	
	public function nodeValue( $node_path ) {
		$path = explode("=>",$node_path);
		if( $path != "" ) {
			$newArray = $this->xml_array;
			for($i  = 0 ; $i < count($path); $i++) {
					$newArray = $newArray[$path[$i]]["0"];
			}
			return $newArray?$newArray:"";
		} else {
			return "";	
		}
	}
}
?>
