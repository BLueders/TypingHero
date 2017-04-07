using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FontCache
{
	private static Dictionary<string, Font> _KnownFonts;
	private const string DEFAULT_FONT = "Arial.ttf";

	private static Dictionary<string, Font> KnownFonts{
		get{if (_KnownFonts == null)
			_KnownFonts = new Dictionary<string, Font> (); 
			return _KnownFonts; 
		}
	}

	public static Font GetFont(string fontName){
		if (KnownFonts [fontName] == null) {
			KnownFonts.Add (fontName, Resources.Load<Font> (typeof(Font), fontName) as Font);
		}
		return KnownFonts [fontName];
	}

	public static Font GetDefaultFont(){
		if (KnownFonts [DEFAULT_FONT] == null) {
			KnownFonts.Add (DEFAULT_FONT, Resources.Load<Font> (typeof(Font), DEFAULT_FONT) as Font);
		}
		return KnownFonts [DEFAULT_FONT];
	}
}

