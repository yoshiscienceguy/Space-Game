using UnityEngine;
using System.Collections;

public class MobilePlatformController: MonoBehaviour {
	public Vector2 route;
	public float timePerCycle = 2.0f;

	[Range (0,2)]
	public float startRelativePosition=0;

	float timeOffset = 0;
	float routeLenght, horizontalSpeed;
	Vector3 basePosition, remotePosition;	
	Vector3 normalizedRoute;

	void Start(){
		initProperties();
		transform.position = Vector3.Lerp(basePosition, remotePosition, startRelativePosition);
		previousPosition = transform.position;
	}
	
	Vector2 velocity;
	Vector3 previousPosition;

	void FixedUpdate(){
		transform.position = basePosition +  Mathf.PingPong((Time.timeSinceLevelLoad) * horizontalSpeed + timeOffset, routeLenght) * normalizedRoute;
		rigidbody2D.velocity = (transform.position - previousPosition)/Time.deltaTime;
		previousPosition = transform.position;
	}	
	
	void initProperties(){
		normalizedRoute = route.normalized;
		routeLenght = route.magnitude;
		horizontalSpeed = routeLenght/ timePerCycle;
		if (startRelativePosition!=0)
			timeOffset = routeLenght  * (2 - startRelativePosition);
		basePosition = transform.position;
		remotePosition = basePosition + (Vector3)route;
	}
	
	void OnDrawGizmos(){
		if (Application.isPlaying){
			Gizmos.DrawLine(basePosition, remotePosition);
		} else {	
			initProperties();
			Vector2 boxSize = (collider2D as BoxCollider2D).size; 
			Gizmos.DrawLine(transform.position, remotePosition);
			Gizmos.DrawCube(Vector3.Lerp(basePosition, remotePosition, startRelativePosition),boxSize);
		}
		
	}
}
