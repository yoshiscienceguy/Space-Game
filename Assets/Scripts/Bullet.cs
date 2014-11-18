using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

//	float Speed = 100f;
//	
//	// The number of seconds before the bullet is automatically destroyed
//	float SecondsUntilDestroy = 10f;
//	Vector3 direction;
//	
//	private float startTime; 
//	// Use this for initialization
//	void Start () {
//		Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,
//		                                                       Input.mousePosition.y, Camera.main.nearClipPlane));
//		                                          Debug.Log("Camera to Mouse"+p);
//		Debug.Log ("Bullet pos : "+transform.position);
//		//Debug.Log(transform.position);
//		direction = new Vector3(p.x,p.y,0);
//		//Debug.Log(direction);
//		direction = direction - transform.position;
//		//Debug.Log(direction);
//		direction.Normalize();
//		direction.z = 0;
//		Debug.Log(direction);
//		transform.position = new Vector3(transform.position.x,transform.position.y+1.4f,0);
//		//startTime = Time.time; 
//
//	}
//
//	// Update is called once per frame
//	void FixedUpdate () {
//		this.gameObject.rigidbody.AddForce(Speed * direction,ForceMode.Acceleration);
//
////		// Move forward
////		//Vector3 dir = new Vector3(0,1,0);
////		//dir.Normalize();
////		this.gameObject.transform.position += Speed * direction;
////	//	transform.position+=ve
////		// If the Bullet has existed as long as SecondsUntilDestroy, destroy it
////		if (Time.time - startTime >= SecondsUntilDestroy) {
////			Destroy(this.gameObject);
////		}
//	}
//
//	void OnCollisionEnter(Collision col) {
//		Debug.Log ("Bullet hit something so");
//		//Destroy(col.gameObject);
//		try{
//		col.gameObject.GetComponent<EnemyHealth>().Hurt(5);
//		Destroy(this.gameObject);
//		}catch{
//				
//		}
//	}
}
