using UnityEngine;
using System.Collections;

public class Blob_AI : MonoBehaviour {
	
	private GameObject player;
	
	private int mergeCount = 0;
	private static int mergeLimit = 5;


	private int HP = 10;
	private float moveSpeed = 1f;
	
	private int maxLoot = 10;
	
	private float previousheight;
	private float currheight;
	
	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		previousheight = 0f;
		currheight = 0f;
	}
	
	// Update is called once per frame

	
	void LateUpdate() {
		currheight = previousheight;
	}
	
//	int RandomLoot(){
//		return Random.Range (1, maxLoot);
//	}
	
	
	void Merge(){
		mergeCount++;
		if (mergeCount == mergeLimit) {
			//call endgame
		} else {
			Vector3 size = transform.localScale;
			size.x *= 2;
			size.y *= 2;
			size.z *= 2;
			transform.localScale = size;
		}
	}
	

	
	//	void OnCollisionEnter(Collision collision) {
	//		if (collision.tag == "INVISWALL") {
	//			Debug.Log("HIT WALL");
	//			//Vector3 temp = transform.position; // copy to an auxiliary variable...
	//			moveSpeed *=-1;
	//			//temp.z = temp.z + moveSpeed; // modify the component you want in the variable...
	//			//transform.position = temp;
	//		}
	//	}
	
	void OnTriggerEnter(Collider col) 
	{
		Debug.Log("Some trigger");
		if (col.tag == "INVISWALL") {
			Debug.Log("HIT WALL");
			//Vector3 temp = transform.position; // copy to an auxiliary variable...
			moveSpeed *=-1;
			//temp.z = temp.z + moveSpeed; // modify the component you want in the variable...
			//transform.position = temp;
		}else
			if(col.tag == "Blob")
		{
			//	Vector3 temp = transform.position; // copy to an auxiliary variable...
			moveSpeed *=-1;
			//	temp.z = temp.z + moveSpeed; // modify the component you want in the variable...
			//	transform.position = temp;
			//			int rand = Random.Range(0,1);
			//			if(rand==0){
			//				Debug.Log("Merge with other");
			//				//Destroy(col);
			//
			//			}else{
			//				Debug.Log("Merge here");
			//				//col.gameObject.GetComponent<ai>().Merge();
			//				//Destroy(this);
			//			}
			// ... find the Enemy script and call the Hurt function.
			//col.gameObject.GetComponent<Enemy>().Hurt();
			
			// Call the explosion instantiation.
			//OnExplode();
			
			// Destroy the rocket.
			//Destroy (gameObject);
		}
		// Otherwise if it hits a bomb crate...
//		else if(col.tag == "Player")
//		{
//			if(Time.time>nextAttack){
//				nextAttack = Time.time+attackSpeed;
//			}
//			// ... find the Bomb script and call the Explode function.
//			//col.gameObject.GetComponent<Bomb>().Explode();
//			
//			// Destroy the bomb crate.
//			//Destroy (col.transform.root.gameObject);
//			
//			// Destroy the rocket.
//			//Destroy (gameObject);
//		}
	}
}
