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

	public static LevelText CreateLevelFromXML(string path, Vector3 startPos){
		XmlDocument doc = new XmlDocument();
		doc.Load(path);
		XmlNode levelNode = doc.DocumentElement.SelectSingleNode(LEVEL_NODE);

		LevelText level = CreateLevelComponent (startPos);

		LetterDef currentDef = LetterDef.CreateDefault ();

		foreach(XmlNode node in levelNode.ChildNodes){
			if (node.Name == PARAGRAPH_NODE) {
				
				Paragraph currentParagraph = CreateParagraphComponent (startPos);
				currentParagraph.transform.SetParent (level.transform);
				currentDef = ChangeDefOnDemand (currentDef, node.Attributes);

				foreach(XmlNode textNode in levelNode.ChildNodes){
					if (node.Name == TEXT_NODE) {
						
					}
					if (node.Name == LETTER_NODE) {
						
					}
				}
			}
		}
	}

	public static Paragraph ParagraphFromText(string path){
		
	}

	private static LevelText CreateLevelComponent(Vector3 pos){
		GameObject levelObject = new GameObject ();
		levelObject.transform.position = pos;
		return levelObject.AddComponent<LevelText> ();
	}

	private static Paragraph CreateParagraphComponent (Vector3 pos)
	{
		GameObject levelObject = new GameObject ();
		levelObject.transform.position = pos;
		return levelObject.AddComponent<Paragraph> ();
	}

	private static LetterDef ChangeDefOnDemand(LetterDef def, XmlAttributeCollection attributes){

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
			def.font = ColorExtensions.ParseColor(attributes [COLOR_ATTRIBUTE].InnerText);
		}
	}
}
