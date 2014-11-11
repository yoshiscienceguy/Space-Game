using UnityEngine;
using System.Collections;

public class CharacterMovementSimple : MonoBehaviour {
	public float Speed = 5;
	// Use this for initialization

	
	// Update is called once per frame
	void Update () {
		transform.Translate(Input.GetAxis("Horizontal") * Speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * Speed * Time.deltaTime, Space.Self);
		//rigidbody.AddForce/AddRelativeForce(Input.GetAxis("Horizontal") * Speed, 0, Input.GetAxis("Vertical") * Speed, ForceMode.???);
	}
}
