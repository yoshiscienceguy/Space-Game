using UnityEngine;
using System.Collections;

public class Push : MonoBehaviour {
	public float power = 2;
	public float distance = 3;
	private Vector3 newposition;
	private bool push = false;
	Animator animator;
	void Start(){
		animator = GetComponentInChildren<Animator>();
	}
	void Update(){
		if (push == true) {
			animator.SetBool("Pushed",true);

			transform.position = Vector3.Lerp (transform.position, newposition, Time.deltaTime * power);

			if(Vector3.Distance(transform.position, newposition) < 1){

				push = false;
				animator.SetBool("Pushed",false);
			}
			if(Input.GetButtonDown("Horizontal")){

				push = false;
				animator.SetBool("Pushed",false);
			}
		}

	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Melee") {
			push = true;

			newposition = new Vector3(transform.position.x - distance, transform.position.y, transform.position.z);

		}

	}




}
