
var zlevels = [];
zlevels[1] = { x: 10, y: 10 };
zlevels[2] = { x: 10, y: 10 };
zlevels[3] = { x: 10, y: 10 };
zlevels[4] = { x: 10, y: 10 };
zlevels[5] = { x: 10, y: 10 };
zlevels[6] = { x: 10, y: 10 };
zlevels[7] = { x: 10, y: 10 };
zlevels[8] = { x: 10, y: 10 };
zlevels[9] = { x: 10, y: 10 };
zlevels[10] = { x: 10, y: 10 };
zlevels[11] = { x: 10, y: 10 };
zlevels[12] = { x: 10, y: 10 };
zlevels[13] = { x: 10, y: 10 };
zlevels[14] = { x: 10, y: 10 };
zlevels[15] = { x: 10, y: 10 };
zlevels[16] = { x: 10, y: 10 };
zlevels[17] = { x: 10, y: 10 };
zlevels[18] = { x: 10, y: 10 };
zlevels[19] = { x: 10, y: 10 };


var gmap;
var gzones;
var gmap_window;
var gmarkers = [];
var gmap_msg = "";


var gxline = [];
var gyline = [];

$(function(){
	var gmap_center = new google.maps.LatLng(49.25, -123.10);
	var myOptions = {
		backgroundColor: "#cccccc",
		draggable: true,
		zoom: 10,
		center: gmap_center,
		mapTypeId: google.maps.MapTypeId.TERRAIN,
		mapTypeControlOptions: { mapTypeIds: google.maps.MapTypeId.SATELLITE|google.maps.MapTypeId.HYBRID|google.maps.MapTypeId.ROADMAP|google.maps.MapTypeId.TERRAIN},
		maxZoom: 21,
		minZoom: 1,
		disableDoubleClickZoom: true
	};
	gmap = new google.maps.Map( $("#div_gmap").get()[0] ,myOptions);
	gzones = new LWH.GZONES_Class({
									map: gmap,
									zlevels: zlevels,
									showLines: 	false,
									showAll: 	false
								});


	
	gmap_window = new google.maps.InfoWindow({
						disableAutoPan:	true,
						pixelOffset: 	google.maps.Size(-20,-20)
						});
	
	google.maps.event.addListener(gmap, "mousemove", function(ev){
		map_msg(ev);
	});

	google.maps.event.addListener(gmap, "zoom_changed", function(){
		map_msg(null);
	});

	google.maps.event.addListener(gmap, "dragend", function(){
		map_msg(null);
	});

	google.maps.event.addListener(gmap, "click", function(ev){
		var latLng = {}
		latLng.lat = ev.latLng.lat();
		latLng.lng = ev.latLng.lng();
		maker_add( latLng );
	});

	google.maps.event.addListener(gmap, "idle", function(){
		map_init();
		//$("#wait").LHide();
		map_msg(null);
	});


	$(".mk_delete").live("click", function(ev){
			var do_yes = window.confirm("Delete this marker, are you sure?");
			if(do_yes) {
				var id 		= $(this).attr("id");
				var ref_id 	= $(this).attr("ref_id"); 
				var zidx 	= $(this).attr("zidx"); 
				var midx 	= $(this).attr("midx"); 
				//gmap_window.close();	
				if( id == "-1" ) { alert("Marker update not done yet, try again later"); return; } 
				/*
				alert( 
						"id:" + id + "\n" + 
						"zidx:" + zidx + "\n" + 
						"midx:" + midx + "\n" + 
						"ref_id:" + ref_id
				);					
				*/
				gmarkers[zidx].markers[midx].marker.setMap(null);
				google.maps.event.clearListeners( gmarkers[zidx].markers[midx].marker, "click");
				gmarkers[zidx].markers[midx].marker	= null;
				gmarkers[zidx].markers[midx] 		= null;
				gmarkers[zidx].total--;
	
				$.ajax({
					data:	{
								marker: {	
											id: id
										}
							},
					error: function(xhr, tStatus, errorTh ) {
						alert("Error(ajax/lwh_delete_marker.php): " + xhr.responseText + "\nStatus: " + tStatus);
					},
					success: function(req, tStatus) {
						if( req.errorCode > 0 ) { 
							$.showError(req);
							return false;
						} else {
							//alert("delete done");
						}
					},
					dataType: 	"json",  
					type: 		"post",
					url:  		"ajax/lwh_delete_marker.php"
				});
				$("#div_marker").DHide();
			}
	});


});

