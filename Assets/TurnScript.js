#pragma strict

private var Player: GameObject;


function Start () {
	Player = GameObject.Find("Player");
}

function Update () {
	var hit : RaycastHit;
	var tmpPos = Vector3(Player.transform.position.x, Player.transform.position.y-1, Player.transform.position.z);

	if(Input.GetKeyDown("q")){
		RotateWorld(90);
	}
	if(Input.GetKeyDown("e")){
		RotateWorld(-90);
	}

	if (Physics.Raycast (tmpPos,Vector3.forward, hit, 999) || Physics.Raycast (tmpPos,Vector3.back, hit, 999)){
		Debug.DrawLine (tmpPos, hit.point);
	}

}

function RotateWorld (WorldRotate : float) {
	var hit : RaycastHit;
	var tmpPos = Vector3(Player.transform.position.x, Player.transform.position.y-1, Player.transform.position.z);

	if (Physics.Raycast (tmpPos,Vector3.forward, hit, 999) || Physics.Raycast (tmpPos,Vector3.back, hit, 999)){
		Debug.DrawLine (tmpPos, hit.point);
		var tmpRotate = Vector3(hit.point.x, hit.point.y, hit.point.z);
		//print(""+tmpRotate);
		transform.RotateAround (tmpRotate, Vector3.up, WorldRotate);
	}
	else{
		transform.RotateAround (Player.transform.position, Vector3.up, WorldRotate);
	}
}