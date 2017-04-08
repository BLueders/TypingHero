using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontCache
{
	private static Dictionary<string, Font> _KnownFonts;
	private const string DEFAULT_FONT = "Arial.ttf";
	private const string FONT_PATH = "Fonts/";

	private static Dictionary<string, Font> KnownFonts{
		get{if (_KnownFonts == null)
			_KnownFonts = new Dictionary<string, Font> (); 
			return _KnownFonts; 
		}
	}

	public static Font GetFont(string fontName){
		if (!KnownFonts.ContainsKey(fontName)) {
			Font newFont = Resources.Load<Font> (FONT_PATH + fontName);
			KnownFonts.Add (fontName, newFont);
		}
		return KnownFonts [fontName];
	}

	public static Font GetDefaultFont(){
		if (!KnownFonts.ContainsKey(DEFAULT_FONT)) {
			KnownFonts.Add (DEFAULT_FONT, Resources.GetBuiltinResource<Font> (DEFAULT_FONT));
		}
		return KnownFonts [DEFAULT_FONT];
	}
}

