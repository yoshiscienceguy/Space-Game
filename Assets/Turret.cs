using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float rotateSpeed = 2f;
	public float minAngle = 0f;
	public float maxAngle = 180f;
	private float dir = 1f;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.z >= maxAngle) {
						dir *= -1f;
				} else if (transform.rotation.z <= minAngle) {
			dir *= -1f;
		}
		transform.Rotate (new Vector3(0,0,Time.deltaTime*rotateSpeed*dir));
	}
}
