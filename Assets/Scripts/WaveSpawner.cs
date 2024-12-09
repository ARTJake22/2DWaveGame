using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Wave
{
	public string waveName;
	public int noOfEnemies;
	public GameObject[] typeOfEnemies;
	public float spawnInterval;

}

public class WaveSpawner : MonoBehaviour
{
	public Wave[] waves;
	public Transform[] spawnPoints; 
	public Animator animator;
	public Text waveName;

	private Wave currentWave;
	private int currentWaveNumber;
	private float nextSpawnTime;

	private bool canSpawn = true;
	private bool canAnimate = false;



//Calls spawnWave, checks if enemies can spawn
	private void Update()
	{
		currentWave = waves[currentWaveNumber];
		SpawnWave(); //Calls SpawnWave to initiate a wave.
		GameObject[] totalEnemies = GameObject.FindGameObjectsWithTag("Enemy");
		if (totalEnemies.Length == 0 && currentWaveNumber+1 != waves.Length && canAnimate) //Checking if we can spawn to spawn the next wave.
		{
			waveName.text = waves[currentWaveNumber + 1].waveName;
			animator.SetTrigger("WaveComplete");
			canAnimate = false;
		}
	}

//Spawns the next wave, called in Update function when conditions to spawn are met
	void SpawnNextWave(){
			currentWaveNumber++;
			canSpawn = true;
	}


//wave spawning function to randomly generate spawn points and instantiate the enemies
	void SpawnWave()  
	{
		if (canSpawn && nextSpawnTime < Time.time)
		{
			GameObject randomEnemy = currentWave.typeOfEnemies[Random.Range(0, currentWave.typeOfEnemies.Length)];
			Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
			Instantiate(randomEnemy, randomPoint.position, Quaternion.identity);
			currentWave.noOfEnemies--;
			nextSpawnTime = Time.time + currentWave.spawnInterval;

			if (currentWave.noOfEnemies == 0) //checking if all enemies are dead, if so nothing will spawn
			{
				canSpawn = false;
				canAnimate = true;
			}

		}
	}
}
