#pragma strict

	// Use this for initialization
	public var delay : float = 12;
	private var override_door : boolean = false;
	function Start(){
		StartCoroutine (AnimationWait (delay));
		if(GetComponent("Openable").active == true){
			override_door = true;
		}
	}
	
	function AnimationWait(time : float ){
		GetComponent(BoxCollider).isTrigger = false;
		yield WaitForSeconds(time);
		if(override_door == false){
			GetComponent(BoxCollider).isTrigger = true;
		}
	}