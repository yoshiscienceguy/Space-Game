using UnityEngine;
using System.Collections;

public class Fix_Rotation_Camera_Script : MonoBehaviour {
	public Transform Astronaut;
	public float Z_Direction = -15;
	private bool change = false;
	public Vector3 offset = Vector3.zero;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		Vector3 pos = Astronaut.transform.position;
		if(change == false){
			pos.z = Z_Direction;
		}
		else{
			pos.x +=offset.x;
			pos.y +=offset.y;
			pos.z +=offset.z;
		}
		transform.position = pos;
	}

	public void Change_User(Transform next,Vector3 offsets){
		Astronaut = next;
		change = true;
		offset = offsets;
	}
	public void Change_Z(float num){
		Z_Direction = num;
	}
}
