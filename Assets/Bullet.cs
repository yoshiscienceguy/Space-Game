using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	float Speed = 0.4f;
	
	// The number of seconds before the bullet is automatically destroyed
	float SecondsUntilDestroy = 10f;
	
	private float startTime; 
	// Use this for initialization
	void Start () {
		startTime = Time.time; 
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Move forward
	//	Vector3 dir = new Vector3(0,1,0);
		//dir.Normalize();
	//	this.gameObject.transform.position += Speed * dir;
		
		// If the Bullet has existed as long as SecondsUntilDestroy, destroy it
		if (Time.time - startTime >= SecondsUntilDestroy) {
			Destroy(this.gameObject);
		}
	}

	void OnCollisionEnter(Collision col) {
		Debug.Log ("Bullet hit something so");
		// Remove the Bullet from the world
		Destroy(this.gameObject);
	}
}
