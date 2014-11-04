using UnityEngine;
using System.Collections;

public class Parent2Child : MonoBehaviour {
	public Transform Parent;


	// Use this for initialization
	void Start () {
		transform.position = Parent.position;
		transform.rotation = Parent.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Parent.position;
		transform.rotation = Parent.rotation;
	}
}
