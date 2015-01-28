using UnityEngine;
using System.Collections;

public class PlayerCollider : MonoBehaviour {

	public float points = 100;

	private StateManager stateManager;
	private ScoreManager scoreManager;

	void Awake() {
		stateManager = GameObject.FindGameObjectWithTag("GameManagers").GetComponent<StateManager>();
		scoreManager = GameObject.FindGameObjectWithTag ("GameManagers").GetComponent<ScoreManager>();
	}
	
	void OnTriggerEnter2D(Collider2D enemy) {
		if (enemy.tag == "Enemy") {
			stateManager.setState(States.loseMenu);
		} else if (enemy.tag == "FishFood"){
			scoreManager.increaseScore(points);
			Destroy(enemy.gameObject);
		}
	}
}
