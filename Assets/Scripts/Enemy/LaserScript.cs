using UnityEngine;
using System.Collections;

public class LaserScript : MonoBehaviour {
	LineRenderer line;
	// Use this for initialization
	void Start () {
		line.gameObject.GetComponent<LineRenderer> ();
		line.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator FireLaser(){
		Ray ray = new Ray (transform.position,transform.forward);
		line.SetPosition (0,ray.origin);
		line.SetPosition (1, ray.GetPoint (100));
		yield return null;
		line.enabled = false;
	}
}
