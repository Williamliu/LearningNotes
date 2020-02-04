// display do not support  "table" , "line-table" 
$.fn.extend({
	lwhScrollbar : function( opts ) {
			var def_settings = {
							resizable:		false,
							hscroll:		true,
							vscroll:		true
					  };
			$.extend(def_settings, opts);
			
			return this.each( function(idx, el0) { 
				var me_id = $(el0).attr("id");
				var el_me = "#" + me_id;
				$(el0).wrap('<div id="lwh-sframe-'+ me_id +'"></div>');
				var jSframe = "#lwh-sframe-" + me_id;
				$(jSframe).data("default_settings", def_settings);
				$(jSframe).attr("style", $(el_me).attr("style"));
				$(jSframe).css({
							display:	($(jSframe).css("display").indexOf("table")<0?$(jSframe).css("display"):"block"),
							position:	"relative",
							overflow:	"hidden"
				});
				
				$(el0).wrap('<div id="lwh-scontent-' + me_id + '" class="lwh-plugin-scrollbar-content">');				
				var jScontent = "#lwh-scontent-" + me_id;
				$(el0).css({
					position: 	"relative",
					width:		"auto",
					height:		"auto",
					padding:	"2px",
					margin:		"0px",
					border:		"0px",
					overflow:	"hidden",
					display:	def_settings.hscroll?"table":"block"
				})			

				var hscroll_html = '<div id="hs-bar" class="lwh-plugin-hscroll">' +
									'<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">' +
									'<tr><td id="hs-left"></td>' +
									'<td id="hs-center" valign="middle" align="left"><div id="hs-center-bar"></div></td>' + 
									'<td id="hs-right"></td><td id="hs-corner"></td></tr>' +
									'</table></div>';
									
				var vscroll_html = '<div id="vs-bar" class="lwh-plugin-vscroll">' +
									'<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%">' + 
									'<tr><td id="vs-top"></td></tr>' + 
									'<tr><td id="vs-middle" align="center" valign="top"><div id="vs-middle-bar"></div></td></tr>' +
									'<tr><td id="vs-bottom"></td></tr>' +
									'<tr><td id="vs-corner"></td></tr>' + 
									'</table></div>';
									
				$(jSframe).append(hscroll_html);
				$(jSframe).append(vscroll_html);
				
				// resizable 
				if(def_settings.resizable) $(jSframe).resizable();
				$(jSframe).resize(function(){
					$.scroll_visible(jSframe, el_me);
				});

				$(el_me).resize(function(){
					$.scroll_visible(jSframe, el_me);
				});

				// mousewheel event
				$(jSframe).mousewheel( function(ev, pos) {
					if(pos > 0 ) {
						$(jScontent).scrollTop($(jScontent).scrollTop()-20);
					} else {
						$(jScontent).scrollTop($(jScontent).scrollTop()+20);
					}
					$.scroll_visible(jSframe, el_me);
					return false;
				});

				// horizontal and vertical bar drag 
				$("#vs-middle-bar", jSframe).draggable({
					axis: "y",
					containment:"parent",
					drag: function(ev, ui) {
						$.drag_vgoing(jSframe, el_me, ui.position.top);
					}
				});
				$("#hs-center-bar", jSframe).draggable({
					axis: "x",
					containment:"parent",
					drag: function(ev, ui) {
						$.drag_hgoing(jSframe, el_me, ui.position.left);
					} 
				});

				// click event
				$("#vs-top", jSframe).live("click", function() {
					$(jScontent).scrollTop($(jScontent).scrollTop()-20);
					$.scroll_vgoing(jSframe, el_me);
				});
				
				$("#vs-middle", jSframe).live("click", function(ev) {
					var hit_top = ev.clientY - $(this).offset().top;
					var new_top;
					if( hit_top > 	parseInt( $("#vs-middle-bar", this).css("top") ) ) {
					 	new_top = 	parseInt( $("#vs-middle-bar", this).css("top") ) + 40;
					} else {
					 	new_top = 	parseInt( $("#vs-middle-bar", this).css("top") ) - 40;
					}
					if( new_top < 0 ) new_top = 0;
					var vs_length 	= $(this).height() - $("#vs-middle-bar",this).outerHeight();
					if( new_top > vs_length ) new_top = vs_length; 
					
					$("#vs-middle-bar", this).css("top", new_top );
					$.drag_vgoing(jSframe, el_me, new_top);
					return false;
				});

				$("#vs-bottom", jSframe).live("click", function() {
					$(jScontent).scrollTop($(jScontent).scrollTop()+40);
					$.scroll_vgoing(jSframe, el_me);
				});


				$("#hs-left", jSframe).live("click", function() {
					$(jScontent).scrollLeft($(jScontent).scrollLeft()-40);
					$.scroll_hgoing(jSframe, el_me);
				});

				$("#hs-center", jSframe).live("click", function(ev) {
					var hit_left = ev.clientX - $(this).offset().left;
					var new_left;
					if( hit_left > 	parseInt( $("#hs-center-bar", 	this).css("left") ) ) {
					 	new_left = 	parseInt( $("#hs-center-bar",	this).css("left") ) + 20;
					} else {
					 	new_left = 	parseInt( $("#hs-center-bar", 	this).css("left") ) - 20;
					}
					if( new_left < 0 ) new_left = 0;
					var hs_length 	= $(this).width() - $("#hs-center-bar",this).outerWidth();
					if( new_left > hs_length ) new_left = hs_length; 
					
					$("#hs-center-bar", this).css("left", new_left );
					$.drag_hgoing(jSframe, el_me, new_left);
					return false;
				});

				$("#hs-right", jSframe).live("click", function() {
					$(jScontent).scrollLeft($(jScontent).scrollLeft()+20);
					$.scroll_hgoing(jSframe, el_me);
				});

				
				// initalize the status bar
				$.scroll_visible(jSframe , el_me);
			});
	}
});


