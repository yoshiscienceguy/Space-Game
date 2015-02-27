using UnityEngine;
using System.Collections;

public class Centerandbutton : MonoBehaviour {



	void OnGUI() {

		GUIStyle style = new GUIStyle(GUI.skin.label);
		style.fontSize = 80;
		if (GUI.Button (new Rect ((Screen.width/2)-75, Screen.height - Screen.height/3, 150, 100), "PLAY")) {
			Application.LoadLevel(Application.loadedLevel + 1);
		}

		GUI.Label(new Rect ((Screen.width/2) - 250, Screen.height - ((Screen.height/2) +  200 ), 600, 100), "Phobos Mars", style);

				
						
		}
}
