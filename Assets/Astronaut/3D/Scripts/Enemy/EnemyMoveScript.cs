using UnityEngine;
using System.Collections;

public class EnemyMoveScript : MonoBehaviour {

	public float sight;
	public float moveSpeed = 0.1f;
	private CharacterController character;
	private bool sighted = false;
	private bool merge = false;

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		character = GetComponent<CharacterController>();
	}

	void PlayerinSight(){
		float distance = Vector3.Distance(player.transform.position, transform.position);
		if (distance <= sight) {
						sighted = true;		
				} else {
			sighted = false;		
		}
	}

	public float Sight(){
		return sight;
	}

	// Update is called once per frame
	void Update () {
		PlayerinSight ();
		if (sighted) {
						Vector3 moveDirection = player.transform.position - transform.position;
			moveDirection.Normalize();
			//Debug.Log ("move : "+moveDirection);
						if (moveDirection.x > 0) {
								transform.eulerAngles = (moveDirection.x > 0) ? Vector3.up * 90 : Vector3.zero;
						}
						if (moveDirection.x < 0) {
								transform.eulerAngles = (moveDirection.x < 0) ? Vector3.up * 270 : Vector3.zero;
						}

//		if (moveDirection.x < 0) {
//						Debug.Log ("I NEED TO ROTATE");		
//				} else {
//			Debug.Log ("NOPE");		
//		}
						Vector3 move = new Vector3 (moveSpeed * Time.deltaTime * moveDirection.x, 0, 0);
						character.Move (move);
			//Debug.Log ("moving : "+move);

				}
		//transform.Translate(moveSpeed * Time.deltaTime, 0,0);
	}
}
