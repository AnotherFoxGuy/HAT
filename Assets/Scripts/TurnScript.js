#pragma strict

private var Player: GameObject;


function Start() {
	Player = GameObject.Find("Player");
}

function Update() {
	var HitPointFront: RaycastHit;
	var HitPointBack: RaycastHit;
	var PosTMP = Vector3(Player.transform.position.x, Player.transform.position.y - 1, Player.transform.position.z);

	if (Input.GetKeyDown("q")) {
		RotateWorld(90);
	}
	if (Input.GetKeyDown("e")) {
		RotateWorld(-90);
	}
}

function RotateWorld(WorldRotate: float) {

	var HitPointFront: RaycastHit;
	var HitPointBack: RaycastHit;
	var PosTMP = Vector3(Player.transform.position.x, Player.transform.position.y - 1, Player.transform.position.z);

	if (Physics.Raycast(PosTMP, Vector3.forward, HitPointFront, 300)) {
		Debug.DrawLine(PosTMP, HitPointFront.point);
		var HitPointFrontTMP = Vector3(HitPointFront.point.x, HitPointFront.point.y, HitPointFront.point.z + 100);
		if (Physics.Raycast(HitPointFrontTMP, Vector3.back, HitPointBack, 200)) {
			Debug.DrawLine(HitPointFrontTMP, HitPointBack.point);
			var HitPointCenter = Vector3.Distance(HitPointBack.point, HitPointFront.point) / 2;
			var RotPointCenter = Vector3(Player.transform.position.x, Player.transform.position.y, HitPointFront.point.z + HitPointCenter);
			Debug.DrawLine(Vector3.zero, RotPointCenter);
			transform.RotateAround (RotPointCenter, Vector3.up, WorldRotate);
		}
	}
 	else if (Physics.Raycast(PosTMP, Vector3.back, HitPointBack, 300)) {
		Debug.DrawLine(PosTMP, HitPointBack.point);
		var HitPointBackTMP = Vector3(HitPointBack.point.x, HitPointBack.point.y, HitPointBack.point.z - 100);
		if (Physics.Raycast(HitPointBackTMP, Vector3.forward, HitPointFront, 200)) {
			Debug.DrawLine(HitPointBackTMP, HitPointFront.point);
			var HitPointCenterBack = Vector3.Distance(HitPointBack.point, HitPointFront.point) / 2;
			var RotPointCenterBack = Vector3(Player.transform.position.x, Player.transform.position.y, HitPointFront.point.z + HitPointCenterBack);
			Debug.DrawLine(Vector3.zero, RotPointCenterBack);
			transform.RotateAround (RotPointCenterBack, Vector3.up, WorldRotate);
		}
	}
	else {
		transform.RotateAround(Player.transform.position, Vector3.up, WorldRotate);
	}
}
