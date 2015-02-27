using UnityEngine;
using System.Collections;

public class PEWPEW : MonoBehaviour {
	public int Damage = 10;

	private GameObject player;
	private Vector3 dir ;

	void Awake(){
		player =GameObject.FindGameObjectWithTag("Player");
//		dir = (player.transform.position - transform.position);
//		dir.z = 0;
	}

	public void SetDir(Vector3 Direction){
		Debug.Log ((player.transform.position - transform.position));
		dir = new Vector3( (Mathf.Cos(Mathf.Deg2Rad *Direction.z)),Mathf.Sin(Mathf.Deg2Rad * Direction.z),0);
		Debug.Log ("Set Dir : "+Direction+" , "+dir+" , ");
		//dir = Direction;
		dir*=-1;
		dir.z = 0;
	}

	void FixedUpdate(){
		this.gameObject.rigidbody.AddForce(dir*20f,ForceMode.Force);		
	}

	void OnTriggerEnter(Collider other) {
		Debug.Log (other.name);
		if (other.name.Equals ("Player")) {
//			player.GetComponent<PlayerController>().Hurt(Damage);		
		}
	}
}
