using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Letter : MonoBehaviour
{
	[SerializeField] Text uiText;

	public Text Text { get { return uiText; } }
	public float spacing;

	private string _letter = "A";
	public string letter { 
		get { 
			return _letter;
		} 
		set { 
			uiText.text = value; 
			_letter = value;
		} 
	}

	private int _fontSize = 250;
	public int fontSize { 
		get { 
			return _fontSize;
		} 
		set { 
			uiText.fontSize = (int)(value * textSize); 
			_fontSize = value;
		} 
	}

	private float _textSize = 1;
	public float textSize { 
		get { 
			return _textSize;
		} 
		set { 
			uiText.fontSize = (int)(value * fontSize); 
			_textSize = value;
		} 
	}

	public Color textColor { 
		get { 
			return uiText.color;
		} 
		set { 
			uiText.color = value; 
		} 
	}

	public Font font {
		get { 
			return uiText.font;
		} 
		set { 
			uiText.font = value; 
		} 
	}
}
