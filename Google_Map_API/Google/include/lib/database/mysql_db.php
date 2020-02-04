<?php
// oracle9i_db.php - main module for Oracle access functions
function sql_open() {
	global $mysql_link;
	global $CFG;
	$mysql_link = mysql_connect($CFG["mysql"]["host"], $CFG["mysql"]["user"], $CFG["mysql"]["pwd"]); 
	if($mysql_link) {
		mysql_select_db( $CFG["mysql"]["database"], $mysql_link );
	} else {
		echo "Error:" .  mysql_errno($mysql_link);
		//echo "<pre>";
		//print_r($CFG);
		//echo "</pre>";
		return false;
	}	
	//echo "<br>sql open:" . $mysql_link . "<br>";
	return $mysql_link;

}

function sql_close() {
	global $mysql_link;
	if (isset($mysql_link)) mysql_close($mysql_link);
	//echo "<br>sql close:" . $mysql_link . "<br>";
}


function sql_query($query) {
	global $mysql_link;
	$result = mysql_query($query, $mysql_link);
	if(!$result) {
		echo "\nError: " .  mysql_errno($mysql_link) . " -- \nMessage: " . mysql_error($mysql_link) . " -- \nQuery: [[[" . $query . "]]]";
		return false; 
	}
	return $result;
}

function sql_exec($query) {
	global $mysql_link;
	sql_open();
	$result = mysql_query($query, $mysql_link);
	if(!$result) {
		echo "\nError: " .  mysql_errno($mysql_link) . " -- \nMessage: " . mysql_error($mysql_link) . " -- \nQuery: [[[" . $query . "]]]";
		sql_close();
		return false; 
	} else {
		sql_close();
		return $result;
	}
}

function fetch_row($result) {
	return mysql_fetch_assoc($result);
}

function row_count($result) {
	return mysql_num_rows($result);
}

function col_count($result) {
	return mysql_num_fields($result);
}

function fetch_fields( $result ) {
	$fields = array();
	$i = 0;
	while ( $i < col_count($result) ) {
		$finfo = mysql_fetch_field($result, $i);
		$field = array();
        $field["name"] =  $finfo->name;
        $field["table"] =  $finfo->table;
        $field["len"] =  $finfo->length;
        $field["flag"] =  $finfo->flags;
        $field["type"] =  $finfo->type;
		$fields[] = $field;
		$i++;	
	}
	return $fields;
}

function fetch_cols( $result ) {
	$fields = array();
	$i = 0;
	while ( $i < col_count($result) ) {
		$finfo = mysql_fetch_field($result, $i);
		$fields[] = $finfo->name;
		$i++;	
	}
	return $fields;
}


function is_exist($sql) {
	$result = sql_exec($sql);
	if( row_count($result) > 0 ) { 
		return true;
	} else { 
		return false;
	}
}

function get_value($table_name, $field, $id) {
	$result = sql_exec("select $field from $table_name where id = '" . $id . "'");
	$row = fetch_row($result);
	return $row[$field];	
}

function get_value_1($table_name, $field, $cfield, $value) {
	$result = sql_exec("select $field from $table_name where $cfield = '" . $value . "'");
	$row = fetch_row($result);
	return $row[$field];	
}

function get_value_2($table_name, $field, $criteria) {
	$result = sql_exec("select $field from $table_name where $criteria");
	$row = fetch_row($result);
	return $row[$field];	
}

// Smart Quote
function smart_quote($val) {
	global $mysql_link;
	sql_open();
	$new_val = mysql_real_escape_string( $val, $mysql_link );
	sql_close();
	return $new_val; 
}

function smart_oquote($val) {
	global $mysql_link;
	$new_val = mysql_real_escape_string( $val, $mysql_link );
	return $new_val;
}

function un_quote($val) {
 	return str_replace(array("\'", '\"'), array("'", '"'), $val);
}

function un_quoteHTML($val) {
 	return str_replace(array("\'", '\"', " ", "\n", "\r"), array("'", '"', "&nbsp;&nbsp;", "<br />" , "<br />"), $val);
}

// Table Insert Update
function table_insert($table, $field_array) {
	sql_open();
	$fields = "";
	$values = "";
	foreach($field_array as $key=>$val) {
		$fields .= ($fields==""?$key: ", " . $key); 
		if($val == "<<<null>>>") {
			$values .= ($values==""?"''" : ", ''"); 
		} else {
			$values .= ($values==""?"'" . $val . "'" : ", '" . $val . "'"); 
		}
	}
	$query = "INSERT INTO " . $table . " (" . $fields . ") VALUES (" . $values . ")";
	//echo "\nquery:" . $query;
	sql_query($query);
	$insert_id = mysql_insert_id();
	sql_close();
	return $insert_id;
}

function table_oinsert($table, $field_array) {
	$fields = "";
	$values = "";
	foreach($field_array as $key=>$val) {
		$fields .= ($fields==""?$key: ", " . $key); 
		if($val == "<<<null>>>") {
			$values .= ($values==""?"''" : ", ''"); 
		} else {
			$values .= ($values==""?"'" . $val . "'" : ", '" . $val . "'"); 
		}
	}
	$query = "INSERT INTO " . $table . " (" . $fields . ") VALUES (" . $values . ")";
	//echo "\nquery:" . $query;
	sql_query($query);
	$insert_id = mysql_insert_id();
	return $insert_id;
}

function table_update($table, $id , $field_array) {
	$fields_update = "";
	foreach($field_array as $key=>$val) {
		if($val == "<<<null>>>") {
			$fields_update .= ($fields_update==""?$key . " = ''" : ", " . $key . " = ''");
		} else {
			$fields_update .= ($fields_update==""?$key . " = '" . $val . "'" : ", " . $key . " = '" . $val . "'");
		}
	}	
	$query = "UPDATE " . $table . " SET " . $fields_update . " WHERE id = '" . $id . "'";
	sql_exec($query);
}

function table_oupdate($table, $criteria , $field_array) {
	$fields_update = "";
	foreach($field_array as $key=>$val) {
		if($val == "<<<null>>>") {
			$fields_update .= ($fields_update==""?$key . " = ''" : ", " . $key . " = ''");
		} else {
			$fields_update .= ($fields_update==""?$key . " = '" . $val . "'" : ", " . $key . " = '" . $val . "'");
		}
	}	
	$query = "UPDATE " . $table . " SET " . $fields_update . " WHERE id = '" . $id . "'";
	sql_query($query);
}

function table_delete($table, $id) {
	$query = "DELETE FROM " . $table . " WHERE id = '" . $id . "'";
	sql_exec($query);
}

function table_odelete($table, $id) {
	$query = "DELETE FROM " . $table . " WHERE id = '" . $id . "'";
	sql_query($query);
}
?>
