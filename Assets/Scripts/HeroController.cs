using UnityEngine;
using System.Collections;

public class HeroController : MonoBehaviour
{
	TextControlledEntity controller = new TextControlledEntity();

	public float speed;

	void Update(){

		if (Input.inputString.Length > 0) {
			char input = Input.inputString.ToCharArray() [0];	
			controller.SetTargetChar (input);
		}

		transform.position = controller.target;
	}
}

