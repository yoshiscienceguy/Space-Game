using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

	GameObject player;
	private float nextAttack = 0.0F;
	private float attackSpeed = 1f;
	private int Damage = 1;

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
				player.GetComponent<PlayerController>().Hurt(Damage);
				nextAttack = Time.time+attackSpeed;
			}
		}
	}
}
