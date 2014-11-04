using UnityEngine;
using System.Collections;

public class DestroyModel : MonoBehaviour {
	//public float speed = 300;
	public GameObject CurrentCamera;
	public GameObject next_model;
	public GameObject next_camera;

	private Vector3 original_position;
	void Start(){
		original_position = transform.position;
	}
	void Update(){
		//transform.Rotate (Vector3.forward * speed * Time.deltaTime, Space.World);
	

	}

	void OnTriggerEnter(Collider c){
		if(c.tag == "Changer")
		{
			Debug.Log ("Upgrade");

			gameObject.SetActive (false);
			CurrentCamera.SetActive(false);
			transform.position = original_position;
			next_model.SetActive(true);
			next_camera.SetActive(true);
		}
	}
}
