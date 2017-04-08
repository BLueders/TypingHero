using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextChar : MonoBehaviour
{
	[SerializeField] Text uiText = null;

	public Text Text { get { return uiText; } }
	public float spacing;

	private char _theChar = 'a';
	public char theChar { 
		get { 
			return _theChar;
		} 
		set { 
			uiText.text = value.ToString(); 
			_theChar = value;
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
