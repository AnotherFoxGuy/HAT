#pragma strict

private var PlayerRigidbody : Rigidbody ;
private var ConstructionWorker : GameObject ;
private var HitPoint: RaycastHit;
private var LastClip: String;
public var MaxSpeed = 7;

function Start () {
	PlayerRigidbody = this.GetComponent(Rigidbody);
	ConstructionWorker = GameObject.Find("ConstructionWorker");
	ConstructionWorker.transform.eulerAngles.y = 90;
}

function Update () {
	if(Input.GetKey("d")){
	ConstructionWorker.transform.eulerAngles.y = 90;
		if(PlayerRigidbody.velocity.x < MaxSpeed)
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.right*20));
	}
	if(Input.GetKey("a")){
	ConstructionWorker.transform.eulerAngles.y = -90;
		if(PlayerRigidbody.velocity.x > -MaxSpeed)
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.left*20));
	}
	if(Input.GetKeyDown("space")){
		if(Physics.Raycast(this.transform.position, Vector3.down, 1))
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.up*400));
	}

	//==============================================================================================
	if (Physics.Raycast(this.transform.position, Vector3.down, 1)){
		AnimateThis("idle" , false);
		if(Input.GetKey("d"))
			AnimateThis("run" , false);
		else if(Input.GetKey("a"))
			AnimateThis("run" , false);
	}
	else if (!Physics.Raycast(this.transform.position, Vector3.down, 1)){
		AnimateThis("jump_pose" , true);
	}

}
function AnimateThis(CurrentClip : String , Forced : boolean) {
	if (LastClip != CurrentClip){
		if(Forced)
			ConstructionWorker.animation.Play(CurrentClip);
		else
			ConstructionWorker.animation.CrossFade(CurrentClip, 0.2);
		LastClip = CurrentClip;
	}
}
