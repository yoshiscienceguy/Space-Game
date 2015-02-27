using UnityEngine;
using System.Collections;

public class Zaxis_Check : MonoBehaviour {

	private float original;
	// Use this for initialization
	void Start () {
		original = transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x, transform.position.y, original);
	}

	void OnTriggerEnter(){

	}
}
