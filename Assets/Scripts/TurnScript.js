#pragma strict

private var Player: GameObject;
private var RotateWorld= false;
private var StopRotateWorld= false;
private var textboxtext = "";
private var WorldRotate = 0;
private var RotSpeed = 0;
private var RotPointCenter : Vector3;
private var HitPointFront: RaycastHit;
private var HitPointBack: RaycastHit;

function Start() {
	Player = GameObject.Find("Player");
}

function Update() {
	//textboxtext = this.transform.eulerAngles.y+"\n"+WorldRotate;

	if (Input.GetKeyDown("q") && !RotateWorld) {
		RotCenterCalculate();
		RotateWorld = true;
		WorldRotate = Mathf.Repeat(WorldRotate + 90, 360);
		RotSpeed = 1;
	}
	if (Input.GetKeyDown("e") && !RotateWorld) {
		RotCenterCalculate();
		RotateWorld = true;
		WorldRotate =  Mathf.Repeat(WorldRotate - 90, 360);
		RotSpeed = -1;
	}
	
	if (RotateWorld) {
		Time.timeScale = 0;
		Debug.DrawLine(Vector3.zero, RotPointCenter);
		transform.RotateAround (RotPointCenter, Vector3.up, RotSpeed);
	}
	
	if (transform.eulerAngles.y > WorldRotate -1 && transform.eulerAngles.y < WorldRotate +1){
		if(StopRotateWorld){
			RotateWorld = false;
			Time.timeScale = 1;
			StopRotateWorld = false;
		}
	}
	if(transform.eulerAngles.y < WorldRotate -2 || transform.eulerAngles.y > WorldRotate +2){
			StopRotateWorld = true;
	}
}
function RotCenterCalculate(){
	var PosTMP = Vector3(Player.transform.position.x, Player.transform.position.y - 1, Player.transform.position.z);
	if (Physics.Raycast(PosTMP, Vector3.forward, HitPointFront, 300)) {
		Debug.DrawLine(PosTMP, HitPointFront.point);
		var HitPointFrontTMP = Vector3(HitPointFront.point.x, HitPointFront.point.y, HitPointFront.point.z + 10);
		if (Physics.Raycast(HitPointFrontTMP, Vector3.back, HitPointBack, 200)) {
			Debug.DrawLine(HitPointFrontTMP, HitPointBack.point);
			var HitPointCenter = Vector3.Distance(HitPointBack.point, HitPointFront.point) / 2;
			RotPointCenter = Vector3(Player.transform.position.x, Player.transform.position.y, HitPointFront.point.z + HitPointCenter);
			}	
		}
	else if (Physics.Raycast(PosTMP, Vector3.back, HitPointBack, 300)) {
		Debug.DrawLine(PosTMP, HitPointBack.point);
		var HitPointBackTMP = Vector3(HitPointBack.point.x, HitPointBack.point.y, HitPointBack.point.z - 10);
		if (Physics.Raycast(HitPointBackTMP, Vector3.forward, HitPointFront, 200)) {
			Debug.DrawLine(HitPointBackTMP, HitPointFront.point);
			var HitPointCenterBack = Vector3.Distance(HitPointBack.point, HitPointFront.point) / 2;
			RotPointCenter = Vector3(Player.transform.position.x, Player.transform.position.y, HitPointFront.point.z + HitPointCenterBack);
		}
	}
	else {
		RotPointCenter = Player.transform.position;
	}
	Debug.DrawLine(Vector3.zero, RotPointCenter);
}
/*
function OnGUI () {
	GUI.Box (Rect (10,100,150,50),textboxtext);
}
*/


