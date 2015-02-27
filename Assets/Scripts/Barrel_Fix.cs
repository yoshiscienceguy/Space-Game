using UnityEngine;
using System.Collections;

public class Barrel_Fix : MonoBehaviour {
	private Quaternion original;
	private float originalz;
	// Use this for initialization
	void Start () {
		originalz = transform.rotation.z;
	}
	
	// Update is called once per frame
	void Update () {
		original = Quaternion.Euler (transform.rotation.x, transform.rotation.y , transform.rotation.z);
		//transform.rotation = original;
	}
}
