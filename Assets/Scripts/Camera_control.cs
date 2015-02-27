using UnityEngine;
using System.Collections;

public class Camera_control : MonoBehaviour {
	public Camera maincamera;
	public float rotation;
	public float speed;
	private bool left = false;
	private Quaternion newposition;
	private Quaternion originalposition;
	// Use this for initialization
	void Start () {
		originalposition = Quaternion.Euler (maincamera.transform.rotation.x, maincamera.transform.rotation.y, maincamera.transform.rotation.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("a")) {
			newposition = Quaternion.Euler(maincamera.transform.rotation.x,originalposition.y- rotation ,maincamera.transform.rotation.z);

		}
		if (Input.GetKeyDown ("d")) {

			newposition = Quaternion.Euler(maincamera.transform.rotation.x,originalposition.y + rotation,maincamera.transform.rotation.z);

		}

		maincamera.transform.rotation  = Quaternion.Slerp(maincamera.transform.rotation,newposition, Time.deltaTime * speed);
	}
}
