using UnityEngine;
using System.Collections;

public class Elevator_Open : MonoBehaviour {
	private Animator animator;
	public Light On;
	public Light Off;
	void Start(){
		animator = GetComponent<Animator>();
		Off.enabled = true;
		On.enabled = false;
	}

	void OnTriggerEnter(Collider other){
		animator.SetBool ("Move", true);
		StartCoroutine (AnimationWait (6));

	}

	void OnTriggerExit(Collider other){
		animator.SetBool ("Move", false);

	}

	IEnumerator AnimationWait(float time){
		Off.enabled = false;
		On.enabled = true;
		yield return new WaitForSeconds(time);
		Off.enabled = true;
		On.enabled = false;
	}
}
