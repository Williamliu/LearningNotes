<?
$CFG = array();
// domain name   and file path
$CFG["web_path"] 		= $_SERVER['DOCUMENT_ROOT'];
$CFG["web_domain"] 		= $_SERVER['HTTP_HOST'];
$CFG["admin_path"] 		= $_SERVER['DOCUMENT_ROOT'] . "/admin/";
$CFG["admin_domain"] 	= $_SERVER['HTTP_HOST'] . "/admin/";
$CFG["include_path"] 	= substr( $CFG["web_path"],0, strripos($CFG["web_path"], "/") ) . "/include";


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//    MySQL Connection Information 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
define("LIVE", "live");
define("BETA", "beta");

define("ENVIR", BETA);
switch(ENVIR) {
	case BETA:
		$CFG["mysql"]["host"] = "localhost";
		$CFG["mysql"]["database"]  = "usanacit_product";
		$CFG["mysql"]["user"] = "usanacit_dbuser";
		$CFG["mysql"]["pwd"] = "usana$011225";
		break;

	case LIVE:
		$CFG["mysql"]["host"] = "localhost";
		$CFG["mysql"]["database"]  = "usanacit_product";
		$CFG["mysql"]["user"] = "usanacit_dbuser";
		$CFG["mysql"]["pwd"] = "usana$011225";
		break;
}
?>