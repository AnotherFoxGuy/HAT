#pragma strict

function Start () {
}
function Update () {
	if(Input.GetKey("d"))
		rigidbody2D.AddForce(transform.TransformDirection(Vector3.right*20));	

	if(Input.GetKey("a"))
		rigidbody2D.AddForce(transform.TransformDirection(Vector3.left*20));
		
	if(Input.GetKeyDown("space"))
		rigidbody2D.AddForce(transform.TransformDirection(Vector3.up*400));

}

