using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class XMLParser {

	private const string LEVEL_NODE = "level";
	private const string PARAGRAPH_NODE = "paragraph";
	private const string TEXT_NODE = "text";
	private const string LETTER_NODE = "letter";

	private const string FONT_ATTRIBUTE = "font";
	private const string SIZE_ATTRIBUTE = "size";
	private const string FONTSIZE_ATTRIBUTE = "font-size";
	private const string SPACING_ATTRIBUTE = "spacing";
	private const string COLOR_ATTRIBUTE = "color";

	public static void CreateLevelFromXML(string path, Vector3 startPos){
		
		XmlDocument doc = new XmlDocument();
		doc.Load(path);
		XmlNode levelNode = doc.SelectSingleNode(LEVEL_NODE);

		LevelText.Initialize (startPos);

		TextCharDef currentDef = TextCharDef.CreateDefault ();

		foreach(XmlNode node in levelNode.ChildNodes){
			if (node.Name == PARAGRAPH_NODE) {
				
				Paragraph currentParagraph = LevelText.AttachNewParagraph ();
				currentDef = ChangeDefOnDemand (currentDef, node.Attributes);

				foreach(XmlNode textNode in node.ChildNodes){

					if (textNode.Name == TEXT_NODE) {
						string text = node.InnerText;
						foreach (char c in text) {
							char convertedC = c.ToString ().ToLower ().ToCharArray()[0];
							if (ValidateChar (convertedC)) {
								currentDef.theChar = convertedC;
								currentParagraph.AddChar (currentDef);
							}
						}
					}

					if (textNode.Name == LETTER_NODE) {
						TextCharDef backup = currentDef;
						currentDef = ChangeDefOnDemand (currentDef, node.Attributes);
						char convertedC = node.InnerText.ToLower ().ToCharArray()[0];
						if (ValidateChar (convertedC)) {
							currentDef.theChar = convertedC;
							currentParagraph.AddChar (currentDef);
						}
						currentDef = backup;
					}
				}
			}
		}
		LevelText.RecalculateLength ();
	}

	public static Paragraph ParagraphFromText(string path){
		return null;
	}

	private static Paragraph CreateParagraphComponent (Vector3 pos)
	{
		GameObject levelObject = new GameObject ();
		levelObject.transform.position = pos;
		return levelObject.AddComponent<Paragraph> ();
	}

	private static TextCharDef ChangeDefOnDemand(TextCharDef def, XmlAttributeCollection attributes){

		if (attributes [FONT_ATTRIBUTE] != null) {
			def.font = FontCache.GetFont (attributes [FONT_ATTRIBUTE].InnerText);
		}

		if (attributes [SIZE_ATTRIBUTE] != null) {
			def.size = float.Parse(attributes [SIZE_ATTRIBUTE].InnerText);
		}

		if (attributes [FONTSIZE_ATTRIBUTE] != null) {
			def.fontSize = int.Parse(attributes [FONTSIZE_ATTRIBUTE].InnerText);
		}

		if (attributes [SPACING_ATTRIBUTE] != null) {
			def.spacing = float.Parse(attributes [SPACING_ATTRIBUTE].InnerText);
		}

		if (attributes [COLOR_ATTRIBUTE] != null) {
			def.color = ColorExtension.ParseColor(attributes [COLOR_ATTRIBUTE].InnerText);
		}

		return def;
	}

								private static bool ValidateChar(char c){
		return "abcdefghijklmnopqrstuvwxyz., ".Contains (c.ToString ());
	}
}
