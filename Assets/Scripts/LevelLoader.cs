using UnityEngine;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
	public string levelToLoad;
	public GameObject heroPrefab;

	void Awake(){
		LoadLevel ();
	}

	public void LoadLevel(){
		string path = System.IO.Path.Combine(Application.dataPath, "Resources/" + levelToLoad);
		XMLParser.CreateLevelFromXML (path, Vector3.zero);
		Instantiate (heroPrefab, Vector3.zero, Quaternion.identity);
	}
}

