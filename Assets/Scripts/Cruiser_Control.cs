using UnityEngine;
using System.Collections;

public class Cruiser_Control : MonoBehaviour {
	public Vector3 offset = new Vector3(0,5,-15);
	public Camera camera;
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.gameObject.SetActive(false);
			GetComponent<Animator>().SetBool("LiftOff",true);
			camera.GetComponent<Fix_Rotation_Camera_Script>().Change_User(this.transform,offset);
		}
	}
}
