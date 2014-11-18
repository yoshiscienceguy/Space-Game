using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour
{
	public Rigidbody bullet;
	public Transform barrelexit;
	public float force = 1000;

	void Update(){

		if (Input.GetMouseButtonDown (0)) {
			Rigidbody bulletInstance;
			bulletInstance = Instantiate(bullet,barrelexit.position,barrelexit.rotation) as Rigidbody;
			bulletInstance.AddForce(barrelexit.forward * force);

		}

	}

}
