using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	public float rotateSpeed = 2f;
	public float minAngle = 0f;
	public float maxAngle = 180f;
	private float dir = -1f;
	private Vector3 min;
	private Vector3 max;

	public bool aimPlayer = false;
	private GameObject player = null;
	private bool flip = false;


	// Use this for initialization
	void Start () {
//		LineRenderer lineRenderer = gameObject.AddComponent<LineRenderer>();
//		lineRenderer.material = new Material(Shader.Find("Particles/Additive"));
//		lineRenderer.SetColors( Color.white, new Color(1, 1, 1, 0));
//		lineRenderer.SetPosition (1,new Vector3(40,40,0));
		//Debug.Log (transform.root.gameObject.name+" : "+ this.gameObject.transform.parent.eulerAngles.z + " , "+transform.eulerAngles.z +", UP "+this.gameObject.transform.parent.up);
		//Vector3 tmp = this.gameObject.transform.parent.up;
		//float newAng = this.gameObject.transform.parent.eulerAngles.z + minAngle;
		float newAng = this.gameObject.transform.parent.eulerAngles.z;
		//Debug.Log (newAng+"+"+minAngle+ "="+(newAng+minAngle));
		transform.eulerAngles = new Vector3(0, 0,newAng-minAngle); 
		min = Quaternion.Euler (0, 0, newAng - minAngle).eulerAngles;
		//max = newAng - maxAngle;
		max = Quaternion.Euler (0, 0, newAng - maxAngle).eulerAngles;
		//Debug.Log ("min : "+transform.eulerAngles.z+ " max : "+max.z+" ");
		flip = false;
		if (aimPlayer) {
			player = GameObject.FindGameObjectWithTag("Player");
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!aimPlayer) {
						if (Vector3.Distance (max, transform.eulerAngles) - rotateSpeed < 0 && flip == false) {	
								dir *= -1;
								flip = true;
							//	Debug.Log ("FLIPPED");
						} else if (Vector3.Distance (min, transform.eulerAngles) - rotateSpeed < 0 && flip) {
								dir *= -1;
								flip = false;
								//Debug.Log ("UNFLIPPED");
						}
						transform.Rotate (new Vector3 (0, 0, Time.deltaTime * rotateSpeed * dir));
				} else {
			//Debug.DrawLine(transform.position,player.transform.position, Color.green, 2, false);
			Vector3 newDir = player.transform.position - transform.position;
			newDir.z = 0;
			Debug.Log(newDir);
			Quaternion rotation = Quaternion.LookRotation(newDir);
			transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 
			                                      Time.deltaTime * rotateSpeed);
			//transform.eulerAngles.z = 0;
			//var q = Quaternion.LookRotation(player.transform.position - transform.position);
			//transform.rotation = Quaternion.RotateTowards(new Vector3(0,0,transform.rotation.z), q, rotateSpeed * Time.deltaTime);
			//transform.LookAt(new Vector3(0,0,player.transform.position.z));		
		
		}
	}


}
