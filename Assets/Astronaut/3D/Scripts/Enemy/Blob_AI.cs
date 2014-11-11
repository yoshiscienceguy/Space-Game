using UnityEngine;
using System.Collections;

public class Blob_AI : MonoBehaviour {
	
	private GameObject player;
	
	private int mergeCount = 0;
	private static int mergeLimit = 5;
	public bool MasterBlob = false;
	private GameObject[] blobs = null;
	private BlobMoveScript ems;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		//if (MasterBlob) {
		//	blobs = GameObject.FindGameObjectsWithTag("AlienMeleeBlob");
		//	Debug.Log("SLAVES : "+(blobs.Length-1));
			//GameObject.FindObjectsOfType<Blob_AI>		
		//}
		ems = GetComponent<BlobMoveScript>();
	}

	void Update(){
		if (MasterBlob) {
			GameObject closest = null;
			float closestDist = ems.Sight();
			float distance = 0f; 
			int a = 0;
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag("AlienMeleeBlob")){
				if(obj!=this.gameObject){
				//	Debug.Log("Something"+(a++));
				distance = Vector3.Distance(obj.transform.position, transform.position);
					//Debug.Log(distance + " "+ems.Sight()+" "+closestDist);
				if(closestDist>distance){
					closest = obj;
					closestDist = distance;
					//	Debug.Log("Closest found "+closestDist +" "+distance );
				}
				}
			}
			if(closest!=null){
				//Debug.Log("MERGING");
				//float distance = Vector3.Distance(closest.transform.position, transform.position);
				closest.GetComponent<BlobMoveScript>().SetMergeDirection(this.transform.position);
				closest.GetComponent<BlobMoveScript>().SetMerge(true);
				GetComponent<BlobMoveScript>().SetMergeDirection(closest.transform.position);
				GetComponent<BlobMoveScript>().SetMerge(true);
				if(closestDist < 2f){
					//Debug.Log("MERGING"+closestDist);
					Merge();
					Destroy(closest.gameObject);
					//GetComponent<BlobMoveScript>().SetMergeDirection(closest.transform.position);
					GetComponent<BlobMoveScript>().SetMerge(false);
				}
			}
		}

	}

	void Merge(){
		mergeCount++;
		if (mergeCount == mergeLimit) {
			Debug.Log("GAME SHALL END");
			//call endgame

		} else {
			Vector3 size = transform.localScale;
			size.x *= 1.5f;
			size.y *= 1.5f;
			size.z *= 1.5f;
			transform.localScale = size;
			GetComponent<BlobMoveScript>().moveSpeed *= 1.5f;
			GetComponent<MeleeAttack>().Damage *= 2;
		}
	}
}
