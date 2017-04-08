using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TextCharDef
{
	private static Font _DEFAULT_FONT = null;

	public static Font DEFAULT_FONT { 
		get { 
			if (_DEFAULT_FONT == null) {
				_DEFAULT_FONT = FontCache.GetDefaultFont ();
			}
			return _DEFAULT_FONT;
		}
	}
	public const float DEFAULT_SIZE = 1;
	public const float DEFAULT_SPACING = 1;
	public const int DEFAULT_FONTSIZE = 250;
	public static readonly Color DEFAULT_COLOR = new Color(0,0,0);

	public char theChar;
	public Font font;
	public float size;
	public int fontSize;
	public float spacing;
	public Color color;

	public static TextCharDef CreateDefault(){
		TextCharDef def = new TextCharDef ();
		def.theChar = 'a';
		def.font = DEFAULT_FONT;
		def.size = DEFAULT_SIZE;
		def.fontSize = DEFAULT_FONTSIZE;
		def.spacing = DEFAULT_SPACING;
		def.color = DEFAULT_COLOR;
		return def;
	}
}
