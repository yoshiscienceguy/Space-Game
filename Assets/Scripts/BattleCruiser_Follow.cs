using UnityEngine;
using System.Collections;

public class BattleCruiser_Follow : MonoBehaviour {

	public float delay;
	private bool ready = true;
	private Animator animator;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (ready == true) {
			StartCoroutine(AnimationWait());
			if(animator.GetBool("Going") == false){
				animator.SetBool("Going",true);
				animator.SetBool ("Coming",false);
			}
			else{
				animator.SetBool ("Going",false);
				animator.SetBool ("Coming",true);
			}
			ready = false;
		}
	}

	IEnumerator AnimationWait(){
		
		yield return new WaitForSeconds(delay);

		ready = true;

	}
}
