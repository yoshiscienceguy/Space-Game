using UnityEngine;
using System.Collections;

public class Moving_Platform : MonoBehaviour {

	public Transform objective;

	private Animator animator;
	//public int sensitivity = 5;
	//public float offset = 2;
	// Update is called once per frame
	void Start(){
		animator = GetComponent<Animator>();
	}
	// Update is called once per frame

	void OnTriggerEnter(Collider other){
		animator.SetBool("Play",true);
		objective.position = transform.position;
	}

	void OnTriggerExit(Collider other){
		animator.SetBool ("Play",false);
		other.transform.parent = null;
	}
	//void Update () {
		//if(Vector3.Distance(transform.position, objective.position) < sensitivity){
			//
		//	objective.transform.position = new Vector3(objective.transform.position.x,gameObject.transform.position.y+offset,objective.transform.position.z);
		//}

	//}
}
