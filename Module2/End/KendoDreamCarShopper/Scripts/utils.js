///#source 1 1 /Scripts/purl.js
/*
 * JQuery URL Parser plugin, v2.2.1
 * Developed and maintanined by Mark Perkins, mark@allmarkedup.com
 * Source repository: https://github.com/allmarkedup/jQuery-URL-Parser
 * Licensed under an MIT-style license. See https://github.com/allmarkedup/jQuery-URL-Parser/blob/master/LICENSE for details.
 */ 

;(function(factory) {
	if (typeof define === 'function' && define.amd) {
		// AMD available; use anonymous module
		if ( typeof jQuery !== 'undefined' ) {
			define(['jquery'], factory);	
		} else {
			define([], factory);
		}
	} else {
		// No AMD available; mutate global vars
		if ( typeof jQuery !== 'undefined' ) {
			factory(jQuery);
		} else {
			factory();
		}
	}
})(function($, undefined) {
	
	var tag2attr = {
			a       : 'href',
			img     : 'src',
			form    : 'action',
			base    : 'href',
			script  : 'src',
			iframe  : 'src',
			link    : 'href'
		},
		
		key = ['source', 'protocol', 'authority', 'userInfo', 'user', 'password', 'host', 'port', 'relative', 'path', 'directory', 'file', 'query', 'fragment'], // keys available to query
		
		aliases = { 'anchor' : 'fragment' }, // aliases for backwards compatability
		
		parser = {
			strict : /^(?:([^:\/?#]+):)?(?:\/\/((?:(([^:@]*):?([^:@]*))?@)?([^:\/?#]*)(?::(\d*))?))?((((?:[^?#\/]*\/)*)([^?#]*))(?:\?([^#]*))?(?:#(.*))?)/,  //less intuitive, more accurate to the specs
			loose :  /^(?:(?![^:@]+:[^:@\/]*@)([^:\/?#.]+):)?(?:\/\/)?((?:(([^:@]*):?([^:@]*))?@)?([^:\/?#]*)(?::(\d*))?)(((\/(?:[^?#](?![^?#\/]*\.[^?#\/.]+(?:[?#]|$)))*\/?)?([^?#\/]*))(?:\?([^#]*))?(?:#(.*))?)/ // more intuitive, fails on relative paths and deviates from specs
		},
		
		toString = Object.prototype.toString,
		
		isint = /^[0-9]+$/;
	
	function parseUri( url, strictMode ) {
		var str = decodeURI( url ),
		res   = parser[ strictMode || false ? 'strict' : 'loose' ].exec( str ),
		uri = { attr : {}, param : {}, seg : {} },
		i   = 14;
		
		while ( i-- ) {
			uri.attr[ key[i] ] = res[i] || '';
		}
		
		// build query and fragment parameters		
		uri.param['query'] = parseString(uri.attr['query']);
		uri.param['fragment'] = parseString(uri.attr['fragment']);
		
		// split path and fragement into segments		
		uri.seg['path'] = uri.attr.path.replace(/^\/+|\/+$/g,'').split('/');     
		uri.seg['fragment'] = uri.attr.fragment.replace(/^\/+|\/+$/g,'').split('/');
		
		// compile a 'base' domain attribute        
		uri.attr['base'] = uri.attr.host ? (uri.attr.protocol ?  uri.attr.protocol+'://'+uri.attr.host : uri.attr.host) + (uri.attr.port ? ':'+uri.attr.port : '') : '';      
		  
		return uri;
	};
	
	function getAttrName( elm ) {
		var tn = elm.tagName;
		if ( typeof tn !== 'undefined' ) return tag2attr[tn.toLowerCase()];
		return tn;
	}
	
	function promote(parent, key) {
		if (parent[key].length == 0) return parent[key] = {};
		var t = {};
		for (var i in parent[key]) t[i] = parent[key][i];
		parent[key] = t;
		return t;
	}

	function parse(parts, parent, key, val) {
		var part = parts.shift();
		if (!part) {
			if (isArray(parent[key])) {
				parent[key].push(val);
			} else if ('object' == typeof parent[key]) {
				parent[key] = val;
			} else if ('undefined' == typeof parent[key]) {
				parent[key] = val;
			} else {
				parent[key] = [parent[key], val];
			}
		} else {
			var obj = parent[key] = parent[key] || [];
			if (']' == part) {
				if (isArray(obj)) {
					if ('' != val) obj.push(val);
				} else if ('object' == typeof obj) {
					obj[keys(obj).length] = val;
				} else {
					obj = parent[key] = [parent[key], val];
				}
			} else if (~part.indexOf(']')) {
				part = part.substr(0, part.length - 1);
				if (!isint.test(part) && isArray(obj)) obj = promote(parent, key);
				parse(parts, obj, part, val);
				// key
			} else {
				if (!isint.test(part) && isArray(obj)) obj = promote(parent, key);
				parse(parts, obj, part, val);
			}
		}
	}

	function merge(parent, key, val) {
		if (~key.indexOf(']')) {
			var parts = key.split('['),
			len = parts.length,
			last = len - 1;
			parse(parts, parent, 'base', val);
		} else {
			if (!isint.test(key) && isArray(parent.base)) {
				var t = {};
				for (var k in parent.base) t[k] = parent.base[k];
				parent.base = t;
			}
			set(parent.base, key, val);
		}
		return parent;
	}

	function parseString(str) {
		return reduce(String(str).split(/&|;/), function(ret, pair) {
			try {
				pair = decodeURIComponent(pair.replace(/\+/g, ' '));
			} catch(e) {
				// ignore
			}
			var eql = pair.indexOf('='),
				brace = lastBraceInKey(pair),
				key = pair.substr(0, brace || eql),
				val = pair.substr(brace || eql, pair.length),
				val = val.substr(val.indexOf('=') + 1, val.length);

			if ('' == key) key = pair, val = '';

			return merge(ret, key, val);
		}, { base: {} }).base;
	}
	
	function set(obj, key, val) {
		var v = obj[key];
		if (undefined === v) {
			obj[key] = val;
		} else if (isArray(v)) {
			v.push(val);
		} else {
			obj[key] = [v, val];
		}
	}
	
	function lastBraceInKey(str) {
		var len = str.length,
			 brace, c;
		for (var i = 0; i < len; ++i) {
			c = str[i];
			if (']' == c) brace = false;
			if ('[' == c) brace = true;
			if ('=' == c && !brace) return i;
		}
	}
	
	function reduce(obj, accumulator){
		var i = 0,
			l = obj.length >> 0,
			curr = arguments[2];
		while (i < l) {
			if (i in obj) curr = accumulator.call(undefined, curr, obj[i], i, obj);
			++i;
		}
		return curr;
	}
	
	function isArray(vArg) {
		return Object.prototype.toString.call(vArg) === "[object Array]";
	}
	
	function keys(obj) {
		var keys = [];
		for ( prop in obj ) {
			if ( obj.hasOwnProperty(prop) ) keys.push(prop);
		}
		return keys;
	}
		
	function purl( url, strictMode ) {
		if ( arguments.length === 1 && url === true ) {
			strictMode = true;
			url = undefined;
		}
		strictMode = strictMode || false;
		url = url || window.location.toString();
	
		return {
			
			data : parseUri(url, strictMode),
			
			// get various attributes from the URI
			attr : function( attr ) {
				attr = aliases[attr] || attr;
				return typeof attr !== 'undefined' ? this.data.attr[attr] : this.data.attr;
			},
			
			// return query string parameters
			param : function( param ) {
				return typeof param !== 'undefined' ? this.data.param.query[param] : this.data.param.query;
			},
			
			// return fragment parameters
			fparam : function( param ) {
				return typeof param !== 'undefined' ? this.data.param.fragment[param] : this.data.param.fragment;
			},
			
			// return path segments
			segment : function( seg ) {
				if ( typeof seg === 'undefined' ) {
					return this.data.seg.path;
				} else {
					seg = seg < 0 ? this.data.seg.path.length + seg : seg - 1; // negative segments count from the end
					return this.data.seg.path[seg];                    
				}
			},
			
			// return fragment segments
			fsegment : function( seg ) {
				if ( typeof seg === 'undefined' ) {
					return this.data.seg.fragment;                    
				} else {
					seg = seg < 0 ? this.data.seg.fragment.length + seg : seg - 1; // negative segments count from the end
					return this.data.seg.fragment[seg];                    
				}
			}
	    	
		};
	
	};
	
	if ( typeof $ !== 'undefined' ) {
		
		$.fn.url = function( strictMode ) {
			var url = '';
			if ( this.length ) {
				url = $(this).attr( getAttrName(this[0]) ) || '';
			}    
			return purl( url, strictMode );
		};
		
		$.url = purl;
		
	} else {
		window.purl = purl;
	}

});


///#source 1 1 /Scripts/jQuery.cssParentSelector.js
/**
 * jQuery cssParentSelector 1.0.10
 * https://github.com/Idered/cssParentSelector
 *
 * Copyright 2011-2012, Kasper Mikiewicz
 * Released under the MIT and GPL Licenses.
 * Date 2012-02-08
 */

(function($) {

    $.fn.cssParentSelector = function() {
        var k = 0, i, j,

             // Class that's added to every styled element
            CLASS = 'CPS',

            stateMap = {
                hover: 'mouseover mouseout',
                checked: 'click',
                focus: 'focus blur',
                active: 'mousedown mouseup',
                selected: 'change',
                changed: 'change'
            },

            attachStateMap = {
                mousedown: 'mouseout'
            },

            detachStateMap = {
                mouseup: 'mouseout'
            },

            pseudoMap = {
                'after': 'appendTo',
                'before': 'prependTo'
            },

            pseudo = {},

            parsed, matches, selectors, selector,
            parent, target, child, state, declarations,
            pseudoParent, pseudoTarget,

            REGEXP = [
                /[\w\s\.\-\:\=\[\]\(\)\'\*\"\^#]*(?=!)/,
                /[\w\s\.\-\:\=\[\]\(\)\,\*\^$#>!]+/,
                /[\w\s\.\-\:\=\[\]\'\,\"#>]*\{{1}/,
                /[\w\s\.\-\:\=\'\*\|\?\^\+\/\\;#%]+\}{1}/
            ],

            REGEX = new RegExp((function(REGEXP) {
                var ret = '';

                for (var i = 0; i < REGEXP.length; i++)
                    ret += REGEXP[i].source;

                return ret;
            })(REGEXP), "gi"),

            parse = function(css) {

                // Remove comments.
                css = css.replace(/(\/\*([\s\S]*?)\*\/)/gm, '');

                if ( matches = css.match(REGEX) ) {

                    parsed = '';
                    for (i = -1; matches[++i], style = matches[i];) {

                        // E! P > F, E F { declarations } => E! P > F, E F
                        selectors = style.split('{')[0].split(',');

                        // E! P > F { declarations } => declarations
                        declarations = '{' + style.split(/\{|\}/)[1].replace(/^\s+|\s+$[\t\n\r]*/g, '') + '}';

                        // There's nothing so we can skip this one.
                        if ( declarations === '{}' ) continue;

                        declarations = declarations.replace(/;/g, ' !important;');

                        for (j = -1; selectors[++j], selector = $.trim(selectors[j]);) {

                            j && (parsed += ',');

                            if (/!/.test(selector) ) {

                                // E! P > F => E
                                parent = $.trim(selector.split('!')[0].split(':')[0]);

                                // E! P > F => P
                                target = $.trim(selector.split('!')[1].split('>')[0].split(':')[0]) || []._;

                                // E:after! P > after
                                pseudoParent = $.trim(selector.split('>')[0].split('!')[0].split(':')[1]) || []._;

                                // E! P:after > after
                                pseudoTarget = target ? ($.trim(selector.split('>')[0].split('!')[1].split(':')[1]) || []._) : []._;

                                // E! P > F => F
                                child    = $($.trim(selector.split('>')[1]).split(':')[0]);

                                // E! P > F:state => state
                                state = (selector.split('>')[1].split(/:+/)[1] || '').split(' ')[0] || []._;


                                child.each(function(i) {

                                    var subject = $(this).parent(parent);

                                    pseudoParent && (subject = pseudoMap[pseudoParent] ?
                                        $('<div></div>')[pseudoMap[pseudoParent]](subject) :
                                        subject.filter(':' + pseudoParent));

                                    target && (subject = subject.find(target));

                                    target && pseudoTarget && (subject = pseudoMap[pseudoTarget] ?
                                        $('<div></div>')[pseudoMap[pseudoTarget]](subject) :
                                        subject.filter(':' + pseudoTarget));

                                    var id = CLASS + k++,
                                        toggleFn = function(e) {

                                            e && attachStateMap[e.type] &&
                                                $(subject).one(attachStateMap[e.type], function() {$(subject).toggleClass(id) });

                                            e && detachStateMap[e.type] &&
                                                $(subject).off(detachStateMap[e.type]);

                                            $(subject).toggleClass(id)
                                        };

                                    i && (parsed += ',');

                                    parsed += '.' + id;
                                    ! state ? toggleFn() : $(this).on( stateMap[state] || state , toggleFn );

                                });
                            } else {
                                parsed += selector;
                            }
                        }

                        parsed += declarations;

                    };

                    $('<style type="text/css">' + parsed + '</style>').appendTo('head');

                };

            };

        $('link[rel=stylesheet], style').each(function() {
            $(this).is('link') ?
                $.get(this.href).success(function(css) { parse(css); }) : parse($(this).text());
        });

    };

    $().cssParentSelector();

})(jQuery);
