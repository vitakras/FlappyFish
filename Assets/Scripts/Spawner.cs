using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public Vector3 range;               //mid mid max
	public float difficultyIncreaseEvery = -1;
	public GameObject[] enemies;		// Array of enemy prefabs.
	public GameObject fishFood;

	private ScoreManager scoreManager;	
	private int enemiesUnlocked = 1;
	//private int lastRange = -2;
	private int rangeCount = 0;
	private int lastEnemySpawnIndex = -1;
	private int enemySpawnCount;

	void Start () {
		this.scoreManager = GameObject.FindGameObjectWithTag("GameManagers").GetComponent<ScoreManager>();

		if (this.difficultyIncreaseEvery > 0) {
			InvokeRepeating("SmartSpawn", spawnDelay, spawnTime);
		} else {
			InvokeRepeating("Spawn", spawnDelay, spawnTime);
		}
	}

	private void SmartSpawn () {
		int enemyIndex = this.lastEnemySpawnIndex;
		float yAxis;
		Vector3 newPosition;

		if (this.difficultyIncreaseEvery < this.scoreManager.getScore ()) {
			this.difficultyIncreaseEvery  = this.difficultyIncreaseEvery * 2;
			if (this.enemiesUnlocked < this.enemies.Length){
				this.enemiesUnlocked++;
			}
		}

		if (this.enemySpawnCount >= 2 && (this.enemiesUnlocked > 1)) { // prevents the enemy from spawning more than twice
			while(enemyIndex != this.lastEnemySpawnIndex){
				enemyIndex = Random.Range(0, enemiesUnlocked);
			}
			this.lastEnemySpawnIndex = enemyIndex;
			this.enemySpawnCount = 1;
		} else {
			enemyIndex = Random.Range(0, enemiesUnlocked);
			if (this.lastEnemySpawnIndex == enemyIndex){
				enemySpawnCount++;
			} else {
				this.lastEnemySpawnIndex = enemyIndex;
				enemySpawnCount = 1;
			}
		}

		Enemy enemy = enemies[enemyIndex].GetComponent<Enemy>();

		/*
		if (this.rangeCount >= 2) {                              // prevents the enemy from spawning from in the same area twice 
			int minRange = calcSpawnRange(enemy.minHeight);
			int maxRange = calcSpawnRange(enemy.maxRange);
			if (minRange == maxRange && ){
				yAxis = Random.Range(enemy.minHeight, enemy.maxHeight);
				this.rangeCount++;
			} else {
				yAxis = Random.Range(enemy.minHeight, enemy.maxHeight);
				while (lastRange == calcSpawnRange(yAxis)){
					yAxis = Random.Range(enemy.minHeight, enemy.maxHeight);
					Debug.Log ("Stuck");
				}
				this.lastRange = calcSpawnRange(yAxis);
				this.rangeCount = 1;
			}
		} else {
			yAxis = Random.Range(enemy.minHeight, enemy.maxHeight);
			int range = calcSpawnRange(yAxis);

			if (this.lastRange == range){
				this.rangeCount++;
			} else {
				this.lastRange = range;
				this.rangeCount = 1;
			}
		} */

		yAxis = Random.Range(enemy.minHeight, enemy.maxHeight);

		newPosition = transform.position;
		newPosition.y = yAxis;
		
		Instantiate(enemies[enemyIndex], newPosition, transform.rotation);
	}


	private void Spawn ()
	{
		int enemyIndex = Random.Range(0, enemies.Length);
		Enemy enemy = enemies[enemyIndex].GetComponent<Enemy>();

		float yAxis = Random.Range(enemy.minHeight, enemy.maxHeight);
		Vector3 newPosition = transform.position;
		newPosition.y = yAxis;

		Instantiate(enemies[enemyIndex], newPosition, transform.rotation);
	}

	private int calcSpawnRange(float ySpawn){
		if (ySpawn >= this.range.x && ySpawn < this.range.y) {
			return -1;
		} else if (ySpawn >= this.range.y && ySpawn < this.range.z)  {
			return 0;
		} else {
			return 1;
		}
	}
}