function map_msg(ev) {
		gmap_msg = 	"[ZOOM: (" + gmap.getZoom() + ")]<br>";
		if(zlevels[gmap.getZoom()]) gmap_msg +=	"[ZONE: (" + zlevels[gmap.getZoom()].x + " X " + zlevels[gmap.getZoom()].y + ")]<br>";
		gmap_msg +=	"[Center-Lat: (" 	+ gmap.getCenter().lat() + 	") Lng: ("	+ 	gmap.getCenter().lng() + ")]<br>";
		gmap_msg +=	"[Bounds SW-Lat: (" 	+ gmap.getBounds().getSouthWest().lat() + ") Lng: (" 	+ 	gmap.getBounds().getSouthWest().lng() + ")]<br>";
		gmap_msg +=	"[Bounds NE-Lat: (" 	+ gmap.getBounds().getNorthEast().lat() + ") Lng: (" 	+ 	gmap.getBounds().getNorthEast().lng() + ")]<br>";
		gmap_msg += "[Bounds Center: (" 	+ gmap.getBounds().getCenter().lat() 	 + ") Lng: (" 	+ 	gmap.getBounds().getCenter().lng() + ")]<br>";
		if(ev) gmap_msg += "[Mouse--Lat: (" 	+ ev.latLng.lat() + 	") Lng: ("	+ 	ev.latLng.lng() + ")]";
		$("#msg").html( gmap_msg );
}

function map_init() {
	gzones.init();
	gmarkers_init();
}

function gmarkers_clear() {
		for(var i = 0; i < gmarkers.length; i++) { 
			if(gmarkers[i].markers) {
				for(var j = 0; j < gmarkers[i].markers.length; j++) {
					if( gmarkers[i].markers[j] && gmarkers[i].markers[j].marker ) {
						gmarkers[i].markers[j].marker.setMap(null);
						gmarkers[i].markers[j] = null;
					}
				} 
				gmarkers[i] = null;
			}
		}
		gmarkers = [];
}


function gmarkers_draw() {
	for( var i = 0; i < gzones.zones.length; i++ ) {
		// 1111111111111111111111111111111111111111
		if( gzones.zones[i].showAll ) {
				for( var j = 0; j < gmarkers[i].markers.length; j++) {
					if(gmarkers[i].markers[j]){
						gmarkers[i].markers[j].marker = new google.maps.Marker({
								animation: 	google.maps.Animation.DEFAULT,
								clickable: 	true,
								draggable: 	true,
								map: 		gmap,
								position: 	new google.maps.LatLng( gmarkers[i].markers[j].lat, gmarkers[i].markers[j].lng),
								title:		"ID:" + gmarkers[i].markers[j].id.toString() + 
											" RID:" + + gmarkers[i].markers[j].ref_id.toString()
						});
						marker_drag(gmarkers[i].markers[j]);
						marker_click(i, j);
					}
				}
		} else {
				if( gmarkers[i].total == 1 ) {
						gmarkers[i].markers[0].marker = new google.maps.Marker({
								animation: 	google.maps.Animation.DEFAULT,
								clickable: 	true,
								draggable: 	true,
								map: 		gmap,
								position: 	new google.maps.LatLng( gmarkers[i].markers[0].lat, gmarkers[i].markers[0].lng),
								title:		"ID:" + gmarkers[i].markers[0].id.toString() + 
											" RID:" + + gmarkers[i].markers[0].ref_id.toString()
						});
						marker_drag(gmarkers[i].markers[0]);
						marker_click(i, 0);
				}
				
				if( gmarkers[i].total > 1 ) {
						gmarkers[i].markers[0].marker = new google.maps.Marker({
								animation: 	google.maps.Animation.DEFAULT,
								clickable: 	true,
								draggable: 	false,
								map: 		gmap,
								position: 	new google.maps.LatLng( gzones.zones[i].ce.lat, gzones.zones[i].ce.lng),
								//icon: 		"https://chart.googleapis.com/chart?chst=d_map_spin&chld=0.8|0|FFFF42|13|b|" + gmarkers[i].total.toString(),
								icon: 		"https://chart.googleapis.com/chart?chst=d_bubble_text_small_withshadow&chld=bb|" + gmarkers[i].total.toString() + "|FFBB00|000000",
								title:		gmarkers[i].total.toString()
						});
						gmarker_click(i, 0);
				}
		}
		
	}
}


function gmarkers_init() {
		$.ajax({
			data:{ 
						general: 	gzones.general,					
						zones:		gzones.zones
				 },
			error: function(xhr, tStatus, errorTh ) {
				alert("Error(ajax/lwh_get_marker.php): " + xhr.responseText + "\nStatus: " + tStatus);
			},
			success: function(req, tStatus) {
				if( req.errorCode > 0 ) { 
					$.showError(req);
					return false;
				} else {
					gmarkers_clear();
					gmarkers = req.data.markers;
					gmarkers_draw();
				}
			},
			dataType: 	"json",  
			type: 		"post",
			url:  		"ajax/lwh_get_marker.php"
		});
}

