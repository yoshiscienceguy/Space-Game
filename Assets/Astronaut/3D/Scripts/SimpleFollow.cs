using UnityEngine;
using System.Collections;

public class SimpleFollow : MonoBehaviour {

	// Use this for initialization
	public Transform target;
	public float x_displacement;
	public float y_displacement;
	public float z_displacement;
	
	// Update is called once per frame
	void Update () {
		Vector3 change = new Vector3(target.position.x + x_displacement,target.position.y + y_displacement, target.position.z + z_displacement);
		transform.position = change;

	}
}
