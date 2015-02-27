using UnityEngine;
using System.Collections;

public class Rockets : MonoBehaviour {

	public GameObject currentDetonator;
	public float Explosion_Damage = 50;
	public bool repeat = true;
	private bool ready = true;
	public float delay = 3;
	private bool explosion = false;
	private bool took_damage = false;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (ready == true) {
			StartCoroutine(AnimationWait(delay));
			ready = false;
		}

	}

	IEnumerator AnimationWait(float time){

		yield return new WaitForSeconds(time);

		GameObject exp = Instantiate(currentDetonator, transform.position, Quaternion.identity) as GameObject;
		if(repeat == true){
			ready = true;
		}
		explosion = true;
		yield return new WaitForSeconds(1);
		explosion = false;
		took_damage = false;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if(explosion== true){
				if(took_damage == false){
					other.GetComponent<Player_Health>().Take_Damage(Explosion_Damage);
					Debug.Log("Exploded -50");
					took_damage = true;
				}
			}
		}
	}
	void OnTriggerStay(Collider other){
		if (other.tag == "Player") {
			if(explosion== true){
				if(took_damage == false){
					other.GetComponent<Player_Health>().Take_Damage(Explosion_Damage);
					Debug.Log("Exploded -50");
					took_damage = true;
				}
			}
		}
	}
}
