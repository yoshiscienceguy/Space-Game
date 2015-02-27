var timeOpen : float ;
var doorOpenSound : AudioClip ;
var doorCloseSound : AudioClip ;
private var doorIsOpen : boolean ;
private var doorTimer : float = 0.0 ;
private var isBlocked : boolean = false ;


function Update () {
	if(doorIsOpen && isBlocked == false) {
		doorTimer += Time.deltaTime ;
		
		if (doorTimer > timeOpen && isBlocked == false) {
			ShutDoor () ;
			doorTimer = 0.0 ;
			
			if (doorTimer > timeOpen && isBlocked == true) {
			doorTimer = 0.0 ;
			}
		}
	}
}

function OnTriggerEnter(other : Collider){
	if(other.gameObject.tag == "Player" && doorIsOpen == false){
	isBlocked = true ;
	OpenDoor () ;
	}
}	

function OnTriggerStay (other : Collider){
	if(other.tag == "Player"){
		if (doorIsOpen == false){
			isBlocked = true ;
			OpenDoor () ;
			if (doorIsOpen == true) {
				isBlocked = true ;
			}
		}
	}
}

function OnTriggerExit (other : Collider){
	if(other.tag =="Player"){
		if(isBlocked == true) {
			isBlocked = false ;
			doorTimer = 0.0 ;
		}
	}
}

function OpenDoor () {
	audio.PlayOneShot (doorOpenSound) ;
	doorIsOpen = true ;
	animation.PlayQueued ("dooropen") ;
}

function ShutDoor () {
	audio.PlayOneShot (doorCloseSound) ;
	doorIsOpen = false ;
	animation.PlayQueued  ("doorclose") ;
	animation.PlayQueued  ("dooridle") ;
}

@script RequireComponent (AudioSource)
@script RequireComponent (BoxCollider)