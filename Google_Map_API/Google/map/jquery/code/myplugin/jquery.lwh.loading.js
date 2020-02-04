$.fn.extend({
	lwhLoading:function( opts ){
		var def_settings = {
								container: 	""
						 	};
		$.extend(def_settings, opts);
		return this.each( function(idx, el) { 
			$(el).data("default_settings", def_settings);

			if($("#mask_ifrm_" + $(el).attr("id") ).length <= 0 ) 
				$(document.body).append('<iframe id="mask_ifrm_' + $(el).attr("id") + '" style="position:absolute; border:1px solid #eeeeee; width:0px; height:0px; left:-2000px; top:-2000px; z-index:99990; display:none;"></iframe>');
			
			if($("#mask_div_" + $(el).attr("id") ).length <= 0 ) 
				$(document.body).append('<div id="mask_div_' + $(el).attr("id") + '" style="position:absolute; border:1px solid #eeeeee; width:0px height:0px; left:-2000px; top:-2000px; z-index:99991; display:none;"></div>');
			

			if($("#loading_img_" + $(el).attr("id") ).length <= 0 ) 
				$(document.body).append('<div id="loading_img_' + $(el).attr("id") + '" class="lwh-pluging-loading">LOADING...<br><div class="lwh-pluging-loading-img"></div></div>');
				
			$("#loading_img_" + $(el).attr("id")).corner({
				  tl: { radius: 20 },
				  tr: { radius: 20 },
				  bl: { radius: 20 },
				  br: { radius: 20 }
			});

			// window resize function
			var container = window;
			if( def_settings.container != "") container = def_settings.container;					

			$(container).resize(function(){ 
				if( !$("#loading_img_" + $(el).attr("id")).is(":hidden") ) {
						var container 			= window;
						var container_left		= $(container).scrollLeft();
						var container_top		= $(container).scrollTop();
						var container_width		= $(container).width() + 16;
						var container_height	= $(container).height() - 4;

						if( def_settings.container != "") {
								container = def_settings.container;
								container_left	= $(container).offset().left;
								container_top	= $(container).offset().top;
								container_width	= $(container).width();
								container_height= $(container).height();
						} 

						var el_width 	= $("#loading_img_" + $(el).attr("id")).width();
						var el_height 	= $("#loading_img_" + $(el).attr("id")).height();
						var el_left 	= container_left + ( container_width - el_width ) / 2;
						var el_top 		= container_top	 + ( container_height- el_height) / 2;
						if(def_settings.left) 	el_left = container_left + def_settings.left;
						if(def_settings.top) 	el_top 	= container_top	 + def_settings.top;
						if( el_left <= 0 ) 	el_left = 5;
						if( el_top 	<= 0 ) 	el_top	= 5;
						
						$("#mask_ifrm_" + $(el).attr("id")).stop(true, true).delay(500).animate({
													left: 	container_left,
													top: 	container_top,
													width:	container_width, 
													height: container_height
											 	 }, 50 ) ;					

						$("#mask_div_" + $(el).attr("id")).stop(true, true).delay(500).animate({
													left: 	container_left,
													top: 	container_top,
													width:	container_width, 
													height: container_height
											  	}, 50 ) ;					
					  
						$("#loading_img_" + $(el).attr("id")).stop(true, true).delay(500).animate({
													left: 	el_left,
													top: 	el_top
								  	 			}, 50 );	
				}
			});
			

			$(container).scroll(function(){ 
					var container 			= window;
					var container_left		= $(container).scrollLeft();
					var container_top		= $(container).scrollTop();
					var container_width		= $(container).width() + 16;
					var container_height	= $(container).height() - 4;
					
					if( def_settings.container != "") {
							container = def_settings.container;
							container_left	= $(container).offset().left;
							container_top	= $(container).offset().top;
							container_width	= $(container).width();
							container_height= $(container).height();
					} 

					if( !$("#mask_div_" + $(el).attr("id") ).is(":hidden") ) {
							$("#mask_ifrm_" + $(el).attr("id") ).stop(true, true).delay(500).animate({
													left: 	container_left,
													top: 	container_top
												  }, 50 ) ;					
							$("#mask_div_" + $(el).attr("id") ).stop(true, true).delay(500).animate({
													left: 	container_left,
													top: 	container_top
												  }, 50 ) ;					
					}
			
					if( !$("#loading_img_" + $(el).attr("id")).is(":hidden") ) {
							var el_width 	= $("#loading_img_" + $(el).attr("id")).width();
							var el_height 	= $("#loading_img_" + $(el).attr("id")).height();
							var el_left		= container_left + (container_width - el_width ) / 2;
							var el_top 		= container_top  + (container_height- el_height) / 2;
							if(def_settings.left) 	el_left = container_left + def_settings.left;
							if(def_settings.top) 	el_top 	= container_top	+ def_settings.top;
							$("#loading_img_" + $(el).attr("id")).stop(true, true).delay(500).animate({
													left: 	el_left,
													top: 	el_top
										 		},  	50);	
					}
			}); // end of $(container).scroll
		});
	},
	
	LShow:function(){
		return this.each( function(idx, el) {
				var def_settings = $(el).data("default_settings");

				var container 			= window;
				var container_left		= $(container).scrollLeft();
				var container_top		= $(container).scrollTop();
				var container_width		= $(container).width() + 16;
				var container_height	= $(container).height() - 4;

				if( def_settings.container != "") {
						container = def_settings.container;
						container_left	= $(container).offset().left;
						container_top	= $(container).offset().top;
						container_width	= $(container).width();
						container_height= $(container).height();
				} 

				var el_width 	= $("#loading_img_" + $(el).attr("id")).width();
				var el_height 	= $("#loading_img_" + $(el).attr("id")).height();
				var el_left 	= container_left + ( container_width - el_width ) / 2;
				var el_top 		= container_top	 + ( container_height- el_height) / 2;
				if(def_settings.left) 	el_left = container_left + def_settings.left;
				if(def_settings.top) 	el_top 	= container_top	 + def_settings.top;
				if( el_left <= 0 ) 	el_left = 5;
				if( el_top 	<= 0 ) 	el_top	= 5;

				$("#mask_ifrm_" + $(el).attr("id")).css({
						backgroundColor:"#000000",
						opacity: 0.3,
						width: 	container_width,
						height: container_height,
						left: 	container_left,
						top: 	container_top
				});

				$("#mask_div_" + $(el).attr("id")).css({
						backgroundColor:"#000000",
						opacity: 0.3,
						width: 	container_width,
						height: container_height,
						left: 	container_left,
						top: 	container_top
				});
				$("#mask_div_" + $(el).attr("id")).stop(true, true).delay(500).fadeIn(100);
				$("#mask_ifrm_" + $(el).attr("id")).stop(true, true).delay(500).fadeIn(100);
			

				$("#loading_img_" + $(el).attr("id")).css({
						left: el_left,
						top:  el_top
				});
				$("#loading_img_" + $(el).attr("id")).stop(true, true).delay(500).fadeIn(100);
		});
	},
	
	LHide:function(){
		return this.each( function(idx, el) {
				$("#mask_div_" + $(el).attr("id")).stop(true, true).delay(500).fadeOut(200);
				$("#mask_ifrm_" + $(el).attr("id")).stop(true, true).delay(500).fadeOut(200);
				$("#loading_img_" + $(el).attr("id")).stop(true, true).delay(500).fadeOut(200);
			
				$("#mask_ifrm_" + $(el).attr("id")).css({
						display: "none",
						width: 0,
						height: 0,
						left: -2000,
						top: -2000
				});

				$("#mask_div_" + $(el).attr("id")).css({
						display: "none",
						width: 0,
						height: 0,
						left: -2000,
						top: -2000
				});
			
				$("#loading_img_" + $(el).attr("id")).css({
						display: "none",
						left: -2000,
						top: -2000
				});
		});
	}
});
