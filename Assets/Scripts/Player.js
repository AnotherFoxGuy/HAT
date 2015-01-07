#pragma strict

private var PlayerRigidbody : Rigidbody ;
private var ConstructionWorker : GameObject ;
private var HitPoint: RaycastHit;
private var LastClip: String;
public var MaxSpeed = 7;
private var CoinsFound = 0;
private var Skybox: GameObject;


function OnTriggerEnter (otherObj : Collider) {
	if (otherObj.tag == "Coin") {
		Destroy(otherObj.gameObject);
		CoinsFound++;
	}
}

function OnGUI () {
	GUI.Box (Rect (10,50,150,25),"Coins collected: "+CoinsFound);
}

function Start () {
	PlayerRigidbody = this.GetComponent(Rigidbody);
	ConstructionWorker = GameObject.Find("ConstructionWorker");
	ConstructionWorker.transform.eulerAngles.y = 90;
	var coinsInLevelTotal : GameObject[];
	coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
	print("coinsInLevelTotal = "+coinsInLevelTotal.length);
	Skybox = GameObject.Find("Skybox");
}

function Update () {
	Skybox.transform.position.x = this.transform.position.x;
	Skybox.transform.position.y = this.transform.position.y;
	if(Input.GetButtonDown("Jump")){
		if(Physics.Raycast(this.transform.position, Vector3.down, 1.5))
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.up*400));
	}
	if (Physics.Raycast(this.transform.position, Vector3.down, 1)){
		AnimateThis("idle" , false);
		if(Input.GetButton("Right"))
			AnimateThis("run" , false);
			else if(Input.GetButton("Left"))
				AnimateThis("run" , false);
			}
			else {
				AnimateThis("jump_pose" , true);
			}


}

function FixedUpdate () {
	if(Input.GetButton("Right")){
	ConstructionWorker.transform.eulerAngles.y = 90;
		if(PlayerRigidbody.velocity.x < MaxSpeed)
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.right*20));
	}
	if(Input.GetButton("Left")){
	ConstructionWorker.transform.eulerAngles.y = -90;
		if(PlayerRigidbody.velocity.x > -MaxSpeed)
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.left*20));
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
