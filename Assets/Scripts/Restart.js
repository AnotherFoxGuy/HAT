﻿#pragma strict

function OnTriggerEnter (otherObj : Collider) {
	if (otherObj.tag == "Player") {
		Application.LoadLevel(Application.loadedLevel);
	}
	else{
		Destroy(otherObj.gameObject);
	}
}