function gmarkers_delete_all() {
	map_init();
	$.ajax({
			data:	{},
			error: function(xhr, tStatus, errorTh ) {
				alert("Error(ajax/lwh_delete_all_markers.php): " + xhr.responseText + "\nStatus: " + tStatus);
			},
			success: function(req, tStatus) {
				if( req.errorCode > 0 ) { 
					$.showError(req);
					return false;
				} else {
				}
			},
			dataType: 	"json",  
			type: 		"post",
			url:  		"ajax/lwh_delete_all_markers.php"
	});
}


function marker_drag(theMarker) {
	google.maps.event.addListener( theMarker.marker, "dragend", function(ev) {
		theMarker.marker.setMap(null);
		google.maps.event.clearListeners( theMarker.marker, "dragend");
		theMarker.marker = null;
		
		var latLng = {};
		latLng.lat = ev.latLng.lat();
		latLng.lng = ev.latLng.lng();
		
		gmarkers[theMarker.zidx].total--;
		marker_draw( latLng, "drag", theMarker.id, theMarker.ref_id);

		$.ajax({
			data:	{
						marker: {	
									id: theMarker.id,
									lat: latLng.lat,
									lng: latLng.lng
								}
					},
			error: function(xhr, tStatus, errorTh ) {
				alert("Error(ajax/lwh_update_marker.php): " + xhr.responseText + "\nStatus: " + tStatus);
			},
			success: function(req, tStatus) {
				if( req.errorCode > 0 ) { 
					$.showError(req);
					return false;
				} else {
					//alert("drag done");
				}
			},
			dataType: 	"json",  
			type: 		"post",
			url:  		"ajax/lwh_update_marker.php"
		});
		theMarker = null;
	});
}

function marker_click(zidx, midx) {
	$("a", $("#marker_info")).attr("id", gmarkers[zidx].markers[midx].id );
	$("a", $("#marker_info")).attr("ref_id", gmarkers[zidx].markers[midx].ref_id);
	$("a", $("#marker_info")).attr("zidx",zidx);
	$("a", $("#marker_info")).attr("midx",midx);
	
	var html = $("#marker_info").html();
	google.maps.event.clearListeners(gmarkers[zidx].markers[midx].marker, "click");
	google.maps.event.addListener( gmarkers[zidx].markers[midx].marker, "click", function(ev) {
		//gmap_window.setContent(html + "<br>ID:" + gmarkers[zidx].markers[midx].id);
		//gmap_window.open(gmap,gmarkers[zidx].markers[midx].marker);
		$(".lwhDialog-content").html("<b>ID:</b> " + gmarkers[zidx].markers[midx].id + "<br><b>Notes:</b> we can use this marker ID to retrieve the data from database" +
									  "<br><b>Information:</b> djfakjdl skdfjaskdfjkasj ajsdfkjdsfkjkdsljfkasjd kasdjfkasdj kasjdf asdjk jdflkasd dkjfaksj kdjfkdjs;lj dfkjasdljfljdfk kjsdfkjas;ljla;dsjfk asd dkfjadsl kjdfla;j kljkljdfkljdskl jkjdfkdjk jdfk" +
									  "<br><br>" + html
									);
		$("#div_marker").DShow();
	});
}

function gmarker_click(zidx, midx) {
	google.maps.event.clearListeners(gmarkers[zidx].markers[midx].marker, "click");
	google.maps.event.addListener( gmarkers[zidx].markers[midx].marker, "click", function(ev) {
		var center = new google.maps.LatLng( gzones.zones[zidx].ce.lat, gzones.zones[zidx].ce.lng );
		gmap.setCenter( center );
		gmap.setZoom( gmap.getZoom() + 1);
	});
}


function maker_add( latLng ) {
		var tmp = marker_draw( latLng, "add", -1, -1 );
		$.ajax({
			data:	{ 
						marker:		{ 
										zidx:	tmp.zidx,
										midx:	tmp.midx,
										lat: 	latLng.lat, 
										lng: 	latLng.lng 
									}
					},
			dataType: "json",  
			error: function(xhr, tStatus, errorTh ) {
				alert("Error(ajax/lwh_add_marker.php): " + xhr.responseText + "\nStatus: " + tStatus);
			},
			success: function(req, tStatus) {
				if( req.errorCode > 0 ) { 
					$.showError(req);
					return false;
				} else {
					marker_set_title( req.data.zidx, req.data.midx, "ID:" + req.data.id + " RID:" + req.data.ref_id);
					marker_set_id( req.data.zidx, req.data.midx, req.data.id, req.data.ref_id);
					marker_click(req.data.zidx, req.data.midx);
				}
			},
			type: "post",
			url:  "ajax/lwh_add_marker.php"
		});
}


