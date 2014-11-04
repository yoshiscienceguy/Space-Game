using UnityEngine;
using System.Collections;

public class Astroid_rotation : MonoBehaviour {
	public float speed = .3f;
	
	void Update(){
		transform.Rotate(0, 0, speed,Space.Self);

		
	}
}
