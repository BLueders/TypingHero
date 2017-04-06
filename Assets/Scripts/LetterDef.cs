using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LetterDef
{
	private static Font _DEFAULT_FONT = null;

	public static Font DEFAULT_FONT { 
		get { 
			if (_DEFAULT_FONT == null) {
				_DEFAULT_FONT = Resources.GetBuiltinResource (typeof(Font), "Arial.ttf") as Font;
			}
			return _DEFAULT_FONT;
		}
	}
	public const float DEFAULT_SIZE = 1;
	public const float DEFAULT_SPACING = 1;
	public const int DEFAULT_FONTSIZE = 250;
	public static readonly Color DEFAULT_COLOR = new Color(0,0,0);

	public string letter;
	public Font font;
	public float size;
	public int fontSize;
	public float spacing;
	public Color color;

	public static LetterDef CreateDefault(){
		LetterDef def = new LetterDef ();
		def.letter = "A";
		def.font = DEFAULT_FONT;
		def.size = DEFAULT_SIZE;
		def.fontSize = DEFAULT_FONTSIZE;
		def.spacing = DEFAULT_SPACING;
		def.color = DEFAULT_COLOR;
		return def;
	}
}
