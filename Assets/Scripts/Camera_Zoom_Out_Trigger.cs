using UnityEngine;
using System.Collections;

public class Camera_Zoom_Out_Trigger : MonoBehaviour {
	public Camera maincamera;
	public float zoomfactor;
	private bool zoom = false;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		if (zoom == true) {
			maincamera.GetComponent<Fix_Rotation_Camera_Script>().Change_Z(zoomfactor);

		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			Debug.Log("yes");
			zoom = true;		
		}
	}
}
