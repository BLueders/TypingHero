using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paragraph : MonoBehaviour {

	[SerializeField] Letter letterPrefab;

	List<Letter> textLetters = new List<Letter>();

	public int fontSize = LetterDef.DEFAULT_FONTSIZE;
	public float textSize = LetterDef.DEFAULT_SIZE;
	public Font font = LetterDef.DEFAULT_FONT;
	public float spacing = LetterDef.DEFAULT_SPACING;

	public void AddLetter(LetterDef def){
		GameObject newLetterObject = Instantiate (letterPrefab.gameObject) as GameObject;
		newLetterObject.transform.position = textLetters[textLetters.Count - 1].transform.position + new Vector3(spacing,0,0);
		newLetterObject.transform.SetParent (transform);
		Letter newLetter = newLetterObject.GetComponent<Letter> ();
		newLetter.letter = def.letter;
		newLetter.textSize = def.size;
		newLetter.textColor = def.color;
		newLetter.fontSize = def.fontSize;
		newLetter.font = def.font;
	}

	public void AddLetter(string letter){
		LetterDef def = LetterDef.CreateDefault ();
		def.letter = letter;
		AddLetter (def);
	}
}
