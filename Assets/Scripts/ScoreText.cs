using UnityEngine;
using System.Collections;

public class ScoreText : MonoBehaviour {

	private ScoreManager scoreManager;

	// Use this for initialization
	void Start () {
		this.scoreManager = GameObject.FindGameObjectWithTag("GameManagers").GetComponent<ScoreManager>();
		this.scoreManager.startScoreCount();
	}

	void OnGUI() {
		guiText.text = "Score: " + scoreManager.getScore();
	}
}
