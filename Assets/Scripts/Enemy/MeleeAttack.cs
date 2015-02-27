using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	GameObject player;
	public AudioClip atkSound;
	private float nextAttack = 0.0F;
	public float attackSpeed = 1f;
	public int Damage = 1;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
	}

	void FixedUpdate ()
	{
		float distance = Vector3.Distance(player.transform.position, transform.position);
		Vector3 dir = (player.transform.position - transform.position).normalized;
		float direction = Vector3.Dot(dir, transform.forward);
		if(distance < 3f) {
			if(nextAttack<Time.time){

				audio.PlayOneShot(atkSound,0.5f);
				nextAttack = Time.time+attackSpeed;
			}
		}
	}
}
