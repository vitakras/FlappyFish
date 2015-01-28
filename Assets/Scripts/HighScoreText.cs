using UnityEngine;
using System.Collections;

public class HighScoreText : MonoBehaviour {
	
	void Start () {
		guiText.text = "HighScore: " + GameObject.FindGameObjectWithTag("GameManagers").GetComponent<ScoreManager>().getHighScore(); 
	}
}
