#pragma strict

private var Player: GameObject;
private var PlayerRigidbody : Rigidbody;
private var Timer = Mathf.Infinity;
private var Win = false;
private var coinsInLevelTotal : GameObject[];


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
		coinsInLevelTotal = GameObject.FindGameObjectsWithTag("Coin");
		print("coins left = "+coinsInLevelTotal.length);
		Win = true;
		Timer = Time.time + 2;
	}
}

function OnGUI () {
	if(Win){
		GUI.Box (Rect (Screen.width/2 - 75,Screen.height/5 - 25, 150, 50),"Win !!\n coins left = "+coinsInLevelTotal.length);
	}
}
