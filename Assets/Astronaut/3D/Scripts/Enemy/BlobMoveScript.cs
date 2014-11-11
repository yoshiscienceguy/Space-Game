using UnityEngine;
using System.Collections;

public class BlobMoveScript : MonoBehaviour {
	public float sight;
	public float moveSpeed = 0.1f;
	private CharacterController character;
	private bool sighted = false;
	private bool merge = false;
	private Vector3 blobDir;
	
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
	
	public void SetMerge(bool ToMerge){
		merge = ToMerge;
	}
	
	public void SetMergeDirection(Vector3 dir){
		Vector3 moveDirection =  dir - transform.position;
		blobDir = moveDirection;
	}
	
	// Update is called once per frame
	void Update () {
		if (merge) {
			if (blobDir.x > 0) {
				transform.eulerAngles = (blobDir.x > 0) ? Vector3.up * 90 : Vector3.zero;
			}
			if (blobDir.x < 0) {
				transform.eulerAngles = (blobDir.x < 0) ? Vector3.up * 270 : Vector3.zero;
			}
			Vector3 move = new Vector3 (moveSpeed * Time.deltaTime * blobDir.x, 0, 0);
			character.Move (move);
		} else {
			PlayerinSight ();
			if (sighted) {
				Vector3 moveDirection = player.transform.position - transform.position;
				moveDirection.Normalize ();
				//Debug.Log ("move : "+moveDirection);
				if (moveDirection.x > 0) {
					transform.eulerAngles = (moveDirection.x > 0) ? Vector3.up * 90 : Vector3.zero;
				}
				if (moveDirection.x < 0) {
					transform.eulerAngles = (moveDirection.x < 0) ? Vector3.up * 270 : Vector3.zero;
				}
				Vector3 move = new Vector3 (moveSpeed * Time.deltaTime * moveDirection.x, 0, 0);
				character.Move (move);
			}
		}
	}

	void OnCollisionEnter(Collision collision){
//		Debug.Log (collision.collider.tag);
//			if (collision.gameObject.name=="Blob"){
//			Blob_AI ai = collision.collider.GetComponent<Blob_AI>();
//			if(!ai.MasterBlob){
//				Debug.Log("BLOB COLLISON");
//				ai.GetComponent<BlobMoveScript>().SetMerge(false);
//				Destroy(gameObject);
//			}
//
//		}

	}


}
