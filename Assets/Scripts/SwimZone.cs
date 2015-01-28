using UnityEngine;
using System.Collections;

public class SwimZone : MonoBehaviour {
	
	void OnTriggerEnter2D(Collider2D player) {
		player.GetComponent<PlayerController>().above_water = true;
	}

	void OnTriggerExit2D(Collider2D player) {
		player.GetComponent<PlayerController>().above_water = false;
	}
}
