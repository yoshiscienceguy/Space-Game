using UnityEngine;
using System.Collections;

public class Sentry_Detection : MonoBehaviour {
	public Transform reference;


	public float y = .5f;


	private Transform initial;

	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		//initial.position = new Vector3(reference.position.x + x,reference.position.y + y,reference.position.z + z);
		//transform.LookAt (reference);
		transform.rotation = Quaternion.LookRotation (reference.position);
		Quaternion pos = transform.rotation;

		pos.x = 0;
		pos.y += y;
		pos.z = 0;
		transform.rotation = pos;

	}

}
