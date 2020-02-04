<?
$CFG = array();
// domain name   and file path
$CFG["web_path"] 		= $_SERVER['DOCUMENT_ROOT'];
$CFG["web_domain"] 		= $_SERVER['HTTP_HOST'];
$CFG["admin_path"] 		= $_SERVER['DOCUMENT_ROOT'] . "/admin/";
$CFG["admin_domain"] 	= $_SERVER['HTTP_HOST'] . "/admin/";
//$CFG["include_path"] 	= substr( $CFG["web_path"],0, strripos($CFG["web_path"], "/") ) . "/include";
$CFG["include_path"] 	= $CFG["web_path"] . "/include";


/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//    MySQL Connection Information 
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////
define("LIVE", "live");
define("BETA", "beta");

define("ENVIR", BETA);
switch(ENVIR) {
	case BETA:
		$CFG["mysql"]["host"] = "localhost";
		$CFG["mysql"]["database"]  = "tas_modAdmSysDev";
		$CFG["mysql"]["user"] = "tas_user";
		$CFG["mysql"]["pwd"] = "hPQLAq43tjqmft3b";
		break;

	case LIVE:
		$CFG["mysql"]["host"] = "localhost";
		$CFG["mysql"]["database"]  = "";
		$CFG["mysql"]["user"] = "";
		$CFG["mysql"]["pwd"] = "";
		break;
}
?>