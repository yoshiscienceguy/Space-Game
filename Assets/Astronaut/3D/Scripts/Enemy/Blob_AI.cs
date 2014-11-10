using UnityEngine;
using System.Collections;

public class Blob_AI : MonoBehaviour {
	
	private GameObject player;
	
	private int mergeCount = 0;
	private static int mergeLimit = 5;
	public bool MasterBlob = false;
	private GameObject[] blobs = null;
	private EnemyMoveScript ems;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		if (MasterBlob) {
			blobs = GameObject.FindGameObjectsWithTag("AlienMeleeBlob");
			Debug.Log("SLAVES : "+(blobs.Length-1));
			//GameObject.FindObjectsOfType<Blob_AI>		
		}
		ems = GetComponent<EnemyMoveScript>();
	}

	void FixedUpdate(){
		if (MasterBlob) {
			GameObject closest = null;
			float distance = 0.0f;
			float closestDist = ems.Sight();
			foreach(GameObject obj in blobs){
				if(obj!=this){
				distance = Vector3.Distance(obj.transform.position, transform.position);
				//Debug.Log(distance + " "+ems.Sight());
				if(closestDist<distance){
					closest = obj;
					closestDist = distance;
				}
				}
			}
			Debug.Log(closestDist);
		}

	}

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
}
