using UnityEngine;
using System.Collections;

public class HellStart_Trigger : MonoBehaviour {
	public GameObject Hellstar;
	public GameObject Crash;
	public Transform crash_position;
	public float crash_delay;
	public GameObject Explosion;
	public Transform explosion_position;
	public float explosion_delay;
	// Use this for initialization
	void OnTriggerEnter(Collider other){
		Hellstar.GetComponent<Animator> ().SetBool ("Crash", true);
		StartCoroutine(AnimationWait());
	}
	IEnumerator AnimationWait(){

		yield return new WaitForSeconds(crash_delay);
		GameObject exp = Instantiate(Crash, crash_position.position, Quaternion.identity) as GameObject;
		yield return new WaitForSeconds(explosion_delay);
		GameObject exp2 = Instantiate(Explosion, explosion_position.position, Quaternion.identity) as GameObject;
	}
}
