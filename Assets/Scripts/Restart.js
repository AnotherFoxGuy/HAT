#pragma strict

function OnTriggerEnter (player : Collider) {
		Application.LoadLevel(Application.loadedLevel);
}