function marker_draw( latLng, action, id, ref_id ) {
	var midx;
	var x = Math.floor( (latLng.lat - gzones.general.sw.lat) / gzones.general.zx_step );
	var y = Math.floor( lngDist(latLng.lng, gzones.general.sw.lng) / gzones.general.zy_step );
	var zidx = x * gzones.general.zy + y;
	
	gmarkers[zidx].total = parseInt(gmarkers[zidx].total) + 1;

	if( gzones.zones[zidx].showAll ) {
			midx = gmarkers[zidx].markers.length;
			market_reset(zidx, midx, latLng, "single", action, id, ref_id);
	} else {
			if( gmarkers[zidx].total == 1 ) {
							midx = 0;
							market_reset(zidx, midx, latLng, "single", action, id, ref_id);
			}
			if( gmarkers[zidx].total > 1 ) {
						midx = 0;
						market_reset(zidx, midx, gzones.zones[zidx].ce, "group", action, -1, -1);
						
						midx = 1;
						market_reset(zidx, midx, latLng, "single", action, id, ref_id);
						
						setTimeout( function() {
							if(gmarkers[zidx].markers[1])
								if( gmarkers[zidx].markers[1].marker ) 
									gmarkers[zidx].markers[1].marker.setMap(null); 
						}, 2000 );
						
			} 
	}
	return {zidx:zidx, midx:midx};
}

function market_reset( zidx, midx, latLng, type, action, id , ref_id) {
	if( gmarkers[zidx].markers[midx] ) {
		if( gmarkers[zidx].markers[midx].marker) gmarkers[zidx].markers[midx].marker.setMap(null);
	} else {
		gmarkers[zidx].markers[midx] = {};
	}
	gmarkers[zidx].markers[midx].lat 	= latLng.lat;
	gmarkers[zidx].markers[midx].lng 	= latLng.lng;
	gmarkers[zidx].markers[midx].id 	= id;
	gmarkers[zidx].markers[midx].ref_id	= ref_id;
	gmarkers[zidx].markers[midx].zidx	= zidx;
	gmarkers[zidx].markers[midx].marker	= null;
	
	switch(type) {
		case "group":
			gmarkers[zidx].markers[midx].marker = new google.maps.Marker({
						animation: 	google.maps.Animation.DEFAULT,
						clickable: 	true,
						draggable: 	false,
						map: 		gmap,
						position: 	new google.maps.LatLng( 
															gmarkers[zidx].markers[midx].lat, 
															gmarkers[zidx].markers[midx].lng
															),
						//icon: 		"https://chart.googleapis.com/chart?chst=d_map_spin&chld=0.8|0|FFFF42|13|b|" + gmarkers[zidx].total.toString(),
						icon: 		"https://chart.googleapis.com/chart?chst=d_bubble_text_small_withshadow&chld=bb|" + gmarkers[zidx].total.toString() + "|FFBB00|000000",
						title:		gmarkers[zidx].total.toString()
			});					
			gmarker_click(zidx, midx);
			break;
		case "single":
			var title = '';
			if( gmarkers[zidx].markers[midx].id 	!= "-1" ) title += "ID:" + gmarkers[zidx].markers[midx].id;  
			if( gmarkers[zidx].markers[midx].ref_id!= "-1" ) title += (title==""?"":" ") + "RID:" + gmarkers[zidx].markers[midx].ref_id; 
			
			var map_ani = google.maps.Animation.DEFAULT;
			if( action == "add" ) map_ani = google.maps.Animation.DROP;
			
			gmarkers[zidx].markers[midx].marker = new google.maps.Marker({
							animation: 	map_ani,
							clickable: 	true,
							draggable: 	true,
							map: 		gmap,
							position: 	new google.maps.LatLng( 
																	gmarkers[zidx].markers[midx].lat, 
																	gmarkers[zidx].markers[midx].lng
																),
							title:	title
			});	
			marker_drag(gmarkers[zidx].markers[midx]);
			marker_click(zidx, midx);
			break;
	}
}

function marker_set_title( zidx, midx, title ) {
	if( gmarkers[zidx].markers[midx] ) {
		if( gmarkers[zidx].markers[midx].marker) gmarkers[zidx].markers[midx].marker.setTitle(title);
	}
}

function marker_set_id( zidx, midx, id, ref_id ) {
	if( gmarkers[zidx].markers[midx] ) {
		gmarkers[zidx].markers[midx].id 	= id;
		gmarkers[zidx].markers[midx].ref_id	= ref_id;
	}
}

function marker_set_latLng( zidx, midx, latLng ) {
	if( gmarkers[zidx].markers[midx] ) {
		gmarkers[zidx].markers[midx].lat = latLng.lat;
		gmarkers[zidx].markers[midx].lng = latLng.lng;
	}
}
