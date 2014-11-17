using UnityEngine;
using System.Collections;

public class Blob_AI : MonoBehaviour {
	
	private GameObject player;
	
	private int mergeCount = 0;
	private static int mergeLimit = 5;
	public bool MasterBlob = false;
	private BlobMoveScript ems;

	// Use this for initialization
	void Start () {
		player = GameObject.FindWithTag("Player");
		ems = GetComponent<BlobMoveScript>();
	}

	void FixedUpdate(){
		if (MasterBlob) {
			GameObject closest = null;
			float distance = 0.0f;
			float closestDist = ems.Sight();
			foreach(GameObject obj in GameObject.FindGameObjectsWithTag("AlienMeleeBlob")){
				if(obj!=this.gameObject && obj.gameObject.GetComponent<Blob_AI>().MasterBlob!=true){
				distance = Vector3.Distance(obj.transform.position, transform.position);
				if(closestDist>distance){
					closest = obj;
					closestDist = distance;
				}
				}
			}
			if(closest!=null){
				BlobMoveScript close;
				if(closestDist <2.0f){
					Destroy(closest.gameObject);
					Merge();
					close = this.GetComponent<BlobMoveScript>();
					close.SetMerge(false);
				}else{
				close = closest.GetComponent<BlobMoveScript>();
				close.SetMerge(true);
				close.SetMergeDirection(transform.position);
				close = GetComponent<BlobMoveScript>();
				close.SetMerge(true);
				close.SetMergeDirection(closest.transform.position);
				}
			}else{
				BlobMoveScript close = this.GetComponent<BlobMoveScript>();
				close.SetMerge(false);
			}
		}

	}

	void Merge(){
		mergeCount++;
		if (mergeCount == mergeLimit) {
			//call endgame
			Debug.Log("BLOB IS TOO HUGE, GAME IS GONNA END");
		} else {
			this.GetComponent<BlobMoveScript>().moveSpeed*=1.5f;
			this.GetComponent<BlobMoveScript>().sight*=1.5f;
			EnemyHealth eh = this.GetComponent<EnemyHealth>();
			eh.HP=10+eh.GetMaxHP();
			eh.SetMaxHP(eh.HP);
			eh.maxLoot*=2;
			//this.GetComponent<MeleeAttack>().attackSpeed*=1.5f;
			this.GetComponent<MeleeAttack>().Damage*=2;
			Vector3 size = transform.localScale;
			size.x *= 1.5f;
			size.y *= 1.5f;
			size.z *= 1.5f;
			transform.localScale = size;
		}
	}
}
