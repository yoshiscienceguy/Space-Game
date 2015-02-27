using UnityEngine;
using System.Collections;

public class Suit_Attributes : MonoBehaviour {
	public GameObject Player;
	public float walkspeed = 10;
	public float runspeed = 30;
	public float jumpheight = 5;
	public float gravity = 20;
	public float fuel_per_frame = 2;

	// Use this for initialization
	void Start () {
		Starter ();

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void Starter(){


		Player.GetComponent<ThirdPersonController> ().originalrunspeed = runspeed;
		Player.GetComponent<ThirdPersonController> ().originalwalkspeed = walkspeed;
		Player.GetComponent<ThirdPersonController> ().originaljumpHeight = jumpheight;
		Player.GetComponent<ThirdPersonController> ().originalgravity = gravity;

		Player.GetComponent<ThirdPersonController>().trotSpeed = walkspeed + 2;
		Player.GetComponent<ThirdPersonController>().walkSpeed = walkspeed;

		Player.GetComponent<ThirdPersonController>().runSpeed = runspeed;
		Player.GetComponent<ThirdPersonController>().jumpHeight = jumpheight;
		Player.GetComponent<ThirdPersonController>().gravity = gravity;
		Player.GetComponent<ThirdPersonController>().fuel_per_frame = fuel_per_frame;
	}
}
