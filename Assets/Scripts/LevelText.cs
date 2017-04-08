using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LevelText : MonoBehaviour {

	private static LevelText _instance;

	[SerializeField] Paragraph paragraphPrefab;

	List<Paragraph> paragraphs = new List<Paragraph>();

	int totalLength = 0;

	void Awake(){
		_instance = this;
	}

	public static Paragraph AttachNewParagraph (){
		Vector3 pos;
		if (_instance.paragraphs.Count > 0) {
			TextChar lastChar = _instance.paragraphs [_instance.paragraphs.Count - 1].IndexToTextChar (_instance.paragraphs [_instance.paragraphs.Count - 1].Count - 1);
			pos = lastChar.transform.position;
			pos.x += lastChar.spacing;
		} else {
			pos = Vector3.zero;
		}
		GameObject newParagraphObject = Instantiate (_instance.paragraphPrefab.gameObject, pos, Quaternion.identity) as GameObject;
		Paragraph p = newParagraphObject.GetComponent<Paragraph> ();
		_instance.paragraphs.Add (p);


		return p;
	}

	public static void RecalculateLength(){
		foreach (Paragraph p in _instance.paragraphs) {
			_instance.totalLength += p.Count;
		}
	}

	public static GameObject GameObject {
		get { return _instance.gameObject; }
	}

	public static void Initialize (Vector3 startPos)
	{
		if (_instance == null) {
			LevelText textInScene = GameObject.FindObjectOfType<LevelText> ();
			_instance = textInScene;
		}
		_instance.transform.position = startPos;
	}

	public static void ClearParagraph(int index){
		
	}

	private static void ConvertIndex(int index, out int charIndex, out int paragraphIndex){
		if (index < 0 || index > _instance.totalLength) {
			charIndex = -1;
			paragraphIndex = -1;
		}
		// look for paragraph to start
		int currentParagraphIndex = 0;
		int maxLength = _instance.paragraphs [currentParagraphIndex].Count;
		while (maxLength < index) {
			currentParagraphIndex++;
			maxLength += _instance.paragraphs [currentParagraphIndex].Count;
		}
		maxLength -= _instance.paragraphs [currentParagraphIndex].Count;
		index -= maxLength;
		charIndex = index;
		paragraphIndex = currentParagraphIndex;
	}

	public static Vector3 IndexToVector3(int index){
		int paragraphIndex = 0;
		int charIndex = 0;
		ConvertIndex (index, out charIndex, out paragraphIndex);
		return _instance.paragraphs [paragraphIndex].IndexToVector3 (charIndex);
	}

	public static int GetIndexOfClosestChar(char c, int start, int range){
		int indexLeft = SearchCharLeft (c, start, range);
		int indexRight = SearchCharRight (c, start, range);
		int distanceLeft = start - indexLeft;
		int distanceRight = indexRight - start;

		if (indexLeft == -1) {
			distanceLeft = int.MaxValue;
		}
		if (indexRight == -1) {
			distanceRight = int.MaxValue;
		}
		return distanceLeft > distanceRight ? indexRight : indexLeft;
	}

	public static int SearchCharLeft(char c, int start, int range){
		int index = start;
		int end = start - range;
		while (index > 0 && index > end) {
			if (IndexToChar (index) == c) {
				return index;
			}
			index--;
		}
		return -1;
	}

	public static int SearchCharRight(char c, int start, int range){
		int index = start;
		int end = start + range;
		while (index < _instance.totalLength && index < end) {
			if (IndexToChar (index) == c) {
				return index;
			}
			index++;
		}
		return -1;
	}

	public static string GetCharsLeft(int start, int range){
		StringBuilder b = new StringBuilder ();
		int index = start;
		int end = start - range;
		while (index > 0 && index > end) {
			b.Append (IndexToChar (index));
			index--;
		}
		return b.ToString();
	}

	public static string GetCharsRight(int start, int range){
		StringBuilder b = new StringBuilder ();
		int index = start;
		int end = start + range;
		while (index < _instance.totalLength && index < end) {
			b.Append (IndexToChar (index));
			index++;
		}
		return b.ToString();
	}

	public static char IndexToChar(int index){
		int paragraphIndex = 0;
		int charIndex = 0;
		ConvertIndex (index, out charIndex, out paragraphIndex);
		return _instance.paragraphs [paragraphIndex].IndexToChar (charIndex);
	}
}
