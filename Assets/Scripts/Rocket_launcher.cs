using UnityEngine;
using System.Collections;

public class Rocket_launcher : MonoBehaviour {
	private bool fire = true;
	public Rigidbody Bullet;
	public float WaitTime = 3;
	public float force = 1000;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fire == true){
			StartCoroutine(FireRate());

			fire = false;
		}
	}

	IEnumerator FireRate(){
		
		Rigidbody bulletInstance;
		bulletInstance = Instantiate(Bullet,transform.position,transform.rotation) as Rigidbody;
		bulletInstance.AddForce(transform.forward * force);

		yield return new WaitForSeconds(1);
		bulletInstance = Instantiate(Bullet,transform.position,transform.rotation) as Rigidbody;
		bulletInstance.AddForce(transform.forward * force);

		yield return new WaitForSeconds(1);
		bulletInstance = Instantiate(Bullet,transform.position,transform.rotation) as Rigidbody;
		bulletInstance.AddForce(transform.forward * force);
		yield return new WaitForSeconds(WaitTime);

		fire = true;
		
		
		
	}

}
