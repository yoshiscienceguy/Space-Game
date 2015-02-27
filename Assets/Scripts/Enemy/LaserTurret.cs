using UnityEngine;
using System.Collections;

public class LaserTurret : MonoBehaviour
{

		public float rotateSpeed = 10f;
		public float minAngle = 0f;
		public float maxAngle = 180f;
	public float visibleRange = 200f;
		private float dir = -1f;
		private Vector3 min;
		private Vector3 max;
		public float FiringLength = 3f;
		public float ReloadTime = 10f;
		private float attackTime;
		private float freezeTime;
		float range = 100.0f;
		public bool aimPlayer = false;
		private GameObject player = null;
		private bool flip = false;
		public Rigidbody laserBeam;
		private Rigidbody la;
		private bool fire = false;
	private int count = 0;
	private Vector3 correction = new Vector3 (0, 1, 0);
	
		// Use this for initialization
		void Start ()
		{
				float newAng = this.gameObject.transform.parent.eulerAngles.z; 
				min = Quaternion.Euler (0, 0, newAng - minAngle).eulerAngles;
				//max = newAng - maxAngle;
				max = Quaternion.Euler (0, 0, newAng - maxAngle).eulerAngles;
				//Debug.Log ("min : "+transform.eulerAngles.z+ " max : "+max.z+" ");
				flip = false;
				attackTime = Time.time + ReloadTime;
				if (aimPlayer) {
						player = GameObject.FindGameObjectWithTag ("Player");
				}
		}

	// Update is called once per frame
	void Update ()
	{
		float dist = Vector3.Distance (this.transform.position, player.transform.position);
		if (dist < visibleRange) {
						if (attackTime <= Time.time && count < 30) {

								la = Instantiate (laserBeam, transform.position, transform.rotation) as Rigidbody;
								PEWPEW yourObject = la.gameObject.GetComponent<PEWPEW> ();
								yourObject.SetDir (transform.eulerAngles);
								Vector3 tmp = new Vector3 (1.5f, 0.18f, 0.18f);
								la.transform.localScale = tmp;
								freezeTime = Time.time + FiringLength;
								attackTime += FiringLength / 30f;
								Destroy (la.gameObject, FiringLength);
								count++;
								fire = true;
						}
						if (freezeTime <= Time.time && fire) {
								fire = false;
								attackTime = Time.time + ReloadTime;
								count = 0;
						}
						if (!fire) {
								if (!aimPlayer) {
										//Debug.Log("asdasdasd");
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
										Vector3 dir = ((player.transform.position + correction) - transform.position).normalized;
										dir.z = 0;
										if (dir.x > 0) {
												float opposite = dir.x * -1;
												float hyp = dir.magnitude;
												float angle = Mathf.Acos (opposite / hyp) * Mathf.Rad2Deg;
												//Debug.Log(angle + " : dir = "+dir + " : ");
												Quaternion targetRotation = Quaternion.Euler (new Vector3 (0, 0, angle));
												transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
				
										} else {
												float opposite = dir.y;
												float hyp = dir.magnitude;
												float angle = Mathf.Asin (dir.y / hyp) * Mathf.Rad2Deg;
												//Debug.Log(angle + " : dir = "+dir + " : ");
												Quaternion targetRotation = Quaternion.Euler (new Vector3 (0, 0, angle) * -1);
												transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
										}
								}
						}
				}
	}//end of update
}
