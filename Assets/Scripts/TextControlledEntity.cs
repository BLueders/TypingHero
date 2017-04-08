using UnityEngine;
using System.Collections;

public class TextControlledEntity
{
	public int range = 5;

	private int currentIndex = 0;

	public Vector3 target{ get; private set;}

	public void SetTargetChar(char c){
		
		int nextIndex = LevelText.GetIndexOfClosestChar (c, currentIndex, range); 
		if (nextIndex != -1) {
			target = LevelText.IndexToVector3 (nextIndex);	
			currentIndex = nextIndex;
		}
	}
}

