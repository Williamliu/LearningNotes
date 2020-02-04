String.prototype.replaceAll = function(s1, s2) {
	return this.replace(new RegExp(s1, "gm"), s2);
}

/*
Array.prototype.insertAt = function( index, value ) {
	var part1 = this.slice( 0, index );
	var part2 = this.slice( index );
	part1.push( value );
	return( part1.concat( part2 ) );
};

Array.prototype.removeAt = function( index )
{
	var part1 = this.slice( 0, index );
	var part2 = this.slice( index );
	part1.pop();
	return( part1.concat( part2 ) );
}
*/

/*******************************************************************************/
/* Google MAPS lng convert   												   */
/*******************************************************************************/
function toLng( lng ) {
	return lng>=180?(lng-360):lng;
}

function lngDist( ne, sw ) {
	return 	(ne < sw)?(ne + 360 - sw):(ne - sw);
}


/*******************************************************************************/
/* DOM Element Value 														   */
/*******************************************************************************/
function jel( el_id ) {
	return $.trim($("#" + el_id).val());
}

/*************************************************************************************/
/*  popUp Windows                                                                    */
/*************************************************************************************/
function popUp(URL, height, width) {
	if(height==null) height=600;
	if(width==null) width=800;
	window.open(URL, 'popUp', 'toolbar=0, scrollbars=0, location=0, statusbar=0, menubar=0, resizable=0, height=' + height + ', width=' + width + ', left=160, top=80');
}

$.extend({
	showError: function(req) {
		alert( req.errorMessage ); 
		$("#" + req.errorField ).focus();
		$("#" + req.errorField ).select();
	},

	showObj: function(obj) {
		var str = '';
		if( $.isPlainObject( obj ) || $.isArray( obj )  ) {
			for(var key in obj) {
				str += "{" + key + ":";
				str += $.showObj(obj[key]);
				str += "}\n";
			}
		} else {
			
			str += obj;
		}
		return str;
	}
});
