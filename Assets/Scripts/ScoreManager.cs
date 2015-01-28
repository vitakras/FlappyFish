using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public float multiplier = 1;

	private float score = 0;
	private float highScore = 0;
	private float incrementBy = 100;

	void Awake () {
		loadData();
		DontDestroyOnLoad(this);
	}
	
	void increment () {
		this.score += (this.incrementBy * this.multiplier);
	}

	public void resetScore(){
		CancelInvoke("increment");
		if (this.score > this.highScore){
			this.highScore = this.score;
			saveData();
		}
		this.score = 0;
	}

	public void startScoreCount() {
		InvokeRepeating("increment",1,1f);
	}

	public float getScore(){
		return this.score;
	}

	public float getHighScore() {
		return this.highScore;
	}

	public void increaseScore(float amount) {
		this.score += amount * multiplier;
	}

	private void loadData() {
		this.highScore = PlayerPrefs.GetFloat("HighScore");
	}

	private void saveData() {
		PlayerPrefs.SetFloat("HighScore", this.highScore);
		PlayerPrefs.Save();
	}
}
