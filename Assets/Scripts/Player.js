#pragma strict

private var PlayerRigidbody : Rigidbody ;
private var HitPoint: RaycastHit;
var MaxSpeed = 7;

function Start () {
	PlayerRigidbody = this.GetComponent(Rigidbody);
}

function Update () {
	
	if(Input.GetKey("d")){
		if(PlayerRigidbody.velocity.x < MaxSpeed){
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.right*20));	
		}
	}

	if(Input.GetKey("a")){
		if(PlayerRigidbody.velocity.x > -MaxSpeed){
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.left*20));
		}
	}
		
	if(Input.GetKeyDown("space")){
		if(Physics.Raycast(this.transform.position, Vector3.down, 0.6)){
			PlayerRigidbody.AddForce(transform.TransformDirection(Vector3.up*400));
		}
	}
}
