#pragma strict

private var PlayerRigidbody2D : Rigidbody2D ;
private var Collision = false;


function Start () {
	PlayerRigidbody2D = this.GetComponent(Rigidbody2D);
}

function Update () {
	var MaxSpeed = 7;
	
	if(Input.GetKey("d")){
		if(PlayerRigidbody2D.velocity.x < MaxSpeed){
			rigidbody2D.AddForce(transform.TransformDirection(Vector3.right*20));	
		}
	}

	if(Input.GetKey("a")){
		if(PlayerRigidbody2D.velocity.x > -MaxSpeed){
			rigidbody2D.AddForce(transform.TransformDirection(Vector3.left*20));
		}
	}
		
	if(Input.GetKeyDown("space")){
		if(Collision){
			rigidbody2D.AddForce(transform.TransformDirection(Vector3.up*400));
		}
	}
}

function OnCollisionEnter2D () {
	Collision = true;
}

function OnCollisionExit2D () {
	Collision = false;
 }
