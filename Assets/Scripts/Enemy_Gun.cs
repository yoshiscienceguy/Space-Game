using UnityEngine;
using System.Collections;

public class Enemy_Gun : MonoBehaviour {

	public Rigidbody bullet;
	public Transform barrelexit;
	public float force = 1000;
	public Animator animator;
	public float rate = 1.5f;
	private float rate_time;

	void Start(){
		animator = GetComponentInParent<Animator>();
	}
	
	void Update(){
		
		if (animator.GetCurrentAnimatorStateInfo(0).IsName("Fire") && Time.time > rate_time)
		{
			rate_time = Time.time + rate;
			Rigidbody bulletInstance;
			bulletInstance = Instantiate(bullet,barrelexit.position,barrelexit.rotation) as Rigidbody;
			bulletInstance.AddForce(barrelexit.forward * force);
			
		}
		
	}
}
