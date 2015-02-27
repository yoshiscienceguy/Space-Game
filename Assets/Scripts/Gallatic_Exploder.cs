using UnityEngine;
using System.Collections;

public class Gallatic_Exploder : MonoBehaviour {

	public GameObject MiniExplosions;
	public Transform mini_position;
	public float mini_delay;
	public GameObject Explosion;
	public Transform explosion_position;
	public float explosion_delay;
	void OnTriggerEnter(Collider other){
		Debug.Log ("start");
		StartCoroutine(AnimationWait());
	}
	
	IEnumerator AnimationWait(){
		yield return new WaitForSeconds(explosion_delay);
		GameObject exp2 = Instantiate(Explosion, explosion_position.position, Quaternion.identity) as GameObject;
		yield return new WaitForSeconds(mini_delay);
		GameObject exp = Instantiate(MiniExplosions, mini_position.position, Quaternion.identity) as GameObject;

	}
}
