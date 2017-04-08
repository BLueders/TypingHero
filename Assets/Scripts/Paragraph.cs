using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paragraph : MonoBehaviour {

	[SerializeField] TextChar letterPrefab = null;

	List<TextChar> textChars = new List<TextChar>();

	public int Count { get { return textChars.Count; } }

	public void AddCharRange(TextCharDef[] defs){
		foreach (TextCharDef d in defs) {
			AddChar (d);
		}
	}

	public void AddChar(TextCharDef def){
		GameObject newCharObject = Instantiate (letterPrefab.gameObject) as GameObject;
		if (textChars.Count == 0) {
			newCharObject.transform.position = transform.position;
		} else {
			newCharObject.transform.position = textChars[textChars.Count - 1].transform.position + new Vector3(def.spacing, 0, 0);
		}
		newCharObject.transform.SetParent (transform);
		TextChar newChar = newCharObject.GetComponent<TextChar> ();
		newChar.theChar = def.theChar;
		newChar.textSize = def.size;
		newChar.textColor = def.color;
		newChar.fontSize = def.fontSize;
		newChar.font = def.font;
		newChar.spacing = def.spacing;
		textChars.Add (newChar);
	}

	public void AddChar(char c){
		TextCharDef def = TextCharDef.CreateDefault ();
		def.theChar = c;
		AddChar (def);
	}

	public char IndexToChar(int index){
		return textChars [index].theChar;
	}

	public TextChar IndexToTextChar(int index){
		return textChars [index];
	}

	public Vector3 IndexToVector3(int index){
		Vector3 pos = textChars [index].transform.position;
		pos += Vector3.up * textChars [index].textSize;
		return pos;
	}
}
