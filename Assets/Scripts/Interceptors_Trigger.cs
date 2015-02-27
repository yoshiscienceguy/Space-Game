using UnityEngine;
using System.Collections;

public class Interceptors_Trigger : MonoBehaviour {
	public GameObject Interceptor;
	// Use this for initialization
	void OnTriggerEnter(Collider other){

		Interceptor.GetComponent<Animator> ().SetBool ("Fly", true);

	}
}
