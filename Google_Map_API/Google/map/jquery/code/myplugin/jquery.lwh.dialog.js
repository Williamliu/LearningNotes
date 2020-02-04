$.fn.extend({
	lwhDialog:function( opts ){
		var def_settings = {
								container: 	"",
								btn_close: 	"",
								icon_close: true,
								maskclick: 	false,
								resizable: 	false,
								cornerable: true,
								css: {
											border:			"1px solid #333333", 
											backgroundColor:"#eeeeee", 
											position:		"absolute", 
											padding:		8, 
											left:			-2000, 
											top:			-2000, 
											display:		"none", 
											zIndex:			9999,
											verticalAlign: 	"top",
											width: 			500,
											height: 		300,
											textAlign: 		"center"
									},
								corner: {
									tl: { radius: 20 },
									tr: { radius: 20 },
									bl: { radius: 20 },
									br: { radius: 20 }
								},
								minWidth: 		500,
								minHeight: 		300,
								zIndex: 		9000,
								resize_start: 	function(){},
								resize_end: 	function(){},
								dialog_start:	function(){},
								dialog_end: 	function(){}
						 };
		
		var main_css;
		if($.isPlainObject(opts)) main_css = $.extend(def_settings.css, opts.css);
		$.extend(def_settings, opts);
		if( main_css) def_settings.css = main_css;
		
		return this.each( function(idx, el) { 
			// initialize
			$(el).data("default_settings", def_settings);
			$(el).css(def_settings.css);

			$(".lwhDialog-content", $(el)).css({
						width: 	$(el).width() - 20,
						height: $(el).height() -60 
			});
			//end of initialize
			
			// corner and resizable
			if(def_settings.cornerable && !def_settings.resizable) {
				$(el).corner(def_settings.corner);
			}
			
			if(def_settings.resizable) {
				$(el).resizable({
					minWidth: 	def_settings.minWidth,
					minHeight: 	def_settings.minHeight,
					resize: function() {
						if( !$(el).is(":hidden") ) {
								$(".lwhDialog-content", $(el)).css({
											width: 	$(el).width() - 20,
											height: $(el).height() -60 
								});
								$(el).stop(true,true).queue("dialog_resize", function(){ def_settings.resize_start(); }).delay(500).dequeue("dialog_resize");
						}
					},
					stop: function() {
						if( !$(el).is(":hidden") ) {
							$(el).DShow();
							$(el).stop(true,true).queue("dialog_stop", function(){ def_settings.resize_end(); }).delay(500).dequeue("dialog_stop");
						}
					}
				});
			}
			// end of corner and resizable
			
			// append close button to dialog  and  append mask  to document
			// dialog close button and icon  ,  click event
			if(def_settings.icon_close && $("#mask_close_button_" + $(el).attr("id") ).length <= 0 )
					$(el).append('<div id="mask_close_button_' + $(el).attr("id") + '" class="lwhDialog_close_button"></div>');
			
			$( "#mask_close_button_" + $(el).attr("id") + "," + def_settings.btn_close ).live("click", function(ev) {
					if( !$("#mask_div_" + $(el).attr("id") ).is(":hidden") ) {
							$("#mask_div_" + $(el).attr("id") ).stop(true, true).fadeOut(200);
							$("#mask_ifrm_" + $(el).attr("id") ).stop(true, true).fadeOut(200);
							
							$("#mask_ifrm_" + $(el).attr("id") ).css({
								display: "none",
								width: 0,
								height: 0,
								left: -2000,
								top: -2000
							});
				
							$("#mask_div_" + $(el).attr("id") ).css({
								display: "none",
								width: 0,
								height: 0,
								left: -2000,
								top: -2000
							});
					}
			
					if( !$(el).is(":hidden") ) {
							$(el).stop(true, true).fadeOut(200);
							$(el).css({
								display: "none",
								left: -2000,
								top: -2000
							});
					}
					def_settings.dialog_end();
			});
			// end of close button  and close icon
			
			if($("#mask_ifrm_" + $(el).attr("id") ).length <= 0 ) 
					$(document.body).append('<iframe id="mask_ifrm_' + $(el).attr("id") + '" style="position:absolute; border:1px solid #eeeeee; width:0px; height:0px; left:-2000px; top:-2000px; z-index:' + (def_settings.zIndex + 1) + '; display:none;"></iframe>');
		
			if($("#mask_div_" + $(el).attr("id") ).length <= 0 ) 
					$(document.body).append('<div id="mask_div_' + $(el).attr("id") + '" style="position:absolute; border:1px solid #eeeeee; width:0px height:0px; left:-2000px; top:-2000px; z-index:' + (def_settings.zIndex + 2) + '; display:none;"></div>');
			
			// mask click to close
			if(def_settings.maskclick) {
				$("#mask_div_" + $(el).attr("id") ).live("click", function() {
						if( !$("#mask_div_" + $(el).attr("id") ).is(":hidden") ) {
								$("#mask_div_" + $(el).attr("id") ).fadeOut(200);
								$("#mask_ifrm_" + $(el).attr("id") ).fadeOut(200);
								
								$("#mask_ifrm_" + $(el).attr("id") ).css({
									display: "none",
									width: 0,
									height: 0,
									left: -2000,
									top: -2000
								});
					
								$("#mask_div_" + $(el).attr("id") ).css({
									display: "none",
									width: 0,
									height: 0,
									left: -2000,
									top: -2000
								});
						}
				
						if( !$(el).is(":hidden") ) {
								$(el).fadeOut(200);
								$(el).css({
									display: "none",
									left: -2000,
									top: -2000
								});
						}
						def_settings.dialog_end();
				});
			}
			
			// window resize function
			var container = window;
			if( def_settings.container != "") container = def_settings.container;					

			$(container).resize(function(){ 
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
													top: 	container_top,
													width:	container_width, 
													height: container_height
												  }, 50 ) ;					
						  $("#mask_div_" + $(el).attr("id") ).stop(true, true).delay(500).animate({
													left: 	container_left,
													top: 	container_top,
													width:	container_width, 
													height: container_height
												  }, 50 ) ;					
					}
			
					if( !$(el).is(":hidden") ) {
						var el_width 	= $(el).width();
						var el_height 	= $(el).height();
						var el_left 	= container_left	+	( container_width - el_width ) / 2;
						var el_top 		= container_top		+	( container_height- el_height) / 2;
						if(def_settings.left) 	el_left = container_left + def_settings.left;
						if(def_settings.top) 	el_top 	= container_top + def_settings.top;
						if( el_left <= 0 ) 	el_left = 5;
						if( el_top 	<= 0 ) 	el_top	= 5;
						
						if( container_width <= el_width) {
							el_width = container_width - 60;
							if(	el_width < def_settings.minWidth) {
								el_width = def_settings.minWidth;
								el_left = 5;
							} else {
								el_left = container_left + ( container_width - el_width ) / 2;
							}
							
							if(def_settings.cornerable && !def_settings.resizable) 
								$(el).width( el_width  + def_settings.corner.tl.radius );
							else 
								$(el).width( el_width );
						} 

						if( container_height <= el_height ) {
							el_height = container_height - 40;
							if(	el_height < def_settings.minHeight) {
								el_height = def_settings.minHeight;
								el_top	= 5;
							} else {
								el_top	= container_top	+ ( container_height- el_height ) / 2;							
							}
							
							if(def_settings.cornerable && !def_settings.resizable) 
								$(el).height( el_height + def_settings.corner.tl.radius );
							else 
								$(el).height( el_height );
						} 
		
						if(def_settings.cornerable && !def_settings.resizable) {
							el_width  = el_width - def_settings.corner.tl.radius;
							el_height = el_height - def_settings.corner.tl.radius;					
						}
						
						$(".lwhDialog-content", $(el)).css({
									width: 	el_width - 20,
									height: el_height -60 
						});

						$(el).stop(true, true).delay(500).animate({
												left:	el_left,
												top: 	el_top
										 },  	50);
					}
					
			}); // end of $(container).resize
			

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
			
					if( !$(el).is(":hidden") ) {
							var el_width 	= $(el).width();
							var el_height 	= $(el).height();
							var el_left		= container_left + (container_width - el_width ) / 2;
							var el_top 		= container_top  + (container_height- el_height) / 2;
							if(def_settings.left) 	el_left = container_left + def_settings.left;
							if(def_settings.top) 	el_top 	= container_top	+ def_settings.top;
							$(el).stop(true, true).delay(500).animate({
												left: 	el_left,
												top: 	el_top
										 },  	50);	
					}
			}); // end of $(container).scroll

		});// end of return this.each
	},
	
	
	DShow:function( opts ){
		var dialog_settings = {
			dialog_open: function() {}
		};
		$.extend(dialog_settings, opts);
		return this.each( function(idx, el) {
				dialog_settings.dialog_open();
				
				var def_settings = $(el).data("default_settings");
				
				var container 			= window;
				var container_left		= $(container).scrollLeft();
				var container_top		= $(container).scrollTop();
				var container_width		= $(container).width() 	+ 16;
				var container_height	= $(container).height() - 4;
				
				if( def_settings.container != "") {
						container = def_settings.container;
						container_left	= $(container).offset().left;
						container_top	= $(container).offset().top;
						container_width	= $(container).width();
						container_height= $(container).height();
				} 

				$("#mask_ifrm_" + $(el).attr("id") ).css({
					backgroundColor:"#000000",
					opacity: 0.3,
					width: 	container_width,
					height: container_height,
					left: 	container_left,
					top: 	container_top
				});
	
				$("#mask_div_" + $(el).attr("id") ).css({
					backgroundColor:"#000000",
					opacity: 0.3,
					width: 	container_width,
					height: container_height,
					left: 	container_left,
					top: 	container_top
				});
				$("#mask_div_" + $(el).attr("id") ).stop(true, true).fadeIn(100);
				$("#mask_ifrm_" + $(el).attr("id") ).stop(true,true).fadeIn(100);

				var el_width 	= $(el).width();
				var el_height 	= $(el).height();
				var el_left 	= container_left + ( container_width  - el_width ) / 2;
				var el_top 		= container_top  + ( container_height - el_height) / 2;
				// think about fix top , left
				if(def_settings.left) 	el_left = container_left + def_settings.left;
				if(def_settings.top) 	el_top 	= container_top	 + def_settings.top;
				// think about  out of boundary;
				if( el_left <= 0 ) 	el_left = 5;
				if( el_top 	<= 0 ) 	el_top	= 5;
			
				// think about resize to fix window
				if( container_width <= el_width) {
					el_width = container_width - 60;
					if( el_width < def_settings.minWidth) {
						el_width = def_settings.minWidth;
						el_left = 5;
					} else {
						el_left	= container_left + ( container_width  - el_width ) / 2;
					}
					$(el).width( el_width );
				} 

				if( container_height <= el_height ) {
					el_height = container_height - 40;
					if( el_height < def_settings.minHeight) {
						el_height = def_settings.minHeight;
						el_top	= 5;
					} else {
						el_top = container_top  + ( container_height - el_height) / 2;
					}
					$(el).height( el_height );
				} 
				
				// think about corner
				if(def_settings.cornerable && !def_settings.resizable) {
					el_width  = el_width - def_settings.corner.tl.radius;
					el_height = el_height - def_settings.corner.tl.radius;					
				}
				
				//alert("el width:" + $(el).width() + "  el_width:" + el_width);
				$(".lwhDialog-content", $(el)).css({
						width: 	el_width - 20,
						height: el_height -60 
				});
				
				$(el).css({
						left:el_left,
						top: el_top
				});

				$(el).stop(true, true).fadeIn(100);
				def_settings.dialog_start();
		});
	},
	
	DHide:function( opts ){
		var dialog_settings = {
			dialog_close: function() {}
		};
		$.extend(dialog_settings, opts);
		return this.each( function(idx, el) {
				dialog_settings.dialog_close();

				var def_settings = $(el).data("default_settings");

				$("#mask_div_" + $(el).attr("id") ).stop(true, true).fadeOut(200);
				$("#mask_ifrm_" + $(el).attr("id") ).stop(true, true).fadeOut(200);
				$(this).stop(true, true).fadeOut(200);
				
				$("#mask_ifrm_" + $(el).attr("id") ).css({
					display: "none",
					width: 0,
					height: 0,
					left: -2000,
					top: -2000
				});
	
				$("#mask_div_" + $(el).attr("id") ).css({
					display: "none",
					width: 0,
					height: 0,
					left: -2000,
					top: -2000
				});
				
				$(el).css({
					display: "none",
					left: -2000,
					top: -2000
				});
				def_settings.dialog_end();
		});
	}
});
