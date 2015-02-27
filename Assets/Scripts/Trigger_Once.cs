using UnityEngine;
using System.Collections;

public class Trigger_Once : MonoBehaviour {
	public string triggername;
	private Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other){
		if(other.tag == "Player"){
			animator.SetBool (triggername, true);
		}
	}
}
