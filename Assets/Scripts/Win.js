#pragma strict

private var Player: GameObject;
private var PlayerRigidbody : Rigidbody;
private var Timer = Mathf.Infinity;
private var Win = false;

function Start () {
	Player = GameObject.Find("Player");
	PlayerRigidbody = Player.GetComponent(Rigidbody);
}

function Update () {
	if(Time.time > Timer){
		Application.LoadLevel(Application.loadedLevel);
	}
	if(Win){
		PlayerRigidbody.isKinematic = true;
		Player.transform.position.y = Player.transform.position.y + Time.deltaTime;
	}
}

function OnTriggerEnter (player : Collider) {
	if(player.gameObject.tag == "Player"){
		Win = true;
		Timer = Time.time + 2;
	}
}
function OnGUI () {
	if(Win){
		GUI.Box (Rect (Screen.width/2 - 50,Screen.height/5 - 25, 100, 50),"Win !!");
	}
}
