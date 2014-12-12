#pragma strict

function OnTriggerEnter2D (player : Collider2D) {
		Application.LoadLevel(Application.loadedLevel);
}