$.extend({
		scroll_visible: function( el0, el1) {
			var def_settings = $(el0).data("default_settings");
			//alert($.showObj(def_settings));
			if( $(el0).width() < $(el1).outerWidth() ) {
				if( def_settings.hscroll ) { 
						$(el1).css("padding-bottom", 20);
						$("#hs-bar", el0).show();
						$("#vs-corner", el0).height(15);
						var new_width = Math.ceil( $(el0).width() / $(el1).outerWidth() * $("#hs-center-bar", el0).parent().width() );
						new_width = new_width<20?20:new_width;
						new_width = $("#hs-center-bar", el0).parent().width()<=20?$("#hs-center-bar", el0).parent().width()-5:new_width;
						if( new_width > 5 ) {
							$("#hs-center-bar", el0).show();
							$("#hs-center-bar", el0).width( new_width );
							$.scroll_hgoing(el0, el1);
						} else {
							$("#hs-center-bar", el0).hide();
						}
				} else {
						$("#hs-bar", el0).hide();
						if( def_settings.resizable ) $("#vs-corner", el0).height(15); else $("#vs-corner", el0).height(0);
						$(el1).css("padding-bottom", 2);
				}
			} else {
				$("#hs-bar", el0).hide();
				if( def_settings.resizable ) $("#vs-corner", el0).height(15); else $("#vs-corner", el0).height(0);
				$(el1).css("padding-bottom", 2);
			}
			
			if( $(el0).height() < $(el1).outerHeight() ) {
				if( def_settings.vscroll ) { 
						$(el1).css("padding-right", 20);
						$("#vs-bar", el0).show();
						$("#hs-corner", el0).width(15);
						var new_height = Math.ceil( $(el0).height() / $(el1).outerHeight() * $("#vs-middle-bar", el0).parent().height() );
						new_height = new_height < 20 ? 20: new_height;
						new_height = $("#vs-middle-bar",el0).parent().height()<=20?$("#vs-middle-bar", el0).parent().height()-5:new_height; 
						if( new_height > 5 ) {
							$("#vs-middle-bar", el0).show();
							$("#vs-middle-bar", el0).height( new_height );
							$.scroll_vgoing(el0, el1);
						} else {
							$("#vs-middle-bar", el0).hide();
						}
				} else {
						$("#vs-bar", el0).hide();
						if( def_settings.resizable ) $("#hs-corner", el0).width(15); else $("#hs-corner", el0).width(0);
						$(el1).css("padding-left", 2);
				}
			} else {
				$("#vs-bar", el0).hide();
				if( def_settings.resizable ) $("#hs-corner", el0).width(15); else $("#hs-corner", el0).width(0);
				$(el1).css("padding-left", 2);
				
			}
		},
		
		scroll_vgoing: function( el0, el1 ) {
			var vs_length 	= $(el1).outerHeight() - $(el0).height();
			var bar_length 	= $("#vs-middle-bar", el0).parent().height() - $("#vs-middle-bar", el0).outerHeight();
			var bar_top = Math.ceil( bar_length *  $(".lwh-plugin-scrollbar-content", el0).scrollTop() / vs_length );
			$("#vs-middle-bar", el0).css("top", bar_top);
			return false;
		},

		scroll_hgoing: function( el0, el1 ) {
			var hs_length 	= $(el1).outerWidth() - $(el0).width();
			var bar_length 	= $("#hs-center-bar", el0).parent().width() - $("#hs-center-bar", el0).outerWidth();
			var bar_left =  Math.ceil( bar_length *  $(".lwh-plugin-scrollbar-content", el0).scrollLeft() / hs_length );
			$("#hs-center-bar", el0).css("left", bar_left);
			return false;
		},
		
		drag_vgoing: function( el0, el1, ytop ) {
			var vs_length 	= $(el1).outerHeight() - $(el0).height();
			var bar_length 	= $("#vs-middle-bar", el0).parent().height() - $("#vs-middle-bar", el0).outerHeight();
			var scroll_top =  Math.ceil( ytop  * vs_length / bar_length );
			$(".lwh-plugin-scrollbar-content", el0).scrollTop(scroll_top);
		},

		drag_hgoing: function( el0, el1, xleft ) {
			var hs_length 	= $(el1).outerWidth() - $(el0).width();
			var bar_length 	= $("#hs-center-bar", el0).parent().width() - $("#hs-center-bar", el0).outerWidth();
			var scroll_left =  Math.ceil( xleft  * hs_length / bar_length );
			$(".lwh-plugin-scrollbar-content", el0).scrollLeft(scroll_left);
		}
});
