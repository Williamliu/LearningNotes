var LWH	 = {};

LWH.GZONES_Class = function( opts ) {
	this.def = {
			map: 		null,
			zlevels: 	[],
			showLines: 	true,
			showAll:	false
	};
	$.extend(this.def, opts);
	
	// object variable here 
	this.map 		= this.def.map;
	this.showLines	= this.def.showLines;
	this.zlevels	= this.def.zlevels;

	this.general	= {};  // the map info: sw, ne, ce , zone_x, zone_y,  x_dist, y_dist, x_step, y_step
	this.zones		= [];  // the zone info: sw, ne, ce , x, y
	this.xlines		= [];  // draw polyline  for lat
	this.ylines		= [];  // drap polyline  for lng
	// present object with self
	var self = this;
	
	//object public method
	this.init	= function () {
		general_init();
		zones_init();
		draw_lines();
	}
	//private method here 
	var general_init = function() {
		self.general = {};
		if( self.map ) {
			self.general.sw = {};
			self.general.sw.lat = self.map.getBounds().getSouthWest().lat();
			self.general.sw.lng = self.map.getBounds().getSouthWest().lng();
			
			self.general.ne = {};
			self.general.ne.lat = self.map.getBounds().getNorthEast().lat();
			self.general.ne.lng = self.map.getBounds().getNorthEast().lng();
			
			self.general.ce = {};
			self.general.ce.lat = self.map.getBounds().getCenter().lat();
			self.general.ce.lng = self.map.getBounds().getCenter().lng();
			
			self.general.zx = 1;
			self.general.zy = 1;
			self.general.zx_dist 	= self.general.ne.lat - self.general.sw.lat;
			self.general.zy_dist 	= lngDist(self.general.ne.lng, self.general.sw.lng);
			
			var zoom_level = self.map.getZoom();
			
			if( self.zlevels[zoom_level] ) { 
						self.general.zx = self.zlevels[zoom_level].x;
						self.general.zy = self.zlevels[zoom_level].y;
						self.general.showAll	= self.def.showAll;
			} else {
						self.general.showAll	= true;
			}
			self.general.zx_step = self.general.zx_dist / self.general.zx;
			self.general.zy_step = self.general.zy_dist / self.general.zy;
		}
	}
	
	var zones_init = function() {
		self.zones = [];
		if( self.map ) {
			var ce_lats = [];
			for(var i = 0; i < self.general.zx; i++) {
				ce_lats[i] = self.general.sw.lat + self.general.zx_step * i + self.general.zx_step / 2;
			}
			
			var ce_lngs = [];
			for(var j = 0; j < self.general.zy; j++) {
				ce_lngs[j] = toLng( self.general.sw.lng + self.general.zy_step * j + self.general.zy_step / 2);
				
			}

			for(var i = 0; i < self.general.zx; i++) {
				for(var j = 0; j < self.general.zy; j++) {
					var sw_lat = ce_lats[i] - self.general.zx_step / 2;
					var ne_lat = ce_lats[i] + self.general.zx_step / 2;
					
					var sw_lng = toLng( ce_lngs[j] - self.general.zy_step / 2 );
					var ne_lng = toLng( ce_lngs[j] + self.general.zy_step / 2 );
					
					var zidx = i * self.general.zy + j;
					self.zones[zidx] = {};
					self.zones[zidx].zidx = zidx;
					self.zones[zidx].x = i + 1;
					self.zones[zidx].y = j + 1;
					
					self.zones[zidx].showAll = self.general.showAll;
					
					self.zones[zidx].sw = {};
					self.zones[zidx].sw.lat = sw_lat;
					self.zones[zidx].sw.lng = sw_lng;
					
					self.zones[zidx].ne = {};
					self.zones[zidx].ne.lat = ne_lat;
					self.zones[zidx].ne.lng = ne_lng;

					self.zones[zidx].ce = {};
					self.zones[zidx].ce.lat = ce_lats[i];
					self.zones[zidx].ce.lng = ce_lngs[j];
					
				}
			}
		}
	}
	
	var draw_lines = function() {
		// clear lines on the map
		if( self.map ) {
				for(var i = 0; i < self.xlines.length; i++) { 
					if( self.xlines[i] ) {
						self.xlines[i].setMap(null); 
						self.xlines[i] = null;
					}
				}
				self.xlines.length = 0;

				for(var i = 0; i < self.ylines.length; i++) { 
					if( self.ylines[i] ) {
						self.ylines[i].setMap(null); 
						self.ylines[i] = null;
					}
				}
				self.ylines.length = 0;
		}
		
		var zoom_level = self.map.getZoom();
		if( self.map && self.showLines && self.zlevels[zoom_level] ) {
				//111111111111111111111111111111111111111
				for(var i = 1; i < self.general.zx; i++) {
					var xline_lat = self.general.sw.lat + self.general.zx_step * i;
					var xline_latlng =	[
											new google.maps.LatLng(xline_lat ,self.general.sw.lng),
											new google.maps.LatLng(xline_lat ,self.general.ne.lng)
										];
					self.xlines[i] = new google.maps.Polyline({
							map: 			self.map,
							clickable: 		false,
							geodesic: 		false,
							strokeColor: 	"red",
							strokeOpacity: 	1,
							strokeWeight: 	0.25,
							path:			xline_latlng
					});
				}

				for(var j = 1; j < self.general.zy; j++) {
					var yline_lng = toLng(self.general.sw.lng + self.general.zy_step * j);
					var yline_latlng =	[
											new google.maps.LatLng(self.general.sw.lat, yline_lng),
											new google.maps.LatLng(self.general.ne.lat, yline_lng)
										];
					self.ylines[j] = new google.maps.Polyline({
							map: 			self.map,
							clickable: 		false,
							geodesic: 		false,
							strokeColor: 	"red",
							strokeOpacity: 	1,
							strokeWeight: 	0.25,
							path:			yline_latlng
					});
				}
				// 1111111111111111111111111111111111111
		}

	}
	// end of private method
	
	
	var _constructor = function() {
	};
	_constructor();
}
