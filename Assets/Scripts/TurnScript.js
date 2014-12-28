#pragma strict

private var Player: GameObject;
private var PlayerRigidbody : Rigidbody;
private var RotateWorld= false;
private var StopRotateWorld= false;
private var textboxtext = "";
private var WorldRotate = 0;
private var RotSpeed = 0;
private var RotPointCenter : Vector3;
private var HitPointFront: RaycastHit;
private var HitPointBack: RaycastHit;


function Start () {
	Player = GameObject.Find("Player");
	PlayerRigidbody = Player.GetComponent(Rigidbody);
}

function Update () {
	var PosTMPFront = Vector3(Player.transform.position.x + PlayerRigidbody.velocity.x/7, Player.transform.position.y - 2, Player.transform.position.z - 100);
	var PosTMPBack = Vector3(Player.transform.position.x + PlayerRigidbody.velocity.x/7, Player.transform.position.y - 2, Player.transform.position.z + 100);
	Debug.DrawLine(Vector3.zero, PosTMPFront);
	if (Physics.Raycast(PosTMPFront, Vector3.forward, HitPointFront, 300) && !RotateWorld) {
		Debug.DrawLine(PosTMPFront, HitPointFront.point);
		if (HitPointFront.point.z > Player.transform.position.z){
			//print("HitPointFront");
			Player.transform.position.z = HitPointFront.point.z + 0.2;
		}
	}
	if (Physics.Raycast(PosTMPBack, Vector3.back, HitPointBack, 300) && !RotateWorld) {
		Debug.DrawLine(PosTMPBack, HitPointBack.point);
		if (HitPointBack.point.z < Player.transform.position.z){
			//print("HitPointBack");
			Player.transform.position.z = HitPointBack.point.z - 0.2;
		}
	}
	if (Input.GetKeyDown("q") && !RotateWorld) {
		RotateWorld = true;
		WorldRotate = Mathf.Repeat(WorldRotate + 90, 360);
		RotSpeed = 1.5;
	}
	if (Input.GetKeyDown("e") && !RotateWorld) {
		RotateWorld = true;
		WorldRotate =  Mathf.Repeat(WorldRotate - 90, 360);
		RotSpeed = -1.5;
	}
	if (RotateWorld) {
		Time.timeScale = 0;
		Debug.DrawLine(Vector3.zero, Player.transform.position);
		transform.RotateAround (Player.transform.position, Vector3.up, RotSpeed);
	}
	if (transform.eulerAngles.y > WorldRotate - 0.1 && transform.eulerAngles.y < WorldRotate +0.1){
		if(StopRotateWorld){
			RotateWorld = false;
			StopRotateWorld = false;
			this.transform.eulerAngles.y =Mathf.Round(this.transform.eulerAngles.y);
			Player.transform.position.y+=0.01;
			Time.timeScale = 1;
		}
	}
	if(this.transform.eulerAngles.y < WorldRotate -2 || this.transform.eulerAngles.y > WorldRotate +2){
			StopRotateWorld = true;
	}

}