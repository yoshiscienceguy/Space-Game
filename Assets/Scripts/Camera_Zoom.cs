using UnityEngine;
using System.Collections;

public class Camera_Zoom : MonoBehaviour {
	public float close= -8;
	public float regular = -12;
	public float far = -20;
	public Camera maincamera;

	private Vector3 newposition;
	private float speed = .2f;
	private bool move = false;

	
	// Update is called once per frame
	void Start(){
		maincamera = GetComponentInChildren<Camera>();
		newposition = transform.position;
	}
	void Update () {
		if (move == true) {
				
		maincamera.transform.position = Vector3.Lerp (maincamera.transform.position, newposition, Time.deltaTime * speed);
		}
	}

	void OnTriggerEnter(Collider other){

		move = true;

		if (other.gameObject.tag == "Close") {
			Debug.Log("close");
			newposition = new Vector3(maincamera.transform.position.x, maincamera.transform.position.y, close);
		}
		if (other.gameObject.tag == "Far") {
			Debug.Log("Far");
			newposition = new Vector3(maincamera.transform.position.x, maincamera.transform.position.y, far);
		}
		if (other.gameObject.tag == "Normal") {
			Debug.Log("Normal");
			newposition = new Vector3(maincamera.transform.position.x, maincamera.transform.position.y, regular);	
		}

	}

}
